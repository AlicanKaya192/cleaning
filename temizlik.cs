using System;
using System.IO;

class Program
{
    static void Main(string[] args)
    {
        CleanTempFolders();
    }

    static void CleanTempFolders()
    {
        try
        {
            string tempPath = Path.GetTempPath();

            DirectoryInfo tempDirectory = new DirectoryInfo(tempPath);

            foreach (FileInfo file in tempDirectory.GetFiles())
            {
                try
                {
                    file.Delete();
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Dosya silinirken bir hata oluştu: {ex.Message}");
                }
            }

            foreach (DirectoryInfo dir in tempDirectory.GetDirectories())
            {
                try
                {
                    dir.Delete(true);
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Klasör silinirken bir hata oluştu: {ex.Message}");
                }
            }

            Console.WriteLine("Geçici dosyalar temizlendi.");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Temizleme işlemi sırasında bir hata oluştu: {ex.Message}");
        }
    }
}
