using System;

namespace CodingTest
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("系统时区：" + TimeZoneInfo.Local);
            Console.WriteLine("当前时区系统时间：" + DateTime.Now);
            Console.WriteLine("当前UTC系统时间：" + DateTime.UtcNow);
            Console.WriteLine("北京时间："+DateTime.UtcNow.AddHours(8));
            Console.WriteLine("北京日期："+DateTime.UtcNow.AddHours(8).Date);
            Console.WriteLine("北京当日0:00的UTC时间："+ DateTime.UtcNow.AddHours(8).Date.ToUniversalTime());
            Console.WriteLine("当日北京0:00的unix："+ DateTime.UtcNow.AddHours(8).Date.ToUniversalTime().ToUnix());

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
        /// <param name="dt">UTC时间</param>
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
