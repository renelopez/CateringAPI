﻿using System.Data.Entity;
using Catering.Data.DataLayer;
using Catering.Data.Models;
using Catering.Data.Repositories.Contracts;

namespace Catering.Data.Repositories.Implementation
{
    public class DishRepository:GenericRepository<Dish>,IDishRepository
    {
        public DishRepository(DbContext context) : base(context)
        {
        }
    }
}
