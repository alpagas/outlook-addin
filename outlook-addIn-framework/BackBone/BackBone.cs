using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OAFramework
{
    public abstract class BackBone : IDataUnit
    {
        public abstract string ControlClassName { get;}

        public EFDataField DataField { get; set; }

        public IField DateField { get; set; }

        public IDataUnit Clone()
        {
            return null;
        }

        public bool IsOrphan
        { get { return true; } }

        public bool IsValid()
        {
            return true;
        }

        public virtual void FillWithDefaultValue()
        {
        }
    }
}
