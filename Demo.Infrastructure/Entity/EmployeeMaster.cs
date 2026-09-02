using System;
using System.Collections.Generic;

namespace Demo.Infrastructure.Entity;

public partial class EmployeeMaster
{
    public Guid EmpId { get; set; }

    public long EmpNo { get; set; }

    public string EmpName { get; set; } = null!;

    public string Mobile { get; set; } = null!;

    public DateTime CreateDate { get; set; }

    public bool IsActive { get; set; }
}
