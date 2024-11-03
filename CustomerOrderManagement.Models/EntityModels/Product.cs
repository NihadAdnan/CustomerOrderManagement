namespace CustomerOrderManagement.Models.EntityModels
{
    public class Product:IEntity
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public double UnitPrice { get; set; }

    }
}
