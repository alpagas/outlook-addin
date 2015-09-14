using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Security.Principal;
using System.Text;
using System.Threading.Tasks;

using OAFramework.Configuration;
using OAFramework.User;

namespace OAFramework
{
    public class OAObjectsInitializer : DropCreateDatabaseAlways<OAObjectsContext>
    {
        protected override void Seed(OAObjectsContext context)
        {
            const string storeProc = @"CREATE PROCEDURE [dbo].[Tree_GetTemplate] (@Id int) AS
                                BEGIN
                                WITH Hierachy(ChildId, ParentId) AS (
                                SELECT ts.TemplateId, ts.Parent_TemplateId FROM dbo.Template ts
                                UNION ALL 
                                SELECT h.ChildId, ts.Parent_TemplateId FROM dbo.Template ts
                                INNER JOIN Hierachy h ON ts.TemplateId = h.ParentId) 
                                SELECT h.ChildId FROM Hierachy h WHERE h.ParentId = @Id
                                END";

            context.Database.ExecuteSqlCommand(storeProc);

            const string grantStoreProc = @"GRANT EXECUTE ON [dbo].[Tree_GetTemplate] TO public";
            context.Database.ExecuteSqlCommand(grantStoreProc);

            /*****************DataUnitBaseView******************/

            const string databaseviewQry = @"CREATE VIEW [dbo].[DataUnitBaseView]
AS
SELECT     dbo.DataUnit.CheckValue, dbo.DataUnit.SelectedValue, dbo.DataUnit.DateValue, dbo.DataUnit.NumberValue, dbo.DataUnit.TextValue, dbo.DataUnit.Discriminator, 
                      dbo.DataField.FieldName, dbo.AddInUserGroup.UserGroupName, dbo.Mail.Subject, dbo.Mail.MailScanUniqueId, dbo.Mail.StatusDate as MailDate, dbo.Mail.StatusUser
FROM         dbo.DataUnit INNER JOIN
                      dbo.MailGroup ON dbo.DataUnit.MailGroupId = dbo.MailGroup.MailGroupId INNER JOIN
                      dbo.Mail ON dbo.MailGroup.MailGroupId = dbo.Mail.MailGroupId INNER JOIN
                      dbo.DataField ON dbo.DataUnit.DataFieldId = dbo.DataField.DataFieldId INNER JOIN
                      dbo.AddInUserGroup ON dbo.Mail.UserGroupId = dbo.AddInUserGroup.UserGroupId";

            context.Database.ExecuteSqlCommand(databaseviewQry);
            
            const string structuredViewQry = @"CREATE VIEW [dbo].[StructuredView]
AS
SELECT     UserGroupName, StatusUser, MailDate, MailScanUniqueId, Subject, FieldName, CASE WHEN SelectedValue IS NOT NULL THEN SelectedValue WHEN DateValue IS NOT NULL 
                      THEN CAST(DateValue AS varchar(50)) WHEN TextValue IS NOT NULL THEN TextValue WHEN CheckValue IS NOT NULL THEN CAST(CheckValue AS varchar(50)) 
                      WHEN NumberValue IS NOT NULL THEN CAST(NumberValue AS varchar(50)) 
                      ELSE NULL END AS Value
FROM         dbo.DataUnitBaseView";

            context.Database.ExecuteSqlCommand(structuredViewQry);

            /*****************[MailGroupAssociationView]******************/

/*            const string associationQry = @"SELECT     dbo.Mail.MailScanId, dbo.MailGroup.MailGroupScanId, dbo.Mail.UserGroupId
                FROM         dbo.Mail INNER JOIN
                dbo.MailGroup ON dbo.Mail.MailGroupId = dbo.MailGroup.MailGroupId";

            context.Database.ExecuteSqlCommand(associationQry);
*/
            

            /*****************combo query******************/
            //const string comboQry = @"CREATE TABLE [dbo].[ComboQuery](
            //    [FieldName] [varchar](50) NOT NULL,
            //    [ComboQueryValue] [varchar](50) NOT NULL
            //    ) ON [PRIMARY]";
            //
            //context.Database.ExecuteSqlCommand(comboQry);
            //
            /****************UserGroup*************************/

            var userGroup1 = new EFUserGroup() { UserGroupName = "User Group 1" };
            var userGroup2 = new EFUserGroup() { UserGroupName = "User Group 2" };
            var userGroup3 = new EFUserGroup() { UserGroupName = "User Group 3" };

            /****************User*************************/

            var user1 = new EFUser() { UserName = WindowsIdentity.GetCurrent().Name };

            userGroup1.Users = new List<EFUser>() {user1};

            context.UserGroups.Add(userGroup1);
            
            /****************Field*************************/

            var groupfield0 = new EFDataFieldGroup() { FieldName = "Defaut User Group " };

            var field0 = new EFDataField()
            {
                FieldName = "Not registered user !",
                ControlType = FieldControlType.EFDataUnitLabel
            };
            var field01 = new EFDataField()
            {
                FieldName = "Please Contact Dev",
                ControlType = FieldControlType.EFDataUnitLabel
            };
            var field02 = new EFDataField()
            {
                FieldName = "your.name@mail.com",
                ControlType = FieldControlType.EFDataUnitLink
            };

            var groupfield1 = new EFDataFieldGroup() { FieldName = "Demo Field Group " };

            var field1 = new EFDataField() { FieldName = "Info 0", ControlType = FieldControlType.EFDataUnitDate, IsLargeControl = false };

            var field2 = new EFDataField() { FieldName = "Info 1", ControlType = FieldControlType.EFDataUnitComboQuery, IsLargeControl = false};
            var field3 = new EFDataField() { FieldName = "Info 1", ControlType = FieldControlType.EFDataUnitComboQuery, IsLargeControl = false };
            var field4 = new EFDataField() { FieldName = "Info 3", ControlType = FieldControlType.EFDataUnitText, IsLargeControl = false };
            var field5 = new EFDataField() { FieldName = "Info 4", ControlType = FieldControlType.EFDataUnitComboQuery, IsLargeControl = false };
            var field6 = new EFDataField() { FieldName = "Info 5", ControlType = FieldControlType.EFDataUnitComboQuery, IsLargeControl = false };
            var field7 = new EFDataField() { FieldName = "Info 6", ControlType = FieldControlType.EFDataUnitComboQuery, IsLargeControl = false };
            var field8 = new EFDataField() { FieldName = "Info 7", ControlType = FieldControlType.EFDataUnitComboQuery, IsLargeControl = false };
            var field9 = new EFDataField() { FieldName = "Info 8", ControlType = FieldControlType.EFDataUnitComboQuery, IsLargeControl = false };
            
            var field10 = new EFDataField() { FieldName = "Info 9", ControlType = FieldControlType.EFDataUnitComboQuery, IsLargeControl = false };
            var field11 = new EFDataField() { FieldName = "Info 10", ControlType = FieldControlType.EFDataUnitComboQuery, IsLargeControl = false };
            var field12 = new EFDataField() { FieldName = "Info 11", ControlType = FieldControlType.EFDataUnitText, IsLargeControl = false };
            var field13= new EFDataField() { FieldName = "Info 12", ControlType = FieldControlType.EFDataUnitComboQuery, IsLargeControl = false };
            var field14 = new EFDataField() { FieldName = "Info 13", ControlType = FieldControlType.EFDataUnitComboQuery, IsLargeControl = false };

            var field15 = new EFDataField() { FieldName = "Info 14", ControlType = FieldControlType.EFDataUnitNumber, IsLargeControl = false };
            var field16 = new EFDataField() { FieldName = "Info 15", ControlType = FieldControlType.EFDataUnitNumber, IsLargeControl = false };
            
            var field17 = new EFDataField() { FieldName = "Info 16", ControlType = FieldControlType.EFDataUnitNumber, IsLargeControl = false };
            var field18 = new EFDataField() { FieldName = "Info 17", ControlType = FieldControlType.EFDataUnitNumber, IsLargeControl = false };
            var field19 = new EFDataField() { FieldName = "Info 18", ControlType = FieldControlType.EFDataUnitNumber, IsLargeControl = false };
            var field20 = new EFDataField() { FieldName = "Info 19", ControlType = FieldControlType.EFDataUnitNumber, IsLargeControl = false };
            var field21 = new EFDataField() { FieldName = "Info 20", ControlType = FieldControlType.EFDataUnitText, IsLargeControl = false };
            var field22 = new EFDataField() { FieldName = "Info 21", ControlType = FieldControlType.EFDataUnitNumber, IsLargeControl = false };
            var field23 = new EFDataField() { FieldName = "Info 22", ControlType = FieldControlType.EFDataUnitText, IsLargeControl = false };
            
            groupfield0.DataFields = new List<EFDataField>() { field0, field01, field02 };
            groupfield1.DataFields = new List<EFDataField>()
                                         {
                                             field1,
                                             field2,
                                             field3,
                                             field4,
                                             field5,
                                             field6,
                                             field7,
                                             field8,
                                             field9,
                                             field10,
                                             field11,
                                             field12,
                                             field13,
                                             field14,
                                             field15,
                                             field16,
                                             field17,
                                             field18,
                                             field19,
                                             field20,
                                             field21,
                                             field22,
                                             field23
                                         };

            context.DataFieldGroups.Add(groupfield0);
            context.DataFieldGroups.Add(groupfield1);

            /****************Template 1*************************/

            var rootNode1 = new EFTemplate()
            {
                ElementName = "Demo Template",
                DataField = field0,
                UserGroup = userGroup1
            }; //technical root

            var templateNode1 = new EFTemplate()
            {
                ElementName = field1.FieldName,
                DataField = field1,
                Parent = rootNode1,
                UserGroup = userGroup1
            };
            var templateNode2 = new EFTemplate()
            {
                ElementName = field2.FieldName,
                DataField = field2,
                Parent = rootNode1,
                UserGroup = userGroup1
            };
            var templateNode3 = new EFTemplate()
            {
                ElementName = field3.FieldName,
                DataField = field3,
                Parent = rootNode1,
                UserGroup = userGroup1
            };
            var templateNode4 = new EFTemplate()
            {
                ElementName = field4.FieldName,
                DataField = field4,
                Parent = rootNode1,
                UserGroup = userGroup1
            };
            var templateNode5 = new EFTemplate()
            {
                ElementName = field5.FieldName,
                DataField = field5,
                Parent = rootNode1,
                UserGroup = userGroup1
            };
            var templateNode6 = new EFTemplate()
            {
                ElementName = field6.FieldName,
                DataField = field6,
                Parent = rootNode1,
                UserGroup = userGroup1
            };
            var templateNode7 = new EFTemplate()
            {
                ElementName = field7.FieldName,
                DataField = field7,
                Parent = rootNode1,
                UserGroup = userGroup1
            };
            var templateNode8 = new EFTemplate()
            {
                ElementName = field8.FieldName,
                DataField = field8,
                Parent = rootNode1,
                UserGroup = userGroup1
            };
            var templateNode9 = new EFTemplate()
            {
                ElementName = field9.FieldName,
                DataField = field9,
                Parent = rootNode1,
                UserGroup = userGroup1
            };
            var templateNode10 = new EFTemplate()
            {
                ElementName = field10.FieldName,
                DataField = field10,
                Parent = rootNode1,
                UserGroup = userGroup1
            };
            var templateNode11 = new EFTemplate()
            {
                ElementName = field11.FieldName,
                DataField = field11,
                Parent = rootNode1,
                UserGroup = userGroup1
            };
            var templateNode12 = new EFTemplate()
            {
                ElementName = field12.FieldName,
                DataField = field12,
                Parent = rootNode1,
                UserGroup = userGroup1
            };
            var templateNode13 = new EFTemplate()
            {
                ElementName = field13.FieldName,
                DataField = field13,
                Parent = rootNode1,
                UserGroup = userGroup1
            };
            var templateNode14 = new EFTemplate()
            {
                ElementName = field14.FieldName,
                DataField = field14,
                Parent = rootNode1,
                UserGroup = userGroup1
            };
            var templateNode15 = new EFTemplate()
            {
                ElementName = field15.FieldName,
                DataField = field15,
                Parent = rootNode1,
                UserGroup = userGroup1
            };
            var templateNode16 = new EFTemplate()
            {
                ElementName = field16.FieldName,
                DataField = field16,
                Parent = rootNode1,
                UserGroup = userGroup1
            };
            var templateNode17 = new EFTemplate()
            {
                ElementName = field17.FieldName,
                DataField = field17,
                Parent = rootNode1,
                UserGroup = userGroup1
            };
            var templateNode18 = new EFTemplate()
            {
                ElementName = field18.FieldName,
                DataField = field18,
                Parent = rootNode1,
                UserGroup = userGroup1
            };
            var templateNode19 = new EFTemplate()
            {
                ElementName = field19.FieldName,
                DataField = field19,
                Parent = rootNode1,
                UserGroup = userGroup1
            };
            var templateNode20 = new EFTemplate()
            {
                ElementName = field20.FieldName,
                DataField = field20,
                Parent = rootNode1,
                UserGroup = userGroup1
            };
            var templateNode21 = new EFTemplate()
            {
                ElementName = field21.FieldName,
                DataField = field21,
                Parent = rootNode1,
                UserGroup = userGroup1
            };
            var templateNode22 = new EFTemplate()
            {
                ElementName = field22.FieldName,
                DataField = field22,
                Parent = rootNode1,
                UserGroup = userGroup1
            };

            var templateNode23 = new EFTemplate()
            {
                ElementName = field23.FieldName,
                DataField = field23,
                Parent = rootNode1,
                UserGroup = userGroup1
            };


            context.Templates.Add(rootNode1);
            context.SaveChanges();
            context.Templates.Add(templateNode1);
            context.SaveChanges();
            context.Templates.Add(templateNode2);
            context.SaveChanges();
            context.Templates.Add(templateNode3);
            context.SaveChanges();
            context.Templates.Add(templateNode4);
            context.SaveChanges();
            context.Templates.Add(templateNode5);
            context.SaveChanges();
            context.Templates.Add(templateNode6);
            context.SaveChanges();
            context.Templates.Add(templateNode7);
            context.SaveChanges();
            context.Templates.Add(templateNode8);
            context.SaveChanges();
            context.Templates.Add(templateNode9);
            context.SaveChanges();
            context.Templates.Add(templateNode10);
            context.SaveChanges();
            context.Templates.Add(templateNode11);
            context.SaveChanges();
            context.Templates.Add(templateNode12);
            context.SaveChanges();
            context.Templates.Add(templateNode13);
            context.SaveChanges();
            context.Templates.Add(templateNode14);
            context.SaveChanges();
            context.Templates.Add(templateNode15);
            context.SaveChanges();
            context.Templates.Add(templateNode16);
            context.SaveChanges();
            context.Templates.Add(templateNode17);
            context.SaveChanges();
            context.Templates.Add(templateNode18);
            context.SaveChanges();
            context.Templates.Add(templateNode19);
            context.SaveChanges();
            context.Templates.Add(templateNode20);
            context.SaveChanges();
            context.Templates.Add(templateNode21);
            context.SaveChanges();
            context.Templates.Add(templateNode22);
            context.SaveChanges();
            context.Templates.Add(templateNode23);
            context.SaveChanges();

            /****************Template 2*************************/


            /****************Defautl Template*************************/

            var rootNode3 = new EFTemplate()
            {
                ElementName = "Defaut Template",
                DataField = field0,
                UserGroup = userGroup3
            };

            var templateNode09 = new EFTemplate()
            {
                ElementName = field0.FieldName,
                DataField = field0,
                Parent = rootNode3,
                UserGroup = userGroup3
            };
            var templateNode010 = new EFTemplate()
            {
                ElementName = field01.FieldName,
                DataField = field01,
                Parent = rootNode3,
                UserGroup = userGroup3
            };
            var templateNode011 = new EFTemplate()
            {
                ElementName = field02.FieldName,
                DataField = field02,
                Parent = rootNode3,
                UserGroup = userGroup3
            };

            context.Templates.Add(rootNode3);
            context.SaveChanges();
            context.Templates.Add(templateNode09);
            context.SaveChanges();
            context.Templates.Add(templateNode010);
            context.SaveChanges();
            context.Templates.Add(templateNode011);
            context.SaveChanges();
            base.Seed(context);

            /**********Defautlt values for combo************/
            
            const string comboValueQry = @"insert into FieldComboValue (ComboValue, DataFieldId)
            select 'toto',DataFieldId From DataField where FieldName ='Info 1' union 
            select 'tata',DataFieldId From DataField where FieldName ='Info 2' ";

            context.Database.ExecuteSqlCommand(comboValueQry);
        }
    }
}
