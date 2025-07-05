using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MiniAccountManagementSystem.Models
{
    public class VoucherEntry
    {
public int AccountId { get; set; }
        public decimal Debit { get; set; }
        public decimal Credit { get; set; }
    }
}