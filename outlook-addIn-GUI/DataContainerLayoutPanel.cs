using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using OAGUI.DataControl;

namespace OAGUI
{
    public class DataContainerLayoutPanel : FlowLayoutPanel
    {
        public  void OnUpClick(object sender, EventArgs e)
        {
            var control = sender as DataControl.DataContainer;
            if (control != null)
            {
                int idx = Controls.GetChildIndex(control);
                if (idx > 0)
                {
                    int idxprev = idx-1;
                    Controls.SetChildIndex(control,idxprev);
                    UpdateDataUnitControl();
                }
            }
        }

        public void OnDownClick(object sender, EventArgs e)
        {
            var control = sender as DataControl.DataContainer;
            if (control != null)
            {
                int idx = Controls.GetChildIndex(control);
                if (idx < Controls.Count-1)
                {
                    int idxprev = idx + 1;
                    Controls.SetChildIndex(control, idxprev);
                    UpdateDataUnitControl();
                }
            }
        }

        public void OnDeleteClick(object sender, EventArgs e)
        {
            var control = sender as DataControl.DataContainer;
            if (control != null)
            {
                Controls.Remove(control);
                UpdateDataUnitControl();
            }
        }

        public void UpdateDataUnitControl()
        {
            if (Controls.Count == 1)
            {
                var crtl = Controls[0] as DataControl.DataContainer;
                crtl.EnableUp = false;
                crtl.EnableDown = false;
            }
            else
            {
                for (int i = 0; i < Controls.Count; i++)
                {
                    var crtl = Controls[i] as DataControl.DataContainer;
                    if (i == 0)
                    {
                        crtl.EnableUp = false;
                        crtl.EnableDown = true;
                    }
                    else if (i == Controls.Count - 1)
                    {
                        crtl.EnableUp = true;
                        crtl.EnableDown = false;
                    }
                    else
                    {
                        crtl.EnableUp = true;
                        crtl.EnableDown = true;
                    }
                }
            }
        }
    }
}
