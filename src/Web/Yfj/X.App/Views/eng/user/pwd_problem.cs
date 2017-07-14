using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace X.App.Views.eng.user {
    public class pwd_problem:_eng {
        protected override void InitDict()
        {
            base.InitDict();
            dict.Add("pwd", GetDictList("pwd.problem", 0 + ""));
        }
    }
}
