/*===================================================
 * Этот код отвечает за запись логов программы
 *===================================================
 */
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace Mes.Classes
{
    public class Logs
    { 
        static string Path = "SaveInfo/Logs.save";
        const bool ActiveDebug = true;

        public static bool Log(string Info , string Type,string Name)
        {
            //Обычная запись
            try
            {
                if(ActiveDebug)
                File.AppendAllText(Path,"   { " + Type + " }   " + " [ " + Info + " ] " +" ( " + System.DateTime.Now +" ) " +"   |" +Name + "|   "+ Environment.NewLine);
                return true;
            }catch(IOException)
            {
                if (Path != "SaveInfo/LogsErrWrite.save")
                {
                    Path = "SaveInfo/LogsErrWrite.save";
                    Log(Info, Type, System.Reflection.MethodBase.GetCurrentMethod().Name);
                }

                return false;
            }
        }


        public static bool Log(string Info, string Type,Exception e, string Name)
        {
            //Запись о ошибке
            try
            {
                if(ActiveDebug)
                    File.AppendAllText(Path, "   { " + Type + " }   " + " [ " + Info + " ] " + " ( " + System.DateTime.Now + " ) " +"  =" + e + "=  "+ "|" + Name + "|" + Environment.NewLine);
                return true;
            }
            catch (IOException)
            {
                if(Path!= "SaveInfo/LogsErrWrite.save")
                Path = "SaveInfo/LogsErrWrite.save";

                Log(Info, Type, System.Reflection.MethodBase.GetCurrentMethod().Name);

                return false;
            }
        }

    }
}
