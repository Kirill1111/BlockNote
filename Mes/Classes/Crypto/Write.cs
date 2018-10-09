using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Navigation;


namespace Mes.Classes.Crypto
{
    class Write
    {
        public static void WriteText(string Text,string path, string Key, string IV)
        {
            UnCode(Text, path, Key, IV);
        }

        public static async void UnCode(string Text, string path, string Key, string IV)
        {
            try
            {
                //Создание объекта для кодирования
                var cryptic = new RijndaelManaged
                {
                    Key = ASCIIEncoding.ASCII.GetBytes(Key),
                    IV = ASCIIEncoding.ASCII.GetBytes(IV)
                };
                //Получения закодированного текста
                var data = ASCIIEncoding.Unicode.GetBytes(Text);
                using (var stream = new FileStream(path, FileMode.OpenOrCreate, FileAccess.Write))
                {
                    using (CryptoStream crStream = new CryptoStream(stream, cryptic.CreateEncryptor(), CryptoStreamMode.Write))
                    {
      
                            crStream.Write(data, 0, data.Length);

                    }
                }
            }
            catch (Exception e)
            {
                MessageBox.Show("Ошибка декодирования");
                Logs.Log("Eror Decode", "FatalErr", e, System.Reflection.MethodBase.GetCurrentMethod().Name);
            }
            
        }

    }
}
