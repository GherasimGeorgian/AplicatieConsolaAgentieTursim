namespace AplicatieConsolaAgentieTursim.Model
{
    interface IValidator<E>
    {
        void Validate(E entity);
    }
}
