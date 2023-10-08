namespace GradeBook
{
    public class Statistics
    {
        public double Average { get => Sum / Count; }
        public double High;
        public double Low;
        public char Letter { get => GetLetterGrade(); }
        private double Sum;
        private int Count;

        private Dictionary<double, char> letterGradeDictionary = new ()
        {
            { 90.0, 'A' },
            { 80.0, 'B' },
            { 70.0, 'C' },
            { 60.0, 'D' },
            { 50.0, 'E' },
            {  0.0, 'F' }
        };

        public Statistics()
        {
            Sum = 0.0;
            Count = 0;
            High = double.MinValue;
            Low = double.MaxValue;
        } 

        public void AddGrade(double number)
        {
            Sum += number;
            Count++;
            High = Math.Max(number, High);
            Low = Math.Min(number, Low);
        }

        private char GetLetterGrade() => letterGradeDictionary.First(item => Average >= item.Key).Value;

        public void ShowStatistics()
        {
            Console.WriteLine($"The average grade is {Average:N1}"); 
            Console.WriteLine($"The minimum grade is {Low:N1}"); 
            Console.WriteLine($"The maximum grade is {High:N1}"); 
            Console.WriteLine($"The letter grade is {Letter}");
        }       
    }
}