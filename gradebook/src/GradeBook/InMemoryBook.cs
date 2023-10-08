namespace GradeBook
{
    public class InMemoryBook : Book
    {
        public override event GradeAddedDelegate GradeAdded;
        private List<double> grades;
        
        private readonly string category = "science";

        public InMemoryBook(string name) : base(name)
        {
            grades = new ();
            Name = name; 
        }

        public override void AddGrade(double grade)
        {
            if(grade < 0 || grade > 100)
            { 
                throw new ArgumentException($"Invalid {nameof(grade)}");
            }
        
            grades.Add(grade);
            if(GradeAdded != null)
                GradeAdded(this, new EventArgs());
        }

        public override Statistics GetStatistics()
        {
            Statistics statistics = new Statistics();
            grades.ForEach(grade => statistics.AddGrade(grade));

            return statistics;
        }
    }
}