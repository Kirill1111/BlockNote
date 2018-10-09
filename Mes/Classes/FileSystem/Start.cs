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
        public static string[] Load(string path)
        {
            string[] result = new string[0];
            string file;

            try
            {
                if(path == null)return null;

                //Считываем файл и сохраняем результаты
                    file = File.ReadAllText(path);
                
                    //Записивыем в строку символы пока не найдём | после чего переходем на следующею строку       
                        if (file != null && file.Length > 0)
                            result = file.Substring(0, file.Length - 1).Split('|');

                    return file != null ? result : new string[0];
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
