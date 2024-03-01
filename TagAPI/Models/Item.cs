﻿namespace TagAPI.Models
{
    public class Item
    {
        public int ItemID { get; set; }
        public required string ItemName { get; set; } = string.Empty;
        public required int ItemPrice { get; set; }
        public required string Description { get; set; } = string.Empty;
    }
}
