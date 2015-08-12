using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using SaMI.DTO;
using SaMI.DataAccess;
using System.Data;

namespace SaMI.Business
{
    public class DocumentTypesBO
    {
        public static DataView GetAll()
        {
            return new DocumentTypesDAO().SelectAll();

        }
        public static int InsertDocumentTypes(DocumentTypes objDocumentTypes)
        {
            return new DocumentTypesDAO().InsertDocumentTypes(objDocumentTypes);
        }
        public static DocumentTypes GetDocumentTypes(int DocumentTypeID)
        {
            DocumentTypes objDocumentTypes = new DocumentTypes();
            return (DocumentTypes)(new DocumentTypesDAO().FillDTO(objDocumentTypes, "DocumentTypeID=" + DocumentTypeID));
        }
        public static int UpdateDocumentTypes(DocumentTypes objDocumentTypes)
        {
            return new DocumentTypesDAO().UpdateDocumentTypes(objDocumentTypes);
        }

        public static int Delete(int DocumentTypeID)
        {
            return new DocumentTypesDAO().Delete("DocumentTypeID=" + DocumentTypeID);
        }

        public static int DeleteDocumentTypes(DocumentTypes objDocumentTypes)
        {
            return new DocumentTypesDAO().DeleteDocumentTypes(objDocumentTypes);
        }
    }
}
