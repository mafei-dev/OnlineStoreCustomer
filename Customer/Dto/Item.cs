using System;

namespace Customer.Dto
{
    public class Item
    {
        public string itemCode { get; set; }
        public string name { get; set; }
        public decimal unitPrice { get; set; }
        public int itemQty { get; set; }
        public int categoryId { get; set; }
        public byte[] itemImage { get; set; }
    }

    public class ItemViewDTO : Item
    {
        public String categoryName { get; set; }
    }
}