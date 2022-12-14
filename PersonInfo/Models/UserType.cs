using System;
using System.Collections.Generic;

namespace PersonInfo.Models
{
    public partial class UserType
    {
        public UserType()
        {
            Users = new HashSet<User>();
        }

        public int Id { get; set; }
        public string Description { get; set; } = null!;
        public string Code { get; set; } = null!;

        public virtual ICollection<User> Users { get; set; }
    }
}
