using BPA.Services;
using BPAClassLibrary.Interface;
using BPAClassLibrary.Model;
using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BPAClassLibrary.Repository
{
  public  class BackbonePageElementIdentifierRepository: IBackbonePageElementIdentifierRepository
    {
        public BackbonePageElementIdentifierResponseModel GetBackbonePageElementIdentifierList()
        {
            BackbonePageElementIdentifierResponseModel response = new BackbonePageElementIdentifierResponseModel();
            response.BackbonePageElementIdentifierList = DataAccess.ExecuteSQLGetList<BackbonePageElementIdentifier>(DataAccess.ConnectionStrings.Ansira, "GetAllBackbonePageElementIdentifiers");
            return response;
           
        }
        public bool CreateBackbonePageElementIdentifier(BackbonePageElementIdentifier backbonepageidentifier)
        {
            ListDictionary param = new ListDictionary();
            param.Add("BackbonePageElementId", backbonepageidentifier.BackbonePageElementId);
            param.Add("BackbonePageId", backbonepageidentifier.BackbonePageId);
            param.Add("Type", backbonepageidentifier.Type);
            param.Add("Identifier", backbonepageidentifier.Identifier);
            param.Add("SerialNo", backbonepageidentifier.SerialNo);
            param.Add("CreatedBy", backbonepageidentifier.CreatedBy);
            param.Add("CreateTs", backbonepageidentifier.CreateTs);
            param.Add("Value", backbonepageidentifier.Value);
            int result = DataAccess.ExecuteSPNonQuery(DataAccess.ConnectionStrings.Ansira, "CreateBackbonePageElementIdentifier", param);
            return Convert.ToBoolean(result);
        }
        public bool UpdateBackbonePageElementIdentifier(BackbonePageElementIdentifier backbonepageidentifier)
        {
            ListDictionary param = new ListDictionary();
            param.Add("BackbonePageElementIdentifierId", backbonepageidentifier.BackbonePageElementIdentifierId);
            param.Add("BackbonePageElementId", backbonepageidentifier.BackbonePageElementId);
            param.Add("BackbonePageId", backbonepageidentifier.BackbonePageId);
            param.Add("Type", backbonepageidentifier.Type);
            param.Add("Identifier", backbonepageidentifier.Identifier);
            param.Add("SerialNo", backbonepageidentifier.SerialNo);
            param.Add("UpdatedBy", backbonepageidentifier.UpdatedBy);
            //param.Add("CreateTs", backbonepageidentifier.BackbonePageElementId);
            param.Add("UpdateTs", backbonepageidentifier.UpdateTs);
            //param.Add("IsActive", backbonepageidentifier.IsActive);
            param.Add("Value", backbonepageidentifier.Value);
            int result = DataAccess.ExecuteSPNonQuery(DataAccess.ConnectionStrings.Ansira, "UpdateBackbonePageElementIdentifier", param);
            return Convert.ToBoolean(result);
        }
        public bool DeleteBackbonePageElementIdentifier(BackbonePageElementIdentifier backbonepageidentifier)
        {
            ListDictionary param = new ListDictionary();
            param.Add("BackbonePageElementIdentifierId", backbonepageidentifier.BackbonePageElementIdentifierId);
            int result = DataAccess.ExecuteSPNonQuery(DataAccess.ConnectionStrings.Ansira, "DeleteBackbonePageElementIdentifier", param);
            return Convert.ToBoolean(result);
        }
    }
    }

