/*===================================================
 * Этот код отвечает за хранение информации о
 * цвете текста внутри элемента управления
 *===================================================
 */
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media;

namespace Mes.Classes.Brush
{
    class BackBrush
    {
        private static SolidColorBrush myBrush = new SolidColorBrush(Color.FromRgb(0xEF, 0xEF, 0xF2));

        public static SolidColorBrush _MyBrush
        {
            get { return myBrush; }
            set { myBrush = value; }
        }

    }
}
