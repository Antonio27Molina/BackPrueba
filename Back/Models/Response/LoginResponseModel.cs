using Back.Entity.Models;

namespace Back.Models.Response
{
    public class LoginResponseModel : Model
    {
        public CustomerModel user { get; set; }
        public string token { get; set; }
        public List<CartModel> cartCustomer { get; set; }
    }
}
