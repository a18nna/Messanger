using Messanger.BLL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Massenger.BLL.Models
{
    public class Friend
    {
        public int id { get; set; }
        public int user_id { get; set; }
        public int friend_id { get; set; }
        public IEnumerable<User> friends { get; } 

        public Friend(int id, int user_id, int friend_id, IEnumerable<User> friends)
        {
            this.id = id;
            this.user_id = user_id;
            this.friend_id = friend_id;
            this.friends = friends;
        }
    }
}
