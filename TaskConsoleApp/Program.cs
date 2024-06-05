// See https://aka.ms/new-console-template for more information
using TaskConsoleApp.Classes;

Console.WriteLine("Hello, World!");

//ContinueWith();

//WhenAllWhenAny();

//WaitAllWaitAny();

//TaskDelay();

//TaskStartNew();

//TaskFromResult();

Console.WriteLine(TaskResult());

async static Task ContinueWith()
{
    var mytask = new HttpClient().GetStringAsync("https://www.google.com").ContinueWith((data) =>
    {
        Console.WriteLine($"Data length: {data.Result.ToString().Length}");
    });

    Console.WriteLine("some codes running");

    await mytask;
}

async static Task WhenAllWhenAny()
{
    Console.WriteLine($"Main thread: {Thread.CurrentThread.ManagedThreadId}");

    List<string> urlsList = new List<string>()
    {
        "https://www.google.com",
        "https://www.microsoft.com",
        "https://www.amazon.com",
    };

    List<Task<Content>> taskList = new List<Task<Content>>();

    urlsList.ToList().ForEach(url =>
    {
        taskList.Add(Content.GetContentAsync(url));
    });


    //WhenAll tüm taskları alır, main threadi bloklamaz
    var contents = Task.WhenAll(taskList.ToArray());

    Console.WriteLine("some codes running");

    var data = await contents;

    data.ToList().ForEach(x =>
    {
        Console.WriteLine($"WhenAll: {x.Site} Length: {x.Length}");
    });

    //WhenAny ilk biten taskı alır, main threadi bloklamaz
    var contentAny = Task.WhenAny(taskList.ToArray());

    Console.WriteLine("some codes running");

    var dataAny = await contentAny;
    Console.WriteLine($"WhenAny: {dataAny.Result.Site} Length: {dataAny.Result.Length}");
}

async static Task WaitAllWaitAny()
{
    Console.WriteLine($"Main thread: {Thread.CurrentThread.ManagedThreadId}");

    List<string> urlsList = new List<string>()
    {
        "https://www.google.com",
        "https://www.microsoft.com",
        "https://www.amazon.com",
    };

    List<Task<Content>> taskList = new List<Task<Content>>();

    urlsList.ToList().ForEach(url =>
    {
        taskList.Add(Content.GetContentAsync(url));
    });


    //WaitAll tüm taskları alır, main threadi bloklar
    Task.WaitAll(taskList.ToArray());

    Console.WriteLine("tüm tasklar çalıştı");


    //WaitAny ilk biten taskı alır, main threadi bloklar
    var contentAny = Task.WhenAny(taskList.ToArray());

    Console.WriteLine("her hangi bir task çalıştı");

    var dataAny = await contentAny;
    Console.WriteLine($"WaitAny: {dataAny.Result.Site} Length: {dataAny.Result.Length}");
}

async static Task TaskDelay()
{
    //bu metot arka arkaya 10 kere çağırılırsa bekleme süresi 50 sn olmaz bu 5000 sn bekleme async olarak çalışır


    Console.WriteLine("some task running");

    await Task.Delay(5000);

    Console.WriteLine("some task running");
}

async static Task TaskStartNew()
{

    //Task.Run'ın obje geçilebilir hali (run bize yeni bir thread üzerinde çalışma imkanı sağlıyordu)
    var myTask = Task.Factory.StartNew((obj) =>
    {
        Console.WriteLine("myTask çalıştı");
        var status = obj as Status;
        status.ThreadId = Thread.CurrentThread.ManagedThreadId;

    }, new Status() { Date = DateTime.Now });

    await myTask;

    Status s = myTask.AsyncState as Status;

    Console.WriteLine($"Date : {s.Date} // ThreadId : {s.ThreadId}");

}

async static Task TaskFromResult()
{
    //genelde cachlenmiş datayı dönmek için kullanılır
    //bir async metottan veri dönmek için kullanılır

    FileCache.CacheData = await FileCache.GetDataAsync();

    Console.WriteLine(FileCache.CacheData);

}

static string TaskResult()
{
    var task = new HttpClient().GetStringAsync("http://www.google.com");

    //burdan sonuç gelinceye kadar threadi bloklar,responsive'liği kaybederiz
    return task.Result; //asenkron olmayan bir metottan asenkron çalışan bir kod parçacığından gelen veriyi dönmek istediğimiz zaman kullanılır
}



Console.ReadLine();