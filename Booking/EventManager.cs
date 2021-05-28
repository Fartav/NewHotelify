using System;
using System.Linq;
using System.Collections.Generic;
//using Rubik_SDK;
using Booking.Models;
using Booking.Utilities.Enums;
using Microsoft.EntityFrameworkCore;

namespace Booking
{
    public class EventManager
    {
        private DataContext db;

        #region CRUD
        #region Create
        // Main create function which handles exception
        public Result CreateEvent(Event newEvent)
        {
            try
            {
                using (db = new DataContext())
                {
                    db.Hosts.Attach(newEvent.EventHost);
                    db.Events.Add(newEvent);
                    db.SaveChanges();
                    return Result.Success;
                }
            }
            catch (Exception ex)
            {
                //General.WriteInLogFile("Booking EventManager-Exception: " + ex.Message +
                //        "<br> Booking EventManager-BaseException: " + ex.GetBaseException().ToString() +
                //        "<br> Booking EventManager-WholeException: " + ex.ToString());
                return Result.Failure;
            }
        }

        public Result CreateEvent(Host host, int startTime, int endTime, List<ClosedDates> closeDates)
        {
            return CreateEvent(host, startTime, endTime, closeDates, "event" + DateTime.Now.Ticks, 0);
        }

        public Result CreateEvent(Host host, int startDate, int endDate, List<ClosedDates> closeDates, string title, int capacity)
        {
            return CreateEvent(new Event()
            {
                Title = title,
                EventHost = host,
                Capacity = capacity,
                StartTime = startDate,
                EndTime = endDate,
                EventClosedDates = closeDates
            });
        }
        #endregion

        #region Edit
        // Main edit function that handles exception
        public Result EditEvent(Event newEvent)
        {
            try
            {
                using (db = new DataContext())
                {
                    db.Entry(newEvent).State = EntityState.Modified;
                    db.Hosts.Attach(newEvent.EventHost);
                    db.SaveChanges();
                }
                return Result.Success;
            }
            catch (Exception ex)
            {
                //General.WriteInLogFile("Booking EventManager-Exception: " + ex.Message +
                //        "<br> Booking EventManager-BaseException: " + ex.GetBaseException().ToString() +
                //        "<br> Booking EventManager-WholeException: " + ex.ToString());
                return Result.Failure;
            }
        }

        public Result EditEvent(int id, Host host, int startTime, int endTime, List<ClosedDates> closeDates)
        {
            return EditEvent(id, host, startTime, endTime, closeDates, "event" + DateTime.Now.Ticks, 0);
        }

        public Result EditEvent(int id, Host host, int startTime, int endTime, List<ClosedDates> closeDates, string title, int capacity)
        {
            return CreateEvent(new Event()
            {
                Id = id,
                Title = title,
                EventHost = host,
                Capacity = capacity,
                StartTime = startTime,
                EndTime = endTime,
                EventClosedDates = closeDates
            });
        }
        #endregion

        #region Delete
        // Main remove funcion that handles exception
        public Result DeleteEvent(Event oldEvent)
        {
            try
            {
                using (db = new DataContext())
                {
                    db.Events.Attach(oldEvent);
                    oldEvent.IsDeleted = true;
                    db.SaveChanges();
                }
                return Result.Success;
            }
            catch (Exception ex)
            {
                //General.WriteInLogFile("Booking EventManager-Exception: " + ex.Message +
                //        "<br> Booking EventManager-BaseException: " + ex.GetBaseException().ToString() +
                //        "<br> Booking EventManager-WholeException: " + ex.ToString());
                return Result.Failure;
            }
        }

        public Result DeleteEvent(int id)
        {
            using (db = new DataContext())
            {
                return DeleteEvent(db.Events.Find(id));
            }
        }
        #endregion
        #endregion

        public Event GetEvent(int id)
        {
            try
            {
                using (db = new DataContext())
                {
                    return db.Events.Include(e => e.EventHost).Where(e => e.Id == id).FirstOrDefault();
                }
            }
            catch (Exception ex)
            {
                //General.WriteInLogFile("Booking EventManager-Exception: " + ex.Message +
                //        "<br> Booking EventManager-BaseException: " + ex.GetBaseException().ToString() +
                //        "<br> Booking EventManager-WholeException: " + ex.ToString());
                return null;
            }
        }

