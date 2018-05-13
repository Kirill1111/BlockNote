using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace Mes.Classes.Element
{
    class FontCombo
    {
        // Информация о всех шрифтах
        public static String[] FontList;

        public static String[] Font
        {
            get => FontList;
            set => FontList = value;
        }

        //Инициализация
        public static void Init()
        {
            int i = 1;
            //Получаем список шрифтоф
            System.Drawing.Text.InstalledFontCollection fonts = new System.Drawing.Text.InstalledFontCollection();
            //Создайм новый массив размер = количеству шрифтоф
            string[] Str = new string[fonts.Families.Length];

            Str[0] = "null";

            //Заполняем Str шрифтами из fonts
            foreach (FontFamily font in fonts.Families)
            {
                if (i < fonts.Families.Length)
                {
                    Str[i] = font.Name;
                    i++;
                }
            }
            
            // Сохраняем информацию о шрифтах
            Font = Str;
        }
    }
}
