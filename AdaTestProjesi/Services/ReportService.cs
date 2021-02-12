using AdaTestProjesi.DBModels;
using AdaTestProjesi.Models.Dto;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AdaTestProjesi.Services
{
    public class ReportService : IReportService
    {
        private readonly AdaInterviewDBFContext _context;

        public ReportService(AdaInterviewDBFContext context)
        {
            _context = context;

        }
        public IEnumerable<ReportDto> ReturnReport()
        {
            List<CartItem> totalCartItem = _context.CartItems.Include("Cart").OrderByDescending(s=>s.Cart).ToList();
            Dictionary<int?, int?> totalCartNumbers = new Dictionary<int?, int?>();

            foreach (var i in totalCartItem)
            {
                if (!totalCartNumbers.ContainsKey(i.CartId))
                {
                    totalCartNumbers[i.CartId] =1;

                }
                totalCartNumbers[i.CartId] += 1;
            }

            List<int?> cartIdList = totalCartItem.Select(s => s.CartId).Distinct().ToList();
            Dictionary<int?,int?> totalAmounthDic = new Dictionary<int?, int?>();
            foreach(var cartItem in totalCartItem)
            {
                if (!totalAmounthDic.ContainsKey(cartItem.CartId))
                {
                    totalAmounthDic[cartItem.CartId] =(int?) cartItem.Total;

                }
                totalAmounthDic[cartItem.CartId] += (int)cartItem.Total;
            }

            List<ReportDto> reportDtoList = new List<ReportDto>();

            List<Cart> cartList = _context.Carts.ToList();
            foreach(Cart cart in cartList)
            {

            }
            
            foreach(KeyValuePair<int?,int?> keyValuePair in totalAmounthDic)
            {
                ReportDto reportDto = new ReportDto();
                Cart cart = _context.Carts.Include("Customer").Where(s => s.Id == keyValuePair.Key).SingleOrDefault();
                reportDto.CityName = cart.Customer.City;
                reportDto.totalAmounth = (int) keyValuePair.Value;
                reportDto.totalCartNumber = (int)totalCartNumbers[cart.Id];
                if (!reportDtoList.Any(s => s.CityName== reportDto.CityName))
                {
                    reportDtoList.Add(reportDto);
                }
                else
                {
                    reportDtoList.First(s => s.CityName == reportDto.CityName).totalAmounth+=(int)keyValuePair.Value ;
                }
                
            }


            return reportDtoList.OrderByDescending(s=>s.totalCartNumber);
           


            


        }
    }
}
