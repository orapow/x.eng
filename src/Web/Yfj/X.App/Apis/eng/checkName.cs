using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using X.Web;
using X.Web.Com;

namespace X.App.Apis.eng {
    public class checkname : _eng {
        public string name { get; set; }
        protected override bool nd_user {
            get {
                return false;
            }
        }

        protected override XResp Execute()
        {
            var q = from u in DB.x_user
                    where u.name == name
                    select u;
            if (q.Count() > 0) {
                throw new XExcep("用户名已被注册");
            }
            else {
                return new XResp();
            }
        }
    }
}
