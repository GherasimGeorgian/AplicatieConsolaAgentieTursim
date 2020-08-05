namespace AplicatieConsolaAgentieTursim.Model
{
    class OfferValidator : IValidator<Oferta>
    {
        public void Validate(Oferta offert)
        {
         

            if (offert.Tip.Equals(null) || offert.Destinatie.Equals(null) || offert.Pret.Equals(null) || offert.Data_placare.Equals(null))
            {
                    throw new System.ArgumentNullException("Homework ID cannot be null");
            }

          
        }
    }
}
