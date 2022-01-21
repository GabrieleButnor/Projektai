using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Loginai.knygu_tvarkymas
{
    public class Del_stat
    {
        public int state { get; }
        public int count { get; }
        public Del_stat(int state, int count)
        {
            this.state = state;
            this.count = count;
        }
    }
}