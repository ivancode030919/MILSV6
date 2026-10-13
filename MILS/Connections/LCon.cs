using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MILS.Connections
{
    class LCon
    {
        public static readonly string ConnectionString = "Data Source=172.16.90.218;Initial Catalog=Inventory_Ledger_NPMI_GSC;User ID=sa;Password=p@ssw0rd";

        public static DataClasses1DataContext db =
            new DataClasses1DataContext(ConnectionString);
    }
}
