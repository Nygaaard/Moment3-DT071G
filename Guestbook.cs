/*
    Uppgift 3 - moment 3 i kurs DT071G 
    Av Andreas Nygård
*/

//Klass som representerar gästboken

using System.Text.Json;

class Guestbook
{
    // Ett attribut - en lista med Post-objekt
    private List<Post> posts;
    public Guestbook()
    {
        posts = [];
    }
    public List<Post> Posts
    {
        get => posts;
        set => posts = value;
    }
    //Metod för att returnera lista med inlägg
    public List<Post> GetPosts()
    {
        return posts;
    }
    //Metod för att att spara ner tillaggda inlägg till en fil i JSON-format
    //Skickar med sökväg och listan över gästboksinlägg
    public static void SavePostsToFile(string filePath, List<Post> posts)
    {
        //Serialiserar och skriver över till JSON-filen
        string json = JsonSerializer.Serialize(posts); 
        File.WriteAllText(filePath, json);              

        System.Console.WriteLine("Posts have been saved successfully");
    }
    //Metod för att läsa in inlägg från JSON-fil
    //Returnerar lista med Post-objekt
    public static List<Post> LoadPostsFromFile(string filePath)
    {
        if (File.Exists(filePath))
        {
            //Deserialiserar
            string json = File.ReadAllText(filePath); 
            return JsonSerializer.Deserialize<List<Post>>(json) ?? []; 
        }
        else
        {
            return [];
        }
    }
}