using System.Collections.Generic;

namespace Booking
{
    public interface IRow
    {
        string Key { get; set; }
        IEnumerable<string> Value { get; set; }
        string Type { get; set; }

        string ToString();
    }

    public class NormalRow : IRow
    {
        public string Key { get; set; }
        public IEnumerable<string> Value { get => throw new System.NotImplementedException(); set => throw new System.NotImplementedException(); }
        public string Type { get => throw new System.NotImplementedException(); set => throw new System.NotImplementedException(); }
    }
}