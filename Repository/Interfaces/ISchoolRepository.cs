﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository.Interfaces
{
    public interface ISchoolRepository<T> : IRepository<T>
    {
        int BulkInsert(List<T> entities);
    }
}
