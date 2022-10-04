using System;
using System.Collections.Generic;

namespace PersonInfo.Models
{
    public partial class UserTitle
    {
        public UserTitle()
        {
            Users = new HashSet<User>();
        }

        public int Id { get; set; }
        public string Description { get; set; } = null!;

        public virtual ICollection<User> Users { get; set; }
    }
}
