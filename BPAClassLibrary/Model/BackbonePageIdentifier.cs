using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BPAClassLibrary.Model
{
   public class BackbonePageIdentifier
    {
        public int BackbonePageIdentifierId { get; set; }
        public int BackboneId { get; set; }
        public string BackboneName { get; set; }
        public int BackbonePageId { get; set; }
        public string PageType { get; set; }
        public string Type { get; set; }
        public string Identifier { get; set; }
        public int SerialNo { get; set; }
        public string CreatedBy { get; set; }
        public string UpdatedBy { get; set; }
        public DateTime CreateTs { get; set; }
        public DateTime UpdateTs { get; set; }
        public bool IsActive { get; set; }
        public string Value { get; set; }

    }

    public class BackbonePageIdentifierResponseModel
    {
        public string Success { get; set; }
        public string Error { get; set; }
        public List<BackbonePageIdentifier> BackbonePageIdentifierList { get; set; }
    }
}
