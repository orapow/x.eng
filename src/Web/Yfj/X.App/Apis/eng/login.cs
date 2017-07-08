using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using X.Core.Utility;
using X.Web;
using X.Web.Com;

namespace X.App.Apis.eng {
    public class login : _eng {
        /// <summary>
        /// 用户名
        /// </summary>
        public string name { get; set; }
        /// <summary>
        /// 密码
        /// </summary>
        public string pwd { get; set; }

        protected override bool nd_user {
            get {
                return false;
            }
        }

        protected override XResp Execute()
        {
            cu = DB.x_user.FirstOrDefault(o => o.name == name);
            if (!string.IsNullOrEmpty(pwd)) {
                if (cu == null || cu.pwd != Secret.MD5(pwd))
                    throw new XExcep("0x0023");
            }
            else {
                throw new XExcep("参数丢失");
            }
            cu.ukey = Secret.MD5(Guid.NewGuid().ToString());
            SubmitDBChanges();
            Context.Response.SetCookie(new HttpCookie("cu_key", cu.ukey));
            return new XResp();
        }

    }
}
