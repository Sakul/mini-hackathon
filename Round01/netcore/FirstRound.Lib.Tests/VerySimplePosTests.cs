using FluentAssertions;
using System.Collections.Generic;
using Xunit;
using System;

namespace FirstRound.Lib.Tests
{
    public class VerySimplePosTests
    {
        private readonly IVerySimplePOS sut;

        public VerySimplePosTests()
        {
            sut = new POS();
        }

        [Theory]
        [InlineData(500, 1000, 50000)]
        [InlineData(650, 1000, 35000)]
        [InlineData(990, 1000, 1000)]
        [InlineData(995, 1000, 500)]
        [InlineData(999, 1000, 100)]
        [InlineData(175.30, 500, 32475)]

        public void ComputeChangeInBahtAndSatangCorrectly(double amount, double payment, int expected)
        {
            var result = this.sut.ComputeChange(amount, payment);
            result.Should().Be(expected);
        }

        [Theory]
        [InlineData(100.25, 101, 75)]
        [InlineData(100.26, 101, 75)]
        [InlineData(100.70,101,50)]
        [InlineData(100.20,101,100)]
        [InlineData(100.60, 101, 50)]
        [InlineData(100.80, 101, 25)]

        public void ComputeRoundUpChangeInBahtAndSatangCorrectly(double amount, double payment, int expected)
        {
            var result = this.sut.ComputeChange(amount, payment);
            result.Should().Be(expected);
        }

        
        [Theory]
        [MemberData(nameof(GetChangeBankNotesAndCoinsCases))]
        public void GetChangeBankNotesAndCoinsReturnsCorrectSolution(int change, ChangeSolution expected)
        {
            var result = this.sut.GetChangeBankNotesAndCoins(change);

            result.Should().BeEquivalentTo(expected);
        }

        public static IEnumerable<object[]> GetChangeBankNotesAndCoinsCases = new List<object[]>
        {
            new object[] { 44800,
                new ChangeSolution
                {
                    HasChange = true,
                    RoundedChange = 448.00,
                    BankNotesAndCoins = new Dictionary<BankNotesAndCoinsInSatang, int>
                    {
                        { BankNotesAndCoinsInSatang.Hundred, 4 },
                        { BankNotesAndCoinsInSatang.Twenty, 2 },
                        { BankNotesAndCoinsInSatang.Five, 1 },
                        { BankNotesAndCoinsInSatang.One, 3 },
                    },
                },
            },
            new object[] { 44800,
                new ChangeSolution
                {
                    HasChange = true,
                    RoundedChange = 448.50,
                    BankNotesAndCoins = new Dictionary<BankNotesAndCoinsInSatang, int>
                    {
                        { BankNotesAndCoinsInSatang.Hundred, 4 },
                        { BankNotesAndCoinsInSatang.Twenty, 2 },
                        { BankNotesAndCoinsInSatang.Five, 1 },
                        { BankNotesAndCoinsInSatang.One, 3 },
                    },
                },
            }
        };
    }
}
