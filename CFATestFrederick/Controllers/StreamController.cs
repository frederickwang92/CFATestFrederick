using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using CFATestFrederick.Service;

namespace CFATestFrederick.Controllers
{
    public class StreamController : ApiController
    {
        private readonly IStreamService _streamService;

        //public StreamController() { }

        public StreamController(IStreamService streamService)
        {
            _streamService = streamService;
        }

        [HttpGet]
        public HttpResponseMessage GetScoreAtIndex(int id)
        {
            int score = _streamService.getScore(id);
            if (score == -1)
            {
                return new HttpResponseMessage(HttpStatusCode.BadRequest);
            }

            HttpResponseMessage response = new HttpResponseMessage(HttpStatusCode.OK);
            response.Content = new StringContent(score.ToString());
            return response;
        }
    }
}
