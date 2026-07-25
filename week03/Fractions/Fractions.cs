namespace Week03Project
{
    public class Fraction
    {
        private int top;
        private int bottom;

        // Constructors
        public Fraction()
        {
            top = 1;
            bottom = 1;
        }

        public Fraction(int numerator)
        {
            top = numerator;
            bottom = 1;
        }

        public Fraction(int numerator, int denominator)
        {
            top = numerator;
            bottom = denominator;
        }

        // Getters and Setters
        public int GetTop() => top;
        public void SetTop(int value) => top = value;

        public int GetBottom() => bottom;
        public void SetBottom(int value) => bottom = value;

        // Methods
        public string GetFractionString()
        {
            return $"{top}/{bottom}";
        }

        public double GetDecimalValue()
        {
            return (double)top / bottom;
        }
    }
}
