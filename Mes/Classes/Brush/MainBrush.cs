/*===================================================
 * Этот код отвечает за хранение информации о
 * цвете элемента управления
 *===================================================
 */
using System.IO;
using System.Windows;
using System.Windows.Media;

namespace Mes.Classes.Brush
{
   public class MainBrush
    {
         static SolidColorBrush myBrush = new SolidColorBrush(Colors.Black);

           public static SolidColorBrush _Brush
           {
            get { return myBrush; }
            set { myBrush = value; }

           }   

    }
}
