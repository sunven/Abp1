using System;
using System.Collections.Generic;
using System.Collections.Immutable;

namespace ImmutableListDemo
{
    public class Order
    {
        public Order(IEnumerable<OrderLine> lines)
        {
            Lines = lines.ToImmutableList();
        }

        public ImmutableList<OrderLine> Lines { get; }

        public Order WithLines(IEnumerable<OrderLine> value)
        {
            return ReferenceEquals(Lines, value)
                ? this
                : new Order(value);
        }

        public Order AddLine(OrderLine value)
        {
            return WithLines(Lines.Add(value));
        }

        public Order RemoveLine(OrderLine value)
        {
            return WithLines(Lines.Remove(value));
        }

        public Order ReplaceLine(OrderLine oldValue, OrderLine newValue)
        {
            return oldValue == newValue
                ? this
                : WithLines(Lines.Replace(oldValue, newValue));
        }
    }
}