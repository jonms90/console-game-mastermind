using System.Collections.Generic;
using MasterMind.Core;
using Xunit;

namespace MasterMind.UnitTests
{
    public class CodeTests
    {
        [Fact]
        public void Solve_GivenAllWrong_EmptyResult()
        {
            var code = new Code(new List<Color> { Color.Red, Color.Red, Color.Red, Color.Red });
            var guess = new Guess(Color.Green, Color.Green, Color.Green, Color.Green);

            var result = code.Solve(guess);
            Assert.Equal(0, result.CorrectPins);
            Assert.Equal(0, result.PartiallyCorrectPins);
        }

        [Fact]
        public void Solve_ResultMatchesGuess()
        {
            const Color expectedPin1 = Color.Green;
            const Color expectedPin2 = Color.Red;
            const Color expectedPin3 = Color.Blue;
            const Color expectedPin4 = Color.Yellow;
            var code = new Code(new List<Color> { Color.Red, Color.Red, Color.Red, Color.Red });
            var guess = new Guess(expectedPin1, expectedPin2, expectedPin3, expectedPin4);

            var result = code.Solve(guess);
            Assert.Equal(expectedPin1, result.Pin1);
            Assert.Equal(expectedPin2, result.Pin2);
            Assert.Equal(expectedPin3, result.Pin3);
            Assert.Equal(expectedPin4, result.Pin4);
        }

        [Fact]
        public void Solve_MatchFirstPinCorrect()
        {
            var code = new Code(new List<Color> { Color.Red, Color.Red, Color.Red, Color.Red });
            var guess = new Guess(Color.Red, Color.Green, Color.Green, Color.Green);

            var result = code.Solve(guess);
            Assert.Equal(1, result.CorrectPins);
            Assert.Equal(0, result.PartiallyCorrectPins);
        }

        [Fact]
        public void Solve_MatchSecondPinCorrect()
        {
            var code = new Code(new List<Color> { Color.Red, Color.Red, Color.Red, Color.Red });
            var guess = new Guess(Color.Green, Color.Red, Color.Green, Color.Green);

            var result = code.Solve(guess);
            Assert.Equal(1, result.CorrectPins);
            Assert.Equal(0, result.PartiallyCorrectPins);
        }

        [Fact]
        public void Solve_MatchThirdPinCorrect()
        {
            var code = new Code(new List<Color> { Color.Red, Color.Red, Color.Red, Color.Red });
            var guess = new Guess(Color.Green, Color.Green, Color.Red, Color.Green);

            var result = code.Solve(guess);
            Assert.Equal(1, result.CorrectPins);
            Assert.Equal(0, result.PartiallyCorrectPins);
        }

        [Fact]
        public void Solve_MatchFourthPinCorrect()
        {
            var code = new Code(new List<Color> { Color.Red, Color.Red, Color.Red, Color.Red });
            var guess = new Guess(Color.Green, Color.Green, Color.Green, Color.Red);

            var result = code.Solve(guess);
            Assert.Equal(1, result.CorrectPins);
            Assert.Equal(0, result.PartiallyCorrectPins);
        }

        [Theory]
        [InlineData(Color.Yellow, Color.Yellow, Color.Yellow, Color.Yellow, 0)]
        [InlineData(Color.Blue, Color.Blue, Color.Blue, Color.Red, 1)]
        [InlineData(Color.Green, Color.Yellow, Color.Red, Color.Red, 2)]
        [InlineData(Color.Red, Color.Red, Color.Blue, Color.Red, 3)]
        [InlineData(Color.Red, Color.Red, Color.Red, Color.Red, 4)]
        public void Solve_MatchCorrectPins(Color pin1, Color pin2, Color pin3, Color pin4, int expectedCorrect)
        {
            var code = new Code(new List<Color> { Color.Red, Color.Red, Color.Red, Color.Red });
            var guess = new Guess(pin1, pin2, pin3, pin4);

            var result = code.Solve(guess);
            Assert.Equal(expectedCorrect, result.CorrectPins);
        }

        [Fact]
        public void Solve_MatchPartiallyCorrectPin()
        {
            var code = new Code(new List<Color> { Color.Red, Color.Red, Color.Green, Color.Green });
            var guess = new Guess(Color.Green, Color.Blue, Color.Blue, Color.Blue);

            var result = code.Solve(guess);
            Assert.Equal(0, result.CorrectPins);
            Assert.Equal(1, result.PartiallyCorrectPins);
        }

        [Theory]
        [InlineData(Color.Blue, Color.Red, Color.Green, Color.Black, 3)]
        [InlineData(Color.Blue, Color.Yellow, Color.Green, Color.Black, 2)]
        [InlineData(Color.Blue, Color.Blue, Color.Yellow, Color.Blue, 1)]
        [InlineData(Color.Black, Color.Black, Color.Black, Color.Black, 0)]
        [InlineData(Color.Blue, Color.Red, Color.Green, Color.Green, 4)]
        public void Solve_MatchPartiallyCorrectPins(Color pin1, Color pin2, Color pin3, Color pin4, int expectedPartiallyCorrect)
        {
            var code = new Code(new List<Color> { Color.Green, Color.Green, Color.Blue, Color.Red });
            var guess = new Guess(pin1, pin2, pin3, pin4);

            var result = code.Solve(guess);
            Assert.Equal(expectedPartiallyCorrect, result.PartiallyCorrectPins);
        }

        [Theory]
        [InlineData(Color.Blue, Color.Red, Color.Green, Color.Black, 0, 2)]
        [InlineData(Color.Red, Color.Blue, Color.Yellow, Color.White, 2, 1)]
        [InlineData(Color.White, Color.Blue, Color.Yellow, Color.Green, 1, 2)]
        [InlineData(Color.Yellow, Color.Blue, Color.Black, Color.White, 4, 0)]
        public void Solve_ComplexMatches(Color pin1, Color pin2, Color pin3, Color pin4, int expectedCorrect, int expectedPartiallyCorrect)
        {
            var code = new Code(new List<Color> { Color.Yellow, Color.Blue, Color.Black, Color.White });
            var guess = new Guess(pin1, pin2, pin3, pin4);

            var result = code.Solve(guess);
            Assert.Equal(expectedCorrect, result.CorrectPins);
            Assert.Equal(expectedPartiallyCorrect, result.PartiallyCorrectPins);
        }
    }
}