        public List<Event> GetEvents(int regionID = 0)
        {
            try
            {
                using (db = new DataContext())
                {
                    return db.Events.Include(e => e.EventHost).Where(e => e.IsDeleted == false && e.EventHost.RegionId == regionID).ToList<Event>();
                }
            }
            catch (Exception ex)
            {
                //General.WriteInLogFile("Booking EventManager-Exception: " + ex.Message +
                //    "<br> Booking EventManager-BaseException: " + ex.GetBaseException().ToString() +
                //    "<br> Booking EventManager-WholeException: " + ex.ToString());
                return null;
            }
        }

        public List<Event> GetEventsContainsShift(int regionID = 0)
        {
            try
            {
                using (db = new DataContext())
                {
                    return db.Events.Include(e => e.EventHost).AsEnumerable()
                        .Where(e => e.IsDeleted == false 
                            && e.EventHost.RegionId == regionID 
                            && GetAvailableDates(e.Id).Count > 0).ToList<Event>();
                }
            }
            catch (Exception ex)
            {
                //General.WriteInLogFile("Booking EventManager-Exception: " + ex.Message +
                //    "<br> Booking EventManager-BaseException: " + ex.GetBaseException().ToString() +
                //    "<br> Booking EventManager-WholeException: " + ex.ToString());
                return null;
            }
        }

        public List<ClosedDates> GetClosedDates(int id)
        {
            try
            {
                using (db = new DataContext())
                {
                    return db.ClosedDates.Include(c => c.Event).Where(c => c.Event.Id == id && c.IsDeleted == false).ToList<ClosedDates>();
                }
            }
            catch (Exception ex)
            {
                //General.WriteInLogFile("Booking EventManager-Exception: " + ex.Message +
                //        "<br> Booking EventManager-BaseException: " + ex.GetBaseException().ToString() +
                //        "<br> Booking EventManager-WholeException: " + ex.ToString());
                return null;
            }
        }

        public Result AddClosedDates(Event currentEvent, DateTime startDate, DateTime endDate, DateType type)
        {
            try
            {
                ClosedDates date = new ClosedDates()
                {
                    Event = currentEvent,
                    StartDate = startDate,
                    EndDate = endDate,
                    Type = type
                };
                using (db = new DataContext())
                {
                    db.Events.Attach(currentEvent);
                    db.ClosedDates.Add(date);
                    db.SaveChanges();
                }
                return Result.Success;
            }
            catch (Exception ex)
            {
                //General.WriteInLogFile("Booking EventManager-Exception: " + ex.Message +
                //        "<br> Booking EventManager-BaseException: " + ex.GetBaseException().ToString() +
                //        "<br> Booking EventManager-WholeException: " + ex.ToString());
                return Result.Failure;
            }
        }

        public Result AddClosedDates(int id, DateTime startDate, DateTime endDate, DateType type)
        {
            using (db = new DataContext())
            {
                return AddClosedDates(db.Events.Find(id), startDate, endDate, type);
            }
        }

        public Result RemoveClosedDate()
        {
            try
            {
                using (db = new DataContext())
                {
                    List<ClosedDates> dates = db.ClosedDates.ToList<ClosedDates>();
                    foreach (ClosedDates date in dates)
                    {
                        db.ClosedDates.Remove(date);
                    }
                    db.SaveChanges();
                }
                return Result.Success;
            }
            catch (Exception ex)
            {
                //General.WriteInLogFile("Booking EventManager-Exception: " + ex.Message +
                //        "<br> Booking EventManager-BaseException: " + ex.GetBaseException().ToString() +
                //        "<br> Booking EventManager-WholeException: " + ex.ToString());
                return Result.Failure;
            }
        }

        public Result RemoveClosedDate(int id)
        {
            try
            {
                using (db = new DataContext())
                {
                    ClosedDates date = db.ClosedDates.Find(id);
                    db.ClosedDates.Remove(date);
                    db.SaveChanges();
                }
                return Result.Success;
            }
            catch (Exception ex)
            {
                //General.WriteInLogFile("Booking EventManager-Exception: " + ex.Message +
                //        "<br> Booking EventManager-BaseException: " + ex.GetBaseException().ToString() +
                //        "<br> Booking EventManager-WholeException: " + ex.ToString());
                return Result.Failure;
            }
        }

