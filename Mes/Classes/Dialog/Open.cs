using System;
using System.Globalization;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;
using Mes.Classes;
using System.Collections.Generic;
using System.Data;
using System.Text;
using System.Windows.Documents;
using System.Windows.Media.Imaging;
using System.Data.SqlClient;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Threading;
using System.IO;
using System.Configuration;
using System.Collections.Specialized;
using System.Collections.ObjectModel;
using System.Drawing;
using System.Linq;
using System.Linq.Expressions;
using System.Net.Mime;
using System.Printing;
using System.Security.Cryptography;
using System.Windows.Controls.Primitives;
using System.Windows.Forms;
using System.Windows.Controls;
using System.Windows.Xps;
using System.Windows.Xps.Packaging;
using Mes.Classes.FileSystem;
using Color = System.Windows.Media.Color;
using KeyEventArgs = System.Windows.Input.KeyEventArgs;
using MenuItem = System.Windows.Controls.MenuItem;
using MessageBox = System.Windows.MessageBox;
using Path = System.IO.Path;
using PrintDialog = System.Windows.Forms.PrintDialog;
using RichTextBox = System.Windows.Controls.RichTextBox;
using TextBox = System.Windows.Controls.TextBox;

namespace Mes.Classes.Dialog
{
    class Open
    {
        public static void OpenFile(System.Windows.Controls.RichTextBox TxtBox)
        {
            try
            {
                //Создаем диалог для выбора файла
                Microsoft.Win32.OpenFileDialog dlg = new Microsoft.Win32.OpenFileDialog();
                //Проверяем закрыт ли диалог
                if (dlg.ShowDialog() == false) return;
                //Создаём поток для чтения из файла
                MemoryStream Stream = new MemoryStream(Encoding.ASCII.GetBytes(File.ReadAllText(dlg.FileName)));

                try
                {
                    TextRange range = new TextRange(TxtBox.Document.ContentStart, TxtBox.Document.ContentEnd);
                    range.Load(Stream, System.Windows.DataFormats.Rtf);
                    //Заполняем RichTextBox информацией из файла формата Rtf
                }
                catch (Exception e)
                {
                    TextRange range = new TextRange(TxtBox.Document.ContentStart, TxtBox.Document.ContentEnd);
                    range.Load(Stream, System.Windows.DataFormats.Text);
                    //Заполняем RichTextBox информацией из файла текстового формата
                }
                finally
                {
                    Stream.Close();
                    //Закрываем поток
                }

                Classes.FileSystem.Instruments.Add = Path.GetFileNameWithoutExtension(dlg.FileName);
                //Добавляем имя открытого файла в список

                File.WriteAllText("SaveInfo/SaveText/" + Path.GetFileNameWithoutExtension(dlg.FileName) + ".SAVE",
                    File.ReadAllText(dlg.FileName));
                //записивыем файл в хранилище

                Mes.Classes.Instruments.Save.FileNameAdd(Path.GetFileNameWithoutExtension(dlg.FileName));
                // Запоминаем , что данный файл был открыт на компьютере
            }
            catch (Exception)
            {
                System.Windows.Forms.MessageBox.Show("Не удалось открыть файл");
            }
        }

    }
}
