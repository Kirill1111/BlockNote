/*===================================================
 * Этот код отвечает за поиск файлов
 *===================================================
 */
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mes.Classes.FileSystem
{
    class SearchString
    {
        public static string[] Search(String StrTxt)
        {
            string[] result = new string[0];
            //Проверяем не пустой ли список файлов и 
            //Проверяем не пустая ли строка
            if (Classes.FileSystem.Instruments.Output == null) return null;

            //Создаём массив и сохраняем в нём список файлов 
            //и Выполняем поиск

                var text = Classes.FileSystem.Instruments.Output;
                result = text.Where(x => x.Substring(0, x.Length < StrTxt.Length ? x.Length : StrTxt.Length) == StrTxt).ToArray();

            return result;
        }
    }
}
