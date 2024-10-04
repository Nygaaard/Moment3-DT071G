/*
    Uppgift 3 - moment 3 i kurs DT071G 
    Av Andreas Nygård
*/

//Klass som representerar ett inlägg i gästboken.
//Har två attribut - Author och Message
public class Post
{
    public string Author { get; set; }
    public string Message { get; set; }

    public Post(string author, string message)
    {
        Author = author;
        Message = message;
    }
    //Parameterlös konstruktor för deserialisering
#pragma warning disable CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider adding the 'required' modifier or declaring as nullable.
    public Post() { }
#pragma warning restore CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider adding the 'required' modifier or declaring as nullable.
}