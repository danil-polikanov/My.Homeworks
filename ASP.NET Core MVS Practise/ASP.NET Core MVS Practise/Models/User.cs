using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ASP.NET_Core_MVS_Practise.Models
{
    public class User:IEntity
    {
   
        public int Id { get; set; }

        [StringLength(50,ErrorMessage ="Длина строки должна быть до 50 символов")]
        public string FirstName { get; set; }

        [StringLength(50, ErrorMessage = "Длина строки должна быть до 50 символов")]
        public string LastName { get; set; }

        [Required(ErrorMessage ="Поле обязательно для заполнения")]
        [EmailAddress(ErrorMessage = "Некорректный адрес")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Поле обязательно для заполнения")]
        [Compare("Email", ErrorMessage = "Emails не совпадает")]
        public string EmailConfirm { get; set; }

        [DataType(DataType.Password)]
        [Required]
        public string Password { get; set; }

        [DataType(DataType.Password)]
        [Required(ErrorMessage = "Поле обязательно для заполнения")]
        [Compare("Password", ErrorMessage = "Пароли не совпадают")]
        public string PasswordConfirm { get; set; }

        public virtual ICollection<ToDo> Todos { get; set; }
    }
}
