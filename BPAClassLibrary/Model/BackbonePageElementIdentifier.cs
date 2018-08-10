using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BPAClassLibrary.Model
{
   public class BackbonePageElementIdentifier
    {
        public int BackbonePageElementIdentifierId { get; set; }
        public int BackbonePageElementId { get; set; }
        public string DataElementName { get; set; }
        public int BackbonePageId { get; set; }
        public string PageType { get; set; }
        public string BackboneName { get; set; }
        public string Type { get; set; }
        public string Identifier { get; set; }
        public int SerialNo { get; set; }
        public bool IsActive { get; set; }
        public string Value { get; set; }
    }
    public class BackbonePageElementIdentifierResponseModel
    {
        public string Success { get; set; }
        public string Error { get; set; }
        public List<BackbonePageElementIdentifier> BackbonePageElementIdentifierList { get; set; }
    }
}
