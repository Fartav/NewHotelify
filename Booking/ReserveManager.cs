using System;
using System.Linq;
using System.Collections.Generic;
//using Rubik_SDK;
using Booking.Models;
using Booking.Utilities.Enums;
using Microsoft.EntityFrameworkCore;

namespace Booking
{
    public class ReserveManager
    {
        private DataContext db;
        private int minutes;// It's useless now

        public ReserveManager()
        {
            CheckForExpiredReserves();
        }
        public ReserveManager(int m = 15)
        {
            minutes = m;
        }

        public List<ReservedDates> GetReserves()
        {
            try
            {
                using (db = new DataContext())
                {
                    //CheckForExpiredReserves();
                    //List<ReservedDates> reserves = db.ReservedDates.Include(r => r.Event)
                    //        .Where(r => r.IsDeleted == false && r.IsCanceled == 0).ToList<ReservedDates>();
                    return db.ReservedDates.Include(r => r.Event).Where(r => r.IsDeleted == false).ToList<ReservedDates>();
                }
            }
            catch (Exception ex)
            {
                //General.WriteInLogFile("Booking ReserveManager-Exception: " + ex.Message +
                //        "<br> Booking ReserveManager-BaseException: " + ex.GetBaseException().ToString() +
                //        "<br> Booking ReserveManager-WholeException: " + ex.ToString());
                return null;
            }
        }

        public ReservedDates GetReserve(int id)
        {
            try
            {
                ReservedDates result;
                using (db = new DataContext())
                {
                    return db.ReservedDates.Include(r => r.Event).Where(r => r.Id == id).FirstOrDefault();
                }
            }
            catch (Exception ex)
            {
                //General.WriteInLogFile("Booking ReserveManager-Exception: " + ex.Message +
                //        "<br> Booking ReserveManager-BaseException: " + ex.GetBaseException().ToString() +
                //        "<br> Booking ReserveManager-WholeException: " + ex.ToString());
                return null;
            }
        }

        public ReservedDates GetReserveIfNotExpired(int id)
        {
            ReservedDates result;
            try
            {
                using (db = new DataContext())
                {
                    var theReserve = GetReserve(id);
                    DateTime d = (DateTime)theReserve.CreateDate;
                    if (d.AddMinutes(theReserve.Event.TemporaryReserve) < DateTime.Now)
                        result = null;
                    else
                        result = theReserve;
                }
            }
            catch (Exception ex)
            {
                result = null;
                //General.WriteInLogFile("Booking ReserveManager-GetReserveIfNotExpired-Exception: " + ex.Message +
                //        "<br> Booking ReserveManager-GetReserveIfNotExpired-BaseException: " + ex.GetBaseException().ToString() +
                //        "<br> Booking ReserveManager-GetReserveIfNotExpired-WholeException: " + ex.ToString());
            }
            return result;
        }

        public ReservedDates GetReserveOnly(int id)
        {
            try
            {
                ReservedDates result;
                using (db = new DataContext())
                {
                    return db.ReservedDates.Where(r => r.Id == id).FirstOrDefault();
                }
            }
            catch (Exception ex)
            {
                //General.WriteInLogFile("Booking ReserveManager-Exception: " + ex.Message +
                //        "<br> Booking ReserveManager-BaseException: " + ex.GetBaseException().ToString() +
                //        "<br> Booking ReserveManager-WholeException: " + ex.ToString());
                return null;
            }
        }

        public List<ReservedDates> GetReservesByEventID(int eventID)
        {
            try
            {
                using (db = new DataContext())
                {
                    return db.ReservedDates.Include(r => r.Event).Where(r => r.Event.Id == eventID && r.IsDeleted == false).ToList<ReservedDates>();
                }
            }
            catch (Exception ex)
            {
                //General.WriteInLogFile("Booking ReserveManager-GetReservesByEventID-Exception: " + ex.Message +
                //        "<br> Booking ReserveManager-GetReservesByEventID-BaseException: " + ex.GetBaseException().ToString() +
                //        "<br> Booking ReserveManager-GetReservesByEventID-WholeException: " + ex.ToString());
                return null;
            }
        }

