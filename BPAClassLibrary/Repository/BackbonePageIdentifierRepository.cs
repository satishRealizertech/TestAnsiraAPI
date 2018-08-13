using BPA.Services;
using BPAClassLibrary.Interface;
using BPAClassLibrary.Model;
using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BPAClassLibrary.Repository
{
   public class BackbonePageIdentifierRepository: IBackbonePageIdentifierRepository
    {
        public BackbonePageIdentifierResponseModel GetBackbonePageIdentifierList()
        {

            BackbonePageIdentifierResponseModel response = new BackbonePageIdentifierResponseModel();
            response.BackbonePageIdentifierList = DataAccess.ExecuteSPGetList<BackbonePageIdentifier>(DataAccess.ConnectionStrings.Ansira, "GetAllBackbonePageIdentifier");
            return response;
        }
        public bool CreateBackbonePageIdentifier(BackbonePageIdentifier backbonepageidentifier)
        {
            ListDictionary param = new ListDictionary();
            param.Add("BackboneId", backbonepageidentifier.BackboneId);
            param.Add("BackbonePageId", backbonepageidentifier.BackbonePageId);
            param.Add("Type", backbonepageidentifier.Type);
            param.Add("Identifier", backbonepageidentifier.Identifier);
            param.Add("SerialNo", backbonepageidentifier.SerialNo);
            param.Add("CreatedBy", backbonepageidentifier.CreatedBy);
            param.Add("CreateTs", backbonepageidentifier.CreateTs);
            param.Add("Value", backbonepageidentifier.Value);
            int result = DataAccess.ExecuteSPNonQuery(DataAccess.ConnectionStrings.Ansira, "CreateBackbonePageIdentifier", param);
            return Convert.ToBoolean(result);

        }

        public bool UpdateBackbonePageIdentifier(BackbonePageIdentifier backbonepageidentifier)
        {
            ListDictionary param = new ListDictionary();
            param.Add("BackbonePageIdentifierId", backbonepageidentifier.BackbonePageIdentifierId);
            param.Add("BackboneId", backbonepageidentifier.BackboneId);
            param.Add("BackbonePageId", backbonepageidentifier.BackbonePageId);
            param.Add("Type", backbonepageidentifier.Type);
            param.Add("Identifier", backbonepageidentifier.Identifier);
            param.Add("SerialNo", backbonepageidentifier.SerialNo);
            param.Add("UpdatedBy", backbonepageidentifier.UpdatedBy);
            param.Add("UpdateTs", backbonepageidentifier.UpdateTs);
            param.Add("Value", backbonepageidentifier.Value);
            int result = DataAccess.ExecuteSPNonQuery(DataAccess.ConnectionStrings.Ansira, "UpdateBackbonePageIdentifier", param);
            return Convert.ToBoolean(result);
        }

        public bool DeleteBackbonePageIdentifier(BackbonePageIdentifier backbonepageidentifier)
        {

            ListDictionary param = new ListDictionary();
            param.Add("BackbonePageIdentifierId", backbonepageidentifier.BackbonePageIdentifierId);
            int result = DataAccess.ExecuteSPNonQuery(DataAccess.ConnectionStrings.Ansira, "DeleteBackbonePageIdentifier", param);
            return Convert.ToBoolean(result);
        }

    }

}
