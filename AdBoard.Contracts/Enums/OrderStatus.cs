using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdBoard.Contracts.Enums
{
    /// <summary>
    /// Статус заказа
    /// </summary>
    public enum OrderStatus
    {
        /// <summary>
        /// Статус не определён
        /// </summary>
        None = 0,

        /// <summary>
        /// Черновик заказа
        /// </summary>
        Draft = 1,

        /// <summary>
        /// Заказ опубликован
        /// </summary>
        Published = 2
    }
}
