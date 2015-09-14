using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OAFramework
{
    public class BackBoneLink : BackBone, IDataUnitLink
    {
        public string LinkValue
        {
            get
            {
                return DataField.FieldName;
            }
            set
            {
            }
        }

        public override string ControlClassName
        {
            get
            {
                return "FiMailGUI.DataControl.LinkDataControl";
            }
        }
    }
}
