using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace X.App.Views.eng.goods {
    public class detail : _eng {
        public int id { get; set; }
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
            var gd = DB.x_goods.FirstOrDefault(o => o.goods_id == id);
            var s1 = gd.x_sale.FirstOrDefault(o => o.etime > DateTime.Now);
            if (s1 != null)
                Context.Response.Redirect("/eng/goods/sale_detail-" + s1.sale_id + ".html");

            dict.Add("g", gd);
            dict.Add("pics", gd.imgs.Split(',').ToList());
            dict.Add("desc", Context.Server.HtmlEncode(gd.desc));
        }

    }
}

