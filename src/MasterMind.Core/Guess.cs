namespace MasterMind.Core
{
    public class Guess
    {
        public Color Pin1 { get; }
        public Color Pin2 { get; }
        public Color Pin3 { get; }
        public Color Pin4 { get; }

        public Guess(Color pin1, Color pin2, Color pin3, Color pin4)
        {
            Pin1 = pin1;
            Pin2 = pin2;
            Pin3 = pin3;
            Pin4 = pin4;
        }
    }
}