        public int NewReserve(ReservedDates date)
        {
            try
            {
                using (db = new DataContext())
                {
                    if (date.ReserveDateStartTicks == null)
                    {
                        date.ReserveDateStartTicks = date.ReserveDateStart.Ticks;
                    }
                    if (date.ReserveDateEndTicks == null)
                    {
                        date.ReserveDateEndTicks = date.ReserveDateEnd.Ticks;
                    }
                    db.ReservedDates.Attach(date);
                    db.ReservedDates.Add(date);
                    db.SaveChanges();
                    return date.Id;
                }
            }
            catch (Exception ex)
            {
                //General.WriteInLogFile("Booking ReserveManager-Exception: " + ex.Message +
                //        "<br> Booking ReserveManager-BaseException: " + ex.GetBaseException().ToString() +
                //        "<br> Booking ReserveManager-WholeException: " + ex.ToString());
                return -1;
            }
        }

        public int NewReserve(Event ev, DateTime startDate, DateTime endDate, int count, DateType type)
        {
            return NewReserve(new ReservedDates()
            {
                Event = ev,
                ReserveDateStart = startDate,
                ReserveDateEnd = endDate,
                ReserveDateStartTicks = startDate.Ticks,
                ReserveDateEndTicks = endDate.Ticks,
                Count = count,
                Type = type
            });
        }

        public Result FinalizeReserve(int id)
        {
            using (db = new DataContext())
            {
                return FinalizeReserve(db.ReservedDates.Where(r => r.Id == id && r.IsDeleted == false).FirstOrDefault());
            }
        }

        public Result FinalizeReserve(ReservedDates reserve)
        {
            try
            {
                using (db = new DataContext())
                {
                    db.ReservedDates.Attach(reserve);
                    reserve.IsFinal = 1;
                    reserve.IsCanceled = 0;
                    db.SaveChanges();
                    return Result.Success;
                }
            }
            catch (Exception ex)
            {
                //General.WriteInLogFile("Booking ReserveManager-Exception: " + ex.Message +
                //        "<br> Booking ReserveManager-BaseException: " + ex.GetBaseException().ToString() +
                //        "<br> Booking ReserveManager-WholeException: " + ex.ToString());
                return Result.Failure;
            }
        }

        public Result CancelReserve(int id)
        {
            using (db = new DataContext())
            {
                return CancelReserve(GetReserveOnly(id));
            }
        }

        public Result CancelDeletedReserve(int id)
        {
            using (db = new DataContext())
            {
                return CancelReserve(db.ReservedDates.Where(r => r.Id == id && r.IsDeleted == true).FirstOrDefault());
            }
        }

        public Result CancelNotDeletedReserve(int id)
        {
            using (db = new DataContext())
            {
                return CancelReserve(db.ReservedDates.Where(r => r.Id == id && r.IsDeleted == false).FirstOrDefault());
            }
        }

        public Result CancelReserve(ReservedDates reserve)
        {
            Result result = Result.Failure;
            try
            {
                using (db = new DataContext())
                {
                    //db.ReservedDates.Attach(reserve);
                    //ReservedDates reserveToCancel = db.ReservedDates.Find(reserve.Id);
                    db.ReservedDates.Attach(reserve);
                    reserve.IsFinal = 0;
                    reserve.IsCanceled = 1;
                    //db.SaveChanges();
                    //return Result.Success;
                    if (db.SaveChanges() > 0)
                        result = Result.Success;
                    if (db.ChangeTracker.HasChanges() == false)
                        result = Result.Success;
                }
            }
            catch (Exception ex)
            {
                result = Result.Failure;
                //General.WriteInLogFile("Booking ReserveManager-Exception: " + ex.Message +
                //        "<br> Booking ReserveManager-WholeException: " + ex.ToString());
            }
            return result;
        }

        public Result CancelAndRemoveReserve(ReservedDates reserve)
        {
            try
            {
                using (db = new DataContext())
                {
                    ReservedDates reserveToChange = db.ReservedDates.Find(reserve.Id);
                    reserveToChange.IsFinal = 0;
                    reserveToChange.IsCanceled = 1;
                    reserveToChange.IsDeleted = true;
                    db.SaveChanges();
                    return Result.Success;
                }
            }
            catch (Exception ex)
            {
                //General.WriteInLogFile("Booking ReserveManager-CancelAndRemoveReserve-Exception: " + ex.Message +
                //        "<br> Booking ReserveManager-CancelAndRemoveReserve-BaseException: " + ex.GetBaseException().ToString() +
                //        "<br> Booking ReserveManager-CancelAndRemoveReserve-WholeException: " + ex.ToString());
                return Result.Failure;
            }
        }

