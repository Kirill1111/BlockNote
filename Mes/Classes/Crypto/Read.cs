using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Remoting.Channels;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Mes.Classes.Crypto
{
    class Read
    {

        public static string ReadText(string path, string Key, string IV)
        {
            try
            {
                return Crypt(path, Key, IV);
            }
            catch (Exception e)
            {
                MessageBox.Show("Ошибка шифрования");
                Logs.Log("Eror Encode","FatalErr",e, System.Reflection.MethodBase.GetCurrentMethod().Name);
                return null;
            }
        }

        private static string Crypt(string path, string Key, string IV)
        {
            //Создание потока для чтения файла
            var stream = new FileStream(path,
                FileMode.Open, FileAccess.Read);

            //Создание объекта для кодирования файла
            var cryptic = new RijndaelManaged
            {
                Key = ASCIIEncoding.ASCII.GetBytes(Key),
                IV = ASCIIEncoding.ASCII.GetBytes(IV)
            };

            //Создание потока для записи закодираванной информации
            var crStream = new CryptoStream(stream,
                cryptic.CreateDecryptor(), CryptoStreamMode.Read);

            //Создание объета для чтения
            var reader = new StreamReader(crStream, Encoding.Unicode);

             var data = reader.ReadToEnd();

            //Закрытие потоков
            reader.Close();
            stream.Close();

            //Запись в файл декодированного текста
            File.WriteAllText(path,data);

            return data;
        }
    }
}
