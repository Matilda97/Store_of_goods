using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Store_of__goods.Abstract
{
    public interface IGoodsRepositiry
    {
        IEnumerable<WAREHOUSE_DATA> WarData { get; }
    }
}