using System.Reflection;

Console.WriteLine("Loading all the classes!");

Console.WriteLine("Please select which application you want to run:");
Assembly assembly = Assembly.GetExecutingAssembly();
var listOfClasses = new List<Type>();
var index = 0;
// Loop through all types in the assembly
foreach (Type type in assembly.GetTypes())
{
    // Check if the type has the LoadOnDemand attribute
    if (type.GetCustomAttribute<LoadOnDemandAttribute>() != null)
    {
        listOfClasses.Add(type);
        // Load and execute the Main method of the class dynamically

        //MethodInfo method = type.GetMethod("Main", BindingFlags.Public | BindingFlags.Static);
        //if (method != null)
        //{
        //    method.Invoke(null, null);
        //}
    }
}


listOfClasses = listOfClasses.OrderBy(x => x.Name).ToList();
foreach (var type in listOfClasses)
{
    Console.WriteLine($"{++index}. {type.Name}");
}

Console.Write("Enter the number of the class to run: ");
if (int.TryParse(Console.ReadLine(), out int selectedClassNumber))
{
    if (selectedClassNumber >= 1 && selectedClassNumber <= listOfClasses.Count)
    {
        Console.WriteLine(selectedClassNumber.ToString());
        Type selectedType = listOfClasses[selectedClassNumber - 1];
        object instance = Activator.CreateInstance(selectedType);
        MethodInfo method = selectedType.GetMethod("Main", BindingFlags.Public | BindingFlags.Instance);
        if (method != null)
        {
            Console.WriteLine($"\n******* Start Executing {selectedType.Name}.Main *******\n");
            method.Invoke(instance, null);
        }
        else
        {
            Console.WriteLine("Main method not found in the selected class.");
        }
    }
    else
    {
        Console.WriteLine("Invalid number. Please select a valid number from the list.");
    }
}
else
{
    Console.WriteLine("Invalid input. Please enter a valid number.");
}