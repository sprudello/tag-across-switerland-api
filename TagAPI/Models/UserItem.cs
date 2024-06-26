﻿using System.Text.RegularExpressions;

namespace TagAPI.Models
{
    public class UserItem
    {
        public int Id { get; set; }
        public required int UserID { get; set; }
        public required int ItemID { get; set; }
        public required DateTime PurchaseDate { get; set; }

        public User User { get; set; }
        public Item Item { get; set; }
    }
}
