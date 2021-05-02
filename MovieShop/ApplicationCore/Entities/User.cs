using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationCore.Entities
{
    public class User
    {
        public int Id { get; set; }
        [StringLength(128)]
        public string? FirstName { get; set; }
        [StringLength(128)]
        public string? LastName { get; set; }
        public DateTime? DateOfBrith { get; set; }
        [StringLength(256)]
        public string? Email { get; set; }
        [StringLength(1024)]
        public string? HashedPassword { get; set; }
        [StringLength(1024)]
        public string? Salt { get; set; }
        [StringLength(16)]
        public string? PhoneNumber { get; set; }
        public bool? TwoFactorEnabled { get; set; }
        public DateTime? LockoutDate { get; set; }
        public DateTime? LastLoginDateTime { get; set; }
        public bool? IsLocked { get; set; }
        public int? AccessFailedCount { get; set; }
    }
}
