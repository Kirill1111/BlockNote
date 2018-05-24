using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Remoting.Channels;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;
using Mes.Classes;
using System.Data;
using System.Drawing;
using System.Drawing.Imaging;
using System.Windows.Documents;
using System.Threading;
using System.Windows.Xps;
using System.Windows.Xps.Packaging;
using Mes.Classes.Element.List;
using Mes.Classes.FileSystem;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Mes.Classes.Crypto
{
    class Read
    {

        public static void ReadText(string path, string Key, string IV)
        {
            try
            {
                Crypt(path, Key, IV);
            }
            catch (Exception e)
            {
                System.Windows.Forms.MessageBox.Show("Ошибка шифрования");
                Logs.Log("Eror Encode","FatalErr",e, System.Reflection.MethodBase.GetCurrentMethod().Name);
            }
        }

        private static async void Crypt(string path, string Key, string IV)
        {
            string data = "";

                //Создание объекта для кодирования файла
                var cryptic = new RijndaelManaged
                {
                    Key = ASCIIEncoding.ASCII.GetBytes(Key),
                    IV = ASCIIEncoding.ASCII.GetBytes(IV)
                };

            using (var stream = new FileStream(path, FileMode.Open, FileAccess.Read))
            {
                var crStream = new CryptoStream(stream, cryptic.CreateDecryptor(), CryptoStreamMode.Read);
                using (var reader = new StreamReader(crStream, Encoding.Unicode))
                {
                    Task t = Task.Run(() =>
                        {
                     data = reader.ReadToEnd();
                        }
                    );
                    t.Wait();
                }
            }
            File.WriteAllText(path, data.ToString());

        }
    }
}
