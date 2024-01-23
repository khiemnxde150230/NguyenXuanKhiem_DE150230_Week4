using System.Net;

class Program
{
    private static void DownloadAsynchronously()
    {
        WebClient client = new WebClient();
        client.DownloadStringCompleted +=
            new DownloadStringCompletedEventHandler(DownloadComplete);
        client.DownloadDataAsync(new Uri("https://github.com/khiemnxde150230/git-test/blob/master/index.html"));
    }

    private static void DownloadComplete(object sender, DownloadStringCompletedEventArgs e)
    {
        if (e.Error != null)
        {
            Console.WriteLine("Some error has occured.");
            return;
        }
        Console.WriteLine(e.Result);
        Console.WriteLine(new string('*', 30));
        Console.WriteLine("Download completed");
    }

    static void Main(string[] args)
    {
        DownloadAsynchronously();
        Console.WriteLine("Main thread : Done");
        Console.WriteLine(new string('*', 30));
        Console.ReadLine();
    }
}