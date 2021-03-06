﻿using ObjectRepository;
using Shop.DAL.DbLayer;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shop.DAL.Repository
{
    public class ProductRepository : CommonRepository<Product, int>
    {
        public ProductRepository(DbContext context) : base(context)
        {
        }
    }
}
