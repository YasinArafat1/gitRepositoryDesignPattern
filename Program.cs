using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace C__Final_Project
{
    class Program
    {
        static void Main(string[] args)
        {
            var productRepository = new ProductRepository();

            while (true)
            {
                Console.WriteLine("Options:");
                Console.WriteLine("1. Add Product");
                Console.WriteLine("2. Update Product");
                Console.WriteLine("3. Delete Product");
                Console.WriteLine("4. Show All Products");
                Console.WriteLine("5. Exit");
                Console.Write("Enter option: ");

                if (int.TryParse(Console.ReadLine(), out int choice))
                {
                    switch (choice)
                    {
                        case 1:
                            Console.Write("Enter product name: ");
                            string name = Console.ReadLine();
                            Console.Write("Enter product price: ");
                            if (decimal.TryParse(Console.ReadLine(), out decimal price))
                            {
                                var newProduct = new Product { ProductName = name, ProductPrice = price };
                                productRepository.Add(newProduct);
                                Console.WriteLine("Product added successfully.");
                            }
                            break;
                        case 2:
                            Console.Write("Enter product ID to update: ");
                            if (int.TryParse(Console.ReadLine(), out int idToUpdate))
                            {
                                var productToUpdate = productRepository.GetById(idToUpdate);
                                if (productToUpdate != null)
                                {
                                    Console.Write("Enter new product name: ");
                                    productToUpdate.ProductName = Console.ReadLine();
                                    Console.Write("Enter new product price: ");
                                    if (decimal.TryParse(Console.ReadLine(), out decimal newPrice))
                                    {
                                        productToUpdate.ProductPrice = newPrice;
                                        productRepository.Update(productToUpdate);
                                        Console.WriteLine("Product updated successfully.");
                                    }
                                }
                                else
                                {
                                    Console.WriteLine("Product not found.");
                                }
                            }
                            break;
                        case 3:
                            Console.Write("Enter product ID to delete: ");
                            if (int.TryParse(Console.ReadLine(), out int idToDelete))
                            {
                                productRepository.Delete(idToDelete);
                                Console.WriteLine("Product deleted successfully.");
                            }
                            break;
                        case 4:
                            var products = productRepository.GetAll();
                            foreach (var product in products)
                            {
                                Console.WriteLine($"ID: {product.ProductId}, Name: {product.ProductName}, Price: {product.ProductPrice:C}");
                            }
                            break;
                        case 5:
                            Environment.Exit(0);
                            break;
                        default:
                            Console.WriteLine("Invalid option. Please try again.");
                            break;
                    }
                }
                else
                {
                    Console.WriteLine("Invalid input. Please enter a valid option.");
                }
            }
        }
    }

}
