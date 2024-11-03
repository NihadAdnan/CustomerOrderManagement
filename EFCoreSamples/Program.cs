// See https://aka.ms/new-console-template for more information
using CustomerOrderManagement.Models.EntityModels;
using Microsoft.EntityFrameworkCore;

Console.WriteLine("Hello, World!");



//Customer customer = new Customer()
//{
//    Name = "Mr. B",
//    PhoneNo = "2343235345",
//    Address = "Dhaka"
//};


//// add customer; 


//db.Add(customer); 

//var existingCustomer = db.Customers.FirstOrDefault(c => c.Id == 1);

//existingCustomer.Address = "Sylthet";

//existingCustomer = new Customer()
//{
//    Id = 1,
//    Name = "Mr. A",
//    PhoneNo = "872873283",
//    Address = "Sylhet"
//};

//System.InvalidOperationException: 'The instance of entity type 'Customer' cannot be tracked because another instance with the key value '{Id: 1}' is already being tracked. When attaching existing entities, ensure that only one entity instance with a given key value is attached.'


//db.UpdateRange(existingCustomer);


//int successCount = db.SaveChanges();

//if (successCount > 0)
//{
//    Console.WriteLine("Operation Successful!");
//}



//var searchFilter = new
//{
//    keyword = "tv"
//};


//// immediate execution vs deferred execution

//var products = db.Products.AsQueryable();


//products = products.Where(c=>c.Name.ToLower().Contains(searchFilter.keyword) || c.Description.ToLower().Contains(searchFilter.keyword)).AsQueryable();


//var productList = products.ToList();


// working with related data 


//var category = new CustomerCategory()
//{
//    Name = "Premium"
//};


//category.Customers = new List<Customer>()
//{
//    new Customer(){ Name = "Mr. Premium A", PhoneNo="1234", Address="Dhaka"},
//    new Customer(){ Name = "Mr. Premium B", PhoneNo="1235", Address="Dhaka"},

//};


//db.CustomersCategories.Add(category);


//var existingCategory = db.CustomersCategories.FirstOrDefault(c=>c.Id ==1);

//var existingCategory = new CustomerCategory()
//{
//    Id = 1,
//    Name = "ABCD"
//};

//var customer = new Customer()
//{
//    Name = "Regular C",
//    PhoneNo = "123",
//    Address = "Dhaka",
//    CategoryId = 1
//};

//customer.Category = existingCategory;

//db.Add(customer);

//int successCount = db.SaveChanges();

//if (successCount > 0)
//{
//    Console.WriteLine("Operation Successful!");
//}

//lazy loading, eager loading, explicitly loading -- > Loading Related Data 

/*var categories = db.CustomersCategories
                        .Include(c=>c.Customers.Where(c=>c.Address=="Sylthet"))
                        .ToList();
*/

/*foreach (var category in categories)
{
    Console.WriteLine(category.Name);
    Console.WriteLine("___________________________");
    Console.WriteLine("Customers in this Category: ");
    if(category.Customers ==null || !category.Customers.Any())
    {
        Console.WriteLine("\t No Customer Record Found!");
        continue; 
    }

    foreach(var customer in category.Customers)
    {
        Console.WriteLine($"\t {customer.Name} {customer.PhoneNo} {customer.Address}");
    }
}

Console.ReadKey();
*/