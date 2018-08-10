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
    [RoutePrefix("api/OEM")]
    public class OEMController : ApiController
    {
        IOEMRepository _repository;
        public OEMController(IOEMRepository repository)
        {
            _repository = repository;
        }

        [HttpGet]
        [Route("GetOEMData")]
        public HttpResponseMessage GetOEMData()
        {
            var result = _repository.GetOEM();
            return Request.CreateResponse(HttpStatusCode.OK, result);
        }

        [HttpPost]
        [Route("CreateOEM")]
        public bool CreateOEM(OEM data)
        {
            var result = _repository.CreateOEM(data);
            return result;
        }
        [HttpPost]
        [Route("UpdateOEMData")]
        public bool UpdateOEMData(OEM update)
        {
            var result = _repository.UpdateOEM(update);
            return result;
        }

        [HttpPost]
        [Route("DeleteOEMData")]
        public bool DeleteOEMData(OEM delete)
        {
            var result = _repository.DeleteOEM(delete);
            return result;
        }
    }
}
