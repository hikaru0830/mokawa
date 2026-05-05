using Mkw.Domain.Entities;
using Mkw.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace Mkw.Application.ViewModelServices
{
    public class Home
    {
        private readonly IUnitOfWork _mkwDb;
        public Home(IUnitOfWork mkwDb)
        {
            _mkwDb = mkwDb;
        }

        public async Task Test()
        {
            //var product = new Product
            //{
            //    Id = Guid.NewGuid(),
            //    ProductCode = "P0001",
            //    ProductName = "測試商品",
            //    UnitPrice = 100,
            //    CreateAt = DateTime.Now,
            //    CreatorId = Guid.NewGuid(),
            //};
            //await _mkwDb.Insert(product);
            var product = new Product
            {
                Id = Guid.Parse("99bb179d-8b60-498d-94ae-218d40b2a10b"),
                ProductName = "測試商品2",
            };
            await _mkwDb.PatchUpdate(product);
        }
    }
}
