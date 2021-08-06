﻿using InterviewCRUD_NetCore.Repository.Context;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace InterviewCRUD_NetCore.Repository.Repositories
{
    public class GenericRepository<TEntity> : IGenericRepository<TEntity> where TEntity : class
    {
        protected readonly DbContext _context;
        protected readonly DbSet<TEntity> _set;

        public GenericRepository(CourseselectionContext context)
        {
            _context = context;
            _set = _context.Set<TEntity>();
        }

        public void Add(TEntity entity)
        {
            _context.Set<TEntity>().Add(entity);
        }

        public void AddRange(IEnumerable<TEntity> entities)
        {
            _context.Set<TEntity>().AddRange(entities);
        }

        public void Remove(TEntity entity)
        {
            _context.Set<TEntity>().Remove(entity);
        }

        public void RemoveRange(IEnumerable<TEntity> entities)
        {
            _context.Set<TEntity>().RemoveRange(entities);
        }

        public IEnumerable<TEntity> Find(Expression<Func<TEntity, bool>> predicate)
        {
            return _context.Set<TEntity>().Where(predicate).AsEnumerable();
        }

        public IEnumerable<TEntity> GetAll()
        {
            return _context.Set<TEntity>().AsEnumerable();
        }

        public TEntity GetById(string id)
        {
            return _context.Set<TEntity>().Find(id);
        }

        public void SaveChanges()
        {
            _context.SaveChanges();
        }
    }
}
