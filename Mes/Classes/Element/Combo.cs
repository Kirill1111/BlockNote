using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace Mes.Classes.Element
{
    class Combo
    {
        // Храним информацию о списке размеров для текста

        public static string[] TextCombo { get; private set; }

        //Инициализация
        public static bool Init(int Lenght)
        {
            try
            {
                //Создаём массив 
                TextCombo = new string[Lenght];
                TextCombo[0] = Convert.ToString("null");

                //Заполняем массив
                for (var i = 1; i < TextCombo.Length; i++)
                {
                    TextCombo[i] =Convert.ToString(8 + 3 * i);
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
