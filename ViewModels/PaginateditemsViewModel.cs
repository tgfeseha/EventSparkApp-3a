﻿using System.Collections.Generic;

namespace EventCatalogApi.ViewModels
{
    public class PaginateditemsViewModel<TEntity>
        where TEntity : class
    {
        public int PageSize { get; set; }
        public int PageIndex { get; set; }
        public long Count { get; set; }

        public IEnumerable<TEntity> Data { get; set; }
    }
}