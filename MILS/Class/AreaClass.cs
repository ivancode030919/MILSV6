using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Linq;
using MILS.Connections;

namespace MILS.Class
{
    class AreaClass
    {
        public static Table<tbl_Area> GetTbl_Areas()
        {
            return LCon.db.GetTable<tbl_Area>();
        }

        public static void SaveArea(String AreaName, String Description, DateTime NowDate, String Category)
        {
            Table<tbl_Area> post = GetTbl_Areas();
            tbl_Area p = new tbl_Area()
            {
                AreaName = AreaName,
                Description = Description,
                Date = NowDate,
                Cateroty = Category

            };

            post.InsertOnSubmit(p);
            post.Context.SubmitChanges();

        }

        public static List<tbl_Area> GetArea()
        {
            List<tbl_Area> querySection = (from s in GetTbl_Areas()
                                            orderby s.AreaId ascending
                                           select s).ToList();

            return querySection;
        }

    }
}
