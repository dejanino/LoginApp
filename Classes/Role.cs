using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LoginApplication.Classes
{
    class Role
    {
        public int ID { get; set; }
        public string Name { get; set; }

        public Role()
        {
        }

        public int SaveRole(string name)
        {
            // save role to json
            return 0;
        }

        public IList<Role> GetAllRoles() {
            //get from json
            return new List<Role>();
        }
    }
}