        public List<AvailableDates> GetAvailableDates(int eventId)
        {
            try
            {
                using (db = new DataContext())
                {
                    return db.AvailableDates.Include(ad => ad.Event).Where(ad => ad.Event.Id == eventId && ad.IsDeleted == false).ToList<AvailableDates>();
                }
            }
            catch (Exception ex)
            {
                //General.WriteInLogFile("Booking EventManager-Exception: " + ex.Message +
                //        "<br> Booking EventManager-WholeException: " + ex.ToString());
                return null;
            }
        }

        public List<AvailableDates> GetAvailableDatesOnly(int eventId)
        {
            try
            {
                using (db = new DataContext())
                {
                    return db.AvailableDates.Include(ad => ad.Event).Where(ad => ad.Event.Id == eventId && ad.IsDeleted == false).ToList<AvailableDates>();
                }
            }
            catch (Exception ex)
            {
                //General.WriteInLogFile("Booking EventManager-Exception: " + ex.Message +
                //        "<br> Booking EventManager-BaseException: " + ex.GetBaseException().ToString() +
                //        "<br> Booking EventManager-WholeException: " + ex.ToString());
                return null;
            }
        }

        public AvailableDates GetAvailableDate(int id)
        {
            try
            {
                using (db = new DataContext())
                {
                    return db.AvailableDates.Include(ad => ad.Event).Where(ad => ad.Id == id).FirstOrDefault();
                }
            }
            catch (Exception ex)
            {
                //General.WriteInLogFile("Booking EventManager-Exception: " + ex.Message +
                //        "<br> Booking EventManager-BaseException: " + ex.GetBaseException().ToString() +
                //        "<br> Booking EventManager-WholeException: " + ex.ToString());
                return null;
            }
        }

        public AvailableDates GetAvailableDateOnly(int id)
        {
            try
            {
                using (db = new DataContext())
                {
                    return db.AvailableDates.Where(ad => ad.Id == id).FirstOrDefault();
                }
            }
            catch (Exception ex)
            {
                //General.WriteInLogFile("Booking EventManager-Exception: " + ex.Message +
                //        "<br> Booking EventManager-WholeException: " + ex.ToString());
                return null;
            }
        }

        public Result AddAvailableDate(AvailableDates date)
        {
            try
            {
                using (db = new DataContext())
                {
                    db.Events.Attach(date.Event);
                    if (date.ReserveDateStart.Hour < date.Event.StartTime || date.ReserveDateEnd.Hour > date.Event.EndTime)
                        return Result.Halt;
                    db.AvailableDates.Add(date);
                    db.SaveChanges();
                }
                return Result.Success;
            }
            catch (Exception ex)
            {
                //General.WriteInLogFile("Booking EventManager-Exception: " + ex.Message +
                //        "<br> Booking EventManager-BaseException: " + ex.GetBaseException().ToString() +
                //        "<br> Booking EventManager-WholeException: " + ex.ToString());
                return Result.Failure;
            }
        }

        //public Result RemoveAvailableDate(int id)
        //{
        //    try
        //    {
        //        using (db = new DataContext())
        //        {
        //            AvailableDates date = db.AvailableDates.Find(id);
        //            db.AvailableDates.Attach(date);
        //            db.AvailableDates.Remove(date);
        //            db.SaveChanges();
        //        }
        //        return Result.Success;
        //    }
        //    catch (Exception ex)
        //    {
        //        General.WriteInLogFile("Booking EventManager-Exception: " + ex.Message +
        //                "<br> Booking EventManager-BaseException: " + ex.GetBaseException().ToString() +
        //                "<br> Booking EventManager-WholeException: " + ex.ToString());
        //        return Result.Failure;
        //    }
        //}

        public Result RemoveAvailableDate(int id)
        {
            return RemoveAvailableDate(GetAvailableDateOnly(id));
        }

