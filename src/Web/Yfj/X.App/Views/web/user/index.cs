using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace X.App.Views.web.user {
    public class index : _web {
        protected override bool nd_user {
            get {
                return true;
            }
        }
        protected override void InitDict()
        {
            base.InitDict();
            dict.Add("cs", GetDictList("sys.city", 0 + ""));
            dict.Add("mycu",cu);
            dict.Add("pwd", GetDictList("pwd.problem", 0 + ""));
        }
    }
}
