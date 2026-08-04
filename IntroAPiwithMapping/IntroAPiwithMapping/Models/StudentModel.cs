namespace IntroAPiwithMapping.Models
{
    public class StudentModel
    {
        public int Id { get; set; }

        public string Name { get; set; } = null!;

        public double Cgpa { get; set; }

        public string Address { get; set; } = null!;

        public int DeptId { get; set; }
    }
}
