using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using X.Web.Com;

namespace X.App.Apis.eng.user {
    class savepwd_problem : _eng {
        public int proid { get; set; }
        public string ans { get; set; }
        protected override XResp Execute()
        {
            cu.pro_id = proid;
            cu.pro_answer = ans;
            SubmitDBChanges();
            return new XResp();
        }
    }
}
