using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using X.Data;

namespace X.App.Views.eng.goods {
    public class sale_detail : _eng {
        public int id { get; set; }
        x_sale sl = null;
        protected override bool nd_user {
            get {
                return false;
            }
        }

        protected override string GetParmNames {
            get {
                return "id";
            }
        }

        protected override void InitDict()
        {
            base.InitDict();
            sl = DB.x_sale.FirstOrDefault(o => o.sale_id == id);
            if (sl == null || sl.goods_id == null || sl.etime <= DateTime.Now || sl.count <= 0) {
                if (sl == null) {
                    dict.Add("msg", "秒杀记录不存在");
                    dict.Add("bt_txt", "返回首页");
                    dict.Add("bt_url", "/eng/index.html");
                }
                else {
                    dict.Add("msg", "秒杀活动已经结束");
                    dict.Add("bt_txt", "浏览此商品");
                    dict.Add("bt_url", "/eng/goods/detail-" + sl.goods_id + ".html");
                }
                dict.Add("show_foot", 0);
            }
            else {
                dict.Add("g", sl.x_goods);
                dict.Add("sl", sl);
                dict.Add("pics", sl.x_goods.imgs.Split(',').ToList());
                dict.Add("desc", Context.Server.HtmlDecode(sl.x_goods.desc));
            }
        }
        public override string GetTplFile()
        {
            if (sl == null || sl.x_goods == null || sl.etime <= DateTime.Now)
                return "wx/no";
            return base.GetTplFile();
        }
    }
}