        public Result RemoveAvailableDate(AvailableDates availableDates)
        {
            Result result = Result.Failure;
            try
            {
                using (db = new DataContext())
                {
                    db.AvailableDates.Attach(availableDates);
                    db.AvailableDates.Remove(availableDates);
                    if (db.SaveChanges() > 0)
                        result = Result.Success;
                }
            }
            catch (Exception ex)
            {
                result = Result.Failure;
                //General.WriteInLogFile("Booking EventManager-Exception: " + ex.Message +
                //        "<br> Booking EventManager-WholeException: " + ex.ToString());
            }
            return Result.Success;
        }

        public Result RemoveAllAvailableDateByEventID(int eventID)
        {
            Result result = Result.Success;
            try
            {
                foreach (var availaleDate in GetAvailableDatesOnly(eventID))
                {
                    if (RemoveAvailableDate(availaleDate.Id) != Result.Success)
                        result = Result.Failure;
                }
            }
            catch (Exception ex)
            {
                result = Result.Failure;
                //General.WriteInLogFile("Booking EventManager-RemoveAllAvailableDateByEventID-Exception: " + ex.Message +
                //        "<br> Booking EventManager-RemoveAllAvailableDateByEventID-BaseException: " + ex.GetBaseException().ToString() +
                //        "<br> Booking EventManager-RemoveAllAvailableDateByEventID-WholeException: " + ex.ToString());
            }
            return result;
        }

        public int GetRemainedCapacityByDate(AvailableDates date, DateTime reserveDateStart, DateTime reserveDateEnd)
        {
            int remainedCapacity = date.Event.Capacity;
            try
            {
                using (db = new DataContext())
                {
                    var selectedAvailableDate = db.AvailableDates.Where(x => x.ReserveDateStart == date.ReserveDateStart && x.ReserveDateEnd == date.ReserveDateEnd && x.Event.Id == date.Event.Id).FirstOrDefault();

                    var joinEventWithReserves = from t1 in db.Events
                                                join t2 in db.ReservedDates on t1.Id equals t2.Event.Id
                                                where t2.ReserveDateStart >= reserveDateStart && t2.ReserveDateEnd <= reserveDateEnd
                                                    && t1.IsDeleted == false && t2.IsDeleted == false && t1.Id == selectedAvailableDate.Event.Id
                                                    && t2.IsCanceled == 0 
                                                select new
                                                {
                                                    events = t1,
                                                    reservedDate = t2
                                                };
                    if (joinEventWithReserves != null && joinEventWithReserves.Count() > 0)
                        if (joinEventWithReserves.FirstOrDefault().events != null && joinEventWithReserves.FirstOrDefault().reservedDate != null)
                            remainedCapacity = joinEventWithReserves.FirstOrDefault().events.Capacity - (joinEventWithReserves.Sum(r => (int?)r.reservedDate.Count) ?? 0);
                }
            }
            catch (Exception ex)
            {
                remainedCapacity = date.Event.Capacity;
                //General.WriteInLogFile("Booking EventManager-GetRemainedCapacityByAvailableDate-Exception: " + ex.Message +
                //        "<br> Booking EventManage-GetRemainedCapacityByAvailableDater-WholeException: " + ex.ToString());
            }
            return remainedCapacity;
        }

        public AvailableDates GetRelatedAvailableDateByReservedDate(ReservedDates reservedDate)
        {
            AvailableDates availableDates = null;
            try
            {
                using (db = new DataContext())
                {

                    var joinEventWithReservesAndDates = from t1 in db.Events
                                                join t2 in db.ReservedDates on t1.Id equals t2.Event.Id
                                                join t3 in db.AvailableDates on t1.Id equals t3.Event.Id
                                                where t2.Id == reservedDate.Id
                                                    && t2.ReserveDateStart.Hour == t3.ReserveDateStart.Hour && t2.ReserveDateStart.Minute == t3.ReserveDateStart.Minute
                                                    && t2.ReserveDateEnd.Hour == t3.ReserveDateEnd.Hour && t2.ReserveDateEnd.Minute == t3.ReserveDateEnd.Minute
                                                    && t1.IsDeleted == false && t2.IsDeleted == false && t3.IsDeleted == false // && t2.IsCanceled == 0
                                                select new
                                                {
                                                    events = t1,
                                                    reservedDate = t2,
                                                    availableDate = t3,
                                                };
                    if (joinEventWithReservesAndDates != null && joinEventWithReservesAndDates.Count() > 0)
                        availableDates = joinEventWithReservesAndDates.FirstOrDefault().availableDate;
                }
            }
            catch (Exception ex)
            {
                availableDates = null;
                //General.WriteInLogFile("Booking-EventManager-GetRemainedCapacityByAvailableDate-Exception: " + ex.Message +
                //        "<br> Booking-EventManager-GetRemainedCapacityByAvailableDater-WholeException: " + ex.ToString());
            }
            return availableDates;
        }

