using System.Linq;

namespace INTEX2.Models
{
    public interface IMummyRepository
    {
        IQueryable<Mummy> Mummies { get; }
    }
}
