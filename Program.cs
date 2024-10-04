/*
    Uppgift 3 - moment 3 i kurs DT071G 
    Av Andreas Nygård
*/

//Klass för att exekvera programmet
//Här hämntas all logik från andra klasser. I detta fall från MenuSystem
class Program
{
    static void Main()
    {
        //Skapar instans av klassen MenuSystem
        //Kör metod som visar huvudmenyn
        MenuSystem menuSystem = new MenuSystem();
        menuSystem.ShowMainMenu();
    }
}