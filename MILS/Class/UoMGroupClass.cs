using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Linq;
using MILS.Connections;

namespace MILS.Class
{
    class UoMGroupClass
    {
        public static Table<tbl_UoMGroup> GetTbl_UoMGroups()
        {
            return LCon.db.GetTable<tbl_UoMGroup>();
        }

        public static void SaveUoM(String ItemNo, String UomCode,float Qty)
        {
            Table<tbl_UoMGroup> post = GetTbl_UoMGroups();
            tbl_UoMGroup p = new tbl_UoMGroup()
            {
               UoM = UomCode,
               ItemNo= ItemNo,
               AltQty = Qty
            };

            post.InsertOnSubmit(p);
            post.Context.SubmitChanges();

        }

        public static void SaveAlterUoM(String ItemNo, String UomCode, float AltQty)
        {
            Table<tbl_UoMGroup> post = GetTbl_UoMGroups();
            tbl_UoMGroup p = new tbl_UoMGroup()
            {
                UoM = UomCode,
                ItemNo = ItemNo,
                AltQty = AltQty
            };

            post.InsertOnSubmit(p);
            post.Context.SubmitChanges();
        }


        public static bool CheckUom(String ItemNo, String UomCode, float AltQty)
        {
            bool result = GetTbl_UoMGroups()
                .Any(p => p.ItemNo == ItemNo &&
                          p.UoM == UomCode &&
                          p.AltQty == AltQty);
            return result;
        }



    }
}
