using BPAClassLibrary.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BPAClassLibrary.Interface
{
    public interface IOEMRepository
    {
        IList<OEM> GetOEM();
        bool CreateOEM(OEM OEM_Data);
        bool UpdateOEM(OEM OEM_Data);
        bool DeleteOEM(OEM OEM_Data);
    }
}
