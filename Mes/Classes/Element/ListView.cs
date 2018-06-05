using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Documents;

namespace Mes.Classes.Element
{
    class ListView
    {
        private static FileStream File1;

        public static void Select(object sender,string path)
        {
            RichTextBox TxtBox = sender as RichTextBox;

            TxtBox.Document.Blocks.Clear();

            if (File.Exists(path)) File1 = new FileStream(path, FileMode.Open);
            else return;

            TextRange range = new TextRange(TxtBox.Document.ContentStart, TxtBox.Document.ContentEnd);
            try
            {
                // Чтение файла формата Rtf
                range.Load(File1, System.Windows.DataFormats.Rtf);
            }
            catch (Exception)
            {
                // Чтение файла другово формата                
                File1.Read(Encoding.Default.GetBytes(range.Text), 0, range.Text.Length);
            }
            finally
            {
                File1.Close();
            }
        }
    }
}
