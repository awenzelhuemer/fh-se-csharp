using System;
using System.Threading.Tasks;

namespace AsyncProgramming
{
    class Program
    {
        private const string URL1 = "https://github.com/progit/progit2/releases/download/2.1.331/progit.pdf"; // Pro Git
        private const string URL2 = "https://enos.itcollege.ee/~jpoial/oop/naited/Clean%20Code.pdf"; // Clean Code

        static async Task Main()
        {
            var downloader = new Downloader();

            Console.WriteLine("====================== DownloadAndSaveSync ======================");

            downloader.DownloadAndSaveSync(URL1, "bookV1.pdf");
            Console.WriteLine($"Main: {nameof(Downloader.DownloadAndSaveSync)} completed work.");
            Console.WriteLine();


            Console.WriteLine("====================== DownloadAndSaveTask ======================");
            Task task1 = downloader.DownloadAndSaveTask(URL1, "book1V2.pdf");
            Console.WriteLine($"Main: {nameof(Downloader.DownloadAndSaveTask)} gave control back to caller");
            task1.Wait();
            Console.WriteLine($"Main: {nameof(Downloader.DownloadAndSaveTask)}) completed work.");
            Console.WriteLine();

            Console.WriteLine("====================== DownloadAndSaveAsync ======================");
            Task task2 = downloader.DownloadAndSaveAsync(URL1, "book1V3.pdf");
            Console.WriteLine($"Main: {nameof(Downloader.DownloadAndSaveAsync)} gave control back to caller");
            await task2;
            Console.WriteLine($"Main: {nameof(Downloader.DownloadAndSaveAsync)}) completed work.");
            Console.WriteLine();

            Console.WriteLine("======================= DownloadAndSaveMultipleAsync =======================");
            Task task3 = downloader.DownloadAndSaveMultipleAsync(URL1, "book1V4.pdf", URL2, "book2V4.pdf");
            Console.WriteLine($"Main: {nameof(Downloader.DownloadAndSaveMultipleAsync)} gave control back to caller");
            await task3;
            Console.WriteLine($"Main: {nameof(Downloader.DownloadAndSaveMultipleAsync)} completed work.");
            Console.WriteLine();
        }
    }
}
