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
    public class CartController : ControllerBase
    {
        private readonly ICartService _cart;
        public CartController(ICartService cart)
        {
            _cart = cart;
        }
        [HttpPost]
        [Route("Add")]
        public ActionResult Add(List<CartModel> cart)
        {
            Model model = new Model();
            model.success = _cart.Add(cart);
            model.mensaje = model.success ? "Registro insertado correctamente" : "Error al insertar el registro";
            return Ok(model);
        }
        [HttpPost]
        [Route("Update")]
        public ActionResult Update(CartModel cart)
        {
            Model model = new Model();
            model.success = _cart.Update(cart);
            model.mensaje = model.success ? "Registro insertado correctamente" : "Error al insertar el registro";
            return Ok(model);
        }
        [HttpPost]
        [Route("Remove")]
        public ActionResult Remove(int id)
        {
            Model model = new Model();
            model.success = _cart.Remove(id);
            model.mensaje = model.success ? "Operación Exitosa" : "Error en operación";
            return Ok(model);
        }
        [HttpGet]
        [Route("GetAll")]
        public ActionResult GetAll()
        {
            Model model = new Model();
            model.success = true;
            var response = _cart.GetAll();
            return Ok(new { items = response, model });
        }
    }
}
