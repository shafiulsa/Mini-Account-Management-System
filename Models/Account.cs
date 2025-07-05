using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MiniAccountManagementSystem.Models
{
    public class Account
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public decimal Balance { get; set; }
        public int? ParentAccountId { get; set; }
    }
}