using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Linq;
using MILS.Connections;

namespace MILS.Class
{
    class BatchClass
    {
        public static Table<tbl_Batch> GetTbl_Batches()
        {
            return LCon.db.GetTable<tbl_Batch>();
        }


        public static void SaveArea(String BatchCode, String BatchName)
        {
            Table<tbl_Batch> post = GetTbl_Batches();
            tbl_Batch p = new tbl_Batch()
            {
                BatchCode = BatchCode,
                BatchName = BatchName,
                Date = DateTime.Now

            };

            post.InsertOnSubmit(p);
            post.Context.SubmitChanges();

        }

        public static List<tbl_Batch> GetBatch()
        {
            List<tbl_Batch> querySection = (from s in GetTbl_Batches()
                                           orderby s.Batchid ascending
                                           select s).ToList();

            return querySection;
        }

        public static List<tbl_Batch> GetBatchesSearch(string search)
        {
            List<tbl_Batch> querySection = (from s in GetTbl_Batches()
                                           where s.BatchName.Contains(search) || s.BatchCode == search
                                           orderby s.BatchName ascending
                                           select s).ToList();
            return querySection;
        }
    }
}
