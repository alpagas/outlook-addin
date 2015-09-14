using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OAFramework
{
    public class BackBoneLabel : BackBone, IDataUnitLabel
    {
        public string LabelValue
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
                return "FiMailGUI.DataControl.LabelDataControl";
            }
        }
    }
}
