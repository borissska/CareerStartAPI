﻿using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApi.Models;
using WebApi.Repository;

namespace WebApi.Repositories
{
    public class ResponseRepository : IRepository<Response>
    {
        private readonly ApplicationContext context;
        public ResponseRepository(ApplicationContext Context)
        {
            context = Context;
        }
        public async Task<Response> Create(Response obj)
        {
            await context.Responses.AddAsync(obj);
            await context.SaveChangesAsync();

            return obj;
        }

        public async Task<bool> Delete(int id)
        {
            Response response = await context.Responses.FindAsync(id);

            if (response != null)
            {
                context.Responses.Remove(response);
                await context.SaveChangesAsync();

                return true;
            }

            return false;
        }

        public async Task<IEnumerable<Response>> Get()
        {
            return await context.Responses.ToListAsync();
        }

        public async Task<Response> Get(int id)
        {
            return await context.Responses.FindAsync(id);
        }

        public async Task<Response> Update(Response newResponse)
        {
            context.Entry(newResponse).State = EntityState.Modified;
            await context.SaveChangesAsync();
            return newResponse;
        }
    }
}
