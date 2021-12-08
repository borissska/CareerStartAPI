﻿using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using WebApi.Models;
using WebApi.Repository;

namespace WebApi.Repositories
{
    public class CompanyRepository : IRepository<Company>
    {
        private readonly ApplicationContext context;
        public CompanyRepository(ApplicationContext Context)
        {
            context = Context;
        }
        public async Task<Company> Create(Company obj)
        {
            await context.Companies.AddAsync(obj);
            await context.SaveChangesAsync();

            return obj;
        }

        public async Task<bool> Delete(int id)
        {
            Company company = await context.Companies.FindAsync(id);

            if (company != null)
            {
                context.Companies.Remove(company);
                await context.SaveChangesAsync();

                return true;
            }

            return false;
        }

        public async Task<IEnumerable<Company>> Get()
        {
            return await context.Companies.ToListAsync();
        }

        public async Task<Company> Get(int id)
        {
            return await context.Companies.FindAsync(id);
        }

        public async Task<Company> Update(Company newCompany)
        {
            context.Entry(newCompany).State = EntityState.Modified;
            await context.SaveChangesAsync();
            return newCompany;
        }
    }
}
