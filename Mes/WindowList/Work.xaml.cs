using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;
using Mes.Classes;
using System.Data;
using System.Drawing;
using System.Drawing.Imaging;
using System.Windows.Documents;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Windows.Controls;
using System.Windows.Xps;
using System.Windows.Xps.Packaging;
using Mes.Classes.Element.List;
using Mes.Classes.FileSystem;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using static System.IO.File;
using Color = System.Windows.Media.Color;
using ComboBox = System.Windows.Controls.ComboBox;
using DataFormats = System.Windows.Forms.DataFormats;
using Encoder = System.Text.Encoder;
using KeyEventArgs = System.Windows.Input.KeyEventArgs;
using MenuItem = System.Windows.Controls.MenuItem;
using MessageBox = System.Windows.MessageBox;
using Path = System.IO.Path;
using PrintDialog = System.Windows.Forms.PrintDialog;
using RichTextBox = System.Windows.Controls.RichTextBox;
using TextBox = System.Windows.Controls.TextBox;
using TextDataFormat = System.Windows.TextDataFormat;

namespace Mes.WindowList
{
    /// <summary>
    /// Логика взаимодействия для Work.xaml
    /// </summary>

    public partial class Work : Window
    {
        private Stream File1;

        //Сохраняем информациюя
        ~Work()
        {
            Save.SaveInfo(Instruments._darkContent, "SaveInfo/Work.SAVE");
            Mes.Classes.Instruments.Save.FileNameSave();
        }

        public Work()
        {
            reestablish test = new reestablish();
            test = null;
            Mes.Classes.Instruments.Save.FileNameOpen();
            GlobalOptions.UpdateState();
            DataContext = new Classes.Brush.BackBrush()._MyBrush;
            Classes.Element.FontCombo.Init();
            InitializeComponent();
            LangSelect.Lang(MenuLanguage);
            Logs.Log("Start loading Log Work", "Info", System.Reflection.MethodBase.GetCurrentMethod().Name);
            Instruments.Output = Classes.FileSystem.Start.Load("SaveInfo/Work.SAVE");
            ListL.ItemsSource = Classes.FileSystem.Instruments.Output;
            Classes.Element.Combo.Init(20);
            ComboB.ItemsSource = Classes.Element.Combo.TextCombo;
            AppDomain.CurrentDomain.UnhandledException += CurrentDomain_UnhandledException;
        }

        private void MenuItem_Click(object sender, RoutedEventArgs e)
        {
            // Открытие окна с настройками
            GlobalOptions global = new GlobalOptions(Top, Left, Height, Width, WindowState);
            global.ShowDialog();
            Work wrk = new Work();
            Close();
            wrk.Show();
            Logs.Log("Menu click work", "Info", System.Reflection.MethodBase.GetCurrentMethod().Name);
        }

        private void MenuItem_Click_1(object sender, RoutedEventArgs e)
        {
            // Открытие окна с информацией
            var inf = new Info(Top, Left, Height, Width, WindowState);
            inf.ShowDialog();
            Logs.Log("Open Info Dialog", "Info", System.Reflection.MethodBase.GetCurrentMethod().Name);
        }

        private void Text1_TextChanged(object sender, TextChangedEventArgs e)
        {
            // Поиск файла
            var result = Classes.FileSystem.SearchString.Search(Text1.Text);
            if (result != null)
            {
                ListL.ItemsSource = result;
            }
            Logs.Log("Search File", "Info", System.Reflection.MethodBase.GetCurrentMethod().Name);
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            //Сохранение
            Mes.Classes.Instruments.Save.SaveInfo(ListL,TxtBox);
            Logs.Log("Save file", "Info", System.Reflection.MethodBase.GetCurrentMethod().Name);
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            // Создать новый файл
            try
            {
                if (Text1.Text == "") return;

                WriteAllText("SaveInfo/SaveText/" + Text1.Text + ".SAVE", @"{\rtf1\ansi\ansicpg1252\uc1\htmautsp\deff2{\fonttbl{\f0\fcharset0 Times New Roman; } {\f2\fcharset0 Segoe UI; } }{\colortbl\red0\green0\blue0;\red255\green255\blue255; }\loch\hich\dbch\pard\plain\ltrpar\itap0{\lang1033\fs18\f2\cf0 \cf0\ql{\f2 {\ltrch }\li0\ri0\sa0\sb0\fi0\ql\par}}}");
                Classes.FileSystem.Instruments.Add = Text1.Text;
                ListL.ItemsSource = Classes.FileSystem.Instruments.Output;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Неверное имя");
                Logs.Log("Error input NameFile", "FatalErr", ex, System.Reflection.MethodBase.GetCurrentMethod().Name);
            }
            Logs.Log("Create new file   ", "Info", System.Reflection.MethodBase.GetCurrentMethod().Name);
        }

