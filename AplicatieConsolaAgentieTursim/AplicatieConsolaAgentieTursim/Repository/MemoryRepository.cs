using System.Collections.Generic;
using AplicatieConsolaAgentieTursim.Model;

namespace AplicatieConsolaAgentieTursim.Repository
{
    class MemoryRepository<ID, E> : IRepository<ID, E> where E : IHasID<ID>
    {
        private List<E> entities = new List<E>();
        private IValidator<E> validator;

        public MemoryRepository(IValidator<E> validator)
        {
            this.validator = validator;
        }

        virtual public E Delete(E entity)
        {
            if (entity.Equals(null)) throw new System.ArgumentNullException("Entity cannot be null!");
            if (!entities.Contains(entity)) throw new System.ArgumentException("Entity does not exist!");
            entities.Remove(entity);
            return entity;
        }

        public IEnumerable<E> FindAll()
        {
            return entities;
        }

        public E FindOne(ID id)
        {
            if (id.Equals(null)) throw new System.ArgumentNullException("ID cannot be null!");
            E result = default(E);
            entities.ForEach(entity => { if (entity.ID.Equals(id)) result = entity; });
            return result;
        }

        virtual public E Save(E entity)
        {
            validator.Validate(entity);
            if (entities.Contains(FindOne(entity.ID))) throw new System.ArgumentException("Entity already exists!");
            entities.Add(entity);
            return default(E);
        }

        virtual public E Update(E entity)
        {
            validator.Validate(entity);
            E result = entity;
            if (!entities.Contains(FindOne(entity.ID))) throw new System.ArgumentException("Entity does not exist!");
            entities.Remove(FindOne(entity.ID));
            entities.Add(entity);
            return default(E);
        }
    }
}
