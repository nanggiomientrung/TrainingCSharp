using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HelloWorld
{
    class Example_3
    {
        static int ten = 10;
        static int maxIntValue = 2147483647;

        public static void CheckedExample()
        {
            // Checked expression.
            Console.WriteLine(checked(maxIntValue + ten));

            // Checked block.
            checked
            {
                int i3 = maxIntValue + ten;
                Console.WriteLine(i3);
            }

            Console.WriteLine(maxIntValue + ten);
            Console.ReadKey();
        }

        public static void UncheckedExample()
        {
            // Unchecked expression.
            Console.WriteLine(unchecked(maxIntValue + ten));

            // Unchecked block.
            unchecked
            {
                int i3 = maxIntValue + ten;
                Console.WriteLine(i3);
            }

            Console.WriteLine(maxIntValue + ten);
            Console.ReadKey();
        }


        public static int TryCatchWithChecked()
        {
            int z = 0;
            try
            {
                // dòng sau sẽ sinh ra exception nếu nó được dùng Checked
                z = checked(maxIntValue + 10);
            }
            catch (System.OverflowException e)
            {
                // Dòng sau sẽ in ra thông tin về lỗi
                Console.WriteLine("CHECKED and CAUGHT:  " + e.ToString());
                Console.ReadLine();
            }
            // giá trị của z vẫn là 0 (vì bị exception luôn ở lúc tính toán => tính toán ko thành công
            return z;
        }


        public static void DebugExample()
        {
            int testVariable = 0;

            testVariable = 15 + 2;
            testVariable = 30 / 7;
            testVariable = 45 - 5;

            Console.WriteLine(testVariable);
            Console.ReadKey();
        }

        public static void AdvanceDebugExample()
        {
            int sum = 0;
            for(int i=0;i<1000;i++)
            {
                sum += i;
                Console.WriteLine("dang duyet phan tu thu: " + i);
            }

            Console.ReadKey();
        }
    }
}
