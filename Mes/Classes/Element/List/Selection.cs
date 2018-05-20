/*===================================================
 * Этот код отвечает за хранение информации о
 * выбранном в ListView элементе
 *===================================================
 */
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Navigation;

namespace Mes.Classes.Element.List
{
    class Selection
    {
        private static string _Selection;

        public static string SelectionElemtnt
        {
            get => _Selection;
            set
            {
                if (value == null) return;
                _Selection = value;
            }
        }
    }
}
