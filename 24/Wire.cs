namespace _24
{
    internal class Wire
    {
        public string Id { get; set; }
        public short Value { get; set; }
        public bool Bool => Convert.ToBoolean(Value);

        public Wire(string id, short value)
        {
            Id = id;
            Value = value;
        }
    }
}
