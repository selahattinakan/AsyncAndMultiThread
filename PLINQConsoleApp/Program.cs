// See https://aka.ms/new-console-template for more information
using PLINQConsoleApp;

Console.WriteLine("Hello, World!");


#region Basic Usage
//AsParallel();

//ForAll();



//Singlethread
static void AsParallel()
{
    var array = Enumerable.Range(1, 200).ToList();

    var newArray = array.AsParallel().Where(x => x % 2 == 0);

    newArray.ToList().ForEach(x =>
    {
        Console.WriteLine(x);
    });
}

//Multithread
static void ForAll()
{
    var array = Enumerable.Range(1, 200).ToList();

    var newArray = array.AsParallel().Where(x => x % 2 == 0);

    newArray.ForAll(value =>
    {
        Console.WriteLine(value);
    });
}
#endregion


#region Entity Usage

//Repository.GetNames();

//Repository.GetNamesForAll();

//Repository.GetNamesForAll(2);

//Repository.GetNamesForAll(ParallelExecutionMode.ForceParallelism);

Repository.ExceptionHandle();

#endregion


Console.ReadLine();
