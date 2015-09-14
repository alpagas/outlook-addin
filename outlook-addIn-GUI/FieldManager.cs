using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using OAFramework.Configuration;
using OAGUI.DataControl;
using OAFramework;

namespace OAGUI
{
    public static class FieldManager
    {
        public static void BuildFieldTree(TreeView treeview, IEnumerable<IField> rootFields)
        {
            treeview.Nodes.Clear();
            foreach (var rootField in rootFields)
            {
                var node = new TreeNode(rootField.FieldName);
                node.Tag = rootField;
                BuildFieldNode(node,rootField);
                treeview.Nodes.Add(node);
            }
            treeview.ExpandAll();
        }

        private static void BuildFieldNode(TreeNode parentNode, IField parentField)
        {
            foreach (var childfield in parentField.Children)
            {
                var node = new TreeNode(childfield.FieldName);
                node.Tag = childfield;
                parentNode.Nodes.Add(node);
                BuildFieldNode(node,childfield);
            }
        }

        public static EFTemplate BuildTemplateFromDataContainer(IEnumerable<DataControl.DataContainer> dataContainer)
        {
            var root = new EFTemplate();
            root.ElementName = "Root Template";
            root.OrderIndex = 1;
            int idx = 2;
            foreach (var container in dataContainer)
            {
                idx++;
                var dataUnit = container.Data;
                var field = dataUnit.DataField;
                var tmpl = new EFTemplate();
                tmpl.DataField = field;
                tmpl.ElementName = field.FieldName;
                tmpl.Parent = root;
                tmpl.OrderIndex = idx;
            }
            return root;
        }

        public static IEnumerable<EFDataUnit> ExtractDataUnitFromPanel(DataContainerLayoutPanel panel)
        {
            var result = new List<EFDataUnit>();
            foreach (var container in panel.Controls.OfType<DataControl.DataContainer>())
            {
                container.UpdateDataUnitWithControlValue();
                if (container.Data.IsValid()) result.Add(container.Data as EFDataUnit);
            }
            return result;
        }

        public static void BuildDataContainerFromTemplate(EFTemplate template, DataContainerLayoutPanel panel, bool editMode)
        {
            panel.Controls.Clear();
            UpdateLayoutPanelFromTemplate(template, panel, editMode);
        }

        private static void UpdateLayoutPanelFromTemplate(EFTemplate template, DataContainerLayoutPanel panel, bool editMode)
        {
            foreach (var tmpl in template.Children)
            {
                UpdateLayoutPanel(tmpl.DataField, panel, editMode);
                UpdateLayoutPanelFromTemplate(tmpl, panel, editMode);
            }
        }

        public static void UpdateLayoutPanel(IField field, DataContainerLayoutPanel panel, bool editMode)
        {
            var dataUnit = field.CreateDataUnit(!editMode);
            var dataUnitControl = DataUnitFactory.CreateDataUnitControl(dataUnit, editMode, panel);
            panel.Controls.Add(dataUnitControl);
        }

        public static ICollection<EFDataFieldGroup> GetAllDataFieldGroups()
        {
            return OADBManager.Instance.DBContext.DataFieldGroups.Include("DataFields").ToList();
        }
    }
}
