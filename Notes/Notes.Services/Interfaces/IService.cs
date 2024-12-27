﻿using Notes.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Notes.Services.Interfaces
{
    public interface IService<T> where T : class
    {
        public IEnumerable<T> GetAll();

        public void AddContact (T addingItem);

        public void RemoveContact (int Id);

        public T Get (int Id);

        public void Update(int Id, T changedItem);
    }
}
