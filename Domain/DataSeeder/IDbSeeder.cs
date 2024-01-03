using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.DataSeeder
{
    public interface IDbSeeder
    {
        public Task SeedData();
    }
}
