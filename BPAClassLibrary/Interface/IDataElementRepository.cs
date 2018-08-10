using BPAClassLibrary.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BPAClassLibrary.Interface
{
   public interface IDataElementRepository
    {
        DataElementResponseModel GetDataElementList();
        bool CreateDataElement(DataElement dataelement);
        bool UpdateDataElement(DataElement dataelement);
        bool DeleteDataElement(DataElement dataelement);
    }
}
