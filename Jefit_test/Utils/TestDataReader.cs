namespace SauceDemo.UtilsServises
{
    public static class TestDataReader
    {
        public static IEnumerable<TestCaseData> ReadCsv(string relativePath, string testNamePattern)
        {
            var projectDir = Directory.GetParent(AppDomain.CurrentDomain.BaseDirectory).Parent.Parent.Parent.FullName;
            var filePath = Path.Combine(projectDir, relativePath);

            var lines = File.ReadAllLines(filePath);

            foreach (var line in lines)
            {
                if (string.IsNullOrWhiteSpace(line)) continue;

                var parts = line.Split(',');
                if (parts.Length < 2) continue;

                yield return new TestCaseData(parts[0].Trim(), parts[1].Trim())
                    .SetName(string.Format(testNamePattern, parts[0].Trim(), parts[1].Trim()));
            }
        }

        public static IEnumerable<TestCaseData> GetData(string relativePath, string testNamePattern)
        {
            return ReadCsv(relativePath, testNamePattern);
        }
    }
}
