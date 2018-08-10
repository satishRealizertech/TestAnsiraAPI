using BPAClassLibrary.Interface;
using BPAClassLibrary.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace BPA.API.Controllers
{
    [RoutePrefix("api/DataElement")]
    public class DataElementController : ApiController
    {
        IDataElementRepository _repository;

        public DataElementController(IDataElementRepository repository)
        {
            _repository = repository;
        }

        [HttpGet]
        [Route("GetDataElementData")]
        public HttpResponseMessage GetDataElementData()
        {
            var result = _repository.GetDataElementList();
            return Request.CreateResponse(HttpStatusCode.OK, result);
        }

        [HttpPost]
        [Route("CreateDataElementData")]
        public bool CreateDataElementData(DataElement create)
        {
            var result = _repository.CreateDataElement(create);
            return result;
        }

        [HttpPost]
        [Route("UpdateDataElementData")]
        public bool UpdateDataElementData(DataElement update)
        {
            var result = _repository.UpdateDataElement(update);
            return result;
        }

        [HttpPost]
        [Route("DeleteDataElementData")]
        public bool DeleteDataElementData(DataElement delete)
        {
            var result = _repository.DeleteDataElement(delete);
            return result;
        }
    }
}
