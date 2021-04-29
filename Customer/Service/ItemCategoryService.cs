using System.Collections.Generic;
using System.Linq;
using Customer.Dto;
using Customer.Models;
using ItemCategory = Customer.Models.ItemCategory;

namespace Customer.Service
{
    public class ItemCategoryService
    {
        DB_Entities db = new DB_Entities();

        public List<ItemCategoryDTO> GetAllCategories()
        {
            List<ItemCategoryDTO> list = new List<ItemCategoryDTO>();
            List<ItemCategory> itemCategories = db.ItemCategories.ToList();
            foreach (ItemCategory itemCategory in itemCategories)
            {
                ItemCategoryDTO data = new ItemCategoryDTO();
                data.categoryId = itemCategory.categoryId;
                data.name = itemCategory.name;
                list.Add(data);
            }

            return list;
        }
    }
}