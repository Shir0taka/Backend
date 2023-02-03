namespace WebApplication2
{
    public class Companies
    {
        public List<Company> companies { get; set; }
    }

    public class Company
    {
        public string Title { get; set; }
        public string Country { get; set; }
        public int NumOfEmployees { get; set; }
        public List<Product> Products { get; set; }
    }

    public class Product
    {
        public string Name { get; set; }
        public int NumOfUsers { get; set; }
    }

    public class Person
    {
        public string Name { get; set; }
        public int Age { get; set; }
        public int Group { get; set; }
    }
}
