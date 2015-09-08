namespace Roullete
{
    using System;
    using System.Security.Cryptography;

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
            var byteArrayOffset = 0;
            var hasher = SHA1.Create();

            return BitConverter.ToInt32(hasher.ComputeHash(this.GetObjectIdentifierAsBytes()), byteArrayOffset);
        }

        public override string ToString()
        {
            return string.Format("{0} ({1}:1)", this.name, this.odds);
        }

        private byte[] GetObjectIdentifierAsBytes()
        {
            var identifierString = this.name + this.odds.ToString();

            return System.Text.Encoding.Unicode.GetBytes(identifierString);
        }
    }
}
