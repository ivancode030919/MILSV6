using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Linq;
using MILS.Connections;

namespace MILS.Class
{
    class ItemClass
    {
        public static Table<tbl_Item> GetTbl_Items()
        {
            return LCon.db.GetTable<tbl_Item>();
        }
        
        public static bool ValidateItem(string itemno)
        {
            var query = (from s in GetTbl_Items()
                         where s.Itemno == itemno
                         select s).FirstOrDefault();
            return query != null;
        }

        public static List<tbl_Item> GetItemsSearch(string search)
        {
            List<tbl_Item> querySection = (from s in GetTbl_Items()
                                           where s.Itemname.Contains(search) || s.Itemno==search
                                           orderby s.Itemname ascending
                                            select s).Take(50).ToList();
            return querySection;
        }

        public static void SaveItem(String itemno, String itemname, DateTime CDate, bool WithEx, bool Status,string UoM)
        {
            Table<tbl_Item> post = GetTbl_Items();
            tbl_Item p = new tbl_Item()
            {
                Itemno = itemno,
                Itemname = itemname,
                Date = CDate,
                WithExpirationDate = WithEx,
                Status = Status,
                UoM = UoM

            };
            post.InsertOnSubmit(p);
            post.Context.SubmitChanges();
        }


        public static void UpdateUoM(string itemno, string UoM)
        {
            Table<tbl_Item> post = GetTbl_Items();

            tbl_Item p = post.FirstOrDefault(x => x.Itemno == itemno);
            p.UoM = UoM;
            post.Context.SubmitChanges();
       
        }

    }
}

