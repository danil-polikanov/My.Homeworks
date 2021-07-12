using System;

namespace OOP.FirstTask
{
    class Program
    {
        static void Main(string[] args)
        {
            String text = @"Text: file.txt(6B); Some string content
            Image: img.bmp(19MB); 1920х1080
            Text:data.txt(12B); Another string
            Text:data1.txt(7B); Yet another string
            Movie:logan.2017.mkv(19GB); 1920х1080; 2h12m";
            Manager text2 = new Manager(text);
            text2.AddParser("Text", new TextParse());
            text2.AddParser("Image", new ImageParse());
            text2.AddParser("Movie", new MovieParse());

            text2.Parse();
            text2.Sort();
            text2.WriteConsole();

        }
    }
}
