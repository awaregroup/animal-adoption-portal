using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AnimalAdoption.Common.Logic;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;

namespace AnimalAdoption.Web.Portal.Pages
{
    public class IndexModel : PageModel
    {
        private readonly ILogger<IndexModel> _logger;

        [BindProperty]
        public IEnumerable<Animal> Animals { get; set; }

        public IndexModel(ILogger<IndexModel> logger, AnimalService animalData)
        {
            _logger = logger;
            Animals = animalData.ListAnimals;
        }

        public void OnGet()
        {
        }
    }
}
