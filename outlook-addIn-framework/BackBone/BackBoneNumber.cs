using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OAFramework
{
    public class BackBoneNumber : BackBone, IDataUnitNumber
    {
        public double NumberValue 
        {
            get
            {
                return 3000;
            }
            set
            {
            }
        }
        
        public override string ControlClassName
        {
            get
            {
                return "FiMailGUI.DataControl.NumberDataControl";
            }
        }
    }
}
