using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AplicatieConsolaAgentieTursim.Model
{
    class HolidayValidator : IValidator<Holiday>
    {
        public void Validate(Holiday holiday)
        {
                throw new System.ArgumentNullException("HolidayValidator ID cannot be null");
        }
    }
}
