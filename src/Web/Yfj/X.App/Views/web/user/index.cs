using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace X.App.Views.web.user {
    public class index : _web {
        protected override void InitDict()
        {
            base.InitDict();
            dict.Add("mycu",cu);
        }
    }
}
