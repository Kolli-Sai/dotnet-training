
using BuberBreakfast.Models;

namespace BuberBreakfast.Services
{
    public class BreakfastService : IBreakfastService
    {
        List<Breakfast> breakfasts = new List<Breakfast>();

        public void CreateBreakfast(Breakfast newBreakfast)
        {
            breakfasts.Add(newBreakfast);
        }

        public void DeleteBreakfast(Guid id)
        {
            for (int i = 0; i < breakfasts.Count; i++)
            {
                if (breakfasts[i].Id == id)
                {
                    breakfasts.RemoveAt(i);
                break;
                }
            }
        }

        public Breakfast GetBreakfast(Guid id)
        {
            Breakfast breakfast = null;
            foreach (Breakfast b in breakfasts)
            {
                if (b.Id == id)
                {
                    breakfast = b;
                    break;
                }
            }

            return breakfast;
        }

        public List<Breakfast> GetBreakfasts()
        {
            return breakfasts;
        }

        public void UpdateBreakfast( Breakfast newBreakfast)
        {
            for (int i = 0; i < breakfasts.Count; i++)
            {
                if (breakfasts[i].Id == newBreakfast.Id)
                {
                    breakfasts[i] = newBreakfast;

                break;
                }
            }
        }
    }
}
