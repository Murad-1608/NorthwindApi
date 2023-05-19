using Core.Entity.Abstract;

namespace Entity.Concrete
{
    public class Product : IEntity
    {
        public int ID { get; set; }
        public int CategoryId { get; set; }
        public string ProductName { get; set; }
        public short UnitsInStock { get; set; }
        public decimal UnitPrice { get; set; }
    }
}
