using System.Linq;

namespace INTEX2.Models
{
    public class EFMummyRepository : IMummyRepository
    {
        private RDSDbContext context { get; set; }
        public EFMummyRepository(RDSDbContext temp) => context = temp;
        public IQueryable<Mummy> Mummies => context.Mummies;

        
    }

}
