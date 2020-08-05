using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AplicatieConsolaAgentieTursim.Model;

namespace AplicatieConsolaAgentieTursim.Model
{
    class Holiday : IHasID<int>
    {
        private string description;

        public int ID { get; set; }
        public string Description { get => description; set => description = value; }
        
        public Holiday(int id, string description)
        {
            ID = id;
            Description = description;
            
        }

        public override string ToString()
        {
            return "id:" + ID + "|" +
                "description:" + Description;
        }
    }
}
