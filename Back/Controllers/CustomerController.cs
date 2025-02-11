using Back.Bussiness.Interfaces;
using Back.Models.Request;
using Microsoft.AspNetCore.Mvc;
using Back.Comun.Encrypt;
using Back.Models.Response;
using Back.Entity.Models;
using Microsoft.AspNetCore.Authorization;

namespace Back.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CustomerController : ControllerBase
    {
        private readonly ICustomerService _customerService;
        private readonly Token _encrypt;
        private readonly ICartService _cartService;
        public CustomerController(ICustomerService customerService, Token encrypt, ICartService cartService)
        {
            _customerService = customerService;
            _encrypt = encrypt;
            _cartService = cartService;
        }
        [HttpPost]
        [Route("Login")]
        public ActionResult Login(LoginRequest request)
        {
            var model = new LoginResponseModel();
            var response=_customerService.Login(request.username, request.password);
            if (response == null)
            {
                model.success = false;
                model.mensaje = "Usuario y/o contraseña incorrecto";
            }
            else
            {
                model.token = _encrypt.GenerateToken(response.UserName);
                model.user = response;
                model.success = true;
                model.cartCustomer = _cartService.GetById(response.idCustomer);
            }
            

            return Ok(model);
        }
        [HttpPost]
        [Route("Add")]
        public ActionResult Add(CustomerModel customer)
        {
            Model model = new Model();
            model.success=_customerService.Add(customer);
            model.mensaje = model.success ? "Registro insertado correctamente" : "Error al insertar el registro";
            return Ok(model);
        }
        [HttpPost]
        [Route("Update")]
        [Authorize]
        public ActionResult Update(CustomerModel customer)
        {
            Model model = new Model();
            model.success = _customerService.Update(customer);
            model.mensaje = model.success ? "Registro insertado correctamente" : "Error al insertar el registro";
            return Ok(model);
        }
        [HttpPost]
        [Route("Remove")]
        [Authorize]
        public ActionResult Remove(int id)
        {
            Model model = new Model();
            model.success = _customerService.Remove(id);
            model.mensaje = model.success ? "Registro insertado correctamente" : "Error al insertar el registro";
            return Ok(model);
        }
        [HttpGet]
        [Route("GetAll")]
        [Authorize]
        public ActionResult GetAll()
        {
            Model model = new Model();
            model.success = true;
            var response= _customerService.GetAll();
            return Ok(new {customers=response, model});
        }
    }
}
