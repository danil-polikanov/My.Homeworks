using System;
using System.Collections.Generic;
using System.Linq;

namespace HomeworkWithAuthors
{
    class Program
    {
        static void Main(string[] args)
        {
            var data = new List<object> {
                "Hello",
                new Article { Author = "Hilgendorf", Name = "Punitive law and criminal law doctrine.", Pages = 44 },
                new List<int> {45, 9, 8, 3},
                new string[] {"Hello inside array"},
                new Film { Author = "Martin Scorsese", Name= "The Departed", Actors = new List<Actor>() {
                    new Actor { Name = "Jack Nickolson", Birthdate = new DateTime(1937, 4, 22)},
                    new Actor { Name = "Leonardo DiCaprio", Birthdate = new DateTime(1974, 11, 11)},
                    new Actor { Name = "Matt Damon", Birthdate = new DateTime(1970, 8, 10)}
                }},
                new Film { Author = "Gus Van Sant", Name = "Good Will Hunting", Actors = new List<Actor>() {
                    new Actor { Name = "Matt Damon", Birthdate = new DateTime(1970, 8, 10)},
                    new Actor { Name = "Robin Williams", Birthdate = new DateTime(1951, 8, 11)},
                }},
                new Article { Author = "Basov", Name="Classification and content of restrictive administrative measures applied in the case of emergency", Pages = 35},
                "Leonardo DiCaprio"
            };
            ActorsNames(data);
            AmountOfActorsByAugust(data);
            OldestActors(data);
            AmountsArticleAuthors(data);
            AmountsArticleAndFilmsAuthors(data);
            AmountOfDistrictLettersName(data);
            SortArticlesByNamesAndPages(data);
            SortActorsByFilms(data);
            SumOfPagesAndArticles(data);
            MakeDictionaryByArticles(data);

        }
        //1
        static void ActorsNames(List<object> data)
        {
            Console.WriteLine(string.Join(',', data.Where(i => i is Film).SelectMany(i => ((Film)i).Actors).Select(i => i.Name).Distinct()));
        }

        //2
        static void AmountOfActorsByAugust(List<object> data)
        {
            Console.WriteLine(string.Join(',', data.Where(i => i is Film).SelectMany(i => ((Film)i).Actors).Where(i => i.Birthdate.Month == 8).Select(i => i.Name).Distinct()));
        }
        //3
        static void OldestActors(List<object> data)
        {
            Console.WriteLine(string.Join(',', data.Where(i => i is Film).SelectMany(i => ((Film)i).Actors).OrderBy(x => x.Birthdate).Select(x => x.Name).Distinct().Take(2)));
        }
        //4
        static void AmountsArticleAuthors(List<object> data)
        {
            Console.WriteLine(string.Join(',', data.Where(i => i is Article).Select(i => (Article)i).GroupBy(i => i.Author).Select(i => $"{i.Key}-{i.Count()}")));
        }
        //5
        static void AmountsArticleAndFilmsAuthors(List<object> data)
        {
            Console.WriteLine(String.Join(',', data.Where(i => i is ArtObject).
            Select(i => (ArtObject)i).GroupBy(i => i.Author).Select(i => $"{i.Key} - {i.Count()}")));
        }
        //6
        static void AmountOfDistrictLettersName(List<object> data)
        {
            Console.WriteLine(data.Where(i => i is Film).SelectMany(i => ((Film)i).Actors)
            .Select(i => i.Name.Replace(" ", "")).Distinct().SelectMany(i => i.ToLower().ToCharArray()).Distinct().Count());
        }
        //7
        static void SortArticlesByNamesAndPages(List<object> data)
        {
            Console.WriteLine(string.Join(" Next:", data.Where(i => i is Article).Select(i => (Article)i).OrderBy(i => i.Pages).ThenBy(i => i.Author).Select(i => i.Name)));
        }
        //8
        static void SortActorsByFilms(List<object> data)
        {
            Console.WriteLine(string.Join('\n', data.Where(i => i is Film).
                SelectMany(i => ((Film)i).Actors).Select(i => i.Name).
                Distinct().Select(i => i + "----> " +
                string.Join(",Next film is : ", data.Where(x => x is Film)
                .Select(i => ((Film)i)).
                Where(x => x.Actors.Any(x => x.Name == i)).
                Select(x => x.Name)))));
        }
        //9        
        static void SumOfPagesAndArticles(List<object> data)
        {
            Console.WriteLine(data.Where(x => x is Article).Select(x => (Article)x)
              .Sum(x => x.Pages) + data.Where(x => x is List<int>).SelectMany(x => (List<int>)x).Sum(x => x));
        }
        //10
        static Dictionary<string, List<Article>> MakeDictionaryByArticles(List<object> data)
        {
            return data.Where(x => x is Article).Select(x => (Article)x).
                ToDictionary(x => x.Author, x => data.Where(x => x is Article).
                Select(x => (Article)x).Where(u => u.Author == x.Author).ToList());
        }
        abstract class ArtObject
        {
            public string Author { get; set; }
            public string Name { get; set; }
            public int Year { get; set; }
        }

        class Film : ArtObject
        {

            public int Length { get; set; }
            public IEnumerable<Actor> Actors { get; set; }
        }

        class Actor
        {
            public string Name { get; set; }
            public DateTime Birthdate { get; set; }
        }

        class Article : ArtObject
        {
            public int Pages { get; set; }
        }
    }
}
