using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BogusExamples
{
    public class Order
    {
        public DateTime Date { get; set; }

        public User User { get; set; }

        public Product Product { get; set; }

        public int Count { get; set; }

        public OrderStatus Status { get; set; }
    }

    public enum OrderStatus
    {
        New,
        Processing,
        Completed,
        Canceled
    }
}
