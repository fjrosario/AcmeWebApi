using Acme.Data.Types;
using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Acme.Data.Models
{
    [Table("Orders")]
    public class Order : BaseModel
    {
        [Column("Title")]
        public string? Title { get; set; }

        [Column("Due_By")]
        public DateTime? DueBy { get; set; }

        [Column("Status")]
        public OrderStatusType Status { get; set; } = OrderStatusType.Unknown;

        public Order()
        {
        }
        public Order(int id, string? title, DateTime? dueBy, OrderStatusType status)
        {
            Id = id;
            Title = title;
            DueBy = dueBy;
            Status = status;
        }
    }
}
