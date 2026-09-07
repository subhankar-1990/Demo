using System;
using System.Collections.Generic;

namespace Demo.Infrastructure.Entity;

public partial class AuthMaster
{
    public Guid AuthId { get; set; }

    public long EmpNo { get; set; }

    public string Password { get; set; } = null!;

    public bool IsLocked { get; set; }
}
