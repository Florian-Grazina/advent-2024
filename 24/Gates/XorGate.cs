﻿namespace _24.Gates
{
    internal class XorGate : Gate
    {
        public override string Id => "XOR";

        public override Wire GetWireOutput(Wire input1, Wire input2, string newWireId)
        {
            short newValue = (short)(input1.Value ^ input2.Value);
            return new Wire(newWireId, newValue);
        }
    }
}
