using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AplicatieConsolaAgentieTursim.Model;

namespace AplicatieConsolaAgentieTursim.Repository
{
    class UserFileRepository : FileRepository<int, User>
    {
        public UserFileRepository(IValidator<User> validator, string fileName) : base(validator, fileName)
        {
        }

        public override User ExtractEntity(string line)
        {
            String[] attributes = line.Split('|');
            int id_user = int.Parse(attributes[0].Split(':')[1]);
            String username = attributes[1].Split(':')[1];
            String password = attributes[2].Split(':')[1];
           
            return new User(id_user, username, password);
        }
    }
}
