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
        static int zero = 0;

        public static void CheckedExample()
        {
            //Console.WriteLine(ten/zero);


            // Checked expression.
            Console.WriteLine(checked(maxIntValue + ten));

            // Checked block.
            checked
            {
                int i3 = maxIntValue + ten;
                Console.WriteLine(i3);
            }

            //Console.WriteLine(maxIntValue + ten);
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

        static int result, num1, num2;
        
        public static void TryCatchExample()
        {
            num1 = 10;
            num2 = 2;
            try
            {
                result = num1 / num2;
            }
            catch (DivideByZeroException e)
            {
                Console.WriteLine("Bat Exception: {0}", e);
            }
            finally
            {
                Console.WriteLine("Ket qua: {0}", result);
            }
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


        public static void GetInputFromKeyBoard()
        {
            string inputString;
            int inputNumber = 0;

            Console.WriteLine("Nhap vao 1 so nguyen bat ky");
            inputString = Console.ReadLine();
            try
            {
                inputNumber = int.Parse(inputString);
                Console.WriteLine("So nguyen ban vua nhap vao la: " + inputNumber);
            }
            catch
            {
                Console.WriteLine("Day khong phai la 1 so nguyen");
            }
            //finally
            //{
            //    Console.WriteLine("So nguyen ban vua nhap vao la: " + inputNumber);
            //}
            
            Console.ReadKey();
        }

        public static void GetInputFromKeyboardTillValidValue()
        {
            string inputString;
            int inputNumber = 0;
            bool isValidInput = false;

            do
            {
                Console.WriteLine("Nhap vao 1 so nguyen bat ky");
                inputString = Console.ReadLine();
                try
                {
                    inputNumber = int.Parse(inputString);
                    isValidInput = true;
                    Console.WriteLine("So nguyen ban vua nhap vao la: " + inputNumber);
                    
                }
                catch
                {
                    Console.WriteLine("Day khong phai la 1 so nguyen");
                    Console.WriteLine("");
                }

                Console.ReadKey();
            }
            while (isValidInput == false);
        }
    }
}
