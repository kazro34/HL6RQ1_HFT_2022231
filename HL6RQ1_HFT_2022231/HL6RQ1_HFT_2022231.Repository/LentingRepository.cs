﻿using HL6RQ1_HFT_2022231.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HL6RQ1_HFT_2022231.Repository
{
    public class LentingRepository : Repository<Lenting>, IRepository<Lenting>
    {
        public LentingRepository(LibraryDbContext context) : base(context)
        {

        }
        public override Lenting Read(int id)
        {
            return context.Lentings.FirstOrDefault(t => t.Id == id);
        }

        public override void Update(Lenting entity)
        {
            var old = Read(entity.Id);
            if (old == null)
            {
                throw new ArgumentException("Item not exist..");
            }
            foreach (var prop in old.GetType().GetProperties())
            {
                if (prop.GetAccessors().FirstOrDefault(t => t.IsVirtual) == null)
                {
                    prop.SetValue(old, prop.GetValue(entity));
                }
            }
            context.SaveChanges();
        }
    }
}
