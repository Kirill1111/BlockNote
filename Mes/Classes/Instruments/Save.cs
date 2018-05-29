/*===================================================
 * Этот код отвечает за хранение информации о
 * файлах которые были открыты
 *===================================================
 */
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.ServiceModel.PeerResolvers;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Documents;
using System.Windows.Forms;
using Mes.Classes.FileSystem;
using ListView = System.Windows.Controls.ListView;
using RichTextBox = System.Windows.Controls.RichTextBox;
using SaveFileDialog = Microsoft.Win32.SaveFileDialog;

namespace Mes.Classes.Instruments
{
    class Save
    {
        //Хранит информацию о файлах
        private static string[] FileName = new string[0];

        //Сохраняем информацию
        public static void FileNameSave()
        {
            Mes.Classes.FileSystem.Save.SaveInfo(FileName, "SaveInfo/Save.SAVE");
        }

        //Читает информацию
        public static void FileNameOpen()
        {
            var result = Mes.Classes.FileSystem.Start.Load("SaveInfo/Save.SAVE");
                FileName = result;
        }

        //Добавляем имя в список
        public static string FileNameAdd(string value)
        {
                //Создаём новый массив с размером FileName + 1 и записываем в него FileName , после чего
                //в последний элемент записываем новое знасение
                var Temp = FileName;
                FileName = new string[FileName.Length+1];
                for (var i = 0; i < Temp.Length; i++)
                {
                    FileName[i] = Temp[i];
                }

                FileName[FileName.Length-1] = value;

            return null;
        }
        
        //Переписываем массиву
        public static string[] FileNameAll
        {
            set => FileName = value;
        }

        //Выполняем поиск по массиву
        public static bool Search(string a)
        {
            if(FileName != null)
            return FileName.Any(t => a == t);
            return false;
        }

        //Сохранение информации
        public static void SaveInfo(ListView ListL , RichTextBox TxtBox)
        {
            if (Search(Element.List.Selection.SelectionElemtnt))
                SaveSystem(TxtBox);
            else
                SaveS(ListL,TxtBox);
        }


        // Сохранение с выбором пути
        public static void SaveSystem(RichTextBox TxtBox)
        {
            // Создаём диалог для сохранения файла
            var save = new SaveFileDialog { Filter = "Text (.txt)|*.txt|Rtf Text (.Rtf)|*.Rtf" };

            try
            {
                //Сохраняем
                if (save.ShowDialog() == true)
                    File.WriteAllText(save.FileName,
                        new TextRange(TxtBox.Document.ContentStart, TxtBox.Document.ContentEnd).Text);
            }
            catch (Exception e)
            {
                MessageBox.Show("Ошибка сохранения файла");
                Logs.Log("ErrorSaveFile" , "FatalErr",e, System.Reflection.MethodBase.GetCurrentMethod().Name);
            }
        }

        //Сохраняем файл в программе
        public static void SaveS(ListView ListL, RichTextBox TxtBox)
        {
            if (Classes.FileSystem.Instruments.Search(Classes.Element.List.Selection.SelectionElemtnt))
            {
                //Очищаем файл
                File.Delete("SaveInfo/SaveText/" + Classes.Element.List.Selection.SelectionElemtnt + ".SAVE");
                //Записываем информацию в файл
                FileStream fileStream = new FileStream("SaveInfo/SaveText/" + Classes.Element.List.Selection.SelectionElemtnt + ".SAVE", FileMode.Create);
                TextRange range = new TextRange(TxtBox.Document.ContentStart, TxtBox.Document.ContentEnd);
                range.Save(fileStream, System.Windows.DataFormats.Rtf);

                //Обновляем информацию о списке файлов
                ListL.ItemsSource = Classes.FileSystem.Instruments.Output;
                // Запрещаем редактировать RichTextBox
                TxtBox.IsReadOnly = true;
                //Закрываем поток чтения файла
                fileStream.Close();
            }
        }
    }
}
