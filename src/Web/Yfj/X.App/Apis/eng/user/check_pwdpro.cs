using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using X.Web.Com;
using X.Web;

namespace X.App.Apis.eng.user {
    public class check_pwdpro : _eng {
        public string ans { get; set; }
        protected override XResp Execute()
        {
            if (!string.IsNullOrEmpty(ans)) {
                if (ans == cu.pro_answer) {
                    // return new XResp();
                    return new XResp("msg", "1");
                }
                else
                    return new XResp();
            }
            throw new XExcep("为空");
        }
    }
}
