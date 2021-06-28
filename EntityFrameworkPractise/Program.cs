using EF.BLL.Services;
using EF.Core.Entities;
using EF.Data.Context;
using EF.Data.Repository;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;

namespace EntityFrameworkPractise
{
    class Program
    {
        static void Main(string[] args)
        {


            var optionsBuilder = new DbContextOptionsBuilder<EntityFrameworkPractiseDbContext>()
               .UseSqlServer(@"Server=DESKTOP-BNTF795;Database=EntityPractiseDb;Trusted_Connection=True;");
            EntityFrameworkPractiseDbContext dbContext = new EntityFrameworkPractiseDbContext(optionsBuilder.Options);
            var fileRepository = new FileRepository(dbContext);
            var directoryRepository = new DirectoryRepository(dbContext);
            FileService fileService = new FileService(fileRepository, directoryRepository);
            DirectoryService directorySerivce = new DirectoryService(fileRepository, directoryRepository);

            //var result=fileService.GetAsync();
            //foreach(var i in result)
            //{
            //    Console.WriteLine(i.Id);
            //}
            //TextFile textFile = new TextFile { DirectoryId = 4, Extension = ".txt", Size = "6 Mb", Content = "Сашка парень", Title = "Сашко" };
            //VideoFile videoFile = new VideoFile { DirectoryId = 3, Duration = new TimeSpan(01, 30, 20), Size = "800 Mb", Extension = ".mp4", Title = "Nuts", Height = 1680, Width = 1280 };
            //List<File> files = new List<File>();
            //files.Add(textFile);
            //files.Add(videoFile);

            //TextFile textFile = new TextFile {Id=14, DirectoryId = 3, Extension = ".txt", Size = "9 Mb", Content = "День победы", Title = "Война" };
            //var result=fileService.AddAsync(new TextFile { DirectoryId = 4, Extension = ".docx", Size = "4 Mb", Content = "Some content", Title = "content" }).GetAwaiter().GetResult();
            //var addedlist = fileService.AddAsync(files).GetAwaiter().GetResult();
            //var remote = fileService.RemoteAsync(15).GetAwaiter().GetResult();
            //var update = fileService.UpdateAsync(textFile).GetAwaiter().GetResult();
            //Console.WriteLine("Задание 5");
            //var GetFilesWhichCanRead = fileService.GetFilesWhichCanRead(2,3,1,10);
            //Console.WriteLine(string.Join(',',GetFilesWhichCanRead.Result.Items.Select(x => x.Title + x.Extension)));

            //Console.WriteLine("Задание 6");
            //var GetFilesAndSubFiles = fileService.GetFilesFromDirectory(new Directory { Id = 3 }, 1, 10);
            //Console.WriteLine(string.Join('\n', GetFilesAndSubFiles.Result.OfType<Directory>().Select(x => x.Title)));
            //Console.WriteLine(string.Join('\n', GetFilesAndSubFiles.Result.OfType<File>().Select(x => x.Title + x.Extension)));

            //Console.WriteLine("Задание 7");
            //var GetDirFullName = fileService.GetDirectoryFullName(new Directory { Id = 3 }, 1, 10);
            //Console.WriteLine(string.Join("\\", GetDirFullName.Result.OfType<string>().Select(x => x)));

            //Console.WriteLine("Задание 8.1");
            //var GetDirectoryCanOpen = fileService.GetAllCanOpen(3,4, 1, 10);
            //Console.WriteLine(string.Join(',',  GetDirectoryCanOpen.Result.OfType<Directory>().Select(x => x.Title)));
            //Console.WriteLine(string.Join('\n', GetDirectoryCanOpen.Result.OfType<File>().Select(x => x.Title + x.Extension)));

            //Console.WriteLine("Задание 8.2");
            //GetDirectoryCanOpen = fileService.GetAllCanOpen(3,4, 1, 10);
            //Console.WriteLine(string.Join(',', GetDirectoryCanOpen.Result.OfType<Directory>().Select(x => x.Title)));
            //Console.WriteLine(string.Join('\n', GetDirectoryCanOpen.Result.OfType<File>().Select(x => x.Title + x.Extension)));
            //GetDirFullName = fileService.GetDirectoryFullName(new Directory { Id = 4 }, 1, 10);
            //Console.WriteLine(string.Join("\\", GetDirFullName.Result.OfType<string>().Select(x => x)));

            //Console.WriteLine("Задание 9");
            //var FilesCount = fileService.CountOfFiles(2, 3, 1, 10);
            //Console.WriteLine($"Файлов в папке всего: {FilesCount.Result[0]}");
            //Console.WriteLine($"Доступных пользователю файлов в папке всего: {FilesCount.Result[1]}");

            Console.WriteLine("Задание 10");
            var SortedFiles = fileService.SortFiles(1, 20);
            var AudioFiles = SortedFiles.Result.Items.OfType<AudioFile>().Count();
            var VideoFiles = SortedFiles.Result.Items.OfType<VideoFile>().Count();
            var TextFiles = SortedFiles.Result.Items.OfType<TextFile>().Count();
            var ImagesFiles = SortedFiles.Result.Items.OfType<ImageFile>().Count();
            Console.WriteLine($"Вид файла   :  Кол-во");
            Console.WriteLine($"Аудио       :      {AudioFiles}");
            Console.WriteLine($"Видео       :      {VideoFiles}");
            Console.WriteLine($"Изображения :      {TextFiles}");
            Console.WriteLine($"Текстовые   :      {ImagesFiles}");
            Console.ReadLine();
        }
    }
}
