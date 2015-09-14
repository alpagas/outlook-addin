using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OAFramework
{
    public class BackBoneCheck : BackBone, IDataUnitCheck
    {
        public bool CheckValue
        {
            get
            {
                return true;
            }
            set
            {
            }
        }

        public override string ControlClassName
        {
            get
            {
                return "FiMailGUI.DataControl.CheckDataControl";
            }
        }
    }
}
