namespace Demo.Domain.DTOs
{
    public class EmployeeDTO
    {
      public long ID { get; set; }

      public string Name { get; set; } = null!;

      public string MobileNo { get; set; } = null!;

      public string EmailID { get; set; } = null!;

      public DateTime CreateDate { get; set; }

      public bool IsActive { get; set; }
    }
}
