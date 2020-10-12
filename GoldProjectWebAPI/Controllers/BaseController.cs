using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using GoldProjectWebAPI.Models;

namespace GoldProjectWebAPI.Controllers
{
    public class BaseController : ApiController
    {
        IGoldPortalContext objEntity;
        public BaseController()
        {
            objEntity = new goldportalEntities();
        }

        public BaseController(IGoldPortalContext context)
        {
            objEntity = context;
        }
        public IGoldPortalContext PortalEntities
        {//get;set;
            get { return objEntity; }
        }
    }
}
