using System;
using System.Collections.Generic;
using X.Core.Cache;
using System.Linq;
using X.Core.Utility;

namespace X.Data {
    partial class x_goods {
    }

    partial class x_order {
    }

    partial class x_mgr {
    }

    partial class x_user {
        public long id { get { return user_id; } }
    }

    partial class x_dict {

        public long id { get { return dict_id; } }

        /// <summary>
        /// 获取字典文字
        /// </summary>
        /// <param name="code"></param>
        /// <param name="value">
        /// 多个值用 , 隔开
        /// </param>
        /// <returns></returns>
        public static string GetDictName(string code, object value, string split, DataClassesDataContext db)
        {
            if (value == null || string.IsNullOrEmpty(code))
                return string.Empty;
            var list = GetDictList(code, "00", db);
            if (list == null || list.Count == 0)
                return string.Empty;

            var val = (value + "").Trim();
            var dicts = list.FindAll(o => {
                return val.Contains("[" + o.value + "]") || val == o.value; //val.IndexOf(String.Format(",{0},", o.value)) >= 0;
            });
            if (dicts == null || dicts.Count == 0)
                return string.Empty;
            var ns = string.Empty;
            foreach (var d in dicts) {
                if (!string.IsNullOrEmpty(ns)) {
                    ns += split;
                }
                ns += d.name;
            }
            return ns;
        }

        /// <summary>
        /// 获取字典列表
        /// </summary>
        /// <param name="code"></param>
        /// <param name="upval"></param>
        /// <returns></returns>
        public static List<x_dict> GetDictList(string code, string upval, DataClassesDataContext db)
        {
            var key = "dict." + code;
            var list = CacheHelper.Get<List<x_dict>>(key);
            if (list == null || list.Count == 0) {
                var q = from c in db.x_dict
                        where c.code == code
                        select c;
                list = q.ToList();
                if (list == null || list.Count == 0)
                    return null;
                CacheHelper.Save(key, list);
            }
            if (upval == "00")
                return list;
            if (string.IsNullOrEmpty(upval) || upval == "0")
                return list.FindAll(o => {
                    return o.upval == "0";
                });
            else {
                var u = list.FirstOrDefault(o => o.value == upval.Split('-').Last());
                return list.FindAll(o => {
                    return o.upval == (u.upval == "0" ? u.value : u.upval + "-" + u.value);
                });
            }
        }

    }
}