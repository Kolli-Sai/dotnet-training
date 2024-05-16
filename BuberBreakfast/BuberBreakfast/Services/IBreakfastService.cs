using BuberBreakfast.Models;

namespace BuberBreakfast.Services
{
    public interface IBreakfastService
    {
        void CreateBreakfast(Breakfast newBreakfast);

        Breakfast GetBreakfast(Guid id);

        List<Breakfast> GetBreakfasts();

        void UpdateBreakfast( Breakfast newBreakfast);
        void DeleteBreakfast(Guid id);
    }
}
