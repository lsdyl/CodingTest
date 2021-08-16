using System;

namespace CodingTest
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("当前系统时间"+DateTime.Now);
            Console.WriteLine("当前UTC系统时间" + DateTime.UtcNow);
            Console.WriteLine(DateTime.Now.ToUniversalTime());
            var unix = (DateTime.Now.ToUniversalTime().Ticks - 621355968000000000) / 10000000;
            Console.WriteLine("当前UNIX"+unix);

            var currentUnix =
                DateTime.UtcNow.AddHours(8).Date.ToUnix(); //服务器时间为Utc时间，先加8小时为北京时间的日期，再设置为0：00，再减8小时变成北京时间0:00的unix
            Console.WriteLine("当前北京日期：" + currentUnix);
            
            Console.WriteLine("当前时区日期："+ (currentUnix ?? 0).ToDateTime());

            Console.WriteLine("主函数接收参数如下：");
            for (int i = 0; i < args.Length; i++)
            {
                Console.Write($"参数{i}：");
                Console.WriteLine(args[i]);
            }
        }
        
    }
    static class MyClass
    {
        /// <summary>
        ///     返回当前时区DateTime类的unix
        ///     如果DateTime未赋值，则返回空
        ///     Unix时间戳：是指格林威治时间1970年01月01日00时00分00秒(北京时间1970年01月01日08时00分00秒)起至现在的总秒数。
        /// </summary>
        /// <param name="dt">DateTime</param>
        /// <returns>unix</returns>
        public static long? ToUnix(this DateTime dt)
        {
            return dt == new DateTime(0001, 01, 01)
                ? new long?()
                : (long)(dt - TimeZoneInfo.ConvertTimeFromUtc(new DateTime(1970, 1, 1), TimeZoneInfo.Local))
                .TotalSeconds;
        }

        /// <summary>
        ///     将unix转换为当前时区时间
        /// </summary>
        /// <param name="unix"></param>
        /// <returns>本地时间</returns>
        public static DateTime? ToDateTime(this long unix)
        {
            return unix == 0
                ? new DateTime?() :
                TimeZoneInfo.ConvertTimeFromUtc(new DateTime(1970, 1, 1), TimeZoneInfo.Local).AddSeconds(unix);
        }
    }
}
