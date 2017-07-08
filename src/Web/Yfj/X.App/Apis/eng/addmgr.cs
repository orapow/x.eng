using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using X.Core.Utility;
using X.Data;
using X.Web.Com;

namespace X.App.Apis.eng {
    public class addmgr:xapi {
        protected override XResp Execute()
        {
            var mgr = new x_mgr();
            mgr.role_id = 3;
            mgr.uid = "xc_01";
            mgr.pwd = Secret.MD5("123");
            mgr.name = "管理员";
            mgr.ctime = DateTime.Now;
            mgr.ukey = Secret.MD5(Guid.NewGuid().ToString());
            DB.x_mgr.InsertOnSubmit(mgr);

            SubmitDBChanges();
            return new XResp();
        }
    }
}
