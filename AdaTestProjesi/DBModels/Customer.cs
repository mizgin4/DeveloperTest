using System;
using System.Collections.Generic;

#nullable disable

namespace AdaTestProjesi.DBModels
{
    public partial class Customer
    {
        public Customer()
        {
            Carts = new HashSet<Cart>();
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public string LastName { get; set; }
        public string City { get; set; }

        public virtual ICollection<Cart> Carts { get; set; }
    }
}
