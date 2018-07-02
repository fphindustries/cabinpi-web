using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CabinPi.Web.Models.Wsdot;
using CabinPi.Web.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace CabinPi.Web.Pages
{
    public class PassModel : PageModel
    {
        private readonly WsdotService _wsdot;
        public PassCondition Conditions { get; private set; }

        public PassModel(WsdotService wsdot)
        {
            _wsdot = wsdot;
        }


        public async Task OnGetAsync()
        {
            Conditions = await _wsdot.GetConditions();

        }
    }
}