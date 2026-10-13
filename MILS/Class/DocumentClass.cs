using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Linq;
using MILS.Connections;

namespace MILS.Class
{
    class DocumentClass
    {


        public static Table<tbl_Document> GetTbl_Documents()
        {
            return LCon.db.GetTable<tbl_Document>();
        }


        public static Table<V_ReceivingDocsPrimary> GetV_ReceivingDocsPrimaries()
        {
            return LCon.db.GetTable<V_ReceivingDocsPrimary>();
        }


        public static Table<V_ReceivingDocsRef> GetV_ReceivingDocsRefs()
        {
            return LCon.db.GetTable<V_ReceivingDocsRef>();
        }



        public static void SaveDocument(String DocCode, String DocName, String Cat, String Mod)
        {
            Table<tbl_Document> post = GetTbl_Documents();
            tbl_Document p = new tbl_Document()
            {
                DocumentCode = DocCode,
               DocumentName = DocName,
               Category = Cat,
               Module = Mod,
               Date = DateTime.Now

            };

            post.InsertOnSubmit(p);
            post.Context.SubmitChanges();

        }


        public static List<tbl_Document> GetDocuments()
        {

            
            List<tbl_Document> querySection = (from s in GetTbl_Documents()
                                           orderby s.DocumentName ascending
                                           select s).ToList();

            return querySection;
        }




        public static List<V_ReceivingDocsPrimary> GetRecvPrimaryDoc()
        {
            List<V_ReceivingDocsPrimary> querySection = (from s in GetV_ReceivingDocsPrimaries()
                                               orderby s.DocumentName ascending
                                               select s).ToList();
            return querySection;
        }


        public static List<V_ReceivingDocsRef> GetRecvRefDoc()
        {
            List<V_ReceivingDocsRef> querySection = (from s in GetV_ReceivingDocsRefs()
                                                         orderby s.DocumentName ascending
                                                         select s).ToList();
            return querySection;
        }

    }




}
