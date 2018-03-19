using System;
using System.Collections.Generic;
using System.IO;

namespace Win10LockScreenPictureSave
{
    class Program
    {
        /// <summary>
        /// 源文件夹地址，自己记得修改
        /// </summary>
        static string sourceDirectory = @"C:\Users\31286\AppData\Local\Packages\Microsoft.Windows.ContentDeliveryManager_cw5n1h2txyewy\LocalState\Assets";
        /// <summary>
        /// 保存的文件地址，自己修改
        /// </summary>
        static string saveDirectory = @"D:\LockScreenPicture";
        /// <summary>
        /// 源文件名数组
        /// </summary>
        static string[] sourceFileName;
        /// <summary>
        /// 保存文件名
        /// </summary>
        static Dictionary<string, int> saveDictionary = new Dictionary<string, int>();

        static void Main(string[] args)
        {
            //保存的新文件计数
            int counter = 0;
            //Console.WriteLine("Hello World!");
            //获取目录
            string[] saveFullName;
            string[] sourceFullName;
            try
            {
                saveFullName = Directory.GetFiles(saveDirectory);
                sourceFullName = Directory.GetFiles(sourceDirectory);
            }
            catch (Exception e)
            {
                Console.WriteLine("FilePath No Found");
                Console.WriteLine(e.Message);
                return;
            }
            //处理sourceFullName
            sourceFileName = new string[sourceFullName.Length];
            for (int i = 0; i < sourceFullName.Length; i++)
            {
                sourceFileName[i] = Path.GetFileName(sourceFullName[i]);
            }
            //将savefullname制作为Dictionary
            foreach (string s in saveFullName)
            {
                saveDictionary.Add(key: Path.GetFileNameWithoutExtension(s), value: 1);
            }
            //在dictionary中查询sourcefilename
            //    ifnot 复制进savefile
            foreach (string s in sourceFileName)
            {
                if (!saveDictionary.ContainsKey(s))
                {
                    File.Copy(sourceDirectory + "\\" + s, saveDirectory + "\\" + s + ".jpg");
                    counter++;
                }
            }
            //end
            Console.WriteLine("We have {0} new picture", counter);
        }
    }
}
