using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TimKiem
{
    
    public class Timing
    {
        TimeSpan startingTime;
        TimeSpan duration;
        public Timing()
        {
            startingTime = new TimeSpan(0);
            duration = new TimeSpan(0);
        }
        public void StopTime()
        {
            duration =
            Process.GetCurrentProcess().Threads[0].
            UserProcessorTime.
            Subtract(startingTime);
        }
        public void startTime()
        {
            GC.Collect();
            GC.WaitForPendingFinalizers();
            startingTime =
            Process.GetCurrentProcess().Threads[0].
            UserProcessorTime;
        }
        public TimeSpan Result()
        {
            return duration;
        }
    }
    public class SinhVien
    {
        public int Id {  get; set; }
        public string HoTen { get; set; }
        public double DiemTB { get; set; }
        public SinhVien(int id, string hoten, double diemTB)
        {
            Id = id;
            HoTen = hoten;
            DiemTB= diemTB;
        }
    }
    public class Program
    {
        public static int TimKiem(List<SinhVien> sinhvien, int idcantim)
        {
            int i = 0;
            while (sinhvien[i].Id != idcantim)
                i++;
            return i;
        }
       
        public static void Main(string[] args)
        {
            Console.Clear();
            Timing timer = new Timing();
            int time = 0;
            timer.startTime();
            List<SinhVien> sinhViens = new List<SinhVien>() {
            new SinhVien(102, "Nguyen Thi A",8.0),
            new SinhVien(202,"Nguyen Thi B",6.0),
            new SinhVien(302,"Nguyen Van C",3.0),
            new SinhVien(402,"Nguyen Van D",2.0),
            new SinhVien(502,"Ho Thi C",3.5),
            new SinhVien(602,"Dang Van C",9.1)
            };

            int[] arr = new int[] { 3, 5, 6, 9, 12, 15 };
            /*Array arr = Array.CreateInstance(typeof(int), 4);
            arr.SetValue(3, 0); arr.SetValue(5, 1);
            arr.SetValue(6, 2); arr.SetValue(9, 3);*/
            Console.WriteLine("Vui long nhap id sinh vien: ");
            int idcantim = int.Parse(Console.ReadLine());
            int vitri = TimKiem(sinhViens, idcantim);                        
            Console.WriteLine($"Vi tri can tim: {vitri} \nva sinh vien la: {sinhViens[vitri].HoTen} co diem la {sinhViens[vitri].DiemTB}");
            timer.StopTime();
            time = timer.Result().Milliseconds;
            Console.WriteLine("Time: " + time);
            Console.ReadLine();
        }
    }
}
