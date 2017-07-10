using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using X.Web.Com;

namespace X.App.Views.eng.goods {
    public class list : _eng {
        public string cid { get; set; }

        protected override bool nd_user {
            get {
                return false;
            }
        }
        protected override string GetParmNames {
            get {
                return "cid";
            }
        }
        protected override void InitDict()
        {
            base.InitDict();
            var q = from g in DB.x_goods
                    where g.status==2
                    select g;
            //var cids = DB.x_dict.Where(o => o.code == "goods.cate" && o.upval.Contains(cid) || o.value == cid).Select(o => o.value);
            q = q.Where(o => o.cate_id==cid);
            var goods = q.OrderByDescending(o => o.sort).ThenByDescending(o => o.ctime)
                 .ToList()
                 .Select(o => new {
                     id = o.goods_id,
                     o.name,
                     o.alias,
                     o.cover,
                     o.new_price

                 });

            dict.Add("goods", goods);

        }
    }
}
