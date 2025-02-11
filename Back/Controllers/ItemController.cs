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
    public class ItemController : ControllerBase
    {
        private readonly IItemService _itemService;
        public ItemController(IItemService itemService)
        {
            _itemService = itemService;
        }
        [HttpPost]
        [Route("Add")]
        public ActionResult Add(ItemModel item)
        {
            Model model = new Model();
            model.success = _itemService.Add(item);
            model.mensaje = model.success ? "Registro insertado correctamente" : "Error al insertar el registro";
            return Ok(model);
        }
        [HttpPost]
        [Route("Update")]
        public ActionResult Update(ItemModel item)
        {
            Model model = new Model();
            model.success = _itemService.Update(item);
            model.mensaje = model.success ? "Registro insertado correctamente" : "Error al insertar el registro";
            return Ok(model);
        }
        [HttpPost]
        [Route("Remove")]
        public ActionResult Remove(int id)
        {
            Model model = new Model();
            model.success = _itemService.Remove(id);
            model.mensaje = model.success ? "Operación Exitosa" : "Error en operación";
            return Ok(model);
        }
        [HttpGet]
        [Route("GetAll")]
        public ActionResult GetAll()
        {
            Model model = new Model();
            model.success = true;
            var response = _itemService.GetAll();
            return Ok(new { items = response, model });
        }
        [HttpGet]
        [Route("GetById")]
        public ActionResult Get(int id)
        {
            Model model = new Model();
            model.success = true;
            var response = _itemService.GetById(id);
            return Ok(new { items = response, model });
        }
    }
}
