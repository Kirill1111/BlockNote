/*===================================================
 * Этот код отвечает за хранение информации о
 * цвете текста внутри элемента управления
 *===================================================
 */
using System.Windows.Media;
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace Mes.Classes.Brush
{
    class BackBrush : INotifyPropertyChanged
    {
        private static SolidColorBrush myBrush = new SolidColorBrush(Color.FromRgb(0xEF, 0xEF, 0xF2));

        public SolidColorBrush _MyBrush
        {
            get { return myBrush; }
            set { myBrush = value; }
        }

        public event PropertyChangedEventHandler PropertyChanged;
        public void OnPropertyChanged([CallerMemberName]string prop = "")
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(prop));
        }

    }
}
