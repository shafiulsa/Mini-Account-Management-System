using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MiniAccountManagementSystem.Models
{
    public class Voucher
    {public int VoucherId { get; set; }
        public string? VoucherType { get; set; }
        public DateTime VoucherDate { get; set; }
        public string? ReferenceNo { get; set; }
        public List<VoucherEntry>? Entries { get; set; }
    }

}