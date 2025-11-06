namespace Jefit_test.Utils
{
    public class TestDataReader
    {
        public string Height { get; set; }
        public string Weight { get; set; }
        public string GoalWeight { get; set; }
        public string Age { get; set; }

        public static TestDataReader FromCsv(string relativePath)
        {
            var projectDir = Directory.GetParent(AppDomain.CurrentDomain.BaseDirectory)
                                      .Parent.Parent.Parent.FullName;
            var filePath = Path.Combine(projectDir, relativePath);
            var lines = File.ReadAllLines(filePath);

            if (lines.Length < 2)
                throw new FileNotFoundException("CSV файл пуст или отсутствует данные");

            var values = lines[1].Split(',');

            return new TestDataReader
            {
                Height = values[0],
                Weight = values[1],
                GoalWeight = values[2],
                Age = values[3]
            };
        }
    }
}