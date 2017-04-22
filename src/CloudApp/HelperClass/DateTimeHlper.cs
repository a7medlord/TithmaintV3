using System;

namespace CloudApp.HelperClass
{
    public class DateTimeHlper
    {
        private int[] _data;
        public string GetDateTimeRimnder(DateTime fromdb , DateTime currenTime)
        {
            //var mocking = new DateTime(1900,1,2,12, 00, 2);
            _data = SubstractDateTime(fromdb, currenTime);
            return GetAlphForHours(_data[0] , _data[1]);
        }

        int[] SubstractDateTime(DateTime fromdb, DateTime curentdate)
        {
            int newhoures = 0;
            int newminute = 0;

            if (curentdate.Day  <= fromdb.Day +1 && curentdate.Hour < fromdb.Hour || fromdb.Day == curentdate.Day)
            {
                int valhors = fromdb.Hour - curentdate.Hour ;
                if (valhors > 0)
                {
                    newhoures =  valhors;
                }
                else
                {
                    newhoures = valhors + 23;
                }
             
                int valminute = fromdb.Minute - curentdate.Minute;

                if (valminute > 0)
                {
                    newminute = valminute;
                }
                else
                {
                    newminute = valminute + 60;
                }

                return new[] { newhoures, newminute };
            }
            
            return new[] { newhoures, newminute };
        }
      
        string GetAlphForHours(int hours , int miute)
        {
            if (hours == 1 && miute ==0)
            {
                return $" تبقي ساعة واحدة فقط علي انتهاء زمن المعاملة";
            }

            if (hours == 1 && miute >0)
            {
                return $" تبقي ساعة و {miute} دقيقة علي انتهاء زمن المعاملة";
            }

            if (hours == 2 && miute ==0)
            {
                return $"تبقي ساعاتان فقط علي انتهاء زمن المعاملة";
            }

            if (hours == 2 && miute > 0)
            {
                return $" تبقي ساعاتان و {miute} دقيقة علي انتهاء زمن المعاملة";
            }

            if (hours >= 10 && miute ==0 )
            {
                return $"تبقي {hours} ساعة علي انتهاء المعاملة";
            }

            if (hours >= 10 && miute > 0)
            {
                return $"تبقي {hours} ساعة و {miute}  دقيقة علي انتهاء زمن المعاملة";
            }

            if (hours < 10 && hours > 0 && miute == 0)
            {
                return $"تبقي  {hours} ساعات علي انتهاء المعاملة";
            }

            if (hours < 10 && hours > 0 && miute > 0)
            {
                return $"تبقي  {hours} ساعات و  {miute} دقيقة علي انتهاء زمن العاملة";
            }

            if (hours == 0 || hours < 0)
            {
                return "انتهي الزمن المحدد لاكمال المعاملة";
            }
            return "غير محدد";
        }

        public int GetSatate()
        {
            if (_data[0] >= 16)
            {
                return 1;
            }
            if(_data[0] >= 8 && _data[0] <= 16)
            {
                return 2;
            }
            if (_data[0] < 8)
            {
                return 3;
            }
            return 5;
        }

        int ConvertToPostive(int value)
        {
            if (value > 0)
            {
                return value;
            }
            return value * -1;
        }
    }
}
