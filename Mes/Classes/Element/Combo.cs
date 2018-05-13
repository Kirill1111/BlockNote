using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace Mes.Classes.Element
{
    class Combo
    {
        // Храним информацию о списке размеров для текста

        private static string[] text;

        public static string[] TextCombo => text;

        //Инициализация
        public static bool Init(int Lenght)
        {
            try
            {
                //Создаём массив 
                text = new string[Lenght];
                text[0] = Convert.ToString("null");

                //Заполняем массив
                for (int i = 1; i < text.Length; i++)
                {
                    text[i] = Convert.ToString((8 + 2 * i) * 1.25);
                }

                return true;

            }
            catch (Exception)
            {
                return false;
            }
        }

    }
}
