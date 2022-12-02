using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WeVolunteer.Core.Services.Category
{
    public interface ICategoryService
    {
        List<Infrastructure.Data.Entities.Category> GetAll();
        int GetCategoryIdByCategoryName(string categoryName);
        bool CategoryExists(int categoryId);
        IEnumerable<string> AllCategoriesNames();
        IEnumerable<string> MineCategoriesNames(string userId);
    }
}
