namespace MasterMind.Core
{
    public class Game
    {
        public bool IsFinished { get; set; }

        private readonly Code _code;

        public Game()
        {
            _code = Code.GenerateRandom();
        }

        public Game(Code code)
        {
            _code = code;
        }

        public int Turn => 1;

        public void Guess(Guess guess)
        {
            var result = _code.Solve(guess);
            if (result.CorrectPins == _code.Length)
            {
                IsFinished = true;
            }
        }
    }
}
