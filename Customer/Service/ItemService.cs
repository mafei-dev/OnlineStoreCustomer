using System.Collections.Generic;
using System.Linq;
using Customer.Dto;
using Customer.Models;

namespace Customer.Service
{
    public class ItemService
    {
        DB_Entities objEntity = new DB_Entities();

        public List<ItemViewDTO> GetItemForView(string categoryId)
        {
            if (categoryId.Equals("0"))
            {
                return objEntity.Items.Join(
                    objEntity.ItemCategories,
                    item => item.categoryId,
                    category => category.categoryId,
                    (item, category) => new ItemViewDTO
                    {
                        itemCode = item.itemCode,
                        name = item.name,
                        unitPrice = item.unitPrice,
                        categoryName = category.name,
                        categoryId =category.categoryId
                    }
                ).Take(10).ToList();
            }
            else
            {
                return objEntity.Items.Join(
                    objEntity.ItemCategories,
                    item => item.categoryId,
                    category => category.categoryId,
                    (item, category) => new ItemViewDTO
                    {
                        itemCode = item.itemCode,
                        name = item.name,
                        unitPrice = item.unitPrice,
                        categoryName = category.name,
                        categoryId =category.categoryId
                    }
                ).Where(dto => dto.categoryId == categoryId).Take(10).ToList();
            }
        }
    }
}