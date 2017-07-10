using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using X.Data;

namespace X.App.Views.web {
    public class _web : xview {
        protected virtual bool nd_user { get { return true; } }
        protected x_user cu { get; set; }
        protected override void InitView()
        {
            base.InitView();

            var cu_key = GetReqParms("cu_key");
            if (!string.IsNullOrEmpty(cu_key))
                cu = DB.x_user.FirstOrDefault(o => o.ukey == cu_key);

                SubmitDBChanges();
                Context.Response.SetCookie(new HttpCookie("cu_key", cu.ukey));
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
