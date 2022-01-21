using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Loginai
{
    class sub
    {
        public string id { get; private set; }
        public string name { get; private set; }

        public sub(string Id, string Name)
        {
            id = Id;
            name = Name;
        }
    }
}