using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OAFramework
{
    public abstract class BackBoneCombo : BackBone, IDataUnitCombo
    {
        public string SelectedValue
        {
            get
            {
                return "DemoValue";
            }
            set
            {
            }
        }

        public abstract IList<string> GetValuesForCombo();

        public abstract bool IsStatic { get; }

        public override string ControlClassName
        {
            get
            {
                return "FiMailGUI.DataControl.ComboDataControl";
            }
        }
    }

    public class BackBoneComboQuery : BackBoneCombo
    {
        public override IList<string> GetValuesForCombo()
        {
            return DataField.ComboValues.Select(x => x.ComboValue).ToList();
        }

        public override bool IsStatic
        {
            get
            {
                return false;
            }
        }
    }

    public class BackBoneComboStatic : BackBoneCombo
    {
        public override IList<string> GetValuesForCombo()
        {
            if (!string.IsNullOrEmpty(DataField.ComboStaticValues)) return DataField.ComboStaticValues.Split(';', '|', ',');
            else
            {
                return new List<string>();
            }
        }
        
        public override bool IsStatic
        {
            get
            {
                return true;
            }
        }
    }
}
