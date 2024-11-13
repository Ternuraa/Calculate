using Calculate.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Calculate.Storage
{
    public class DatabaseStorage : IStorage
    {
        public List<double> Load()
        {
            using (ApplicationContext db = new ApplicationContext())
            {
                var histories = db.History.ToArray();
                return histories.Select(h => h.Value).ToList();
            }
        }

        public void Save(double value)
        {
            using (ApplicationContext db = new ApplicationContext())
            {
                var h = db.History.ToArray();
                db.History.Add(new History() { Value = value });
                db.SaveChanges();
            }
        }
    }
}
