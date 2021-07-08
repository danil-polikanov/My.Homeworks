using BLL.Abstractions.Interfaces;
using Core.Models;
using DAL.Services;
using System;
using System.Collections.Generic;
using BLL.Services;
using DAL.Abstractions.Interfaces;

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
            IRepository userRepository = new UserRepository();     
            IUserService userService = new UserService(userRepository);
            var users = userService.LoadRecords();

            for (int i = 0; i < users.Count; i++)
            {
                List<User> result = users.FindAll(delegate (User user) {
                    return user.Lastname == users[i].Lastname;
                    });
                foreach (var item in result)
                {
                    Console.WriteLine($"Matching Record, got name={item.Firstname}, lastname={item.Lastname}, age={item.Age}");
                }
            }
            
            Console.ReadKey();
        }
    }
}