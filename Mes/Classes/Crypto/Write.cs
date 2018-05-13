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
        public static string WriteText(string Text,string path, string Key, string IV)
        {
            try
            {
                return UnCode(Text, path, Key, IV);
            }
            catch (Exception e)
            {
                MessageBox.Show($@"Ошибка декодирования");
                Logs.Log("Eror Decode", "FatalErr", e, System.Reflection.MethodBase.GetCurrentMethod().Name);
                return null;
            }
        }

        public static string UnCode(string Text, string path, string Key, string IV)
        {    
            //Создание потока для записи в файл
                var stream = new FileStream(path, FileMode.OpenOrCreate, FileAccess.Write);

                //Создание объекта для кодирования
                var cryptic = new RijndaelManaged
                {
                    Key = ASCIIEncoding.ASCII.GetBytes(Key),
                    IV = ASCIIEncoding.ASCII.GetBytes(IV)
                };

                //Создания потока для записи в файл закодираванного объетка
                CryptoStream crStream = new CryptoStream(stream,
                    cryptic.CreateEncryptor(), CryptoStreamMode.Write);

                //Получения закодированного текста
                var data = ASCIIEncoding.Unicode.GetBytes(Text);

                //Запись в файл
                crStream.Write(data, 0, data.Length);

                //Закрытие потоков
                crStream.Close();
                stream.Close();

                return Convert.ToString(data);
        }

    }
}
