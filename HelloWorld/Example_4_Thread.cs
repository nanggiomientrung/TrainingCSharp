using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace HelloWorld
{
    class Example_4_Thread
    {
        public static void FirstThreadExample()
        {
            // ApartmentState: STA = Single-threaded, MTA = Multi-threaded
            Console.WriteLine("Da luong trong C#");
            Console.WriteLine("Vi du minh hoa Main Thread");
            Console.WriteLine("-----------------------------------");
            Thread th = Thread.CurrentThread; // lay thread dang chay
            th.Name = "MainThread";
            //th.CurrentCulture = System.Globalization.CultureInfo.GetCultures(System.Globalization.CultureTypes.AllCultures)[0];
            Console.WriteLine("Day la {0}", th.Name);

            Console.ReadKey();
        }

        //==========================================================================================================
        public static void CreateAThread()
        {
            Console.WriteLine("Da luong trong C#");
            Console.WriteLine("Vi du minh hoa cach tao Thread");
            Console.WriteLine("----------------------------------");
            ThreadStart childref = new ThreadStart(CallAChildThread);
            Console.WriteLine("Trong Main Thread: tao thread con.");
            Thread childThread = new Thread(childref);
            childThread.Start();
            Console.WriteLine("Da start thread con.");


            Console.ReadKey();

            if (childThread.IsAlive) Console.WriteLine("Thread van dang chay");
            else Console.WriteLine("Thread da ket thuc");

            Console.ReadKey();
        }

        public static void CallAChildThread()
        {
            Console.WriteLine("Bat dau thread con");

            int sleepTime = 5000;

            Console.WriteLine("Thread con sleep trong vong {0}", sleepTime / 1000 + " giay");
            Thread.Sleep(sleepTime); // thread sleep trong 5 giây
            Console.WriteLine("Bat dau chay lai thread con");

        }

        //===========================================================================================================

        public static void AbortAThread()
        {
            Console.WriteLine("Da luong trong C#");
            Console.WriteLine("Vi du minh hoa huy Thread");
            Console.WriteLine("-------------------------------------");

            ThreadStart childref = new ThreadStart(CallAChildThreadWithTryCatch);
            Console.WriteLine("Trong Main Thread: tao Thread con.");
            Thread childThread = new Thread(childref);
            childThread.Start();

            //dừng main thread trong 2000 mili giây
            Thread.Sleep(2000);

            //bây giờ hủy thread con
            Console.WriteLine("Trong Main Thread: huy Thread con.");

            childThread.Abort();
            Console.ReadKey();
        }

        public static void CallAChildThreadWithTryCatch()
        {
            try
            {
                Console.WriteLine("Bat dau thread con");

                for (int i = 0; i < 10; i++)
                {
                    Thread.Sleep(500);
                    Console.WriteLine("Vong lap dang dem: " + i);
                }

                Console.WriteLine("Hoan thanh thread con");
            }
            catch (ThreadAbortException e)
            {
                Console.WriteLine("Co exception xay ra khi dang chay thread con");
                Console.WriteLine("Exception infor: " + e.Message);
            }
        }

        // ==============================================================

        public static void ParallelThread()
        {
            Console.WriteLine("Create new Thread...\n");

            // Tạo ra một Thread con, để chạy song song với Thread chính (main thread).
            Thread newThread = new Thread(WriteB);

            Console.WriteLine("Start newThread...\n");

            // Kích hoạt chạy newThread.
            newThread.Start();

            Console.WriteLine("Call Write('-') in main Thread...\n");

            // Trong Thread chính ghi ra các ký tự '-'
            for (int i = 0; i < 50; i++)
            {
                Console.Write('-');

                // Ngủ (sleep) 70 mili giây.
                Thread.Sleep(70);
            }


            Console.WriteLine("Main Thread finished!\n");
            Console.Read();
        }

        public static void WriteB()
        {
            // Vòng lặp 100 lần ghi ra ký tự 'B'
            for (int i = 0; i < 100; i++)
            {
                Console.Write('B');

                // Ngủ 100 mili giây
                Thread.Sleep(100);
            }
        }

        // ===========================================================================

        public static void ThreadWithParameter()
        {
            Console.WriteLine("Create new thread.. \n");

            // Tạo một đối tượng Thread bao lấy (wrap) phương thức tĩnh MyWork.DoWork
            Thread workThread = new Thread(ChildThreadWithParameter);

            Console.WriteLine("Start workThread...\n");

            // Chạy workThread,
            // và truyền vào tham số cho phương thức MyWork.DoWork.
            workThread.Start("A");


            for (int i = 0; i < 20; i++)
            {
                Console.Write("a");

                // Ngủ 30 giây.
                Thread.Sleep(30);
            }

            Console.WriteLine("MainThread ends");
            Console.Read();
        }

        public static void ChildThreadWithParameter(object paramString)
        {
            for (int i = 0; i < 100; i++)
            {
                Console.Write(paramString);
                Thread.Sleep(50);
            }
        }

        // =================================================================================

        public static void ThreadWithJoin()
        {
            Console.WriteLine("Create new thread");

            Thread countThread = new Thread(CountToTen);

            // Bắt đầu Thread (start thread).
            countThread.Start();

            // Nói với thread cha (ở đây sẽ là Main thread)
            // hãy chờ cho countThread hoàn thành rồi mới tiếp tục chạy.
            countThread.Join();

            // Dòng code này phải chờ cho countThread hoàn thành, rồi mới được chạy.
            Console.WriteLine("Main thread ends");
            Console.Read();
        }

        public static void CountToTen()
        {
            for (int i = 0; i < 10; i++)
            {
                Console.WriteLine("Count to: " + (i + 1));
            }
        }

        // ==================================================================================

        public static void ThreadWithLock()
        {
            Example_4_Thread ex4 = new Example_4_Thread();
            Thread t1 = new Thread(new ThreadStart(ex4.PrintToTen));
            Thread t2 = new Thread(new ThreadStart(ex4.PrintToTen));
            t1.Name = "Thread 1";
            t2.Name = "Thread 2";
            t1.Start();
            t2.Start();

            Console.ReadKey();
        }

        public void PrintToTen()
        {
            lock (this) // từ khóa Lock
            {
                for (int i = 1; i <= 10; i++)
                {
                    Thread.Sleep(500);
                    Console.WriteLine(i + " " + Thread.CurrentThread.Name);
                }
            }
        }
    }
}
