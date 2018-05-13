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

namespace Mes.Classes.Dialog
{
    class Print
    {
        public static void PrintText(System.Windows.Controls.RichTextBox TxtBox)
        {
            string Text = new TextRange(TxtBox.Document.ContentStart, TxtBox.Document.ContentEnd).Text;
            System.Windows.Controls.PrintDialog printDialog = new System.Windows.Controls.PrintDialog();
            if (printDialog.ShowDialog() == true)
            {
                // Создать текст
                Run run = new Run(Text);

                // Поместить его в TextBlock
                TextBlock visual = new TextBlock();
                visual.Inlines.Add(run);

                // Использовать поля для получения рамки страницы
                visual.Margin = new Thickness(5);

                // Разрешить перенос для заполнения всей ширины страницы
                visual.TextWrapping = TextWrapping.Wrap;

                // Увеличить TextBlock по обоим измерениям в 5 раз. 
                // (В этом случае увеличение шрифта дало бы тот же эффект, 
                // потому что TextBlock — единственный элемент)
                visual.LayoutTransform = new ScaleTransform(5, 5);

                // Установить размер элемента
                System.Windows.Size pageSize = new System.Windows.Size(printDialog.PrintableAreaWidth, printDialog.PrintableAreaHeight);
                visual.Measure(pageSize);
                visual.Arrange(new Rect(0, 0, pageSize.Width, pageSize.Height));

                // Напечатать элемент
                printDialog.PrintVisual(visual, "Распечатываем текст");
            }
        }
    }
}
