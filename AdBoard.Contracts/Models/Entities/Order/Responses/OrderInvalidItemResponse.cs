using System;

namespace AdBoard.Contracts.Models.Entities.Order.Responses
{
    /// <summary>
    /// Представляет ответ о недействительном элементе заказа.
    /// </summary>
    public class OrderInvalidItemResponse
    {
        /// <summary>
        /// Идентификатор недействительного элемента заказа.
        /// Может быть null, если элемент не был идентифицирован.
        /// </summary>
        public long? OrderItemId { get; set; }

        /// <summary>
        /// Идентификатор заказа, к которому относится недействительный элемент.
        /// </summary>
        public long OrderId { get; set; }

        /// <summary>
        /// Сообщение, описывающее причину недействительности элемента.
        /// </summary>
        public string Message { get; set; }
    }
}
