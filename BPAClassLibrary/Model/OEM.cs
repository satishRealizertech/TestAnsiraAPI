using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BPAClassLibrary.Model
{
   public class OEM
    {
        public int OEMId { get; set; }
        public string OEMName { get; set; }
        public string CreatedBy { get; set; }
        public string UpdatedBy { get; set; }
        public DateTime CreateTs { get; set; }
        public DateTime UpdateTs { get; set; }
        public bool IsActive { get; set; }
    }
    public class OEMResponseModel
    {
        List<OEM> oem = new List<OEM>();
    }
}
