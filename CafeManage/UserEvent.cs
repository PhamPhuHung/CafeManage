using CafeManage.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CafeManage
{
    public class UserEvent:EventArgs
    {
        private UserAccount user;

        public UserAccount User { get => user; set => user = value; }

        public UserEvent(UserAccount user)
        {
            this.User = user;
        }
    }
}
