using System;
using System.Reflection;

//ref link:https://www.youtube.com/watch?v=eZFtSwh0k4E&list=PLRwVmtr-pp05brRDYXh-OTAIi-9kYcw3r&index=23
//   reflector output
// ildasm---

class Person
{
    public Person()
    {
        Console.WriteLine("Person()");
    }
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public int Age { get; set; }
    public int meField;
    public void AnnounceThyself()
    {
        Console.WriteLine("Boooooooooooooooyah!");
    }
    public event Action GotSomeAction;
}

class MainClass
{
    static void Main()
    {
        var assembly = Assembly.GetExecutingAssembly();
        Console.WriteLine(assembly.FullName);
        foreach(Type type in assembly.GetTypes())
        {
            Console.WriteLine("\t" + type.Name);
            Console.WriteLine("\t\tFields:");
            foreach (FieldInfo field in type.GetFields())
                Console.WriteLine("\t\t\t" + field.FieldType + " " + field.Name);
            Console.WriteLine("\t\tProperties:");
            foreach (PropertyInfo prop in type.GetProperties())
                Console.WriteLine("\t\t\t" + prop.PropertyType + " " + prop.Name);
            Console.WriteLine("\t\tMethods:");
            foreach (MethodInfo method in type.GetMethods())
                Console.WriteLine("\t\t\t" + method.ReturnType + " " + method.Name + "()");
            Console.WriteLine("\t\tEvents:");
            Console.WriteLine("\tEvents:");
            foreach (EventInfo eventInfo in type.GetEvents())
            {
                Console.WriteLine("\t\t" + eventInfo.EventHandlerType + " " + eventInfo.Name);
                Console.WriteLine("\t\t\tAdd method: " + eventInfo.GetAddMethod().Name);
                Console.WriteLine("\t\t\tRemove method: " + eventInfo.GetRemoveMethod().Name);
            }
        }
    }
}