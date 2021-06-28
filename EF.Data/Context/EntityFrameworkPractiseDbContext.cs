using EF.Core;
using EF.Core.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace EF.Data.Context
{
    public class EntityFrameworkPractiseDbContext : DbContext
    {
        public DbSet<User> Users { get; set; }
        public DbSet<File> Files { get; set; }
        public DbSet<FilePermission> FilePermissions { get; set; }
        public DbSet<DirectoryPermission> DirectoryPermissions { get; set; }
        public DbSet<Directory> Directories { get; set; }
        public DbSet<AudioFile> AudioFiles { get; set; }
        public DbSet<VideoFile> VideoFiles { get; set; }
        public DbSet<TextFile> TextFiles { get; set; }
        public DbSet<ImageFile> ImageFiles { get; set; }
        public EntityFrameworkPractiseDbContext(DbContextOptions<EntityFrameworkPractiseDbContext> options) : base(options)
        {

        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Server=DESKTOP-BNTF795;Database=EntityPractiseDb;Trusted_Connection=True;");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasDefaultSchema("sch");

            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());

            modelBuilder.Entity<FilePermission>(builder =>
            {
                builder.HasKey(x => new { x.UserId, x.FileId });
            });
            modelBuilder.Entity<DirectoryPermission>(builder =>
            {
                builder.HasKey(x => new { x.UserId, x.DirectoryId });
            });


            modelBuilder.Entity<AudioFile>().ToTable("AudioFiles");
            modelBuilder.Entity<ImageFile>().ToTable("ImageFiles");
            modelBuilder.Entity<VideoFile>().ToTable("VideoFiles");
            modelBuilder.Entity<TextFile>().ToTable("TextFiles");

            modelBuilder.Entity<User>().HasData(
                new User[]
                {
                    new User { Id=1, UserName="Vlad",  Email="Vlad@ukrnet.com", PasswordHash = "1324sdtr4"},
                    new User { Id=2, UserName="Polya", Email="Polya@gmail.com", PasswordHash = "654634hfga"},
                    new User { Id=3, UserName="Danya", Email="Danya@gmail.com", PasswordHash = "s54436366"}
                });

            modelBuilder.Entity<Directory>().HasData(
                new Directory[]
                {
                    new Directory { Id=1, ParentDirectoryId=null, Title=@"C:"},
                    new Directory { Id=2, ParentDirectoryId=null, Title=@"F:"},
                    new Directory { Id=3, ParentDirectoryId=1, Title=@"Users"},
                    new Directory { Id=4, ParentDirectoryId=2, Title=@"MyFiles"},
                });

            modelBuilder.Entity<AudioFile>().HasData(
                new AudioFile[]
                {
                    new AudioFile { Id = 1, Bitrate = "320kbps",SampleRate = "192 кГц", ChannelCount = 2, DirectoryId = 4, Duration = new TimeSpan(5,30,30), Extension=".mp3", Size = "5 Mb", Title="Rock"},
                    new AudioFile { Id = 2, Bitrate = "160kbps",SampleRate = "96 кГц", ChannelCount = 4, DirectoryId = 3, Duration = new TimeSpan(3,20,20),  Extension=".ogg", Size = "10 Mb", Title="Pop"},
                    new AudioFile { Id = 3, Bitrate = "480kbps",SampleRate = "192 кГц", ChannelCount = 3, DirectoryId = 4, Duration = new TimeSpan(4,25,25), Extension=".mp3", Size = "7 Mb", Title="Country"}
                });
            modelBuilder.Entity<ImageFile>().HasData(
                new ImageFile[]
                {
                    new ImageFile { Id = 4,Heigth = 720, Width = 480, DirectoryId = 1, Extension = ".jpg",Size = "1 Mb",Title = "Art" },
                    new ImageFile { Id = 5,Heigth = 1280, Width = 720, DirectoryId = 3, Extension = ".jpg",Size = "2 Mb", Title = "War" },
                    new ImageFile { Id = 6,Heigth = 1680, Width = 1280, DirectoryId = 4, Extension = ".jpg",Size = "2 Mb", Title = "Apple" }
                });
            modelBuilder.Entity<VideoFile>().HasData(
                new VideoFile[]
                {
                    new VideoFile { Id = 7, Height = 720, Width = 480, DirectoryId = 2, Extension = ".mp4",  Size = "2 Gb", Duration = new TimeSpan(1,15,21), Title = "Romantic"},
                    new VideoFile { Id = 8, Height = 1080, Width = 1920,DirectoryId = 4, Extension = ".wmv",  Size = "5 Gb",  Duration = new TimeSpan(2,25,20), Title = "Hero"},
                    new VideoFile { Id = 9, Height = 1680, Width = 1280, DirectoryId = 3, Extension = ".mp4",  Size = "1 Gb", Duration = new TimeSpan(6,50,50), Title = "777"}
                });
            modelBuilder.Entity<TextFile>().HasData(
                new TextFile[]
                {
                    new TextFile { Id = 10, DirectoryId = 3, Extension = ".txt", Size = "3 Mb", Content = "Dictionary text", Title = "Dictionary"},
                    new TextFile { Id = 11, DirectoryId = 4, Extension = ".docx", Size = "2 Mb", Content = "List of wishes", Title = "Wishes"},
                    new TextFile { Id = 12, DirectoryId = 4, Extension = ".docx", Size = "800 Mb", Content = "Zero text", Title = "Zero"}
                });

            modelBuilder.Entity<FilePermission>().HasData(
                new FilePermission[]
                {
                    new FilePermission {FileId = 1, UserId = 1, CanRead = true, CanWrite = true },
                    new FilePermission {FileId = 2, UserId = 1, CanRead = true, CanWrite = false },
                    new FilePermission {FileId = 3, UserId = 1, CanRead = true, CanWrite = true },
                    new FilePermission {FileId = 4, UserId = 1, CanRead = false, CanWrite = false },
                    new FilePermission {FileId = 5, UserId = 1, CanRead = true, CanWrite = true },
                    new FilePermission {FileId = 6, UserId = 1, CanRead = false, CanWrite = false },
                    new FilePermission {FileId = 7, UserId = 1, CanRead = true, CanWrite = true },
                    new FilePermission {FileId = 8, UserId = 1, CanRead = true, CanWrite = false },
                    new FilePermission {FileId = 9, UserId = 1, CanRead = false, CanWrite = false },
                    new FilePermission {FileId = 10, UserId = 1, CanRead = true, CanWrite = true },
                    new FilePermission {FileId = 11, UserId = 1, CanRead = true, CanWrite = true },
                    new FilePermission {FileId = 12, UserId = 1, CanRead = false, CanWrite = false },

                    new FilePermission {FileId = 1, UserId = 2, CanRead = true, CanWrite = true },
                    new FilePermission {FileId = 2, UserId = 2, CanRead = true, CanWrite = false },
                    new FilePermission {FileId = 3, UserId = 2, CanRead = true, CanWrite = false },
                    new FilePermission {FileId = 4, UserId = 2, CanRead = false, CanWrite = false },
                    new FilePermission {FileId = 5, UserId = 2, CanRead = true, CanWrite = true },
                    new FilePermission {FileId = 6, UserId = 2, CanRead = false, CanWrite = false },
                    new FilePermission {FileId = 7, UserId = 2, CanRead = true, CanWrite = true },
                    new FilePermission {FileId = 8, UserId = 2, CanRead = true, CanWrite = false },
                    new FilePermission {FileId = 9, UserId = 2, CanRead = false, CanWrite = false },
                    new FilePermission {FileId = 10, UserId = 2, CanRead = true, CanWrite = false },
                    new FilePermission {FileId = 11, UserId = 2, CanRead = true, CanWrite = true },
                    new FilePermission {FileId = 12, UserId = 2, CanRead = false, CanWrite = false },

                    new FilePermission {FileId = 1, UserId = 3, CanRead = true, CanWrite = true },
                    new FilePermission {FileId = 2, UserId = 3, CanRead = true, CanWrite = false },
                    new FilePermission {FileId = 3, UserId = 3, CanRead = false, CanWrite = false },
                    new FilePermission {FileId = 4, UserId = 3, CanRead = false, CanWrite = false },
                    new FilePermission {FileId = 5, UserId = 3, CanRead = true, CanWrite = true },
                    new FilePermission {FileId = 6, UserId = 3, CanRead = true, CanWrite = false },
                    new FilePermission {FileId = 7, UserId = 3, CanRead = true, CanWrite = true },
                    new FilePermission {FileId = 8, UserId = 3, CanRead = true, CanWrite = false },
                    new FilePermission {FileId = 9, UserId = 3, CanRead = false, CanWrite = false },
                    new FilePermission {FileId = 10, UserId = 3, CanRead = true, CanWrite = false },
                    new FilePermission {FileId = 11, UserId = 3, CanRead = true, CanWrite = true },
                    new FilePermission {FileId = 12, UserId = 3, CanRead = false, CanWrite = false }
                });

            modelBuilder.Entity<DirectoryPermission>().HasData(
                new DirectoryPermission[]
                {
                    new DirectoryPermission {DirectoryId = 1, UserId = 1, CanRead = true, CanWrite = true },
                    new DirectoryPermission {DirectoryId = 2, UserId = 1, CanRead = true, CanWrite = true },
                    new DirectoryPermission {DirectoryId = 3, UserId = 1, CanRead = true, CanWrite = true },
                    new DirectoryPermission {DirectoryId = 4, UserId = 1, CanRead = true, CanWrite = true },


                    new DirectoryPermission {DirectoryId = 1, UserId = 2, CanRead = true, CanWrite = false },
                    new DirectoryPermission {DirectoryId = 2, UserId = 2, CanRead = true, CanWrite = false },
                    new DirectoryPermission {DirectoryId = 3, UserId = 2, CanRead = false, CanWrite = false },
                    new DirectoryPermission {DirectoryId = 4, UserId = 2, CanRead = true, CanWrite = true },

                    new DirectoryPermission {DirectoryId = 1, UserId = 3, CanRead = true, CanWrite = false },
                    new DirectoryPermission {DirectoryId = 2, UserId = 3, CanRead = true, CanWrite = true },
                    new DirectoryPermission {DirectoryId = 3, UserId = 3, CanRead = true, CanWrite = false },
                    new DirectoryPermission {DirectoryId = 4, UserId = 3, CanRead = true, CanWrite = true },

                });
        }
    }
}
