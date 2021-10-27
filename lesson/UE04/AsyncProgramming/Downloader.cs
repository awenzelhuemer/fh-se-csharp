using System;
using System.IO;
using System.Net;
using System.Threading.Tasks;

namespace AsyncProgramming
{
    public class Downloader
    {
        public void DownloadAndSaveSync(string url, string filePath)
        {
            using var client = new WebClient();
            byte[] bytes = client.DownloadData(url);
            Console.WriteLine($"{nameof(DownloadAndSaveSync)}: Downloaded {url}");

            File.WriteAllBytes(filePath, bytes);
            Console.WriteLine($"{nameof(DownloadAndSaveSync)}: Saved {filePath}");
        } // client.Dispose();

        public Task DownloadAndSaveTask(string url, string filePath)
        {
            using var client = new WebClient();
            Task task = client.DownloadDataTaskAsync(url)
                .ContinueWith((Task<byte[]> t) =>
                {
                    Console.WriteLine($"{nameof(DownloadAndSaveTask)}: Downloaded {url}");
                    return t.Result;
                })
                .ContinueWith((Task<byte[]> t) => File.WriteAllBytesAsync(filePath, t.Result))
                .ContinueWith((Task t) => Console.WriteLine($"{nameof(DownloadAndSaveTask)}: Saved {filePath}"));
            return task;
        }

        public async Task DownloadAndSaveAsync(string url, string filePath)
        {
            using var client = new WebClient();
            byte[] bytes = await client.DownloadDataTaskAsync(url);
            Console.WriteLine($"{nameof(DownloadAndSaveAsync)}: Downloaded {url}");

            await File.WriteAllBytesAsync(filePath, bytes);
            Console.WriteLine($"{nameof(DownloadAndSaveAsync)}: Saved {filePath}");
        }

        public async Task DownloadAndSaveMultipleAsync(string url1, string filePath1, string url2, string filePath2)
        {
            var task1 = DownloadAndSaveAsync(url1, filePath1);
            Console.WriteLine($"{nameof(DownloadAndSaveMultipleAsync)}: Download of {url1} started ...");
            var task2 = DownloadAndSaveAsync(url2, filePath2);
            Console.WriteLine($"{nameof(DownloadAndSaveMultipleAsync)}: Download of {url2} started ...");

            await Task.WhenAll(task1, task2);
            Console.WriteLine($"{nameof(DownloadAndSaveMultipleAsync)}: Download and save of all documents completed");
        }
    }
}
