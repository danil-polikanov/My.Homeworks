using BLL.Abstractions.Interfaces;
using Core.Models;
using DAL.Services;
using System;
using System.Collections.Generic;

namespace ConsoleApp8
{
    // Task:
    // Program should return "Matching Record, got name=Fred, lastname=Smith, age=40"
    // Могут быть ошибки любого вида:
    // - отсутствие ссылок на проекты, классы, интерфейсы или же ссылки на несуществующие классы, методы, интерфейсы
    // - ошибки в нейминге
    // - ошибки в логике работы программы
    // - Ошибки в версии целевого фреймворка
    // - очепятки
    // - ошибки в DI контейнере
    // - и т.д.
    // Необходимо исправить все проблемы и ошибки системы и сделать так, чтобы программа заработала
    
    class Program
    {
        static void Main(string[] args)
        {
            UserRepository userRepository = new UserRepository();
            var users = userRepository.LoadRecords();

            for (int i = 0; i < users.Count; i++)
            {
                List<User> result = users.FindAll(delegate (User user) {
                    return user.lastname == users[i].lastname;
                    });
                foreach (var item in result)
                {
                    Console.WriteLine($"Matching Record, got name={item.firstname}, lastname={item.lastname}, age={item.age}");
                }
            }
            
            Console.ReadKey();
        }
    }
}