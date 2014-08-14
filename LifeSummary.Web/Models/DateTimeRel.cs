using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Web;

namespace LifeSummary
{
    public static class TimeSpanExtensions
    {
        public static string RelativeDate2(DateTime theDate)
        {
            if (theDate == DateTime.MinValue)
                return "";
            Dictionary<long, string> thresholds = new Dictionary<long, string>();
            int minute = 60;
            int hour = 60 * minute;
            int day = 24 * hour;
            thresholds.Add(60, "{0} saniye önce");
            thresholds.Add(minute * 2, "1 dk önce");
            thresholds.Add(45 * minute, "{0} dakika önce");
            thresholds.Add(120 * minute, "1 saat önce");
            thresholds.Add(day, "{0} gün önce");
            thresholds.Add(day * 2, "dün");
            thresholds.Add(day * 30, "{0} gün önce");
            thresholds.Add(day * 365, "{0} ay önce");
            thresholds.Add(long.MaxValue, "{0} yıl önce");

            long since = (DateTime.Now.Ticks - theDate.Ticks) / 10000000;
            foreach (long threshold in thresholds.Keys)
            {
                if (since < threshold)
                {
                    TimeSpan t = new TimeSpan((DateTime.Now.Ticks - theDate.Ticks));
                    return string.Format(thresholds[threshold], (t.Days > 365 ? t.Days / 365 : (t.Days > 0 ? t.Days : (t.Hours > 0 ? t.Hours : (t.Minutes > 0 ? t.Minutes : (t.Seconds > 0 ? t.Seconds : 0))))).ToString());
                }
            }
            return "";
        }
        public static string RelativeDate(DateTime theDate)
        {
            if (theDate == DateTime.MinValue)
                return "";
            else
                return (DateTime.Now - theDate).ToHumanString();
        }
        static readonly Formatter formatter = new Formatter();

        public static string ToHumanString(this TimeSpan timeSpan)
        {
            return formatter.Format(timeSpan);
        }
    }
    internal class Formatter
    {
        readonly IDictionary<TimeSpan, Func<TimeSpan, string>> thresholds = new Dictionary<TimeSpan, Func<TimeSpan, string>>
        {
            {
                TimeSpan.FromSeconds(0),
                t => "şimdi"
            },
            {
                TimeSpan.FromSeconds(30),
                t => "30 saniye önce"
            },
            {
                TimeSpan.FromMinutes(1),
                t => "bir dakika önce"
            },
            {
                TimeSpan.FromMinutes(1.5),
                t => string.Format("{0} dakika önce", Math.Round(t.TotalMinutes, 0))
            },
            {
                TimeSpan.FromMinutes(50),
                t => "yaklaşık bir saat önce"
            },
            {
                TimeSpan.FromHours(1.5),
                t => string.Format("{0} saat önce", Math.Round(t.TotalHours, 0))
            },
            {
                TimeSpan.FromHours(20),
                t => "dün"
            },
            {
                TimeSpan.FromDays(1.5),
                t => string.Format("{0} gün önce", Math.Round(t.TotalDays, 0))
            },
            {
                TimeSpan.FromDays(6),
                t => "geçen hafta"
            },
            {
                TimeSpan.FromDays(13),
                t => string.Format("{0} hafta önce", Math.Round(t.TotalDays / 7, 0))
            },
            {
                TimeSpan.FromDays(30),
                t => "yaklaşık bir ay önce"
            },
            {
                TimeSpan.FromDays(60),
                t => string.Format("{0} ay önce", Math.Round(t.TotalDays / 30, 0))
            },
            {
                TimeSpan.FromDays(345),
                t => "yaklaşık bir yıl önce"
            },
            {
                TimeSpan.FromDays(547.5),
                t => string.Format("{0} yıl önce", Math.Round(t.TotalDays / 365, 0))
            }
        };

        public string Format(TimeSpan timeSpan)
        {
            var threshold = thresholds
                .Keys
                .OfType<TimeSpan?>()
                .OrderBy(t => t)
                .Where(t => timeSpan >= t)
                .LastOrDefault() ?? TimeSpan.MaxValue;

            var formatCallback = thresholds[threshold];

            return formatCallback(timeSpan);
        }
    }
}