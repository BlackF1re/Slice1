using System;
using System.Collections.Generic;

namespace Slice1.Models;

public partial class User
{
    public int Id { get; set; }

    public string Fio { get; set; } = null!;

    public string Phone { get; set; } = null!;

    public string Bitrhday { get; set; } = null!;

    public string Address { get; set; } = null!;

    public int RoleId { get; set; }

    public virtual Role Role { get; set; } = null!;
    
    public User(string fio, string text) { }

     public User(string fio, string birthday, string phone, string address, Role role)
     {
         this.Fio = fio;
         this.Phone = phone;
         this.Bitrhday = birthday;
         this.Address = address;
         this.Role = role;
     }
}

// using System;
// using System.Collections.Generic;
//
// namespace Slice1.Models;
//
// public partial class User
// {
//     // id, ФИО, дата рождения, номер телефона, адрес проживания, role
//     public int Id { get; set; }
//
//     public string FIO { get; set; }
//     
//     public string Birthday { get; set; } = null!;
//
//     public string Phone { get; set; } = null!;
//
//     public string Address { get; set; } = null!;
//
//     public string Role { get; set; } = null!;
//     
//     public User(string fio) { }
//
//     public User(string fio, string birthday, string phone, string address, string role)
//     {
//         this.FIO = fio;
//         this.Phone = phone;
//         this.Birthday = birthday;
//         this.Address = address;
//         this.Role = role;
//     }
// }

