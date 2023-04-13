using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace INTEX2.Models
{
/*    public class EFMummyRepository : IMummyRepository
    {
        private RDSDbContext context { get; set; }
        public EFMummyRepository(RDSDbContext temp) => context = temp;
        public IQueryable<Mummy> Mummies => context.Mummies;

        
    }*/
    public class EFMummyRepository : IMummyRepository
    {
        private RDSDbContext context { get; set; }
        public EFMummyRepository(RDSDbContext temp) => context = temp;

        public IQueryable<Mummy> Mummies => context.Mummies;

        public Mummy GetMummyById(long mummyId)
        {
            return context.Mummies.FirstOrDefault(m => m.id == mummyId);
        }
        


        public void DeleteMummy(Mummy mummy)
        {
            context.Mummies.Remove(mummy);
            context.SaveChanges();
        }

        public void UpdateMummy(Mummy mummy)
        {
            context.Mummies.Update(mummy);
            context.SaveChanges();
        }
        public void AddMummy(Mummy mummy)
        {
            // Get the max id of the last mummy in the database
            long maxId = context.Mummies.DefaultIfEmpty().Max(m => m == null ? 0 : m.id);

            // Set the id of the new mummy to the max id + 1
            mummy.id = maxId + 1;

            context.Mummies.Add(mummy);
            context.SaveChanges();
        }

    }

}
