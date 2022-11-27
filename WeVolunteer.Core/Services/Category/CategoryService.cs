﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WeVolunteer.Core.Services.Category
{
    public class CategoryService : ICategoryService
    {
        private readonly IRepository repository;

        public CategoryService(IRepository _repository)
        {
            this.repository = _repository;
        }

        public bool CategoryExists(int categoryId)
        {
            return this.repository.All<Infrastructure.Data.Entities.Category>(c => c.Id == categoryId).ToList().First() != null;
        }

        public int GetCategoryIdByCategoryName(string categoryName)
        {
            return this.repository.All<Infrastructure.Data.Entities.Category>(c => c.Name == categoryName).ToList().First().Id;
        }

        List<Infrastructure.Data.Entities.Category> ICategoryService.GetAll()
        {
            return this.repository.All<Infrastructure.Data.Entities.Category>().ToList();
        }
    }
}
