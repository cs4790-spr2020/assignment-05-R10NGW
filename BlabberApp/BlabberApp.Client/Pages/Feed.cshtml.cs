using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BlabberApp.Domain.Entities;
using BlabberApp.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace BlabberApp.Client.Pages
{
    public class FeedModel : PageModel
    {
        private readonly IBlabService _service;
        public FeedModel(IBlabService service)
        {
            _service = service;
        }
        public void OnGet()
        {
        }
        public void OnPost()
        {
            var email = Request.Form["email"];
            var message = Request.Form["message"];
            try
            {
                _service.AddBlab(new Blab(message, new Domain.Entities.User(email)));
            }
            catch (Exception ex)
            {
                throw new Exception(ex.ToString());
            }
        }
    }
}
