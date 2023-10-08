namespace GradeBook
{
    public class DiskBook : Book
    {
        public override event GradeAddedDelegate GradeAdded;
        private string fileName;

        public DiskBook(string name) : base(name)
        {
            fileName = $"{Name}.txt";
        }

        public override void AddGrade(double grade)
        {
            using(var writer = File.AppendText(fileName))
            {
                writer.WriteLine(grade);
                if(GradeAdded != null)
                    GradeAdded(this, new EventArgs());
            };
        }

        public override Statistics GetStatistics()
        {
            var statistics = new Statistics();
            using(var reader = File.OpenText(fileName))
            {
                var line = reader.ReadLine();
                while(line != null)
                {
                    var grade = double.Parse(line);
                    statistics.AddGrade(grade);
                    line = reader.ReadLine();
                }
            }

            return statistics;
        }
    }
}
