/*
    Uppgift 3 - moment 3 i kurs DT071G 
    Av Andreas Nygård
*/

//Klass för att hantera menysystem och interaktion med användaren
//Klassen har två attribut - gästboken och filvägen till JSON-filen
class MenuSystem
{
    private Guestbook guestbook;
    private string filePath = "posts.json";
    public MenuSystem()
    {
        guestbook = new Guestbook();
        //Läser in inlägg från angiven JSON-fil
        guestbook.Posts = Guestbook.LoadPostsFromFile(filePath);
    }
    //Metod för att skriva ut huvudmeny
    public void ShowMainMenu()
    {
        bool on = true;

        //While-loop för att förhindra att program kraschar
        while (on)
        {
            System.Console.WriteLine();
            System.Console.WriteLine("A N D R E A S ' S   G U E S T B O O K");
            System.Console.WriteLine();
            System.Console.WriteLine("==== Main Menu ====");
            System.Console.WriteLine();
            System.Console.WriteLine("1. Add new post");
            System.Console.WriteLine("2. Remove current post");
            System.Console.WriteLine("3. View all posts");
            System.Console.WriteLine();
            System.Console.WriteLine("0. Exit program");
            System.Console.Write("Your choice: ");

            string? userInput = Console.ReadLine();
            //Olika metoder anropas beroende på input
            switch (userInput)
            {
                case "1":
                    Console.Clear();
                    AddPost();
                    break;
                case "2":
                    Console.Clear();
                    RemovePost();
                    break;
                case "3":
                    Console.Clear();
                    System.Console.WriteLine("3");
                    ShowPosts();
                    break;
                case "0":
                    on = false;
                    //Spara inlägg när man väljer att stänga programmet
                    Guestbook.SavePostsToFile(filePath, guestbook.Posts);
                    Console.Clear();
                    System.Console.WriteLine("Exit program");
                    break;
                default:
                    Console.Clear();
                    System.Console.WriteLine("Invalid input...");
                    break;
            }
        }
    }
    public void AddPost()
    {
        bool on = true; 

        //Förhindra krasch med while-loop
        while (on)
        {
            Console.Clear();
            Console.WriteLine();
            Console.WriteLine("A N D R E A S ' S   G U E S T B O O K");
            Console.WriteLine();
            Console.WriteLine("=== Add a post ===");
            Console.WriteLine();
            Console.WriteLine("Here you can add a new post to the guestbook.");
            Console.WriteLine("Follow the instructions below.");
            Console.WriteLine();

            string? nameInput = null;
            string? messageInput = null;

            //Validera input
            //Om namn-input är tomt
            while (string.IsNullOrEmpty(nameInput))
            {
                Console.Write("What is your name?: ");
                nameInput = Console.ReadLine();
                if (String.IsNullOrEmpty(nameInput))
                {
                    Console.Clear();
                    Console.WriteLine("This field cannot be empty. Please enter your name.");
                }
            }
            
            //Validera om message-input är tomt eller för långt
            while (string.IsNullOrEmpty(messageInput) || messageInput.Length > 35)
            {
                Console.Write("Your message (max 35 chars): ");
                messageInput = Console.ReadLine();

                if (String.IsNullOrEmpty(messageInput))
                {
                    Console.Clear();
                    Console.WriteLine("This field cannot be empty. Please enter your message.");
                }
                else if (messageInput.Length > 35)
                {
                    Console.Clear();
                    Console.WriteLine("Your message cannot be longer than 35 characters.");
                }
            }
            
            //Lägg till inlägg i lista i gästboken
            guestbook.Posts.Add(new Post(nameInput, messageInput));

            on = false;
            Console.Clear();
            Console.WriteLine("Your post has been added!");
            
        }
    }
    //Metod för att visa alla inlägg
    public void ShowPosts()
    {
        Console.Clear();
        System.Console.WriteLine();
        System.Console.WriteLine("A N D R E A S ' S   G U E S T B O O K");
        System.Console.WriteLine();
        System.Console.WriteLine("=== All current posts ===");
        System.Console.WriteLine();

        //Hämta lista med inlägg från gästbok
        var posts = guestbook.GetPosts();

        //Validera att listan inte är tom
        if (posts.Count == 0)
        {
            System.Console.WriteLine("No posts available...");
        }
        else
        {
            //Skriv ut inlägg 
            for (int i = 0; i < posts.Count; i++)
            {
                System.Console.WriteLine($"[{i}] {posts[i].Author} - {posts[i].Message}");
            }
        }

        System.Console.WriteLine();
        System.Console.WriteLine("Press any key to continue...");
        Console.ReadKey();
        Console.Clear();
    }
    //Metod för att ta bort
    public void RemovePost()
    {
        Console.Clear();
        Console.WriteLine();
        Console.WriteLine("A N D R E A S ' S   G U E S T B O O K");
        Console.WriteLine();
        Console.WriteLine("=== Remove a post ===");
        Console.WriteLine();

        var posts = guestbook.GetPosts();

        if (posts.Count == 0)
        {
            Console.WriteLine("No posts available to remove...");
            Console.WriteLine();
            Console.WriteLine("Press any key to return to the main menu...");
            Console.ReadKey();
            Console.Clear();
            return;
        }

        // Visa alla inlägg
        for (int i = 0; i < posts.Count; i++)
        {
            Console.WriteLine($"[{i}] {posts[i].Author} - {posts[i].Message}");
        }

        Console.WriteLine();
        Console.Write("Enter the index number of the post to remove: ");
        string? userInput = Console.ReadLine();

        // Kontrollera om användarens input är en giltig siffra och om indexet finns i listan
        if (int.TryParse(userInput, out int index) && index >= 0 && index < posts.Count)
        {
            // Ta bort inlägget från gästboken
            posts.RemoveAt(index);
            Console.Clear();
            Console.WriteLine("The post has been removed!");
        }
        else
        {
            Console.Clear();
            Console.WriteLine("Invalid index. No post was removed.");
        }

        Console.WriteLine();
        Console.WriteLine("Press any key to return to the main menu...");
        Console.ReadKey();
        Console.Clear();
    }

}