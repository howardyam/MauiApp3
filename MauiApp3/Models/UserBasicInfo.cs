using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MauiApp3.Models
{
    public class UserBasicInfo
    {
        public string FullName { get; set; }
        public string Email { get; set; }
        public int RoleID { get; set; }
        public string RoleText { get; set; }
        public string Password { get; set; }
    }

    public enum RoleDetails
    {
        Student = 1,
        Teacher,
        Admin,
    }
}
