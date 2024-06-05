// See https://aka.ms/new-console-template for more information
using ParallelForEachConsoleApp;
using System;
using System.Diagnostics;
using System.Drawing;


//MultiThread();

//MultiThreadSharedVariable();

//RaceCondition();

//MultiThreadFor();

//MultiThreadLocalVariable();

static void MultiThread()
{
    Console.WriteLine("MultiThread işlem başladı");

    Stopwatch sw = Stopwatch.StartNew();

    var path = FolderPath.GetFolderPathInProject("images");

    var files = Directory.GetFiles(path);

    Parallel.ForEach(files, file =>
    {
        Console.WriteLine($"ThreadId: {Thread.CurrentThread.ManagedThreadId}");

        Image img = new Bitmap(file);
        var thumbnail = img.GetThumbnailImage(50, 50, () => false, IntPtr.Zero);

        thumbnail.Save(Path.Combine(path, "thumbnail", Path.GetFileName(file)));
    });

    Console.WriteLine("MultiThread işlem bitti");

    sw.Stop();

    Console.WriteLine($"Geçen süre(ms): {sw.ElapsedMilliseconds}");


    Console.WriteLine("********************************");


    Console.WriteLine("SingleThread işlem başladı");
    sw.Reset();
    sw.Start();

    files.ToList().ForEach(file =>
    {
        Console.WriteLine($"ThreadId: {Thread.CurrentThread.ManagedThreadId}");

        Image img = new Bitmap(file);
        var thumbnail = img.GetThumbnailImage(50, 50, () => false, IntPtr.Zero);

        thumbnail.Save(Path.Combine(path, "thumbnail", Path.GetFileName(file)));
    });


    Console.WriteLine("SingleThread işlem bitti");

    sw.Stop();

    Console.WriteLine($"Geçen süre(ms): {sw.ElapsedMilliseconds}");
}

static void MultiThreadSharedVariable()
{
    long FilesByte = 0;

    Console.WriteLine("MultiThread shared variable işlem başladı");

    Stopwatch sw = Stopwatch.StartNew();

    var path = FolderPath.GetFolderPathInProject("images");

    var files = Directory.GetFiles(path);

    Parallel.ForEach(files, file =>
    {
        Console.WriteLine($"ThreadId: {Thread.CurrentThread.ManagedThreadId}");

        FileInfo f = new FileInfo(file);

        //interlocked diğer threadlerin bu paylaşımlı değişkene işlem süreci boyunca erişmesini engelliyor, bu kod çalışması bittikten sonra değeri değişmiş olan değişkene diğer threadlerin erişmesine izin veriyor
        Interlocked.Add(ref FilesByte, f.Length);
        //Interlocked.Exchange(ref FilesByte, 500); //değer değiştirme
        Console.WriteLine(FilesByte);
    });

    Console.WriteLine($"Toplam boyut:{FilesByte}");

    Console.WriteLine("MultiThread işlem bitti");

    sw.Stop();

    Console.WriteLine($"Geçen süre(ms): {sw.ElapsedMilliseconds}");
}

static void RaceCondition()
{
    int deger = 0;

    Parallel.ForEach(Enumerable.Range(1, 100000).ToList(), (x) =>
    {
        deger = x;
    });

    Console.WriteLine(deger);
}

static void MultiThreadFor()
{
    long totalByte = 0;

    var path = FolderPath.GetFolderPathInProject("images");

    var files = Directory.GetFiles(path);

    Parallel.For(0, files.Length, (index) =>
    {
        var file = new FileInfo(files[index]);

        Interlocked.Add(ref totalByte, file.Length);
    });

    Console.WriteLine($"Total Byte: {totalByte}");
}

static void MultiThreadLocalVariable()
{
    int total = 0;

    //normalde foreache girmeden önce sistem bu foreach için kaç thread ayıracaksa rastgele o threadlerden biri geliyor ve kodu çalıştırıyordu
    //burda ise o threadin yapacağı işler bütünü belli olduğu için sadece onları toplayacak(sub total) sonrasında da toplam değere(total) ekleyecek
    //yani 1 nolu threadn görevi 1-25 arasındaki sayıları toplamak ise önce bunları topluyor sonra total'e ekliyor. bu bize performans kazandırıyor
    Parallel.ForEach(Enumerable.Range(1, 100).ToList(), () => 0, (x, loop, subTotal) =>
    {
        subTotal += x;
        return subTotal;
    }, (y) => Interlocked.Add(ref total, y));

    Console.WriteLine(total);
}

Console.ReadLine();