using System;
using System.IO;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace RunTasksInParallel
{
    public class CreateFileService
    {
        public async Task<string> HandleAsync(int millisecondsTimeout) 
        {
            var dateTime = DateTime.Now;
            var fileName = $"{dateTime.Hour}_{dateTime.Minute}_{dateTime.Second}_{dateTime.Millisecond}.txt";
            Console.WriteLine("{0} : {1}", dateTime, fileName);

            var sb = new StringBuilder();
            sb.Append($"{dateTime} {fileName}");

            await File.WriteAllTextAsync($"data/{fileName}", sb.ToString());

            await Task.Delay(millisecondsTimeout);
            return fileName.ToString();
        }

        public string Handle()
        {
            var fileName = Guid.NewGuid();
            var dateTime = DateTime.Now;

            var sb = new StringBuilder();
            sb.Append($"{dateTime} {fileName}");

            File.WriteAllText($"data/{fileName}.txt", sb.ToString());

            // Console.WriteLine("{0} : {1}", dateTime, fileName);

            Thread.Sleep(1000);
            return fileName.ToString();
        }
    }
}
