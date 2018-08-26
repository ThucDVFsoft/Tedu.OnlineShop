using System;
using System.Collections.Generic;
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
    }
}
