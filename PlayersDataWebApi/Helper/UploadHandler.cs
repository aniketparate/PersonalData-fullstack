namespace PlayersDataWebApi.Helper
{
    public class UploadHandler
    {
        public string Upload(IFormFile file)
        {
            
            List<string> validExtensions = new List<string>() { ".jpg", ".png", ".jpeg" };
            string extension = Path.GetExtension(file.FileName);
            if (!validExtensions.Contains(extension))
            {
                return $"Extension is not supported ({string.Join(',', validExtensions)})";
            }

            long size = file.Length;
            if (size > (5 * 1024 * 1024))
            {
                return "File size is too large";
            }

            string fileName = Path.GetFileNameWithoutExtension(file.FileName) + Guid.NewGuid().ToString() + extension;
            string path = Path.Combine(Directory.GetCurrentDirectory(), "Images\\");
            Console.WriteLine(path);
            using FileStream stream = new FileStream(path + fileName, FileMode.Create);
            file.CopyTo(stream);
            return fileName;
        }

        public bool Delete(string fileName)
        {
            string path = Path.Combine(Directory.GetCurrentDirectory(), "Images", fileName);
            if (File.Exists(path))
            {
                File.Delete(path);
                return true;
            }
            return false;
        }
    }
}
