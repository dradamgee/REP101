using System;
using System.Drawing;

namespace ChartSandbox
{
    public class Order {
        public decimal Quantity { get; set; }
        public decimal ExecutedPercent { get; set; }
        public decimal TradedConsideration { get; set; }
        public Side Side { get; set; }
        public DateTime LastUpdated { get; set; }        

        public Order(decimal quantity, decimal executedPercent, decimal tradedConsideration, Side side)
        {
            Quantity = quantity;
            ExecutedPercent = executedPercent;
            TradedConsideration = tradedConsideration;
            Side = side;
        }
    }
}