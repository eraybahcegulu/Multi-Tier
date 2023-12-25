using BLL.ManagerServices.Abstracts;
using DAL.Repositories.Abstracts;
using ENTITIES.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.ManagerServices.Concretes
{
    public class CategoryManager : BaseManager<Category>, ICategoryManager
    {
        ICategoryRepository _catRepository;

        public CategoryManager(ICategoryRepository catRepository) : base(catRepository)
        {
            _catRepository = catRepository;
        }

        public async Task<Category> GetCategoryByIdAsync(int categoryId)
        {
            return await _catRepository.GetCategoryByIdAsync(categoryId);
        }
    }
}