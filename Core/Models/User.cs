using System.Runtime.Serialization;

namespace Core.Models
{
    [DataContract]
    public class User
    {
        [DataMember]
        public string firstname;

        [DataMember]
        public string lastname;

        [DataMember]
        public string points;

        [DataMember]
        public int age;
    }
}