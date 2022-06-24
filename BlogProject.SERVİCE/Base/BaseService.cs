﻿using BlogProject.CORE.Entity;
using BlogProject.CORE.Service;
using BlogProject.MODEL.Context;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using System.Transactions;

namespace BlogProject.SERVICE.Base
{
    public class BaseService<T> : ICoreService<T> where T:CoreEntity
    {
        private readonly BlogContext context;
        public BaseService(BlogContext _context)
        {
            this.context = _context;
        }
        public bool Activate(Guid i)
        {
            T activeted = GetByID(i);
            activeted.Status = CORE.Entity.Enums.Status.Active;
            
            return Update(activeted);
        }

        public bool Add(T item)
        {
            try
            {
                context.Set<T>().Add(item);
                return Save()>0;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public bool Add(List<T> itemList)
        {
            try
            {
                using (TransactionScope ts = new TransactionScope())
                {
                    context.Set<T>().AddRange(itemList);
                    ts.Complete();
                    return Save() > 0;
                }
            }
            catch (Exception)
            {

                throw;
            }
        }

        //public bool Any(Expression<Func<T, bool>> exp)
        //{
        //    retrun  context.Set<T>().Any(exp);
        //}
        public bool Any(Expression<Func<T, bool>> exp)=> context.Set<T>().Any(exp);

        public List<T> GetActive() => context.Set<T>().Where(a => a.Status != CORE.Entity.Enums.Status.Deleted).ToList();

        //public List<T> GetActive()
        //{
        //    throw new NotImplementedException();
        //}
        public List<T> GetAll() => context.Set<T>().ToList();
        //public List<T> GetAll()
        //{
        //    throw new NotImplementedException();
        //}
        public T GetByDefault(Expression<Func<T, bool>> exp) => context.Set<T>().FirstOrDefault(exp);
        

        public T GetByID(Guid id)
        {
            return context.Set<T>().Find(id);
        }

        public List<T> GetDefault(Expression<Func<T, bool>> exp) => context.Set<T>().Where(exp).ToList();
       

        public bool Remove(T item)
        {
            item.Status = CORE.Entity.Enums.Status.Deleted;
            return Update(item);
        }

        public bool Remove(Guid id)
        {
            try
            {
                using (TransactionScope ts = new TransactionScope())
                {
                    T removedItem = GetByID(id);
                    removedItem.Status = CORE.Entity.Enums.Status.Deleted;
                    ts.Complete();
                    return Update(removedItem);
                }
            }
            catch (Exception)
            {
                return false;
            }
        }

        public bool RemoveAll(Expression<Func<T, bool>> exp)
        {
            try
            {
                using (TransactionScope ts = new TransactionScope())
                {
                    var collection = GetDefault(exp);
                    int count = 0;
                    foreach (var item in collection)
                    {
                        item.Status = CORE.Entity.Enums.Status.Deleted;
                        bool opResult = Update(item);

                        if (opResult) count++;
                        
                    }
                    if (collection.Count == count) ts.Complete();
                    else return false;
                }
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public int Save()
        {
            return context.SaveChanges();
        }

        public bool Update(T item)
        {
            try
            {
                context.Set<T>().Update(item);
                return Save()>0;

            }
            catch (Exception)
            {
                return false;
            }
        }
    }
}
