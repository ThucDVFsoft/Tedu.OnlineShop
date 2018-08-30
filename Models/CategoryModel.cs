using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Models.Framework;

namespace Models
{
    public class CategoryModel
    {
        private OnlineShopDbContext context = null;

        public CategoryModel()
        {
            context = new OnlineShopDbContext();
        }

        public IEnumerable<Category> GetAll()
        {
            var categories = context.Database.SqlQuery<Category>("Sp_Category_GetAll");
            return categories;
        }

        public int Create(Category category)
        {
            var parameters = new SqlParameter[]
            {
                new SqlParameter("@Name", category.Name),
                new SqlParameter("@Alias", category.Alias),
                new SqlParameter("@ParentID", category.ParentID),
                new SqlParameter("@Order", category.Order),
                new SqlParameter("@Status", category.Status),
            };
            try
            {
                int res = context.Database.ExecuteSqlCommand("Sp_Category_Insert @Name,@Alias,@ParentID,@Order,@Status", parameters);
                return res;
            }
            catch(Exception ex)
            {
                return -1;
            }
        }
    }
}
