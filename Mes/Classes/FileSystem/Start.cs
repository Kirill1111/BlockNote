/*===================================================
 * Этот код отвечает за чтение информации о известных
 * файлах и её записи
 *===================================================
 */
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace Mes.Classes.FileSystem
{
    public class Start
    {
        private static string[] Content;
        private static int Len = 0;

        public static string[] Load(string path)
        {
            try
            {
                if(path == null)return null;

                //Считываем файл и сохраняем результаты
                string file = File.ReadAllText(path, Encoding.Unicode);
                //Создаём массив с размером = file
                Content = new string[file.Length];

                //Записивыем в строку символы пока не найдём | после чего переходем на следующею строку
                for (var i = 0; i < file.Length; i++)
                {
                    if (file[i] != '|')
                    {
                        Content[Len] += file[i];
                    }
                    else
                    {
                        Len++;
                    }
                }

                //Очищаем массив от нулевых значений
                Content = Content.Where(x => x != null).ToArray();
                
                Len = 0;
                return Content;
            }

            catch (IOException e)
            {
                Logs.Log("Error Load Data", "FatalErr", e, System.Reflection.MethodBase.GetCurrentMethod().Name);
                MessageBox.Show("Ошибка открытия файла");
                return null;
            }
        }
    }
}
