using System;
using AplicatieConsolaAgentieTursim.Model;

namespace AplicatieConsolaAgentieTursim.Repository
{
    class UserRepositoryMemory: MemoryRepository<int, User> 
    {
        public UserRepositoryMemory(IValidator<User> validator) : base(validator)
        {
            this.Save(new User(12, "admin", "admin"));
        }

       
    }
}