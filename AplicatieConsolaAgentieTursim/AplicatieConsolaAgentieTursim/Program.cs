using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AplicatieConsolaAgentieTursim.Service;
using AplicatieConsolaAgentieTursim.Repository;
using AplicatieConsolaAgentieTursim.Model;

namespace AplicatieConsolaAgentieTursim
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                
                IRepository<int, Oferta> repoOffers = new OffersRepositoryMemory(new OfferValidator());
                IRepository<int, User> repoUser = new UserFileRepository(new UserValidator(), "C:/Users/Geo/source/repos/AplicatieConsolaAgentieTursim/AplicatieConsolaAgentieTursim/Repository/User.txt");
                Service.Service service = new Service.Service(repoOffers, repoUser);

                UI.Console console = new UI.Console(service);

                 bool authenticated = console.Login();
                  if (authenticated)
                  {
                   console.RunMenu();
                  }
                  else
                  {
                Console.WriteLine("Login failed...");
                }
               
                Console.ReadLine();
            }
            catch (Exception ex)
            {
                Console.WriteLine("Unexpected exception " + ex.Message);
                Console.ReadKey();
            }
        }
    }
}
