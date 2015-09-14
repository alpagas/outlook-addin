using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OAFramework
{
    public class BackBoneText : BackBone, IDataUnitText
    {
        public string TextValue
        {
            get
            {
                return "DemoValue";
            }
            set
            {
            }
        }

        public override string ControlClassName
        {
            get
            {
                return "FiMailGUI.DataControl.TextDataControl";
            }
        }
    }
}
