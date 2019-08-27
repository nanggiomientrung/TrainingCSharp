using System;
using System.Collections.Generic;

namespace HelloWorld
{
    class Example_2
    {
        // hiển thị các phép toán cho số
        public static void ViDu1()
        {
            Console.WriteLine("1. Tổng cua 2 so 5 va 3 la: " + Sum(5,3));
            Console.WriteLine("2. Hieu cua 2 so 5 va 3 la: " + Sub(5, 3));
            Console.WriteLine("3. Tich cua 2 so 5 va 3 la: " + Multi(5, 3));
            Console.WriteLine("4. Thương cua 2 so 5 va 3 la: " + Divide(5, 3));
            Console.WriteLine("5. Số dư cua 2 so 5 va 3 la: " + Mod(5, 3));
            Console.WriteLine("6. Lũy thừa cua 2 so 5 va 3 la: " + Exponential(5, 3));
            Console.WriteLine("7. Phép và cua 2 so 5 va 3 la: " + AndInt(5, 3)); // 5 = 101, 3 = 11 => 2 số và với nhau kết quả sẽ là 1

            Console.ReadKey();
        }


        // hiển thị các phép toán cho string
        public static void ViDu2()
        {
            string s1 = "utring s1";
            string s2 = "string s2";
            string s3 = string.Concat(s1, s2);
            Console.WriteLine("1. Ghep 2 chuoi s1, s2: " + s3); // string s1string s2
            Console.WriteLine("2. so sanh 2 chuoi s1, s2: " + string.Compare(s1, s2)); // < 0
            Console.WriteLine("3. Vi tri dau tien cua ky tu s trong s2: " + s2.IndexOf('a')); // 0
            Console.WriteLine("4. Vi tri cuoi cung cua ky tu s trong s2: " + s2.LastIndexOf('s')); // 7
            Console.WriteLine(string.Format("5. Hom nay co {0} ban di hoc", 20)); //Hom nay co {0} ban di hoc
            Console.ReadKey();
        }


        // các ví dụ cho danh sách và vòng lặp
        // tạo một List danh sách tên sinh viên và in ra
        public static void ViDu3()
        {
            List<string> studentList = new List<string>() { "Trang", "Hoang", "Ha" };
            studentList.Add("Nam");
            studentList.Add("Tung");

            // Bỏ comment 3 dòng sau để test sự khác biệt
            //studentList.Clear();
            //studentList.Add("Dat");
            //studentList.Add("Hai");

            for (int i = 0; i < studentList.Count; i++)
            {
                Console.WriteLine(string.Format("Thanh vien thu {0} trong danh sach la {1}", i + 1, studentList[i]));             
            }
            Console.ReadKey();
        }

        // ví dụ cho mảng và vòng lặp
        // sắp xếp 1 mảng theo thứ tự tăng dần
        public static void ViDu4()
        {
            int[] numberArray = new int[5]; // hoặc là = new int[5] { 8, 7, 9, 5, 4 }; và bỏ 5 dòng sau
            numberArray[0] = 8;
            numberArray[1] = 7;
            numberArray[2] = 9;
            numberArray[3] = 5;
            numberArray[4] = 4;


            int temp = 0; // dùng để lưu giá trị tạm
            for (int i = 0; i < numberArray.Length - 1; i++) // với Array thì dùng Length để biết số phần tử của mảng
            {
                for (int j = i; j < numberArray.Length - 0; j++)
                {
                    if (numberArray[i] > numberArray[j])
                    {
                        // đổi giá trị ở 2 index i và j cho nhau
                        temp = numberArray[i];
                        numberArray[i] = numberArray[j];
                        numberArray[j] = temp;
                    }
                }
            }

            for (int i = 0; i < numberArray.Length; i++)
            {
                Console.WriteLine(string.Format("So thu {0} trong danh sach sau khi sap xep la {1}", i + 1, numberArray[i]));
            }

            Console.ReadKey();
        }

        // ví dụ cho dictionary + rẽ nhánh + lặp
        public static void ViDu5()
        {
            Dictionary<string, int> scoreDict = new Dictionary<string, int>() { { "Trang", 9 }, { "Nam", 8 } };
            scoreDict.Add("Tung", 6);
            scoreDict.Add("Dat", 10);

            int totalF, totalD, totalC, totalB, totalA;
            totalF = totalD = totalC = totalB = totalA = 0;

            foreach (int value in scoreDict.Values)
            {
                switch(value)
                {
                    case 0:
                    case 1:
                    case 2:
                    case 3:
                        totalF++;
                        break;
                    case 4:                        
                    case 5:
                        totalD++;
                        break;
                    case 6:
                        totalC++;
                        break;
                    case 7:
                    case 8:
                        totalB++;
                        break;
                    default:
                        totalA++;
                        break;
                }
            }

            Console.WriteLine("So luong diem A: " + totalA);
            Console.WriteLine("So luong diem B: " + totalB);
            Console.WriteLine("So luong diem C: " + totalC);
            Console.WriteLine("So luong diem D: " + totalD);
            Console.WriteLine("So luong diem F: " + totalF);
            Console.ReadKey();
        }

