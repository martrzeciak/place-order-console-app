using PlaceOrderConsoleApp.Interfaces;

namespace PlaceOrderConsoleApp;

public class App
{
    private readonly IProductService _productService;

    public App(IProductService productService)
    {
        _productService = productService;
    }

    public async Task Run(string[] args)
    {
        bool exit = false;

        // Simple menu loop
        while (!exit)
        {
            Console.Clear();
            Console.WriteLine("Welcome to the Place Order App");
            Console.WriteLine("Please choose an option:");
            Console.WriteLine("1. List all products");
            Console.WriteLine("2. Place order");
            Console.WriteLine("3. Order history");
            Console.WriteLine("4. Exit");
            Console.Write("Enter your choice (1-4): ");

            var choice = Console.ReadLine();

            switch (choice)
            {
                case "1":
                    await ListProducts();
                    break;

                case "2":
                    await PlaceOrder();
                    break;

                case "3":
                    await ViewOrderHistory();
                    break;

                case "4":
                    exit = true;
                    Console.WriteLine("Exiting the application...");
                    break;

                default:
                    Console.WriteLine("Invalid choice. Please select an option between 1 and 4.");
                    break;
            }

            if (!exit)
            {
                Console.WriteLine("Press any key to continue...");
                Console.ReadKey();
            }
        }
    }

    private async Task ListProducts()
    {
        bool backToMainMenu = false;

        while (!backToMainMenu)
        {
            Console.Clear(); // Clear the screen to list products
            Console.WriteLine("\nProduct list:");
            var products = await _productService.GetProductListAsync();
            if (products.Count == 0)
            {
                Console.WriteLine("No products found.");
            }
            else
            {
                foreach (var product in products)
                {
                    Console.WriteLine($"{product.Id}. Name: {product.Name}, Price: {product.Price} PLN");
                }
            }

            Console.WriteLine("\nOptions:");
            Console.WriteLine("1. Back to main menu");
            Console.Write("Enter your choice (1 to go back): ");
            var choice = Console.ReadLine();

            if (choice == "1")
            {
                backToMainMenu = true; // Exit the loop and go back to the main menu
            }
            else
            {
                Console.WriteLine("Invalid choice. Press 1 to go back to the main menu.");
                Console.ReadKey(); // Wait for user input before showing the options again
            }
        }
    }

    private async Task ViewOrderHistory()
    {
        bool backToMainMenu = false;

        while (!backToMainMenu)
        {
            Console.Clear();
            Console.WriteLine("\nOrder History:");

            Console.WriteLine("\nOptions:");
            Console.WriteLine("1. Back to main menu");
            Console.Write("Enter your choice (1 to go back): ");
            var choice = Console.ReadLine();

            if (choice == "1")
            {
                backToMainMenu = true;
            }
            else
            {
                Console.WriteLine("Invalid choice. Press 1 to go back to the main menu.");
                Console.ReadKey();
            }
        }
    }

    private async Task PlaceOrder()
    {
        bool backToMainMenu = false;

        while (!backToMainMenu)
        {
            Console.Clear();
            Console.WriteLine("\nPlace order:");

            Console.WriteLine("\nOptions:");
            Console.WriteLine("1. Back to main menu");
            Console.Write("Enter your choice (1 to go back): ");
            var choice = Console.ReadLine();

            if (choice == "1")
            {
                backToMainMenu = true;
            }
            else
            {
                Console.WriteLine("Invalid choice. Press 1 to go back to the main menu.");
                Console.ReadKey();
            }
        }
    }
}