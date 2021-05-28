using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Booking.UI.Components
{
    public class PageListNav
    {
        public static string Nav01 =
@"        <nav>
            <ul>
               <li><a href=""/admin"">صفحه مدیریت اصلی</a></li>
                <li style=""border-style: none; background-color: transparent""><hr /></li>
                <li><a href=""/modules/bookingindex.aspx"">صفحه نخست</a></li>
                <li><a href=""/modules/bookinghostlist.aspx"">لیست میزبانان </a></li>
                <li><a href=""/modules/bookingaddhost.aspx"">ایجاد میزبان </a></li>
                <li><a href=""/modules/bookingeventlist.aspx"">لیست رویداد ها</a></li>
                <li><a href=""/modules/bookingaddevent.aspx"">ایجاد رویداد</a></li>
                <li><a href=""/modules/bookingreservelist.aspx"">لیست رزرو ها</a></li>
            </ul>
        </nav>";
        public static string Nav02 =
@"        <nav>
            <ul>
                <li><a href=""/modules/bookinghostlist.aspx"">لیست میزبانان </a></li>
                <li><a href=""/modules/bookingaddhost.aspx"">ایجاد میزبان </a></li>
                <li><a href=""/modules/bookingeventlist.aspx"">لیست رویداد ها</a></li>
                <li><a href=""/modules/bookingaddevent.aspx"">ایجاد رویداد</a></li>
            </ul>
        </nav>";

        public static string Nav03 =
@"        <nav>
            <ul>
                <li><a href=""/modules/bookinghostlist.aspx"">لیست میزبانان </a></li>
                <li><a href=""/modules/bookingaddhost.aspx"">ایجاد میزبان </a></li>
                <li><a href=""/modules/bookingeventlist.aspx"">لیست رویداد ها</a></li>
                <li><a href=""/modules/bookingaddevent.aspx"">ایجاد رویداد</a></li>
                <li><a href=""/modules/bookinggrouplist.aspx"">لیست گروه‌ها </a></li>
                <li><a href=""/modules/bookingaddgroup.aspx"">ایجاد گروه </a></li>
            </ul>
        </nav>";
    }
}
