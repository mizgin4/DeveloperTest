using System;
using System.Collections.Generic;

#nullable disable

namespace AdaTestProjesi.DBModels
{
    public partial class CartItem
    {
        public int Id { get; set; }
        public int? CartId { get; set; }
        public decimal? Total { get; set; }
        public string Message { get; set; }

        public virtual Cart Cart { get; set; }
    }
}
