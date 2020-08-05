using System.Collections.Generic;

namespace AplicatieConsolaAgentieTursim.Repository
{
    interface IRepository<ID, E>
    {
        E FindOne(ID id);
        IEnumerable<E> FindAll();
        E Save(E entity);
        E Delete(E entity);
        E Update(E entity);
    }
}
