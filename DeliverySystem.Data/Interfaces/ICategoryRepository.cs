using DeliverySystem.Data.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace DeliverySystem.Data.Interfaces
{
    public interface ICategoryRepository
    {
        void Add(TestCategories category);
        void Delete(int id);
        void Update(TestCategories category);
        TestCategories GetById(int id);
        List<TestCategories> GetAll();
    }
}
