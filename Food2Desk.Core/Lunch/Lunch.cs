using Food2Desk.Shared.Interfaces.Lunch;

namespace Food2Desk.Core.Lunch
{
    public class Lunch : ILunchCore
    {
        private readonly ILunchDataAccess LunchDA;

        public Lunch(ILunchDataAccess lunchDA)
        {
            LunchDA = lunchDA;
        }

        public int List() {
            return 1;
        }
    }
}
