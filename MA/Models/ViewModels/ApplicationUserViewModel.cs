using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MA.Models.ViewModels
{
    public class ApplicationUserViewModel
    {
        public string ID { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }
        public ApplicationRoleViewModel RoleViewModel { get; set; }
    }
}
