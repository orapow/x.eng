using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace X.App.Views.eng.goods {
    public class sale_list : _eng {
        protected override bool nd_user {
            get {
                return false;
            }
        }

        protected override void InitDict()
        {
            base.InitDict();
            var q = from s in DB.x_sale
                    select s;

            var sale = q.OrderByDescending(o => o.ctime)
                .ToList()
                .Select(o => new {
                    sid = o.sale_id,
                    id = o.goods_id,
                    cid = o.city_id,
                    o.limit,
                    o.price,
                    o.count,
                    o.ctime,
                    o.etime,
                    goods=o.x_goods
                });
            dict.Add("sale", sale);

        }
    }
}
