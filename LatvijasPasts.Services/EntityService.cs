﻿using LatvijasPasts.Core.Models;
using LatvijasPasts.Core.Services;
using LatvijasPasts.Data;


namespace LatvijasPasts.Services
{
    public class EntityService<T> : DbService, IEntityService<T> where T : Entity
    {
        public EntityService(ILatvijasPastsDbContext context) : base(context) { }
        public void Create(T entity)
        {
            Create<T>(entity);
        }

        public void Delete(T entity)
        {
            Delete<T>(entity);
        }

        public IEnumerable<T> GetAll()
        {
            return GetAll<T>();
        }

        public T? GetById(int id)
        {
            return GetById<T>(id);
        }

        public void Update(T entity)
        {
            Update<T>(entity);
        }
    }
}
