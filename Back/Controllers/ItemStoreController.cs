using Back.Bussiness.Interfaces;
using Back.Bussiness.Services;
using Back.Entity.Models;
using Back.Models.Response;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Back.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ItemStoreController : ControllerBase
    {
        private readonly IItemStoreService _service;
        public ItemStoreController(IItemStoreService service)
        {
            _service = service;
        }
        [HttpPost]
        [Route("Add")]
        public ActionResult Add(ItemStoreModel item)
        {
            Model model = new Model();
            model.success = _service.Add(item);
            model.mensaje = model.success ? "Registro insertado correctamente" : "Error al insertar el registro";
            return Ok(model);
        }
        [HttpPost]
        [Route("Update")]
        public ActionResult Update(ItemStoreModel item)
        {
            Model model = new Model();
            model.success = _service.Update(item);
            model.mensaje = model.success ? "Registro insertado correctamente" : "Error al insertar el registro";
            return Ok(model);
        }
        [HttpPost]
        [Route("Remove")]
        public ActionResult Remove(int idItem, int idStore)
        {
            Model model = new Model();
            model.success = _service.Remove(idItem, idStore);
            model.mensaje = model.success ? "Operación Exitosa" : "Error en operación";
            return Ok(model);
        }
        [HttpGet]
        [Route("GetAll")]
        public ActionResult GetAll()
        {
            Model model = new Model();
            model.success = true;
            var response = _service.GetAll();
            return Ok(new { items = response, model });
        }
    }
}
