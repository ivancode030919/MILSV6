using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Linq;
using MILS.Connections;


namespace MILS.Class
{
    class UOMClass
    {
        public static Table<tbl_UoM> GetTbl_UoMs()
        {
            return LCon.db.GetTable<tbl_UoM>();
        }

        public static Table<tbl_UoMGroup> GetTbl_UoMGroups()
        {
            return LCon.db.GetTable<tbl_UoMGroup>();
        }

        public static void SaveUOM(String UOMCode, String UOMName)
        {
            Table<tbl_UoM> post = GetTbl_UoMs();
            tbl_UoM p = new tbl_UoM()
            {
                UOMCode = UOMCode,
                UOMName=UOMName
            };

            post.InsertOnSubmit(p);
            post.Context.SubmitChanges();

        }

        public static List<tbl_UoM> GetUOM()
        {
            List<tbl_UoM> querySection = (from s in GetTbl_UoMs()
                                           orderby s.UOMCode ascending
                                           select s).ToList();

            return querySection;
        }


        public static List<tbl_UoM> GetUOMsSearch(string search)
        {
            List<tbl_UoM> querySection = (from s in GetTbl_UoMs()
                                           where s.UOMName.Contains(search) || s.UOMCode == search
                                           orderby s.UOMCode ascending
                                           select s).ToList();
            return querySection;
        }


        public static List<tbl_UoMGroup> GetUOMGroup()
        {
            List<tbl_UoMGroup> querySection = (from s in GetTbl_UoMGroups()
                                          orderby s.UoMgroupID ascending
                                          select s).ToList();

            return querySection;
        }




    }
}
