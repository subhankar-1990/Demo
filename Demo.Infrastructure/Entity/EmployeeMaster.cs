using System;
using System.Collections.Generic;

namespace Demo.Infrastructure.Entity;

public partial class EmployeeMaster
{
    public Guid EmpId { get; set; }

    public long EmpNo { get; set; }

    public string EmpName { get; set; } = null!;

    public string? Mobile { get; set; }

    public string? Email { get; set; }

    public DateTime CreateDate { get; set; }

    public bool IsActive { get; set; }
}
