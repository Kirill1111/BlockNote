using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mes.Classes.FileSystem
{
    class Instruments
    {
        ////////////////////////////////////////////////////////
        // Храним список всех известных фалов
        public static string[] _darkContent;

        public static string[] Output
        {
            get
            {
                if (_darkContent == null) return null;

                _darkContent = _darkContent.Where(x => x != null).ToArray();
                return _darkContent;
            }
            set
            { 
                if (value == null ) return;

                    _darkContent = new string[value.Length];
                    _darkContent = value;
            }
        }
        ////////////////////////////////////////////////////////

        ////////////////////////////////////////////////////////
        //Удаляем из списка известных файлов 
        public static string Delete
        {
            set
            {
                int Num = Array.IndexOf(Output, value);
                Output[Num] = null;
                Output.Where(x => x != null).ToArray();
            }
        }
        ////////////////////////////////////////////////////////

        ////////////////////////////////////////////////////////
        //Добавляем в список известных файлов
        public static string Add
        {
            set
            {
                if (value == null) return;
                if (_darkContent == null) return;

                if (_darkContent.Any(t => value == t))
                {
                    return;
                }

                string[] Temp = _darkContent;
                _darkContent = new string[_darkContent.Length + 1];
                for (int i = 0; i < Temp.Length; i++)
                _darkContent[i] = Temp[i];
                _darkContent[_darkContent.Length - 1] = value;
                Temp = null;

            }
        }
        ////////////////////////////////////////////////////////

        ////////////////////////////////////////////////////////
        //Изменяем имя одного из известных файлов+-
        public static void Rename(string Name, string NewName)
        {
            Delete = Name;

            Add = NewName;
        }
        ////////////////////////////////////////////////////////

        ////////////////////////////////////////////////////////
        //Проверяем есть ли какой-то файл в списке известных файлов
        public static bool Search(string Name)
        {
            foreach (var t in Output)
                if (Name == t) return true;

            return false;
        }
        ////////////////////////////////////////////////////////
    }
}