        public static void BaiTap2()
        {
            Dictionary<string, float> danhSachDiem = new Dictionary<string, float>();
            float tongDiemCacBanVanT = 0;
            

            danhSachDiem.Add("Ha", 25.5f);
            danhSachDiem.Add("Hung", 21.25f);
            danhSachDiem.Add("Lan", 26.75f);
            danhSachDiem.Add("Tuan", 22.75f); //
            danhSachDiem.Add("Tu", 19.5f); //
            danhSachDiem.Add("Dat", 23.0f);
            danhSachDiem.Add("Tung", 24.5f); // 
            danhSachDiem.Add("Phuong", 28.75f);
            danhSachDiem.Add("Cuong", 25.5f);
            danhSachDiem.Add("Thanh", 20.75f); //

            // tinh tong diem cac ban co van ten T
            foreach (KeyValuePair<string, float> keyValuePair in danhSachDiem)
            {
                //if (keyValuePair.Key.IndexOf("T") == 0)
                //{
                //    Console.WriteLine(keyValuePair.Key + ": " + keyValuePair.Value);
                //    tongDiemCacBanVanT += keyValuePair.Value;
                //    // tongDiemCacBanVanT =tongDiemCacBanVanT + keyValuePair.Value;
                //}
            }

            foreach(string key in danhSachDiem.Keys)
            {
                //if(key.IndexOf("T") == 0)
                //{
                //    Console.WriteLine(key + ": " + danhSachDiem[key]);
                //    tongDiemCacBanVanT += danhSachDiem[key];
                //}
            }

            //Console.WriteLine("Tong diem cac ban van T: " + tongDiemCacBanVanT);
            //=====================================================

            //string[] sapXepTen = new string[10];
            //int indexDangDuyet = 0;
            //string temp = "";
            //foreach (string key in danhSachDiem.Keys)
            //{
            //    sapXepTen[indexDangDuyet] = key;
            //    indexDangDuyet++;
            //}
            //===================================
            //for (int i = 0; i < sapXepTen.Length - 1; i++)
            //{
            //    for (int j = i + 1; j < sapXepTen.Length; j++)
            //    {
            //        if (string.Compare(sapXepTen[i], sapXepTen[j]) > 0)
            //        {
            //            doi vi tri 2 ten cho nhau
            //           temp = sapXepTen[i];
            //            sapXepTen[i] = sapXepTen[j];
            //            sapXepTen[j] = temp;
            //        }
            //    }
            //}

            //for (int i = 0; i < sapXepTen.Length; i++)
            //{
            //    Console.WriteLine(sapXepTen[i] + ": " + danhSachDiem[sapXepTen[i]]);
            //}

            // ---------------------------------------------------
            List<string> sapXepTen = new List<string>();
            //sapXepTen.Add("abcv");
            //sapXepTen.Add("def");

            //List<string> nameList = new List<string>() { "abcv", "def" };
            //nameList.Add("afdfdf");

            
            string temp = "";
            foreach (string key in danhSachDiem.Keys)
            {
                sapXepTen.Add(key);
            }
            //===================================
            for (int i = 0; i < sapXepTen.Count - 1; i++)
            {
                for (int j = i + 1; j < sapXepTen.Count; j++)
                {
                    if (danhSachDiem[sapXepTen[i]] > danhSachDiem[sapXepTen[j]])
                    {
                        // doi vi tri 2 ten cho nhau
                        temp = sapXepTen[i];
                        sapXepTen[i] = sapXepTen[j];
                        sapXepTen[j] = temp;
                    }
                }
            }

            for (int i = 0; i < sapXepTen.Count; i++)
            {
                Console.WriteLine(sapXepTen[i] + ": " + danhSachDiem[sapXepTen[i]]);
            }

            
            Console.ReadKey();
        }

        #region Number calculator
        static int Sum(int a, int b)
        {
            return a + b;
        }

        static int Sub(int a, int b)
        {
            return a - b;
        }

        static int Multi(int a, int b)
        {
            return a * b;
        }

        static int Divide(int a, int b)
        {
            return a / b;
        }

        static int Mod(int a, int b)
        {
            return a % b;
        }

        static double Exponential(int a, int b)
        {
            return Math.Pow(a, b);
        }

        static int AndInt(int a, int b)
        {
            return a &= b;
        }
        #endregion
    }
}
