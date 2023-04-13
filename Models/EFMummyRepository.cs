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
    }

}
