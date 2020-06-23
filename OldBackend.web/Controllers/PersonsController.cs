using Microsoft.AspNetCore.Mvc;
using Pencil42App.Util;
using Pencil42App.Web.Entities;
using Pencil42App.Web.Repositories;
using Pencil42App.Web.Contracts;
using System;
using System.Linq;
namespace Pencil42App.Web.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PersonController : Controller
    {
        [Route("/")]
        [HttpGet]
        public string getResponseFromJoski()
        {
            return "Joski: hello!";
        }
    }
}