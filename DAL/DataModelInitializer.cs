using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;

namespace DAL
{
    public class DataModelInitializer : DropCreateDatabaseIfModelChanges<AppoinmentContext>
    {
        protected override void Seed(AppoinmentContext context)
        {
            context.SaveChanges();
        }

    }
}
