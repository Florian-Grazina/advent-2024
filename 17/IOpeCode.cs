using Microsoft.Win32;

namespace _17
{
    internal abstract class OpeCode
    {
        public short Operand { get; set; }

        protected OpeCode(short operand)
        {
            Operand = operand;
        }

        public abstract short Execute();

        public int GetCombo()
        {
            if (Operand > 0 && Operand <= 3)
                return Operand;

            if(Operand == 4)
                return Register.A;

            if(Operand== 5)
                return Register.B;

            if(Operand == 6)
                return Register.C;

            if (Operand == 7)
                throw new Exception("7 is reserved");

            throw new Exception("Can't parse Operand");
        }
    }

    internal class Adv(short operand) : OpeCode(operand)
    {
        public override short Execute()
        {
            int numerator = Register.A;
            int denominator = (int)Math.Pow(2, GetCombo());

            int result = numerator / denominator;
            Register.A = result;

            return 99;
        }
    }

    internal class Bxl(short operand) : OpeCode(operand)
    {
        public override short Execute()
        {
            Register.B ^= operand;
            return 99;
        }
    }

    internal class Bst(short operand) : OpeCode(operand)
    {
        public override short Execute()
        {
            int value = GetCombo() % 8;
            Register.B = value;
            return 99;
        }
    }

    internal class Jnz(short operand) : OpeCode(operand)
    {
        public override short Execute()
        {
            if (Register.A == 0)
                return 99;

            return Operand;
        }
    }

    internal class Bxc(short operand) : OpeCode(operand)
    {
        public override short Execute()
        {
            int result = Register.B ^ Register.C;
            Register.B = result;
            return 99;
        }
    }

    internal class Out(short operand) : OpeCode(operand)
    {
        public override short Execute()
        {
            int value = GetCombo() % 8;
            Register.Outputs.Add(value);
            Console.WriteLine(value);
            return 99;
        }
    }

    internal class Bdv(short operand) : OpeCode(operand)
    {
        public override short Execute()
        {
            int numerator = Register.A;
            int denominator = (int)Math.Pow(2, GetCombo());

            int result = numerator / denominator;
            Register.B = result;
            return 99;
        }
    }

    internal class Cdv(short operand) : OpeCode(operand)
    {
        public override short Execute()
        {
            int numerator = Register.A;
            int denominator = (int)Math.Pow(2, GetCombo());

            int result = numerator / denominator;
            Register.C = result;
            return 99;
        }
    }
}
