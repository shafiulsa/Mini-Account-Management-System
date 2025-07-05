using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MiniAccountManagementSystem.Models
{
    public class RolePermission
    {
        public int Id { get; set; }
        public string? RoleId { get; set; }
        public string? ModuleName { get; set; }
        public bool CanAccess { get; set; }
    }
}