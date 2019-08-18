using System.Collections.Generic;

namespace WebMvc.Models
{
    public class Catalog
    {
        public int PageSize { get; set; }
        public int PageIndex { get; set; }
        public long Count { get; set; }

        public List<Catalogitem> Data { get; set; }
    }
}
