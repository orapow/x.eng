using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using X.Data;
using X.Web.Com;

namespace X.App.Apis.eng.user {
    public class infosave : _eng {
        public int uid { get; set; }
        public string name { get; set; }
        public int c1 { get; set; }
        public int c2 { get; set; }
        public string ptel { get; set; }
        public string wtel { get; set; }
        public string email { get; set; }

        protected override XResp Execute()
        {
            if (uid > 0) {
                cu.name = name;
                if (c1 > 0)
                    cu.country = c1;
                if (c2 > 0)
                    cu.city = c2;
                cu.ptel = ptel;
                cu.wtel = wtel;

                SubmitDBChanges();
            }
            return new XResp();
        }

    }
}
