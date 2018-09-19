using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using template.Models;


namespace template.Controllers
{
    public class ModelController : Controller
    {

        private readonly Model _model;
        public ModelController(Model model)
        {
            _model = model;
        }
        public ModelController GetAllModels(int pageNumber = 1, int pageSize = 10)
        {
            private Envelope<ModelDto> ret;            

        }
        public ModelController getModelById()
        {
            return _model
        }

    }
}