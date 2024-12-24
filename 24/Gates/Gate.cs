namespace _24.Gates
{
    internal abstract class Gate
    {
        public Wire Input1 { get; set; }
        public Wire Input2 { get; set; }

        public abstract Wire GetWireOutput();
    }
}
