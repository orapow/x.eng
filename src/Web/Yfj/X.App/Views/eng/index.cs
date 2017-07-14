using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace X.App.Views.eng {
    public class index : _eng {
        protected override bool nd_user {
            get {
                return false;
            }
        }
        protected override void InitDict()
        {
            base.InitDict();
            //热销商品
            var goods = DB.x_goods.Where(o => o.hot == 1).Select(o => new {
                o.name,
                o.alias,
                o.cover,
                o.new_price,
                id = o.goods_id
            });
            dict.Add("goods", goods);
        }
    }
}
