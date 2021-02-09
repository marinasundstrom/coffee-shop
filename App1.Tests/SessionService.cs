using App1.Data;
using App1.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App1.Tests
{
    public class SessionService
    {
        private readonly ApplicationDataContext dataContext;

        public SessionService(ApplicationDataContext dataContext)
        {
            this.dataContext = dataContext;
        }

        public async Task<Session> GetSessionAsync()
        {
            return await dataContext.Sessions
                .FirstAsync();
        }
    }
}
