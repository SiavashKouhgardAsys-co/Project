using System.Collections.Generic;
using System.Linq;

namespace MoshaverAmlak.DataLayer.Common
{
    public class ReturnEntity<T>
    {
        public Result Result { get; set; }
        public T Entity { get; set; }
    }

    public class ReturnEntity_List<T>
    {
        public Result Result { get; set; }
        public List<T> Entity { get; set; }
    }

    public class ReturnEntity_IQueryable<T>
    {
        public Result Result { get; set; }
        public IQueryable<T> Entity { get; set; }
    }
}
