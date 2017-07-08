using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace X.App.Views.eng {
    public class reg :xview{
        protected override void InitDict()
        {
            base.InitDict();
            dict.Add("cs", GetDictList("sys.city", 0 + ""));
          
        }
    }
}
