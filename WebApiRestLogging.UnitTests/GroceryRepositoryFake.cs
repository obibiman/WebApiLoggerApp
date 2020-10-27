using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using WebApiRestLogging.Models;
using WebApiRestLogging.Services;

namespace WebApiRestLogging.UnitTests
{
    public class GroceryRepositoryFake : IGroceryRepository
    {
        private readonly IEnumerable<Grocery> _lstGroceries;

        public GroceryRepositoryFake()
        {
            _lstGroceries = new List<Grocery>
            {
                new Grocery{Id = 200, CreatedBy="Fake", DateCreated=DateTime.Parse("05/11/2020"), DateModified=null, Department="Bakery",Description="Glazed Donuts", ModifiedBy=null,Name="Dozen Donuts", Quantity=13, UnitPrice=5.05m},
                new Grocery{Id = 200, CreatedBy="Randy Nunn", DateCreated=DateTime.Parse("11/11/2019"), DateModified=null, Department="Bakery",Description="Glazed Donuts", ModifiedBy=null,Name="Wheat Bread", Quantity=3, UnitPrice=5.05m},
                new Grocery{Id = 200, CreatedBy="Maurice", DateCreated=DateTime.Parse("03/21/2020"), DateModified=null, Department="Dairy",Description="Yogurt", ModifiedBy=null,Name="Frozen Yogurt", Quantity=1, UnitPrice=5.05m}
            };
        }

        public Task<Grocery> CreateAsync(Grocery grocery)
        {
            throw new NotImplementedException();
        }

        public Task DeleteAsync(Grocery grocery)
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<Grocery>> GetAllAsync()
        {
            throw new NotImplementedException();
            //List<Grocery> grocerySku = _ctxt.Groceries.ToListAsync();
            //return grocerySku;
        }

        //public async Task<IEnumerable<Grocery>> GetAllAsync()
        //{
        //    IEnumerable<Grocery> _lstGroceries = new List<Grocery>
        //    {
        //        new Grocery{Id = 200, CreatedBy="Fake", DateCreated=DateTime.Parse("05/11/2020"), DateModified=null, Department="Bakery",Description="Glazed Donuts", ModifiedBy=null,Name="Dozen Donuts", Quantity=13, UnitPrice=5.05m},
        //        new Grocery{Id = 200, CreatedBy="Randy Nunn", DateCreated=DateTime.Parse("11/11/2019"), DateModified=null, Department="Bakery",Description="Glazed Donuts", ModifiedBy=null,Name="Wheat Bread", Quantity=3, UnitPrice=5.05m},
        //        new Grocery{Id = 200, CreatedBy="Maurice", DateCreated=DateTime.Parse("03/21/2020"), DateModified=null, Department="Dairy",Description="Yogurt", ModifiedBy=null,Name="Frozen Yogurt", Quantity=1, UnitPrice=5.05m}
        //    };
        //    //throw new NotImplementedException();
        //    var grocerySk = await _lstGroceries.ToListAsync();
        //    return grocerySk;
        //}

        public Task<Grocery> GetByIdAsync(int Id)
        {
            throw new NotImplementedException();
        }

        public Task<Grocery> UpdateAsync(Grocery grocery)
        {
            throw new NotImplementedException();
        }
    }
}