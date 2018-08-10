using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BPAClassLibrary.Model
{
   public class DataElement
    {
        public int DataElementTypeId { get; set; }
        public string DataElementName { get; set; }
        public string CreatedBy { get; set; }
        public string UpdatedBy { get; set; }
        public DateTime CreateTs { get; set; }
        public DateTime UpdateTs { get; set; }
        public bool IsActive { get; set; }
    }

    public class DataElementResponseModel
    {
        public string Success { get; set; }
        public string Error { get; set; }
        public List<DataElement> DataElementList { get; set; }
    }
}
