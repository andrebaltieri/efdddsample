namespace EFDDDSample.Domain
{
    public class Product
    {
        protected Product()  { }

        public Product(string name)
        {
            this.Name = name;
        }

        public int Id { get; protected set; }
        public string Name { get; protected set; }
        public int CategoryId { get; protected set; }
        public Category Category { get; protected set; }
    }
}
