using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

namespace Base
{
    public class ContextFactory <TContext>: IDesignTimeDbContextFactory<TContext> where TContext:DbContext
    {
        public TContext CreateDbContext(string[] args) {

            var optionBuilder = new DbContextOptionsBuilder<TContext>();

            var connString = BaseConfiguration.GetConnectionString;

            optionBuilder.UseMySQL(connString);

            return (TContext)Activator.CreateInstance(typeof(TContext), optionBuilder.Options);

        }
    }
}
