using System;
using AplicatieConsolaAgentieTursim.Model;

namespace AplicatieConsolaAgentieTursim.Repository
{

    class OffersRepositoryMemory : MemoryRepository<int, Oferta> 
    {
       
        public OffersRepositoryMemory(IValidator<Oferta> validator) : base(validator)
        {
            this.Save(new Oferta(1,12,"munte", "ArabiaSaudi", new DateTime(2015, 12, 25), 300));
            this.Save(new Oferta(2,12,"mare", "BlackSea", new DateTime(2019, 12, 25), 4000));

        }
        
       

       
    }
}