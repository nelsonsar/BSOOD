using System;
using System.Security.Cryptography;

namespace Roullete
{
    public class Outcome
    {
        private readonly string name;
        private readonly int odds;

        public Outcome(string name, int odds)
        {
            this.name = name;
            this.odds = odds;
        }

        public float CalculateWinAmount(float betAmount)
        {
            return (this.odds * betAmount);
        }

        public override bool Equals(Object other)
        {
            if (other == null || GetType() != other.GetType()) return false;

            var convertedOther = (Outcome) other;

            return (this.name == convertedOther.name && this.odds == convertedOther.odds);
        }

        public override int GetHashCode()
        {
            var hasher = SHA1.Create();
            var identifierString = this.name + this.odds.ToString();
            var bytesToBeConverted = System.Text.Encoding.Unicode.GetBytes(identifierString);

            return BitConverter.ToInt32(hasher.ComputeHash(bytesToBeConverted), 0);
        }

        public override string ToString()
        {
            return string.Format("{0} ({1}:1)", this.name, this.odds);
        }
    }
}