        private void ButtonBase_OnClick(object sender, RoutedEventArgs e)
        {
            // Начать редактирование файла
            TxtBox.IsReadOnly = false;
            Logs.Log("Start edit file", "Info", System.Reflection.MethodBase.GetCurrentMethod().Name);
        }

        private void TxtBox_OnKeyDown(object sender, KeyEventArgs e)
        {
            // Переход на следующею строку
            if (e.Key == Key.Enter)
            {
                TxtBox.Document.Blocks.Add(new Paragraph(new Run(Environment.NewLine)));
            }
            Logs.Log("Go to new line", "Info", System.Reflection.MethodBase.GetCurrentMethod().Name);
        }

        private void ButDelete_OnClick(object sender, RoutedEventArgs e)
        {
            //Удаление файла
            DialogResult dialogResult = System.Windows.Forms.MessageBox.Show((string)System.Windows.Application.Current.Resources["Title56"], (string)System.Windows.Application.Current.Resources["Title35"], MessageBoxButtons.YesNo);
            if (dialogResult == System.Windows.Forms.DialogResult.Yes)
            {
                try
                {
                    Instruments.Delete = Classes.Element.List.Selection.SelectionElemtnt;
                    ListL.ItemsSource = Classes.FileSystem.Instruments.Output;
                    Delete("SaveInfo/SaveText/" + Classes.Element.List.Selection.SelectionElemtnt + ".SAVE");
                    Classes.Element.List.Selection.SelectionElemtnt = null;
                    TxtBox.Document.Blocks.Clear();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Выберите файл для удаления");
                    Logs.Log("Error delete File", "FatalErr", ex, System.Reflection.MethodBase.GetCurrentMethod().Name);
                }
                Logs.Log("Delete file", "Info", System.Reflection.MethodBase.GetCurrentMethod().Name);
            }
        }

        private void Copy_OnClick(object sender, RoutedEventArgs e)
        {
            //Копирование файла
            try
            {
                Classes.FileSystem.Instruments.Add = Classes.Element.List.Selection.SelectionElemtnt + "_Copy";
                var text = ReadAllText("SaveInfo/SaveText/" + Classes.Element.List.Selection.SelectionElemtnt + ".SAVE");
                WriteAllText("SaveInfo/SaveText/" + Classes.Element.List.Selection.SelectionElemtnt + "_Copy.SAVE", text);
                ListL.ItemsSource = Classes.FileSystem.Instruments.Output;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Выберите файл для копирования");
                Logs.Log("Error copy file", "FatalErr", ex, System.Reflection.MethodBase.GetCurrentMethod().Name);
            }
            Logs.Log("Copy file", "Info", System.Reflection.MethodBase.GetCurrentMethod().Name);
        }


        private void Open_OnClick(object sender, RoutedEventArgs e)
        {
            //Открытие файла
            Classes.Dialog.Open.OpenFile(TxtBox);
            ListL.ItemsSource = Classes.FileSystem.Instruments.Output;
            Logs.Log("Open file", "Info", System.Reflection.MethodBase.GetCurrentMethod().Name);
        }

