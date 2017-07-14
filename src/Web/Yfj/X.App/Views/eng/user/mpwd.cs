using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace X.App.Views.eng.user {
    public class mpwd:_eng {
        protected override void InitDict()
        {
            base.InitDict();

            var flag = cu.pro_id > 0 ? 0 : 1;
            dict.Add("flag", flag);
        }
    }
}
