namespace ParkViewServices.Helpers
{
    public static class DateCalculator
    {
        public static int CalculateNightsBetweenDates(DateTime startDate, DateTime endDate)
        {
            if (startDate > endDate)
            {
                throw new ArgumentException("startDate cannot be greater than endDate.");
            }
            TimeSpan timeSpan = endDate - startDate;
            int nights = (int)Math.Ceiling(timeSpan.TotalDays);

            return nights;
        }

    }
}
