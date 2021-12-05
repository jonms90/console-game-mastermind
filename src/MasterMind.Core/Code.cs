using System;
using System.Collections.Generic;
using System.Linq;

namespace MasterMind.Core
{
    public class Code
    {
        private const int DefaultCodeLength = 4;
        private readonly IReadOnlyList<Color> _code;
        public int Length { get; private set; }

        public Code(List<Color> pins)
        {
            _code = pins;
            Length = pins.Count;
        }

        public Solution Solve(Guess guess)
        {
            var pinsInCode = new List<Color>(_code);
            var guessedPins = new List<Color> { guess.Pin1, guess.Pin2, guess.Pin3, guess.Pin4 };
            var correctGuesses = CorrectGuesses(pinsInCode, guessedPins);
            var unsolvedPinsInCode = pinsInCode.Where(p => correctGuesses.All(c => c != p)).ToList();
            var incorrectGuesses = guessedPins.Where(p => correctGuesses.All(c => c != p)).ToList();
            var partiallyCorrectPins = PartiallyCorrectPins(unsolvedPinsInCode, incorrectGuesses);

            return new Solution
            {
                Pin1 = guess.Pin1,
                Pin2 = guess.Pin2,
                Pin3 = guess.Pin3,
                Pin4 = guess.Pin4,
                CorrectPins = correctGuesses.Count,
                PartiallyCorrectPins = partiallyCorrectPins
            };
        }

        private static List<Color> CorrectGuesses(List<Color> pinsInCode, List<Color> guessedPins)
        {
            var correctGuesses = new List<Color>();
            for (var i = 0; i < pinsInCode.Count; i++)
            {
                var pin = pinsInCode[i];
                if (pin == guessedPins[i])
                {
                    correctGuesses.Add(pin);
                }
            }

            return correctGuesses;
        }

        private static int PartiallyCorrectPins(List<Color> unsolvedPinsInCode, List<Color> incorrectGuesses)
        {
            var partiallyCorrectPins = 0;
            foreach (var unsolvedPin in unsolvedPinsInCode)
            {
                if (incorrectGuesses.Contains(unsolvedPin))
                {
                    incorrectGuesses.Remove(unsolvedPin);
                    partiallyCorrectPins++;
                }
            }

            return partiallyCorrectPins;
        }

        public static Code GenerateRandom()
        {
            var random = new Random();
            var colors = Enum.GetValues<Color>().Length;
            var randomCode = new List<Color>();
            for (var i = 0; i < DefaultCodeLength; i++)
            {
                randomCode.Add((Color)random.Next(colors));
            }

            return new Code(randomCode);
        }


    }
}
