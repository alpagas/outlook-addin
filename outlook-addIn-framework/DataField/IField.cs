using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace OAFramework
{
    public interface IField
    {
        string FieldName { get; set; }
        IDataUnit CreateDataUnit(bool createDBValue);
        IList<IField> Children { get; }
    }
}
