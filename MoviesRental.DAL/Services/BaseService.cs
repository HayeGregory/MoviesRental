﻿using ADOLibrary;
using System;
using System.Collections.Generic;
using System.Text;

namespace MoviesRental.DAL.Services
{
    public abstract class BaseService<TKey, TEntity> : IService<TKey, TEntity>
        where TEntity : IEntity<TKey>
    {
        protected Connection connection { get; private set; }

        protected BaseService(Connection connection)
        {
            this.connection = connection;
        }

        protected BaseService()
        {
            this.connection = new Connection(@"Data Source=DESKTOP-RQPUUKM;Initial Catalog=MoviesRental;Integrated Security=True;Connect Timeout=60;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False");
        }

        public abstract IEnumerable<TEntity> GetAll();
    }
}
