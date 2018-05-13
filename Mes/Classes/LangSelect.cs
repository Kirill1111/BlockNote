using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Media;

namespace Mes.Classes
{
    class LangSelect
    {
        private static object MenuL;

        public static void Lang(object sender)
        {
            MenuItem MenuLanguage = sender as MenuItem;
            MenuL = MenuLanguage;

            App.LanguageChanged += LanguageChanged;

            CultureInfo currLang = App.Language;
            //Заполняем меню смены языка:
            MenuLanguage.Items.Clear();
            foreach (var lang in App.Languages)
            {
                MenuItem menuLang = new MenuItem();
                menuLang.Foreground = new SolidColorBrush(Colors.Black);
                menuLang.Header = lang.DisplayName;
                menuLang.Tag = lang;
                menuLang.IsChecked = lang.Equals(currLang);
                menuLang.Click += ChangeLanguageClick;
                MenuLanguage.Items.Add(menuLang);
            }
        }


        public static void LanguageChanged(object sender, EventArgs e)
        {
            MenuItem MenuLanguage = MenuL as MenuItem;

            CultureInfo currLang = App.Language;

            //Отмечаем нужный пункт смены языка как выбранный язык
            foreach (MenuItem i in MenuLanguage.Items)
            {
                CultureInfo ci = i.Tag as CultureInfo;
                i.IsChecked = ci != null && ci.Equals(currLang);
            }
        }

        public static void ChangeLanguageClick(object sender, EventArgs e)
        {
            MenuItem mi = sender as MenuItem;
            if (mi != null)
            {
                CultureInfo lang = mi.Tag as CultureInfo;
                if (lang != null)
                {
                    App.Language = lang;
                }
            }

        }
    }
}
