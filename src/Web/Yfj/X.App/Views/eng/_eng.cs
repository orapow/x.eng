using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using X.App.Com;
using X.Core.Utility;
using X.Data;

namespace X.App.Views.eng {
    public class _eng:xview {
        protected virtual bool nd_user { get { return true; } }
        protected string opid { get; set; }
        protected x_user cu { get; set; }
        protected bool isWx { get; set; }
        private void initUser()
        {
            if (cu != null)
                return;

            //if (!isWx && !nd_user) return;

            if (!isWx && nd_user)if (Context.Request.RawUrl != "/eng/login.html")Context.Response.Redirect("/eng/login.html");else return;
            if (!isWx)return;

            var code = GetReqParms("code");
            if (string.IsNullOrEmpty(code))
                toWxUrl("snsapi_base");

            if (!string.IsNullOrEmpty(code)) {
                var tk = Wx.GetWebToken(cfg.wx_appid, cfg.wx_scr, code);
                if (!string.IsNullOrEmpty(tk.errcode))
                    toWxUrl("snsapi_base");
                opid = tk.openid;
            }

            if (nd_user) {
                cu = DB.x_user.FirstOrDefault(o => o.wx_opid == opid);

                if (cu == null)
                    cu = new x_user() { ctime = DateTime.Now, etime = DateTime.Now, wx_opid = opid, balance = 0, group = 1, exp = 0, used_exp = 0, invter = 0 };

                if (cu.id == 0 || cu.etime.Value.AddDays(7) < DateTime.Now) {
                    var uk = Wx.GetToken(cfg.wx_appid, cfg.wx_scr);
                    var us = Wx.User.GetUserInfo(cu.wx_opid, uk);
                    cu.nickname = us.nickname;
                    cu.headimg = us.headimgurl;
                    cu.sex = us.sex == 1 ? "男" : us.sex == 2 ? "女" : "未知";
                }

                cu.ukey = Secret.MD5(Guid.NewGuid().ToString());
                if (cu.id == 0)
                    DB.x_user.InsertOnSubmit(cu);

                Context.Response.SetCookie(new HttpCookie("cu_key", cu.ukey));
            }
        }

        private void toWxUrl(string scope)
        {
            var url = Context.Request.RawUrl.Split('?')[0];
            Context.Response.Redirect("https://open.weixin.qq.com/connect/oauth2/authorize?appid=" + cfg.wx_appid + "&redirect_uri=" + Context.Server.UrlEncode("http://" + cfg.domain + url) + "&response_type=code&scope=" + scope + "&state=" + Tools.GetRandRom(6, 3) + "#wechat_redirect");
            Context.Response.End();
        }

        protected override void InitView()
        {
            base.InitView();

            var cu_key = GetReqParms("cu_key");
            if (!string.IsNullOrEmpty(cu_key))
                cu = DB.x_user.FirstOrDefault(o => o.ukey == cu_key);

            isWx = Context.Request.UserAgent.Contains("MicroMessenger");

            if (cu == null || isWx)
                initUser();

            if (cu != null) {
                cu.etime = DateTime.Now;
                
                SubmitDBChanges();
                Context.Response.SetCookie(new HttpCookie("cu_key", cu.ukey));
            }
            
        }

        protected override void InitDict()
        {
            base.InitDict();
            if (cu != null) {
                dict.Add("cu", cu);
            }

        }
    }
}
