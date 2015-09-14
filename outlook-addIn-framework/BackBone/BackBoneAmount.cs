using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OAFramework
{
    public class BackBoneAmount : BackBone, IDataUnitAmount
    {
        public double Amount 
        {
            get
            {
                return 3000;
            }
            set
            {
            }
        }

        public string Ccy 
        {
            get
            {
                return "EUR";
            }
            set
            {
            }
        }

        public override string ControlClassName
        {
            get
            {
                return "FiMailGUI.DataControl.AmountDataControl";
            }
        }
    }
}
