
using App.Models;

namespace App.Services {
    public class ProductService : List<ProductModel> {
        public ProductService() {
            this.AddRange(new ProductModel[] {
                new () {ID = 1 , Name = "Iphone" , Price = 1000},
                new () {ID = 2 , Name = "Samsung" , Price = 800},
                new () {ID = 3 , Name = "Xiaomi" , Price = 600}, 
                new () {ID = 4 , Name = "Huewai" , Price = 400}
            });
        }
    }
}