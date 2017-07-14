using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace X.App.Views.eng.user {
    public class check_pwdpro :_eng{
        protected override void InitDict()
        {
            base.InitDict();
            dict.Add("pwd", GetDictName("pwd.problem", cu.pro_id));
        }
    }
}