        public Result CancelAndRemoveReservesByEventID(int eventID)
        {
            Result result = Result.Success;
            try
            {
                foreach (var item in GetReservesByEventID(eventID))
                {
                    if (CancelAndRemoveReserve(GetReserve(item.Id)) != Result.Success)
                        result = Result.Failure;
                }
            }
            catch (Exception ex)
            {
                result = Result.Failure;
                //General.WriteInLogFile("Booking ReserveManager-CancelAndRemoveReservesByEventID-Exception: " + ex.Message +
                //        "<br> Booking ReserveManager-CancelAndRemoveReservesByEventID-BaseException: " + ex.GetBaseException().ToString() +
                //        "<br> Booking ReserveManager-CancelAndRemoveReservesByEventID-WholeException: " + ex.ToString());
            }
            return result;
        }

        public Result CheckForExpiredReserves()
        {
            try
            {
                using (db = new DataContext())
                {
                    //List<ReservedDates> reserves = GetReserves();
                    //foreach (ReservedDates r in reserves)
                    //{
                    //    DateTime d = (DateTime)r.CreateDate;
                    //    if(d.AddMinutes(minutes) < DateTime.Now)
                    //    {
                    //        CancelReserve(r);
                    //    }
                    //}
                    //db.ReservedDates.Where(x => DbFunctions.AddMinutes(x.CreateDate.Value, minutes) < DateTime.Now
                    //        && x.IsDeleted == false && x.IsCanceled == 0 && x.IsFinal == 0).ToList().ForEach(x => x.IsCanceled = 1);

                    // Comented by Sharif @202010311430
                    // TODO: EF currently does not support dbfunctions so this linq query must be replaced with a raw sql query
                    //db.ReservedDates.Include(ev => ev.Event).Where(x => DbFunctions.AddMinutes(x.CreateDate.Value, x.Event.TemporaryReserve) < DateTime.Now
                    //        && x.IsDeleted == false && x.IsCanceled == 0 && x.IsFinal == 0).ToList().ForEach(x => x.IsCanceled = 1);
                    //db.SaveChanges();
                    return Result.Success;
                }
            }
            catch (Exception ex)
            {
                //General.WriteInLogFile("Booking ReserveManager-Exception: " + ex.Message +
                //        "<br> Booking ReserveManager-BaseException: " + ex.GetBaseException().ToString() +
                //        "<br> Booking ReserveManager-WholeException: " + ex.ToString());
                return Result.Failure;
            }
        }

        public Result CheckForExpiredReserve(ReservedDates reserve)
        {
            try
            {
                using (db = new DataContext())
                {
                    DateTime d = (DateTime)reserve.CreateDate;
                    //if (d.AddMinutes(minutes) < DateTime.Now)
                    if (d.AddMinutes(reserve.Event.TemporaryReserve) < DateTime.Now)
                    {
                        CancelReserve(reserve);
                        return Result.Halt;
                    }
                    return Result.Success;
                }
            }
            catch (Exception ex)
            {
                //General.WriteInLogFile("Booking ReserveManager-Exception: " + ex.Message +
                //        "<br> Booking ReserveManager-BaseException: " + ex.GetBaseException().ToString() +
                //        "<br> Booking ReserveManager-WholeException: " + ex.ToString());
                return Result.Failure;
            }
        }

        public Result CheckForExpiredReserve(int id)
        {
            try
            {
                using (db = new DataContext())
                {
                    return CheckForExpiredReserve(db.ReservedDates.Include(ev => ev.Event).Where(r => r.Id == id && r.IsCanceled == 0 && r.IsFinal==0).FirstOrDefault());
                }
            }
            catch (Exception ex)
            {
                //General.WriteInLogFile("Booking ReserveManager-Exception: " + ex.Message +
                //        "<br> Booking ReserveManager-BaseException: " + ex.GetBaseException().ToString() +
                //        "<br> Booking ReserveManager-WholeException: " + ex.ToString());
                return Result.Failure;
            }
        }

        public Result RemoveReserve(int id)
        {
            return RemoveReserve(GetReserveOnly(id));
        }

        public Result RemoveReserve(ReservedDates reserve)
        {
            Result result = Result.Failure;
            try
            {
                using (db = new DataContext())
                {
                    db.ReservedDates.Attach(reserve);
                    db.ReservedDates.Remove(reserve);
                    if (db.SaveChanges() > 0)
                        result = Result.Success;
                    if (db.ChangeTracker.HasChanges() == false)
                        result = Result.Success;
                }
            }
            catch (Exception ex)
            {
                result = Result.Failure;
                //General.WriteInLogFile("Booking RemoveReserve-Exception: " + ex.Message +
                //        "<br> Booking RemoveReserve-BaseException: " + ex.GetBaseException().ToString() +
                //        "<br> Booking RemoveReserve-WholeException: " + ex.ToString());
            }
            return result;
        }
    }
}
