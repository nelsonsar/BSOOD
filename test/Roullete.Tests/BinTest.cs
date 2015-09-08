namespace Roullete.Tests
{
    using System;
    using System.Collections.Generic;
    using Xunit;
    using Roullete;

    public class BinTest
    {
        [Fact]
        public void CreateFromOutcomeList()
        {
            var outcomeList = new [] {
                new Outcome("Number 1", 35),
                new Outcome("Red", 1)
            };

            var result = Bin.CreateFromOutcomeList(outcomeList);

            Assert.Equal("Number 1 (35:1), Red (1:1)", result.ToString());
        }

        [Fact]
        public void AddOutcomeToList()
        {
            var bin = Bin.CreateFromOutcomeList(new List<Outcome>());
            var newItem = new Outcome("Number 1", 35);

            bin.Add(newItem);

            Assert.Equal("Number 1 (35:1)", bin.ToString());
        }

        [Fact]
        public void ToStringReturnsEmptyWhenBinHasNoOutcomes()
        {
            var bin = Bin.CreateFromOutcomeList(new List<Outcome>());

            Assert.Empty(bin.ToString());
        }
    }
}
