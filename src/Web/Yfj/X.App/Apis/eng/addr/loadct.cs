using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using X.Web.Com;

namespace X.App.Apis.eng.addr {
    public class loadct :xapi {
        public string up { get; set;}
        protected override XResp Execute()
        {
            if (!string.IsNullOrEmpty(up)) {
                var r = new Resp_List();
                r.items = GetDictList("sys.city", up).Select(o => new { o.name, o.value });
                return r;
            }
            else {
                return new XResp();
            }
        }
    }
}
