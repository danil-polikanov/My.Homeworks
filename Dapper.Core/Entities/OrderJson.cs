using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dapper.Core.Entities
{
    public class OrderJson
    {
        public int OrderId { get; set; }
        public JsonUser User { get; set; }
        public ICollection<JsonProd> Products { get; set; }
        public OrderJson(int OrderId,User user, List<Product> products)
        {
            this.OrderId = OrderId;
            this.User = new JsonUser(user);

            List<JsonProd> jsonProducts = new List<JsonProd>();
            foreach (var product in products)
            {
                jsonProducts.Add(new JsonProd(product.Merchant,product));
            }          
            this.Products = jsonProducts;         

        }
        public class JsonUser
        {
            public string FullName { get; set; }
            public string Email { get; set; }
            public JsonUser(User user)
            {
               this.FullName = user.FullName;
               this.Email = user.Email;
            }
        }
        public class JsonMerchant
        {
            public string Name { get; set; }
            public JsonMerchant(Merchant merchant)
            {
                this.Name = merchant.Name;
            }
        }
        public class JsonProd
        {

            public string Name { get; set; }
            public string Price { get; set; }
            public JsonMerchant merchant { get; set; }
            public JsonProd(Merchant merchant,Product prod)
            {
                this.merchant = new JsonMerchant(merchant);
                this.Name = prod.Name;
                this.Price = Convert.ToString(prod.Price);
            }

            
        }
    }
}
