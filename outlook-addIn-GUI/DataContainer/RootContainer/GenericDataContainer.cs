using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using OAFramework;
using System.Windows.Forms;

namespace OAGUI.DataControl
{    
    public class GenericLargeDataContainer<T> : LargeDataContainer where T : IDataUnit
    {
        public T TypedData
        {
            get
            {
                return (T)Data;
            }
        }
        
    }

    public class GenericSmallDataContainer<T> : SmallDataContainer where T : IDataUnit
    {
        public T TypedData
        {
            get
            {
                return (T)Data;
            }
        }

    }
}
