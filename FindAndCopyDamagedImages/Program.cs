
using ImageProcessor;
using System.Configuration;
using System.Drawing;

DirectoryInfo dir = new DirectoryInfo(ConfigurationManager.AppSettings["CurrentImageFolder"]);

FileInfo[] imageFiles = dir.GetFiles("*."+ ConfigurationManager.AppSettings["ImageType"]);
int count = 0;

foreach (FileInfo f in imageFiles)
{
    try
    {
        ImageFactory factory = new ImageFactory();
        factory.Load(f.FullName);
    }
    catch (Exception ex) {
        var destPath = ConfigurationManager.AppSettings["DestImageFolder"];
        System.IO.File.Copy(f.FullName, Path.Combine(destPath, f.Name));
        Console.WriteLine("Corrupted File Name Proccessed : " + f.Name);
        count++;
    }
}

Console.WriteLine(count);