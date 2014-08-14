using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Whe;
using Whe.Data;

namespace LifeSummary
{
    public class Manager : EntityManager<Manager>
    {
        public override string ConnectionName
        {
            get
            {
                return "LifeSummary";
            }
        }

       
    }
}