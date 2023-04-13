using System.Linq;

namespace INTEX2.Models
{
    public interface IMummyRepository
    {
        IQueryable<Mummy> Mummies { get;}

        Mummy GetMummyById(long id);

        void DeleteMummy(Mummy mummy);
        void UpdateMummy(Mummy mummy);
        // void AddMummy(Mummy mummy);
    }
}
