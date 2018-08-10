using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using BPAClassLibrary.Interface;
using BPAClassLibrary.Model;

namespace BPA.API.Controllers
{
    [RoutePrefix("api/Dealer")]
    public class DealerController : ApiController
    {
        IDealerRepository _repository;

        public DealerController(IDealerRepository repository)
        {
            _repository = repository;
        }

        [HttpGet]
        [Route("GetDealerData")]
        public HttpResponseMessage GetDealerData()
        {
            var result = _repository.GetDealerData();
            return Request.CreateResponse(HttpStatusCode.OK, result);
        }

        [HttpPost]
        [Route("CreateDealerData")]
        public bool CreateDealerData(Dealer create)
        {
            var result = _repository.CreateDealer(create);
            return result;
        }

        [HttpPost]
        [Route("UpdateDealerData")]
        public bool UpdateDealerData(Dealer update)
        {
            var result = _repository.UpdateDealer(update);
            return result;
        }

        [HttpPost]
        [Route("DeleteDealerData")]
        public bool DeleteDealerData(Dealer delete)
        {
            var result = _repository.DeleteDealer(delete);
            return result;
        }

    }
}
