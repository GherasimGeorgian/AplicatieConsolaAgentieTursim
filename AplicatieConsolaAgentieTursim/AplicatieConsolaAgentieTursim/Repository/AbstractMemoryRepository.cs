namespace AplicatieConsolaAgentieTursim.Repository
{
    public class AbstractMemoryRepository
    {
        protected object[] entities = new object[100];
        protected int count = 0;
    }
}