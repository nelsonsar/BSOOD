using System;
using System.Collections.Generic;
using System.Linq;
using Xunit;
using Roullete;

namespace Roullete.Tests
{
    public class OutcomeTest
    {
        private readonly Outcome outcome;

        public OutcomeTest()
        {
            this.outcome = new Outcome("1", 35);
        }

        [Fact]
        public void CalculateWinAmount()
        {
            var expectedResult = 350;
            var betAmount = 10;

            var result = this.outcome.CalculateWinAmount(betAmount);

            Assert.Equal(expectedResult, result);
        }

        [Fact]
        public void EqualsReturnsTrueForOutcomesWithSameNameAndOdds()
        {
            var otherOutcome = new Outcome("1", 35);

            Assert.True(this.outcome.Equals(otherOutcome));
        }

        [Fact]
        public void EqualsReturnsFalseForOutcomesWithDifferentName()
        {
            var otherOutcome = new Outcome("Red", 35);

            Assert.False(this.outcome.Equals(otherOutcome));
        }

        [Fact]
        public void EqualsReturnsFalseForOutcomesWithDifferentOdds()
        {
            var otherOutcome = new Outcome("1", 1);

            Assert.False(this.outcome.Equals(otherOutcome));
        }

        [Fact]
        public void EqualsReturnsFalseForNullComparison()
        {
            Assert.False(this.outcome.Equals(null));
        }

        [Fact]
        public void EqualsReturnsFalseWhenNotComparedWithAnotherOutcome()
        {
            Assert.False(this.outcome.Equals(new object()));
        }

        [Fact]
        public void ReturnsSameHashForOutcomesWithSameNameAndOdds()
        {
            var otherOutcome = new Outcome("1", 35);

            Assert.Equal(this.outcome.GetHashCode(), otherOutcome.GetHashCode());
        }

        [Fact]
        public void ReturnsStringRepresentationForOutcome()
        {
            var expectedResult = "1 (35:1)";

            Assert.Equal(expectedResult, this.outcome.ToString());
        }
    }
}
