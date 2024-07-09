using Aspose.Cells;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Net.NetworkInformation;
using System.Text;

namespace ConsoleApp8
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string filePath = "C:\\Users\\zheng.zhang\\Desktop\\New folder\\test.pptx"; // 指定要读取的文件路径
            Stopwatch stopWatch = Stopwatch.StartNew();
            using var fs = new FileStream(filePath, FileMode.Open);
            Ppt2ImageAsync(fs);
            //Ppt2ImageAsync(fs);
            stopWatch.Stop();
            Console.WriteLine($"ppt to pdf {stopWatch.Elapsed.TotalMilliseconds}");
        }

        private static Boolean Ppt2ImageAsync(FileStream FileStream)
        {
            var list = new List<string>();

            Stopwatch stopWatch1 = Stopwatch.StartNew();
            Aspose.Slides.License license = new Aspose.Slides.License();
            license.SetLicense(AsposeLicense.LicenseStream);

            Aspose.Slides.Presentation presentation = new Aspose.Slides.Presentation(FileStream);

            stopWatch1.Stop();
            Console.WriteLine($"ppt to pdf {stopWatch1.Elapsed.TotalMilliseconds}");
            stopWatch1.Restart();
            using (MemoryStream pdfStream = new MemoryStream())
            {
                presentation.Save(pdfStream, Aspose.Slides.Export.SaveFormat.Pdf);

                var file = new FileInfo("C:\\Users\\zheng.zhang\\Desktop\\New folder\\" + "test" + ".pdf");
                if (!file.Exists)
                {
                    using (var content = file.Create())
                    {
                        var contentBytes = pdfStream.ToArray();
                        content.Write(contentBytes, 0, contentBytes.Length);
                    }
                }

                var a= Pdf2ImageAsync(pdfStream);
            }

            stopWatch1.Stop();
            Console.WriteLine($"Pdf2ImageAsync : {stopWatch1.Elapsed.TotalMilliseconds}");

            return true;
        }

        private static Boolean Pdf2ImageAsync(Stream FileStream)
        {
            var list = new List<string>();
            Aspose.Pdf.License license = new Aspose.Pdf.License();
            license.SetLicense(AsposeLicense.LicenseStream);

            Aspose.Pdf.Document doc = new Aspose.Pdf.Document(FileStream);
            int pageNumber = 0;

            foreach (var page in doc.Pages)
            {
                if (pageNumber >= 200)
                {
                    break;
                }
                string name = pageNumber.ToString("000");
                var png = page.ConvertToPNGMemoryStream();
                var file = new FileInfo("C:\\Users\\zheng.zhang\\Desktop\\New folder\\" + name + ".png");
                if (!file.Exists)
                {
                    using (var content = file.Create())
                    {
                        var contentBytes = png.ToArray();
                        content.Write(contentBytes, 0, contentBytes.Length);
                        pageNumber++;
                    }
                }
            }
            return true;
        }
    }


    public static class AsposeLicense
    {
        private static readonly byte[] _licenseByte = Encoding.UTF8.GetBytes(LicenseString);
        /// <summary>
        /// MemoryStream不需要释放，使用的byte数据全局唯一，不会造成内存泄漏问题
        /// https://github.com/microsoft/referencesource/blob/master/mscorlib/system/io/memorystream.cs#L147
        /// </summary>
        public static Stream LicenseStream => new MemoryStream(_licenseByte);

        public const string LicenseString = @"<License>
</License>";
    }

}
