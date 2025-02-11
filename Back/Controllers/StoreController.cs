using Back.Bussiness.Interfaces;
using Back.Bussiness.Services;
using Back.Entity.Models;
using Back.Models.Response;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Back.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class StoreController : ControllerBase
    {
        private readonly IStoreService _storeService;
        private readonly IItemStoreService _itemStoreService;
        public StoreController(IStoreService storeService, IItemStoreService itemStoreService) 
        {
            _storeService = storeService;
            _itemStoreService=itemStoreService;
        }
        [HttpPost]
        [Route("Add")]
        public ActionResult Add(StoreModel store)
        {
            Model model = new Model();
            model.success = _storeService.Add(store);
            model.mensaje = model.success ? "Registro insertado correctamente" : "Error al insertar el registro";
            return Ok(model);
        }
        [HttpPost]
        [Route("Update")]
        public ActionResult Update(StoreModel store)
        {
            Model model = new Model();
            model.success = _storeService.Update(store);
            model.mensaje = model.success ? "Registro insertado correctamente" : "Error al insertar el registro";
            return Ok(model);
        }
        [HttpPost]
        [Route("Remove")]
        public ActionResult Remove(int id)
        {
            Model model = new Model();
            model.success = _storeService.Remove(id);
            model.mensaje = model.success ? "Operación Exitosa" : "Error en operación";
            return Ok(model);
        }
        [HttpGet]
        [Route("GetAll")]
        public ActionResult GetAll()
        {
            Model model = new Model();
            model.success = true;
            var response = _storeService.GetAll();
            return Ok(new { items = response, model });
        }
        [HttpGet]
        [Route("GetById")]
        public ActionResult Get(int id)
        {
            Model model = new Model();
            var response = _storeService.GetById(id);
            var products = _itemStoreService.GetProductsStore(id);
            return Ok(new { items = response, model, products=products });
        }
        [HttpGet]
        [Route("GetProducts")]
        public ActionResult GetProducts(int id)
        {
            Model model = new Model();
            var response = _storeService.GetById(id);
            var products = _itemStoreService.GetProductsStoreAll(id);
            return Ok(new { items = response, model, products = products });
        }
    }
}
