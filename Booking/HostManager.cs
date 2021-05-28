using System;
using System.Linq;
using System.Collections.Generic;
//using Rubik_SDK;
using Booking.Models;
using Booking.Utilities.Enums;
using Microsoft.EntityFrameworkCore;
using NetTopologySuite.Geometries;

namespace Booking
{
    public class HostManager
    {
        private DataContext db;

        public Host GetHost(int id)
        {
            try
            {
                using (db = new DataContext())
                {
                    return db.Hosts.Where(h => h.Id == id).FirstOrDefault();
                }
            }
            catch(Exception ex)
            {
                //General.WriteInLogFile("Booking HostManager-Exception: " + ex.Message +
                //        "<br> Booking HostManager-BaseException: " + ex.GetBaseException().ToString() +
                //        "<br> Booking HostManager-WholeException: " + ex.ToString());
                return null;
            }
        }

        public List<Host> GetHosts()
        {
            try
            {
                using (db = new DataContext())
                {
                    return db.Hosts.Where(h => h.IsDeleted == false).ToList<Host>();
                }
            }
            catch(Exception ex)
            {
                //General.WriteInLogFile("Booking HostManager-Exception: " + ex.Message +
                //        "<br> Booking HostManager-BaseException: " + ex.GetBaseException().ToString() +
                //        "<br> Booking HostManager-WholeException: " + ex.ToString());
                return null;
            }
        }

        public List<Host> GetHosts(int regionId)
        {
            try
            {
                using (db = new DataContext())
                {
                    return db.Hosts.Where(h => h.IsDeleted == false && h.RegionId == regionId).ToList<Host>();
                }
            }
            catch (Exception ex)
            {
                //General.WriteInLogFile("Booking HostManager-Exception: " + ex.Message +
                //        "<br> Booking HostManager-BaseException: " + ex.GetBaseException().ToString() +
                //        "<br> Booking HostManager-WholeException: " + ex.ToString());
                return null;
            }
        }

        public Result CreateHost(Host newHost)
        {
            try
            {
                using (db = new DataContext())
                {
                    db.Hosts.Add(newHost);
                    db.SaveChanges();
                }
                return Result.Success;
            }
            catch (Exception ex)
            {
                //General.WriteInLogFile("Booking HostManager-Exception: " + ex.Message +
                //        "<br> Booking HostManager-BaseException: " + ex.GetBaseException().ToString() +
                //        "<br> Booking HostManager-WholeException: " + ex.ToString());
                return Result.Failure;
            }
        }

        public Result CreateHost(string name, string address, string phoneNumber)
        {
            return CreateHost(name, address, "", null, "", phoneNumber);
        }

        public Result CreateHost(string name, string address, string locationLink, Point location, string postalCode, string phoneNumber)
        {
            return CreateHost(new Host()
            {
                Name = name,
                Address = address,
                Location = location,
                PostalCode = postalCode,
                PhoneNumber = phoneNumber
            });
        }

        public Result EditHost(Host newEvent)
        {
            try
            {
                using (db = new DataContext())
                {
                    db.Entry(newEvent).State = EntityState.Modified;
                    db.SaveChanges();
                }
                return Result.Success;
            }
            catch (Exception ex)
            {
                //General.WriteInLogFile("Booking HostManager-Exception: " + ex.Message +
                //        "<br> Booking HostManager-BaseException: " + ex.GetBaseException().ToString() +
                //        "<br> Booking HostManager-WholeException: " + ex.ToString());
                return Result.Failure;
            }
        }

        public Result EditHost(int id, int regionId, string name, string address, string phoneNumber)
        {
            return EditHost(id, regionId, name, address, null, "", phoneNumber);
        }

        public Result EditHost(int id, int regionId, string name, string address, Point location, string postalCode, string phoneNumber)
        {
            return EditHost(new Host()
            {
                Id = id,
                RegionId = regionId,
                Name = name,
                Address = address,
                //Location = location,
                PostalCode = postalCode,
                PhoneNumber = phoneNumber
            });
        }

        public Result DeleteHost(Host oldHost)
        {
            try
            {
                using (db = new DataContext())
                {
                    db.Hosts.Attach(oldHost);
                    oldHost.IsDeleted = true;
                    db.SaveChanges();
                }
                return Result.Success;
            }
            catch(Exception ex)
            {
                //General.WriteInLogFile("Booking HostManager-Exception: " + ex.Message +
                //        "<br> Booking HostManager-BaseException: " + ex.GetBaseException().ToString() +
                //        "<br> Booking HostManager-WholeException: " + ex.ToString());
                return Result.Failure;
            }
        }

        public Result DeleteHost(int id)
        {
            using (db = new DataContext())
            {
                return DeleteHost(db.Hosts.Find(id));
            }
        }
    }
}