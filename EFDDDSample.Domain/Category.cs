using System.Collections.Generic;

namespace EFDDDSample.Domain
{
    public class Category
    {
        private IList<Product> _products { get; set; }

        protected Category() { this._products = new List<Product>(); }

        public Category(string name)
        {
            this.Name = name;
            this._products = new List<Product>();
        }

        public int Id { get; protected set; }
        public string Name { get; protected set; }
        public ICollection<Product> Products
        {
            get { return _products; }
            protected set { _products = new List<Product>(value); }
        }

        public void ChangeName(string name)
        {
            this.Name = name;
        }

        public void AddProduct(Product product)
        {
            this._products.Add(product);
        }
    }
}
