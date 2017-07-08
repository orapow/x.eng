using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using X.Core.Utility;
using X.Data;
using X.Web.Com;

namespace X.App.Apis.eng {
    public class reg : _eng {
        [ParmsAttr(name = "用户名", req = true)]
        public string name { get; set; }
        public string sex { get; set; }
        public string country { get; set; }
        public string city { get; set; }
        public string Phone_tel { get; set; }
        public string WhatsApp_tel { get; set; }
        public string email { get; set; }
        public string pwd { get; set; }

        protected override bool nd_user {
            get {
                return false;
            }
        }

        protected override XResp Execute()
        {
            var user = new x_user();
            user.name = name;
            user.sex = sex;
            user.ptel = Phone_tel;
            user.wtel = WhatsApp_tel;
            user.pwd = Secret.MD5(pwd);
            user.email = email;
            user.ctime = DateTime.Now;
            cu = user;
            cu.ukey = Secret.MD5(Guid.NewGuid().ToString());//保存cookie状态,这个key用以识别用户身份

            DB.x_user.InsertOnSubmit(user);
            SubmitDBChanges();

            Context.Response.SetCookie(new HttpCookie("cu_key", cu.ukey));//保存cookie状态

            return new XResp();
        }

    }
}
