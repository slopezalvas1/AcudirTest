using Acudir.Infraestructure.Models;
using Acudir.Services.Data;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Acudir.Services.Services
{
    public abstract class GenericService<T> where T : Entity
    {
        private readonly AcudirContext _context;

        public GenericService(AcudirContext context)
        {
            _context = context;
        }

        protected DbSet<T> Set { get { return _context.Set<T>(); } }

        public virtual void Add(T element)
        {
            Set.Add(element);
            _context.SaveChanges();
        }

        public virtual void Edit(T element)
        {
            _context.Entry(element).State = EntityState.Modified;
            _context.SaveChanges();
        }

        public virtual T Find(int? id)
        {
            return Set.Find(id);
        }

        public virtual void Delete(int? id)
        {
            var element = Find(id);
            Set.Remove(element);
            _context.SaveChanges();
        }


    }
}
