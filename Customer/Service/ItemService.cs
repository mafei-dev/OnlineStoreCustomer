using System.Collections.Generic;
using System.Linq;
using Customer.Dto;
using Customer.Models;

namespace Customer.Service
{
    public class ItemService
    {
        DB_Entities objEntity = new DB_Entities();

        public List<ItemViewDTO> GetItemForView()
        {
            return objEntity.Items.Join(
                objEntity.ItemCategories,
                item => item.categoryId,
                category => category.categoryId,
                (item, category) => new ItemViewDTO
                {
                    itemCode = item.itemCode,
                    name = item.name,
                    categoryName = category.name,
                }
            ).Take(10).ToList();
        }
    }
}