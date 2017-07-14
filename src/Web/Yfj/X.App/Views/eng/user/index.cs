using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace X.App.Views.eng.user {
    public class index : _eng {
        public int id { get; set; }
        protected override string GetParmNames {
            get {
                return "id";
            }
        }
        protected override void InitDict()
        {
            base.InitDict();
            dict.Add("cs", GetDictList("sys.city", 0 + ""));

            // if (id > 0) {
            dict.Add("ent", cu);
            // }

            dict.Add("pwd", GetDictList("pwd.problem", 0 + ""));

        }
    }
}
