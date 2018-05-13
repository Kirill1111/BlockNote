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
using System.Windows.Xps;
using System.Windows.Xps.Packaging;

namespace Mes.Classes.Dialog
{
    class SaveFileDialog
    {
        public static string Save(System.Windows.Controls.RichTextBox TxtBox)
        {
            // Создаём диалог для сохранения файла
            var dlg = new Microsoft.Win32.SaveFileDialog {Filter = "Text (.txt)|*.txt|Rtf Text (.Rtf)|*.Rtf|All (*.*)|*.*"};

            //Проверяем закрыт ли диалог
            if (dlg.ShowDialog() == false) return null;

            try
            {
                switch (dlg.FilterIndex)
                {
                    case 2:
                        //Сохранения файла с форматом Rtf
                        FileStream fileStream = new FileStream(dlg.FileName, FileMode.Create);
                        TextRange range = new TextRange(TxtBox.Document.ContentStart, TxtBox.Document.ContentEnd);
                        range.Save(fileStream, System.Windows.DataFormats.Rtf);
                        break;
                    case 1:
                        //Сохранения файла с форматом Txt
                        File.WriteAllText(dlg.FileName,
                            new TextRange(TxtBox.Document.ContentStart, TxtBox.Document.ContentEnd).Text);
                        break;
                }

                return dlg.SafeFileName;

            }catch(Exception)
            {
                System.Windows.Forms.MessageBox.Show("Ошибка сохранения файла");
                return null;
            }
        }


    }
}
