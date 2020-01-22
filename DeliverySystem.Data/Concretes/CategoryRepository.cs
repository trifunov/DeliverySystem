using DeliverySystem.Data.Interfaces;
using DeliverySystem.Data.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;

namespace DeliverySystem.Data.Concretes
{
    public class CategoryRepository : ICategoryRepository
    {
        private readonly DeliverySystemContext _context;

        public CategoryRepository(DeliverySystemContext context)
        {
            _context = context;
        }

        public void Add(TestCategories category)
        {
            _context.TestCategories.Add(category);
            _context.SaveChanges();
        }

        public void Delete(int id)
        {
            var candidate = _context.TestCategories.Find(id);

            if (candidate != null)
            {
                _context.TestCategories.Remove(candidate);
                _context.SaveChanges();
            }
            else
            {
                throw new Exception("Category not found");
            }
        }

        public void Update(TestCategories categoryInput)
        {
            var category = _context.TestCategories.Find(categoryInput.Id);

            if (category != null)
            {
                category.Name = categoryInput.Name;
                _context.SaveChanges();
            }
            else
            {
                throw new Exception("Category not found");
            }
        }

        public TestCategories GetById(int id)
        {
            var candidate = _context.TestCategories.Find(id);

            if (candidate != null)
            {
                return candidate;
            }
            else
            {
                throw new Exception("Category not found");
            }
        }

        public List<TestCategories> GetAll()
        {
            return _context.TestCategories.ToList();
        }
    }
}
