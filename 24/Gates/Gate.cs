namespace _24.Gates
{
    internal abstract class Gate
    {
        public abstract string Id { get; }
        public abstract Wire GetWireOutput(Wire input1, Wire input2, string newWireId);
    }
}
