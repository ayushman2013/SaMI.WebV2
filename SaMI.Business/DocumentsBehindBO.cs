using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using SaMI.DTO;
using SaMI.DataAccess;
using System.Data;

namespace SaMI.Business
{
     public class DocumentsBehindBO
    {
         public static DataView GetAll(Boolean Select = false)
        {
            return new DocumentsBehindDAO().SelectAll(Select);

        }

         public static int InsertDocumentsBehind(DocumentsBehind objDocumentsBehind)
         {
             return new DocumentsBehindDAO().InsertDocumentsBehind(objDocumentsBehind);
         }

         public static DocumentsBehind GetDocumentBehind(int DocumentBehindID)
         {
             DocumentsBehind objDocumentsBehind = new DocumentsBehind();
             return (DocumentsBehind)(new DocumentsBehindDAO().FillDTO(objDocumentsBehind, "DocumentBehindID=" + DocumentBehindID));
         }

         public static int UpdateDocumentsBehind(DocumentsBehind objDocumentsBehind)
         {
             return new DocumentsBehindDAO().UpdateDocumentsBehind(objDocumentsBehind);
         }

         public static int Delete(int DocumentBehindID)
         {
             return new DocumentsBehindDAO().Delete("DocumentBehindID=" + DocumentBehindID);
         }

         public static int DeleteDocumentsBehind(DocumentsBehind objDocumentsBehind)
         {
             return new DocumentsBehindDAO().DeleteDocumentsBehind(objDocumentsBehind);
         }

    }
}
