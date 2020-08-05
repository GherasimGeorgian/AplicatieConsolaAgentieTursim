using System;
using AplicatieConsolaAgentieTursim.Repository;
using AplicatieConsolaAgentieTursim.Model;
using System.Collections.Generic;
using System.Linq;
namespace AplicatieConsolaAgentieTursim.Service
{
    class Service
    {
      

        private IRepository<int, Oferta> offerRepository;
        private IRepository<int, User> userRepository;
        public Service(IRepository<int, Oferta> offerRepository, IRepository<int,User> userRepository)
        {
            this.offerRepository = offerRepository;
            this.userRepository = userRepository;
        }

        public IEnumerable<Oferta> FindAllOfferts()
        {
            return offerRepository.FindAll();
        }

        public Oferta FindOneOffer(int id)
        {
            return offerRepository.FindOne(id);
        }

        public Oferta DeleteOffert(Oferta s)
        {
            if (s.Equals(null)) throw new System.ArgumentException("Student does not exist!");
            return offerRepository.Delete(s);
        }

        public User Authenticate(string username, string password)
        {
            bool size = false;

            if (username == null || password == null)
            {
                throw new ArgumentException("username or password null");
            }

            foreach (User g in userRepository.FindAll())
            {
                size = true;
                if (g.Username == username && g.Password == password)
                    return g;
            }
            if (size == false) return null;
            return null;

          
        }

        public Oferta AddOffer(int id,int id_user,string tip, string destinatie, DateTime data_plecare, int pret)
        {
            Oferta off = new Oferta(id,id_user,tip, destinatie,data_plecare,pret);
            offerRepository.Save(off);
            return off;
        }

        public List<Oferta> FilterOffersByUser(int user)
        {
            return (
                from ofrs in FindAllOfferts()
                where ofrs.Iuser == user
                select ofrs
                ).ToList();
        }
    }
}