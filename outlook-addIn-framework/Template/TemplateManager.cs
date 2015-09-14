using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using OAFramework.Configuration;
using OAFramework.User;

namespace OAFramework
{
    public static class TemplateManager
    {
        private static OAObjectsContext Context = OADBManager.Instance.DBContext;

        public static IList<EFTemplate> GetAllRootTemplates()
        {
            var result = new List<EFTemplate>();
            var findRootSqlQry = string.Format("SELECT TemplateId from dbo.Template where Parent_TemplateId is NULL");
            var roots = Context.Database.SqlQuery<int>(findRootSqlQry).ToList<int>();

            GetTemplateForRoots(roots, result);

            return result;
        }

        private static void GetTemplateForRoots(List<int> roots, List<EFTemplate> result)
        {
            foreach (var root in roots)
            {
                var children = GetChildrenOfRoot(root);
                var tree = PopulateTemplateTree(root, children);
                tree.SortChildren();
                result.Add(tree);
            }
        }

        private static IEnumerable<int> GetChildrenOfRoot(int root)
        {
            var childrenSqlQry = string.Format("EXEC Tree_GetTemplate {0}", root);
            return Context.Database.SqlQuery<int>(childrenSqlQry).ToList<int>();
        }

        private static EFTemplate PopulateTemplateTree(int root,IEnumerable<int> children)
        {
            return Context.Templates
                    .Include(x => x.Children)
                    .Include(x=>x.DataField)
                    .Include(x => x.DataField.ComboValues)
                    .Include(x => x.DataField.DataFieldGroup)
                    .Include(x => x.UserGroup)
                    .Where(s => s.TemplateId == root || children.Any(c => s.TemplateId == c))
                    .ToList()
                    .FirstOrDefault();
        }

        public static EFTemplate GetTemplateByName(string templateName)
        {
            var findRootSqlQry = string.Format("SELECT TemplateId from dbo.Template where ElementName = '{0}' and Parent_TemplateId is NULL",templateName);
            var root = Context.Database.SqlQuery<int>(findRootSqlQry).First();
            if (root != 0)
            {
                var children = GetChildrenOfRoot(root);
                return PopulateTemplateTree(root, children);                
            }
            return null;
        }

        public static IEnumerable<string> GetAllTemplateRootName()
        {
            return new List<string>();
        }

        public static EFTemplate GetDefaultTemplatesForUserGroup(EFUserGroup userGroup)
        {
            return GetTemplatesForUserGroup(userGroup).FirstOrDefault();
        }

        public static IList<EFTemplate> GetTemplatesForUserGroup(EFUserGroup userGroup)
        {
            var result = new List<EFTemplate>();
            var findRootSqlQry = string.Format("SELECT TemplateId from dbo.Template where UserGroupId = {0} and Parent_TemplateId is NULL",userGroup.UserGroupId);
            var roots = Context.Database.SqlQuery<int>(findRootSqlQry).ToList<int>();

            GetTemplateForRoots(roots, result);

            return result;
        }
    }
}
