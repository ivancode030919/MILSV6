using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Linq;
using MILS.Connections;

namespace MILS.Class
{
    class LocationClass
    {
        public static Table<tbl_Location> GetTbl_Locations()
        {
            return LCon.db.GetTable<tbl_Location>();
        }

        public static Table<V_LOCATION> GetV_LOCATIONs()
        {
            return LCon.db.GetTable<V_LOCATION>();
        }

        public static void SaveLocation(String LocCode, String LocName, int AreaId)
        {
            Table<tbl_Location> post = GetTbl_Locations();
            tbl_Location p = new tbl_Location()
            {
              LocationCode = LocCode,
              LocationName = LocName,
              Area = AreaId,
              DateAdded = DateTime.Now,
              DateModified = DateTime.Now

            };

            post.InsertOnSubmit(p);
            post.Context.SubmitChanges();

        }


        public static List<V_LOCATION> GetLocation()
        {
            List<V_LOCATION> querySection = (from s in GetV_LOCATIONs()
                                           orderby s.LocationCode ascending
                                           select s).ToList();

            return querySection;
        }
        public static List<tbl_Location> GetlocationSearch(string search)
        {
            List<tbl_Location> querySection = (from s in GetTbl_Locations()
                                            where s.LocationName.Contains(search) || s.LocationCode == search
                                            orderby s.LocationName ascending
                                            select s).ToList();
            return querySection;
        }

    }
}
