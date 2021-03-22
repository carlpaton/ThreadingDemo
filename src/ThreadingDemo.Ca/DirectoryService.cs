using System.IO;

namespace RunTasksInParallel
{
    public class DirectoryService
    {
        private readonly string _directory = "data";

        public void CreateDirectory() 
        {
            if (!Directory.Exists(_directory)) 
            {
                Directory.CreateDirectory(_directory);
            }
        }

        public void ClearDirectory()
        {
            var files = Directory.GetFiles(_directory);
            foreach (var file in files)
            {
                File.Delete(file);
            }
        }
    }
}