        private void ReName_OnClick(object sender, RoutedEventArgs e)
        {
            //Изменение имени
            var name = new ReName();
            name.ShowDialog();
            if (Classes.FileSystem.Instruments.Search(Classes.Element.List.Selection.SelectionElemtnt))
            {
                Move("SaveInfo/SaveText/" + Classes.Element.List.Selection.SelectionElemtnt + ".SAVE", "SaveInfo/SaveText/" + name.Name + ".SAVE");
                Classes.Instruments.Save.FileNameAdd(name.Name);
                Instruments.Rename(Classes.Element.List.Selection.SelectionElemtnt, name.Name);
                ListL.ItemsSource = Classes.FileSystem.Instruments.Output;
            }
            Logs.Log("Chendge filename", "Info", System.Reflection.MethodBase.GetCurrentMethod().Name);
        }

        private void ComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            //Изменение размера выделенного текста
            var a = sender as System.Windows.Controls.ComboBox;
            if (a.SelectedIndex != 0)
                TxtBox.Selection.ApplyPropertyValue(RichTextBox.FontSizeProperty, a.SelectedValue);
            a.SelectedIndex = 0;
        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            //Изменение цвета выделенного текста
            var colorq = new ColorDialog();
            if (colorq.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                TxtBox.Selection.ApplyPropertyValue(ForegroundProperty,
                    new SolidColorBrush(Color.FromArgb(colorq.Color.A, colorq.Color.R, colorq.Color.G,
                        colorq.Color.B)));
            }
        }

        private void Button_Click_3(object sender, RoutedEventArgs e)
        {
            //Печать
            Classes.Dialog.Print.PrintText(TxtBox);
            Logs.Log("Start print file", "Info", System.Reflection.MethodBase.GetCurrentMethod().Name);
        }

        private void Save_OnClick(object sender, RoutedEventArgs e)
        {
            //Сохранение
            Classes.Dialog.SaveFileDialog.Save(TxtBox);
        }

        private void Selector_OnSelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            //Изменение шрифта выделенного текста
            if (sender is ComboBox a && a.SelectedIndex != 0)
                TxtBox.Selection.ApplyPropertyValue(FontFamilyProperty,
                    new System.Windows.Media.FontFamily((string) a.SelectedValue));
            else return;

            a.SelectedIndex = 0;
        }

        private void MenuItem_OnClick(object sender, RoutedEventArgs e)
        {
            var crypt = new Crypto(Classes.Element.List.Selection.SelectionElemtnt);
            if (crypt.ShowDialog() == false)
            {
                 Classes.Element.ListView.Select(TxtBox, "SaveInfo/SaveText/" + Selection.SelectionElemtnt + ".SAVE");
                ListL_OnSelectionChanged(null, null);
            }
        }

        private void Button_MouseEnter(object sender, System.Windows.Input.MouseEventArgs e)
        {
            var but = sender as System.Windows.Controls.Button;
            but.FontSize = 14;
        }

        private void Button_MouseLeave(object sender, System.Windows.Input.MouseEventArgs e)
        {
            var but = sender as System.Windows.Controls.Button;
            but.FontSize = 11;
        }

        private void Help_OnClick(object sender, RoutedEventArgs e)
        {
            var help = new WindowList.Help();
            help.ShowDialog();
        }

        private void ListL_OnSelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            Mes.Classes.Element.ListView.Select(TxtBox,
                "SaveInfo/SaveText/" + Classes.Element.List.Selection.SelectionElemtnt + ".SAVE");
        }

        private void CurrentDomain_UnhandledException(object sender, UnhandledExceptionEventArgs e)
        {
            Exception Ex = (Exception)e.ExceptionObject;
            MessageBox.Show("Произошла критическая ошибка");
            Logs.Log("FatalErr", "StopProgram", Ex, System.Reflection.MethodBase.GetCurrentMethod().Name);
        }

        private void Button_Click_4(object sender, RoutedEventArgs e)
        {
            TxtBox.Selection.ApplyPropertyValue(Paragraph.TextAlignmentProperty,TextAlignment.Left);
        }

        private void Button_Click_5(object sender, RoutedEventArgs e)
        {
            TxtBox.Selection.ApplyPropertyValue(Paragraph.TextAlignmentProperty, TextAlignment.Center);
        }

        private void Button_Click_6(object sender, RoutedEventArgs e)
        {
            TxtBox.Selection.ApplyPropertyValue(Paragraph.TextAlignmentProperty, TextAlignment.Right);
        }
    }
}