using System;
using AplicatieConsolaAgentieTursim.Model;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AplicatieConsolaAgentieTursim.Repository
{
    abstract class FileRepository<ID, E> : MemoryRepository<ID, E> where E : IHasID<ID>
    {
        private String fileName;

        public FileRepository(IValidator<E> validator, String fileName) : base(validator)
        {
            this.fileName = fileName;
            LoadFile();
        }
        private void LoadFile()
        {
            using (StreamReader streamReader = new StreamReader(fileName))
            {
                String line;
                while ((line = streamReader.ReadLine()) != null)
                {
                    E entity = ExtractEntity(line);
                    base.Save(entity);
                }
            }
        }
        private void WriteFile()
        {
            using (StreamWriter streamWriter = new StreamWriter(fileName))
            {
                base.FindAll().ToList().ForEach(e => streamWriter.WriteLine(e.ToString()));
            }
        }
        public abstract E ExtractEntity(String line);
        public override E Delete(E entity)
        {
            E result = base.Delete(entity);
            WriteFile();
            return result;
        }

        public override E Save(E entity)
        {
            E result = base.Save(entity);
            WriteFile();
            return result;
        }

        public override E Update(E entity)
        {
            E result = base.Update(entity);
            WriteFile();
            return result;
        }
    }
}
