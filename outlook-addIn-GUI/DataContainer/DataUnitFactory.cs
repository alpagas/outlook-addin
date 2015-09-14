using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using OAGUI.DataControl;
using OAFramework;

namespace OAGUI
{
    public static class DataUnitFactory
    {
        public static DataControl.DataContainer CreateDataUnitControl(IDataUnit dataUnit, bool editMode, DataContainerLayoutPanel panel)
        {
            var controlType = Type.GetType(dataUnit.ControlClassName);
            var result = Activator.CreateInstance(controlType)  as DataControl.DataContainer;
            result.Data = dataUnit;
            result.ShowEditItem = editMode;
            if (editMode)
            {
                result.UpClick += panel.OnUpClick;
                result.DownClick += panel.OnDownClick;
                result.DeleteClick += panel.OnDeleteClick;    
            }
            return result;
        }
        
    }
}
