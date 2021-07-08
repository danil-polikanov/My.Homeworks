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
            Console.WriteLine("1. Выведите имена всех актеров.");
            ActorsNames(data);
            Console.WriteLine("2. Выведите количество актеров родившихся в августе.");
            AmountOfActorsByAugust(data);
            Console.WriteLine("3. Выведите имена двух самых старых актеров.");
            OldestActors(data);
            Console.WriteLine("4. Выведите количество статей на каждого автора.");
            AmountsArticleAuthors(data);
            Console.WriteLine("5. Выведите количество статей по авторам и фильмов по режиссеру.");
            AmountsArticleAndFilmsAuthors(data);
            Console.WriteLine("6. Выведите сколько разных букв используется во всех именах актеров.");
            AmountOfDistrictLettersName(data);
            Console.WriteLine("7. Выведите названия всех статей, отсортированных по фамилиям их авторов и количеству страниц.");
            SortArticlesByNamesAndPages(data);
            Console.WriteLine("8. Выведите имя актера и все фильмы с этим актером.");
            SortActorsByFilms(data);
            Console.WriteLine("9. Выведите сумму общего количества страниц во всех статьях и во всех значениях int во всех последовательностях данных.");
            SumOfPagesAndArticles(data);
            Console.WriteLine("10. Получить словарь с ключом — автор статьи, значение — список статей.");
            MakeDictionaryByArticles(data);
        }
        static void ActorsNames(List<object> data)
        {
            Console.WriteLine(string.Join(',', data.OfType<Film>().SelectMany(i => i.Actors).Select(i => i.Name).Distinct()));
        }
        static void AmountOfActorsByAugust(List<object> data)
        {
            Console.WriteLine(string.Join(',', data.OfType<Film>().SelectMany(i => i.Actors).Where(i => i.Birthdate.Month == 8).Select(i => i.Name).Distinct()));
        }
        static void OldestActors(List<object> data)
        {
            Console.WriteLine(string.Join(',', data.OfType<Film>().SelectMany(i => i.Actors).OrderBy(x => x.Birthdate).Select(x => x.Name).Distinct().Take(2)));
        }
        static void AmountsArticleAuthors(List<object> data)
        {
            Console.WriteLine(string.Join(',', data.OfType<Article>().Select(i => i).GroupBy(i => i.Author).Select(i => $"{i.Key}-{i.Count()}")));
        }
        static void AmountsArticleAndFilmsAuthors(List<object> data)
        {
            Console.WriteLine(String.Join(',', data.OfType<ArtObject>().
            Select(i => i).GroupBy(i => i.Author).Select(i => $"{i.Key} - {i.Count()}")));
        }
        static void AmountOfDistrictLettersName(List<object> data)
        {
            Console.WriteLine(data.OfType<Film>().SelectMany(i => i.Actors)
            .Select(i => i.Name.Replace(" ", "")).Distinct().SelectMany(i => i.ToLower().ToCharArray()).Distinct().Count());
        }
        static void SortArticlesByNamesAndPages(List<object> data)
        {
            Console.WriteLine(string.Join(" Next:", data.OfType<Article>().Select(i => i).OrderBy(i => i.Pages).ThenBy(i => i.Author).Select(i => i.Name)));
        }
        static void SortActorsByFilms(List<object> data)
        {
            Console.WriteLine(string.Join('\n', data.OfType<Film>().
                SelectMany(i => i.Actors).Select(i => i.Name).
                Distinct().Select(i => i + "----> " +
                string.Join(",Next film is : ", data.OfType<Film>().
                Where(x => x.Actors.Any(x => x.Name == i)).
                Select(x => x.Name)))));
        }
        static void SumOfPagesAndArticles(List<object> data)
        {
            Console.WriteLine(data.OfType<Article>().
                Sum(x => x.Pages) + data.OfType<List<int>>().SelectMany(x => x).Sum(x => x));
        }
        static Dictionary<string, List<Article>> MakeDictionaryByArticles(List<object> data)
        {
            return data.OfType<Article>().
                ToDictionary(x => x.Author, x => data.OfType<Article>().
                Where(u => u.Author == x.Author).ToList());
        }

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
