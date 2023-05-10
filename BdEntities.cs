using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WPF_BD_PR10
{
    public partial class BdEntities : DbContext
    {
        private static BdEntities context;

        public static BdEntities GetContext()
        {
            if (context == null) context = new BdEntities();
            return context;
        }
    }
}
