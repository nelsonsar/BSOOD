namespace Roullete
{
    using System;
    using System.Linq;
    using System.Text;
    using System.Collections.Generic;
    using System.Collections.Immutable;

    public class Bin
    {
        private ImmutableList<Outcome> outcomeList;

        private Bin(IList<Outcome> outcomeList)
        {
            this.outcomeList = ImmutableList<Outcome>.Empty.AddRange(outcomeList);
        }

        public static Bin CreateFromOutcomeList(IList<Outcome> outcomeList)
        {
            return new Bin(outcomeList);
        }

        public void Add(Outcome outcome)
        {
            this.outcomeList = this.outcomeList.Add(outcome);
        }

        public override string ToString()
        {
            if (this.outcomeList.IsEmpty) {
                return "";
            }

            var stringBuilder = new StringBuilder();
            var allExceptLast = this.outcomeList.Count - 1;

            var filteredList = this.outcomeList.Take(allExceptLast);

            foreach (Outcome outcome in filteredList) {
                stringBuilder.Append(string.Format("{0}, ", outcome.ToString()));
            }

            stringBuilder.Append(this.outcomeList.Last().ToString());

            return stringBuilder.ToString();
        }
    }
}
