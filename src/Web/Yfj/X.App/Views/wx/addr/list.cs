using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using X.Core.Utility;

namespace X.App.Views.wx.addr
{
    public class list : _wx
    {
        public string sel { get; set; }
        protected override string GetParmNames
        {
            get
            {
                return "sel";
            }
        }
        protected override void InitDict()
        {
            base.InitDict();
            dict.Add("ads", cu.x_address.OrderByDescending(o => o.ctime));
        }
    }
}
