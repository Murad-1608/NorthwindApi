using Core.Entity.Abstract;

namespace Entity.Concrete
{
    public class Customer : IEntity
    {
        public string CustomerId { get; set; }
        public string CustomerName { get; set; }
        public string CompanyName { get; set; }
        public string City { get; set; }
    }
}
