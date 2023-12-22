class Program
{
    static void Main()
    {
        GiftControlApp app = new GiftControlApp();

        while (true)
        {
            Console.WriteLine("Введите команду (APerson, AStatus, AGift, LWOUTGift, LWGift):");
            string command = Console.ReadLine();

            switch (command)
            {
                case "APerson":
                    Console.WriteLine("Введите имя человека:");

                    string name = Console.ReadLine();

                    Console.WriteLine("Введите статус человека:");

                    string status = Console.ReadLine();

                    if (app.ContainsStatus(status))
                        app.AddPerson(name, status);

                    Console.WriteLine("\n");

                    break;

                case "AStatus":
                    Console.WriteLine("Введите статус: ");

                    string newStatus = Console.ReadLine();

                    app.AddStatus(newStatus);

                    Console.WriteLine("\n");

                    break;

                case "AGift":
                    Console.WriteLine("Введите имя человека, которому хотите выдать подарок:");

                    string fullName = Console.ReadLine();

                    Console.WriteLine("Введите подарок, который вы хотите ему выдать: ");

                    string gift = Console.ReadLine();

                    app.AssignGift(fullName, gift);

                    Console.WriteLine("\n");

                    break;

                case "LWOUTGift":
                    Console.WriteLine("Список людей без подарка: ");

                    app.GetPeopleWithoutGifts();

                    Console.WriteLine("\n");

                    break;

                case "LWGift":
                    Console.WriteLine("Список людей с подарком: ");

                    app.PrintGifts();

                    Console.WriteLine("\n");

                    break;

                default:
                    Console.WriteLine("Неверная команда.");

                    Console.WriteLine("\n");

                    break;
            }
        }
    }
}


public class Person
{
    public string FullName { get; set; }
    public string Status { get; set; }
    public string Gift { get; set; }
}

public class GiftControlApp
{

    private List<Person> people = new List<Person>();
    private List<string> statuses = new List<string>();

    public void AddPerson(string fullName, string status)
    {
        people.Add(new Person { FullName = fullName, Status = status });
    }

    public void AddStatus(string newStatus)
    {
        if (!statuses.Contains(newStatus))
        {
            statuses.Add(newStatus);
        }
        else
        {
            Console.WriteLine("Такой статус уже имеется!");
        }
    }

    public void AssignGift(string fullName, string gift)
    {
        foreach (var person in people)
        {
            if (person.FullName == fullName)
            {
                person.Gift = gift;
                break;
            }
        }
    }

    public void GetPeopleWithoutGifts()
    {
        foreach (var person in people)
        {
            if (string.IsNullOrEmpty(person.Gift))
            {
                Console.WriteLine($"Person: {person.FullName},Status: {person.Status}, Gift: None");
            }
        }
    }

    public void PrintGifts()
    {
        foreach (var person in people)
        {
            if (!string.IsNullOrEmpty(person.Gift))
            {
                Console.WriteLine($"Person: {person.FullName},Status: {person.Status}, Gift: {person.Gift}");
            }
        }
    }

    internal bool ContainsStatus(string? status)
    {
        if (statuses.Contains(status))
        { 
            return true; 
        }
        else
        {
            return false;
        }
    }
}