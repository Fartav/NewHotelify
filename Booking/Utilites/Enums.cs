namespace Booking.Utilities.Enums
{
    public enum DateType
    {
        Hour,
        Day,
        Week,
        Month,
        Year,
        DayOfWeeKOverMonth,
        DayOfWeeKOverMonths,
        NthDayOfWeeKOverMonth,
        NthDayOfWeeKOverMonths,
        MonthOverYears,
        MonthsOverYears,
        DayOfWeeKOverMonthOverYears,
        DayOfWeeKOverMonthsOverYears,
        NthDayOfWeeKOverMonthOverYears,
        NthDayOfWeeKOverMonthsOverYears,
        DayOfWeeKOverYear,
        DayOfWeeKOverYears,
        DayOfWeeKOverCalendar,
        MonthOverCalendar
    };
    public enum Result
    {
        Success,
        Failure,
        Duplicate,
        Halt
    };
    public enum EventType
    {
        Auto,
        Manual,
        Custom
    }

    public enum MultiMediaTypes
    {
        Image,
        Video,
        Gif
    }

}
