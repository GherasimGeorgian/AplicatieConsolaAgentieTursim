using System;
using AplicatieConsolaAgentieTursim.Service;
using AplicatieConsolaAgentieTursim.Model;
using AplicatieConsolaAgentieTursim.Repository;

namespace AplicatieConsolaAgentieTursim.UI

{

    class Console
    {
        private User currentUser;
        private Menu menu = new Menu("Aplicatie agentie turism\n");
        public Service.Service service;
        public Console(Service.Service service)
        {
            this.service = service;

            menu.AddCommand("1. Adaugare oferta", new AddOffer(service));
            menu.AddCommand("2. Afisare lista oferte", new ShowOfferts(service));
            menu.AddCommand("3. Stergere oferta", new DeleteOfferts(service));
            menu.AddCommand("4. Ofertele unui user", new FilterOffersByUser(service));

        }
        private static string Input(string prompt)
        {
            System.Console.Write(prompt);
            return System.Console.ReadLine();
        }
        public bool Login()
        {
            try
            {
                string username = Input("Username: ");
                string password = Input("Password: ");
                User user = service.Authenticate(username, password);
                if (user != null)
                {
                    currentUser = user;
                }
                return user != null;
            }
            catch (RepositoryException e)
            {
                System.Console.WriteLine(e.Message);
                return false;
            }
        }

        public class AddOffer : ICommand
        {
            private Service.Service service;
        
            public AddOffer(Service.Service service)
            {
                this.service = service;
                
            }

            public void Execute()
            {
                try
                {
                    System.Console.Write("ID:");
                    string id_z = System.Console.ReadLine();

                    System.Console.Write("ID-ul userului:");
                    string id_user = System.Console.ReadLine();
                    System.Console.Write("Tip:");
                    string tip = System.Console.ReadLine();
                    System.Console.Write("Destinatie:");
                    string destiantie = System.Console.ReadLine();


                    System.Console.Write("Data plecare:");
                    System.Console.Write("Introdu anul:");
                    string an = System.Console.ReadLine();
                    System.Console.Write("Introdu luna:");
                    string luna = System.Console.ReadLine();
                    System.Console.Write("Introdu ziua:");
                    string ziua = System.Console.ReadLine();
                    DateTime data_plecare = new DateTime(Int32.Parse(an), Int32.Parse(luna), Int32.Parse(ziua));

                    System.Console.Write("Pret:");
                    string pret = System.Console.ReadLine(); 

                    

                    try
                    {
                        
                        service.AddOffer(Int32.Parse(id_z), Int32.Parse(id_user),tip, destiantie, data_plecare, Int32.Parse(pret));
                        System.Console.WriteLine("Adaugare reusita!");
                    }
                    catch (ValidationException ex)
                    {
                        System.Console.WriteLine("Validation failed " + ex.Message);
                    }
                    catch (RepositoryException ex)
                    {
                        System.Console.WriteLine("Unable to persist data " + ex.Message);
                    }
                }
                catch
                {
                    System.Console.WriteLine("Date invalide!");
                }
                System.Console.WriteLine();
            }
        }
        public class ShowOfferts : ICommand
        {
            private Service.Service service;

            public ShowOfferts(Service.Service service)
            {
                this.service = service;
            }

            public void Execute()
            {
                foreach (Oferta s in service.FindAllOfferts())
                {
                    System.Console.WriteLine(s.ToString());
                }
                System.Console.WriteLine();
            }
        }

        public class DeleteOfferts : ICommand
        {
            private Service.Service service;

            public DeleteOfferts(Service.Service service)
            {
                this.service = service;
            }

            public void Execute()
            {
                System.Console.Write("Dati ID-ul ofertei: ");
                int id = int.Parse(System.Console.ReadLine());
                try
                {
                    service.DeleteOffert(service.FindOneOffer(id));
                    System.Console.WriteLine("Oferta sters cu succes!");
                }
                catch (Exception e)
                {
                    System.Console.WriteLine("Stergere esuata! " + e.Message);
                }
                System.Console.WriteLine();
            }
        }

        public class FilterOffersByUser : ICommand
        {
            private Service.Service service;

            public FilterOffersByUser(Service.Service service)
            {
                this.service = service;
            }

            public void Execute()
            {
                System.Console.Write("Dati ID-ul userului: ");
                int user = int.Parse(System.Console.ReadLine());
                service.FilterOffersByUser(user).ForEach(e => System.Console.WriteLine(e.ToString()));
                System.Console.WriteLine();
            }
        }
        public void RunMenu()
        {
            System.Console.WriteLine(menu.GetName());
            menu.Execute();

            while (true)
            {
                System.Console.Write("Dati comanda: ");
                try
                {
                    int command = int.Parse(System.Console.ReadLine());
                    if (command > 0 && command <= menu.GetCommands().Count)
                    {
                        ICommand selectedCommand = menu.GetCommands()[command - 1].Value;
                        selectedCommand.Execute();
                    }
                    else
                    {
                        throw new Exception();
                    }
                }
                catch
                {
                    System.Console.WriteLine("Invalid option!");
                    System.Console.WriteLine();
                }
            }
        }
    }

   
}