/*===================================================
 * Этот код отвечает за хранение информации о
 * цвете элемента управления
 *===================================================
 */
using System.Windows.Media;
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace Mes.Classes.Brush
{
   public class MainBrush : INotifyPropertyChanged
    {
         static SolidColorBrush myBrush = new SolidColorBrush(Colors.Black);

           public SolidColorBrush _Brush
           {
            get { return myBrush; }
            set
            {
                myBrush = value;
                OnPropertyChanged();
            }
           }

        public event PropertyChangedEventHandler PropertyChanged;
        public void OnPropertyChanged([CallerMemberName]string prop = "")
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(prop));
        }
    }
}
