namespace UniversityPO.Domain.Dto
{
    public class DisciplineDto
    {
        public int DisciplineId { get; set; }
        public string Name { get; set; }
        public int? DeliveryTypeId { get; set; }
        public int? TotalHours { get; set; }

        //public DeliveryType DeliveryType { get; set; }
        //public List<AcademicPerfomance> AcademicPerfomance { get; set; }
        //public List<Teacher> Teacher { get; set; }
    }
}