        public static int GetTimingCase(int eventID)
        {
            int timeCase = 0;
            Event reserveEvent = new EventManager().GetEvent(eventID);
            try
            {
                if (reserveEvent.Type == EventType.Auto && reserveEvent.WorkingShifts <= 1 && reserveEvent.WorkingTimes <= 1)
                    timeCase = 1;
                else if (reserveEvent.Type == EventType.Auto && reserveEvent.WorkingShifts > 1 && reserveEvent.WorkingTimes <= 1)
                    timeCase = 2;
                else if (reserveEvent.Type == EventType.Auto && reserveEvent.WorkingShifts > 1 && reserveEvent.WorkingTimes > 1)
                    timeCase = 3;
                else if (reserveEvent.Type == EventType.Manual)
                    timeCase = 4;
                else if (reserveEvent.Type != EventType.Custom)
                    timeCase = 5;
            }
            catch (Exception ex)
            {
                timeCase = -1;
                //General.WriteInLogFile("Booking-EventManager-TimingCase-Exception: " + ex.Message +
                //        "<br> Booking-EventManager-TimingCase-Exception: " + ex.ToString());
            }
            return timeCase;
        }

        public static string GetTimingCaseToPersianString(int eventID)
        {
            string timeCasePersianName = "اولیه";
            try
            {
                switch (GetTimingCase(eventID))
                {
                    case -1:
                        timeCasePersianName = "بدون نوع";
                        break;
                    case 0:
                        timeCasePersianName = "اولیه";
                        break;
                    case 1:
                        timeCasePersianName = "روزانه";
                        break;
                    case 2:
                        timeCasePersianName = "شیفتی";
                        break;
                    case 3:
                        timeCasePersianName = "ساعتی";
                        break;
                    case 4:
                        timeCasePersianName = "شیفت دستی";
                        break;
                    case 5:
                        timeCasePersianName = "آزاد";
                        break;
                    default:
                        timeCasePersianName = "نوع دیگر";
                        break;
                }
            }
            catch (Exception ex)
            {
                timeCasePersianName = "حالت دیگر";
                //General.WriteInLogFile("Booking-EventManager-GetTimingCaseToPersianString-Exception: " + ex.Message +
                //        "<br> Booking-EventManage-GetTimingCaseToPersianString-WholeException: " + ex.ToString());
            }
            return timeCasePersianName;
        }

        public int CalculateCapacityForEachPieceOfTime(DateTime dateOfSelectedDay, AvailableDates dateOfHourAndMinute)
        {
            int remainedCapacity = 0;
            try
            {
                DateTime reserveDateStart = new DateTime(dateOfSelectedDay.Year, dateOfSelectedDay.Month, dateOfSelectedDay.Day,
                    dateOfHourAndMinute.ReserveDateStart.Hour, dateOfHourAndMinute.ReserveDateStart.Minute, 0);
                DateTime reserveDateEnd = new DateTime(dateOfSelectedDay.Year, dateOfSelectedDay.Month, dateOfSelectedDay.Day,
                    dateOfHourAndMinute.ReserveDateEnd.Hour, dateOfHourAndMinute.ReserveDateEnd.Minute, 0);
                remainedCapacity = GetRemainedCapacityByDate(dateOfHourAndMinute, reserveDateStart, reserveDateEnd);
            }
            catch (Exception ex)
            {
                remainedCapacity = 0;
                //General.WriteInLogFile("Booking-EventManager-CalculateCapacityForEveryPieceOfTime-Exception: " + ex.Message +
                //    "<br>Booking-EventManager-CalculateCapacityForEveryPieceOfTime-WholeException: " + ex.ToString());
            }
            return remainedCapacity;
        }
    }
}
