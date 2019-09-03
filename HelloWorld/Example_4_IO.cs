using System;
using System.Text;
using System.IO;

namespace HelloWorld
{
    class Example_4_IO
    {
        public static void File_WriteToFile()
        {
            string file1Path = @"D:\File1";
            string file2Path = @"D:\File2";

            string[] lines = new string[2];
            lines[0] = "Dong 1, File 1";
            lines[1] = "Dong 2, File 1";

            System.IO.File.WriteAllLines(file1Path, lines);

            string str;
            str = "Chi ghi dong nay";

            System.IO.File.WriteAllText(file2Path, str);
        }

        // ========================================================================

        public static void File_ReadFromFile()
        {
            Console.OutputEncoding = Encoding.Unicode;

            string filePath = @"D:\File12";

            string[] lines;
            string str;

            if (System.IO.File.Exists(filePath))
            {
                lines = System.IO.File.ReadAllLines(filePath);
                for (int i = 0; i < lines.Length; i++)
                {
                    Console.WriteLine("Line {0}: {1}", i, lines[i]);
                }
                Console.WriteLine();

                str = System.IO.File.ReadAllText(filePath);
                Console.WriteLine("String: {0}", str);
            }
            else
            {
                Console.WriteLine("File does not exist");
            }

            Console.ReadKey();
        }

        // ============================================================================

        public static void File_Move()
        {
            string oldFilePath = @"D:\FileE";
            string newFilePath = @"D:\File3"; // với trường hợp này thì chỉ đơn giản là đổi tên

            try
            {
                System.IO.FileInfo fileInfo = new System.IO.FileInfo(oldFilePath);
                fileInfo.MoveTo(newFilePath);
            }
            catch
            {
                Console.WriteLine("File does not exist");
                Console.ReadKey();
            }           
        }

        // ============================================================================

        public static void BinaryReaderExample()
        {
            string filePath = @"D:\binary.dat";
            float aspectRatio;
            string tempDirectory;
            int autoSaveTime;
            bool showStatusBar;

            if (File.Exists(filePath))
            {
                using (BinaryReader reader = new BinaryReader(File.Open(filePath, FileMode.Open)))
                {
                    aspectRatio = reader.ReadSingle();
                    tempDirectory = reader.ReadString();
                    autoSaveTime = reader.ReadInt32();
                    showStatusBar = reader.ReadBoolean();
                }

                Console.WriteLine("Aspect ratio set to: " + aspectRatio);
                Console.WriteLine("Temp directory is: " + tempDirectory);
                Console.WriteLine("Auto save time set to: " + autoSaveTime);
                Console.WriteLine("Show status bar: " + showStatusBar);
            }

            Console.ReadKey();
        }


        public static void BinaryWritterExample()
        {
            string filePath = @"D:\binary.dat";
            using (BinaryWriter writer = new BinaryWriter(File.Open(filePath, FileMode.Create)))
            {
                writer.Write(1.250F); // float
                writer.Write(@"c:\Temp"); // string
                writer.Write(10); // int
                writer.Write(true); // bool
            }
        }

        public static void FileStreamReader()
        {
            FileStream F = new FileStream(@"D:\binary2.dat", FileMode.OpenOrCreate, FileAccess.ReadWrite);

            F.Position = 0;
            for (int i = 0; i <= 24; i++) // thay 24 bằng số lớn hơn thì kq trả về là -1
            {
                Console.Write(F.ReadByte() + " ");
            }
            F.Close();

            Console.ReadKey();
        }

        public static void FileStreamWritter()
        {
            FileStream F = new FileStream(@"D:\binary2.dat", FileMode.OpenOrCreate, FileAccess.ReadWrite);
            for (int i = 1; i <= 25; i++)
            {
                F.WriteByte((byte)i);
            }
        }
    }
}
