using AdaTestProjesi.DBModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AdaTestProjesi.Services
{
    public class TestService : ITestService
    {
        private readonly AdaInterviewDBFContext _context;
        private readonly Random _random = new Random();

        public TestService(AdaInterviewDBFContext context)
        {
            _context = context;

        }
        
        public int RandomNumber(int min, int max)
        {
            return _random.Next(min, max);
        }
        public void TestVerisiOlustur(int musteriAdet, int sepetAdet)
        {
            //Musteri ekleme
            string[] maleNames = new string[10] { "aaron", "abdul", "abe", "abel", "abraham", "adam", "adan", "adolfo", "adolph", "adrian" };
            string[] cityNames = new string[10] { "Ankara", "İstanbul", "İzmir", "Bursa", "Edirne", "Konya", "Antalya", "Diyarbakır", "Van", "Rize" };
            List<int> IdList = new List<int>();
            List<int> CartIdList = new List<int>();

           for(int i=0; i < musteriAdet; i++)
            {
                Customer customer = new Customer();
                customer.Name = maleNames[RandomNumber(0, maleNames.Length)];
                customer.LastName = maleNames[RandomNumber(0, maleNames.Length)];
                customer.City = cityNames[RandomNumber(0, cityNames.Length)];
                _context.Customers.Add(customer);
                _context.SaveChanges();
                IdList.Add(customer.Id);
            }

           //Cart ve Item EKleme
            List<Cart> cartList= new List<Cart>();
            for (int i = 0; i < sepetAdet; i++)
            {
                Cart cart = new Cart();
                cart.CustomerId = IdList[RandomNumber(0,IdList.Count)];
                _context.Carts.Add(cart);
                _context.SaveChanges();
                CartIdList.Add(cart.Id);
                for (int j = 0; j < RandomNumber(1, 6); j++)
                {
                    CartItem cartItem = new CartItem();
                    cartItem.CartId = cart.Id;
                    cartItem.Total = RandomNumber(100, 1001);
                    cartItem.Message = "Msg";
                    _context.CartItems.Add(cartItem);
                    _context.SaveChanges();

                }

            }


        }
    }
}
