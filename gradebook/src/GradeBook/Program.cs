namespace GradeBook
{
    class Program
    {
        static void Main(string[] args)
        {
            var book = new DiskBook("Scott's Grade Book");
            book.GradeAdded += OnGradeAdded;
            
            EnterGrades(book);

            var statistics = book.GetStatistics();
            statistics.ShowStatistics();
        }

        private static void EnterGrades(IBook book)
        {
            Console.WriteLine("Enter a grade or 'q' to quit");
            var input = Console.ReadLine();
            while (input != "q")
            {
                try
                {
                    var grade = double.Parse(input);
                    book.AddGrade(grade);
                }
                catch (ArgumentException e)
                {
                    Console.WriteLine(e.Message);
                }
                catch (FormatException e)
                {
                    Console.WriteLine(e.Message);
                }
                finally
                {
                    Console.WriteLine("**");
                }

                Console.WriteLine("Enter a grade or 'q' to quit");
                input = Console.ReadLine();
            }
        }

        private static void OnGradeAdded(object sender, EventArgs args) 
            => Console.WriteLine("A grade was added");
    }
}


