using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SessionStatistics.Classes
{
    public class Statistic
    {
        public DateTime JoinTime { get; set; }
        public Int32 JoinExperience { get; set; }
        public Int32 Kills { get; set; }
        public Int32 Rares { get; set; }

        public Int32 Uniques { get; set; }
        public Int32 Experience { get; set; }

        public Statistic()
        {
            JoinTime = DateTime.Now;
            JoinExperience = (Int32)SessionStatisticsCore.API.GameController.Player.GetComponent<PoeHUD.Poe.Components.Player>().XP;
                  
        }

        
        public String GetValuePerHour(Int32 Value)
        {
            if(Value == 0)
            {
                return "0/h";
            }
            TimeSpan _seconds = DateTime.Now - JoinTime;
            Decimal _PerHour = Decimal.Divide(Value, (Decimal)_seconds.TotalHours);
            if (_PerHour > 999999)
            {
                return _PerHour.ToString("#,,M/h", System.Globalization.CultureInfo.InvariantCulture);
            }
            if (_PerHour > 999)
            {
                return _PerHour.ToString("#,K/h", System.Globalization.CultureInfo.InvariantCulture);
            }
            return _PerHour.ToString("#/h", System.Globalization.CultureInfo.InvariantCulture);
        }
        public Double GainedExp()
        {
            return Player.Exp - JoinExperience;
        }

        public String GetPlaytime()
        {
            TimeSpan _diff = DateTime.Now - JoinTime;
            return String.Format("{0:hh\\:mm\\:ss}", _diff);
        }
        public String GetExpPerHour()
        {
            TimeSpan _seconds = DateTime.Now - JoinTime;
            Decimal _PerHour = Decimal.Divide(Experience, (Decimal)_seconds.TotalHours);
            if (_PerHour > 999999)
            {
                return _PerHour.ToString("#,,M/h", System.Globalization.CultureInfo.InvariantCulture);
            }
            if (_PerHour > 999)
            {
                return _PerHour.ToString("#,K/h", System.Globalization.CultureInfo.InvariantCulture);
            }
            return _PerHour.ToString("#/h", System.Globalization.CultureInfo.InvariantCulture);
        }
    }
}
