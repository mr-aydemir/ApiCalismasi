using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using VatanAPI.Domain.Repositories;
using VatanAPI.Persistence.Contexts;
using VatanAPI.Persistence.Repositories;
using VatanAPI.Core.Security.Hashing;
using VatanAPI.Security.Hashing;
using Xunit;
using VatanAPI.Domain.Models;
using System.Collections.ObjectModel;
using System.Threading.Tasks;

namespace VatanAPITest.Persistence.Repositories
{
    public class CategoryRepositoryTests
    {
        static AppDbContext AppDbContext = new AppDbContext( new DbContextOptions<AppDbContext>());
        private ICategoryRepository _categoryRepository = new CategoryRepository(AppDbContext);


        [Fact]
        public async Task Should_Find_Existing_User_By_Email()
        {

            await _categoryRepository.AddAsync(new Category() { Id = 100, Name = "Test", Products = new Collection<Product>() });
            var category = await _categoryRepository.FindByIdAsync(100);

            Assert.NotNull(category);
            Assert.Equal(100, category.Id);
        }
    }
}
