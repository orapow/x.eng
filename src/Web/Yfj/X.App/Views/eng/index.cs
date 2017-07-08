using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace X.App.Views.eng {
    public class index:xview {

        //protected override bool nd_user {
        //    get {
        //        return false;
        //    }
        //}
        protected override void InitDict()
        {
            base.InitDict();
            var goods = DB.x_goods.Select(o => new {
                o.name,
                o.alias,
                o.cover,
                o.new_price,
                id=o.goods_id
            });
            dict.Add("goods", goods);
        }
    }
}
