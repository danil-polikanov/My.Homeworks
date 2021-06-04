using Core.Models;
using DAL.Abstractions.Interfaces;
using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization.Json;
using System.Text;

namespace DAL.Services
{
    public class UserRepository : IRepository
    { 
        public List<User> LoadRecords()
        {
            User deserializedUser = new User();
            List<User> users = new List<User>();
            MemoryStream ms = new MemoryStream(Encoding.UTF8.GetBytes(GetJsonData()));
            DataContractJsonSerializer ser = new DataContractJsonSerializer(users.GetType());

            users = ser.ReadObject(ms) as List<User>;

            ms.Close();
            return users;
        }
        
        private string GetJsonData()
        {
            string json = "[{ \"Age\":40,\"Firstname\":\"Fred\",\"Lastname\":\"Smith\"}]";
            return json;
        }
    }
}