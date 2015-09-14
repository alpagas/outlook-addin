using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OAFramework
{
    public class BackBoneDate : BackBone, IDataUnitDate
    {
        public DateTime DateValue
        {
            get
            {
                return DateTime.Now;
            }
            set
            {
            }
        }

        public override string ControlClassName
        {
            get
            {
                return "FiMailGUI.DataControl.DateDataControl";
            }
        }
    }
}
