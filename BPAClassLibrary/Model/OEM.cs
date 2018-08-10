using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BPAClassLibrary.Model
{
   public class OEM
    {
        public int OEM_Id { get; set; }
        public string OEM_Name { get; set; }
    }
    public class OEMResponseModel
    {
        List<OEM> oem = new List<OEM>();
    }
}
