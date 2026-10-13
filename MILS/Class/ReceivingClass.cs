using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Linq;
using MILS.Connections;
using MILS.Modules;

namespace MILS.Class
{
    class ReceivingClass
    {
        public static int EntryNumber;
        public static int Area;
        //private Modules.Receiving.ReceivingRegister _receiving;

        public static Table<tbl_RecHeader> GetTbl_RecHeaders()
        {
            return LCon.db.GetTable<tbl_RecHeader>();
        }

        public static Table<tbl_RecDetail> GetTbl_RecDetails()
        {
            return LCon.db.GetTable<tbl_RecDetail>();
        }

        public static Table<tbl_Inventory> GetTbl_Inventories()
        {
            return LCon.db.GetTable<tbl_Inventory>();
        }


        public static void SaveHeader(int Areaid,int DoctypeId,string DocNo,int Remarksid,int RefDocType,string RefDocNo,String Ownership,DateTime Date,int UserID,int AreaID)
        {

            tbl_RecHeader p = new tbl_RecHeader()
            {
              AreaId = Areaid,
              DoctypeId = DoctypeId,
              DocumentNo = DocNo,
              Remarks = Remarksid,
              RefDocType = RefDocType,
              RefDocNo = RefDocNo,
              Ownership = Ownership,
              DocDate = Date,
              UserID = UserID,
              UserArea = AreaID
            };
            LCon.db.tbl_RecHeaders.InsertOnSubmit(p);
            LCon.db.tbl_RecHeaders.Context.SubmitChanges();

            Area = p.AreaId.Value;
            EntryNumber = p.RecHeaderId;
       
        }

        public static void SaveDetail(string ItemNo,int BatchId,int LocId, double Qty,String UOM)
        {
    
                tbl_RecDetail s = new tbl_RecDetail()
                {
                    ItemNo = ItemNo,
                    BatchId = BatchId,
                    LocationId = LocId,
                    Quantity = Qty,
                    RecHeaderId = EntryNumber,
                    UoM= UOM

                };
                LCon.db.tbl_RecDetails.InsertOnSubmit(s);
                LCon.db.tbl_RecDetails.Context.SubmitChanges();
        }

        public static bool CheckInventory(string ItemNo, int BatchId, int LocId)
        {
            bool exists = GetTbl_Inventories()
                .Any(p => p.ItemNo == ItemNo &&
                          p.Area == Area &&
                          p.Batch == BatchId &&
                          p.Location == LocId);

            return exists;
        }


        public static void AddToInventory(string ItemNo, int BatchId, int LocId, double Qty)
        {
            if (CheckInventory(ItemNo, BatchId, LocId) == true)
            {
                var u = LCon.db.tbl_Inventories.FirstOrDefault(p =>
                 p.ItemNo == ItemNo &&
                 p.Batch == BatchId &&
                 p.Location == LocId &&
                 p.Area == Area);

                if (u != null)
                {
                    u.Quantity = u.Quantity + Qty;
                }

            }
            else
            {

                tbl_Inventory s = new tbl_Inventory()
                {
                    ItemNo = ItemNo,
                    Batch = BatchId,
                    Location = LocId,
                    Quantity = Qty,
                    Area = Area

                };
                LCon.db.tbl_Inventories.InsertOnSubmit(s);
            }
              
            LCon.db.tbl_Inventories.Context.SubmitChanges();
        }



        public static object RegisterDEtails(int? EntryNo)
        {
            var header = (from s in GetTbl_RecHeaders()
                          join a in AreaClass.GetTbl_Areas()         
                          on s.AreaId equals a.AreaId
                          join j in DocumentClass.GetTbl_Documents()
                          on s.DoctypeId equals j.Docid
                          where s.RecHeaderId == EntryNo || EntryNo == null
                          select new
                          {
                              documentdate = s.DocDate,
                              Entryno = s.RecHeaderId,
                              docname = j.DocumentName,
                              docno = s.DocumentNo,
                              AreaName = a.AreaName

                          }).ToList();

            return header;
        }

    }
}
