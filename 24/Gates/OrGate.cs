namespace _24.Gates
{
    internal class OrGate : Gate
    {
        public override string Id => "OR";

        public override Wire GetWireOutput(Wire input1, Wire input2, string newWireId)
        {
            short newValue = (short)(input1.Value | input2.Value);
            return new Wire(newWireId, newValue);
        }
    }
}
