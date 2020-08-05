using System;
using System.Runtime.InteropServices;

namespace AplicatieConsolaAgentieTursim.Model
{
    class Oferta : IHasID<int>
    {
        private int iuser;
        private string tip;
        private string destinatie;
        private DateTime data_plecare;
        private int pret;
       


        public Oferta(int ID,int user,string tip, string destinatie, DateTime data_plecare, int pret)
        {
            this.ID = ID;
            this.iuser = user;
            this.tip = tip;
            this.destinatie = destinatie;
            this.data_plecare = data_plecare;
            this.pret = pret;
         
        }

        public Oferta( int user, string tip, string destinatie, DateTime data_plecare, int pret)
        {
          
            this.iuser = user;
            this.tip = tip;
            this.destinatie = destinatie;
            this.data_plecare = data_plecare;
            this.pret = pret;

        }


        public int ID { get; set; }

         public int Iuser { get { return iuser; } set { iuser = value; } }

        public string Destinatie { get { return destinatie; } set { destinatie = value; } }

        public string Tip { get { return tip; } set { tip = value; } }

        public DateTime Data_placare { get { return data_plecare; } set { data_plecare = value; } }

        public int Pret { get { return pret; } set { pret = value; } }


       

        public override string ToString()
        {
            return "---->" + ID + "<----" + " " + tip + " " + destinatie + " " + data_plecare.ToString() + " " + pret.ToString();
        }
    }
}