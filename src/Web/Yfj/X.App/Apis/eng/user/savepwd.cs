using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using X.Web.Com;
using X.Web;
using X.Core.Utility;

namespace X.App.Apis.eng.user {
    public class savepwd : _eng {
        public string old_pwd { get; set; }
        public string new_pwd { get; set; }

        protected override XResp Execute()
        {
            if (cu.pwd != Secret.MD5(old_pwd))
                throw new XExcep("密码错误");
            cu.pwd =Secret.MD5(new_pwd);
            SubmitDBChanges();
            return new XResp();
        }
    }
}
