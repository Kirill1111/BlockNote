/*===================================================
 *Данный код сохраняем информацию о всех доступных файлах
 *===================================================
 */
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Mes.Classes.FileSystem
{
    class Save
    {
        public static bool SaveInfo(string[] Input, string path)
        {
            //Проверяем входные параметры
            if (Input == null||path == null ) return false;

            try
            {
                //Очищаем файл
              File.WriteAllText(path,"");

                //Записываем названия файлов разделяя их между собой знаком - |
                foreach (var t in Input)
                {
                    File.AppendAllText(path, t + "|", Encoding.Unicode);
                }

                return true;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Сохранить данные не удалось");
                Logs.Log("Error Save Data", "FatalErr", ex, System.Reflection.MethodBase.GetCurrentMethod().Name);
                return false;
            }
        }
    }
}