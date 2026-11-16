using System;
using System.Collections.Generic;

namespace PESMini.Core.Models;

public partial class ProductionShift
{
    public int ShiftId { get; set; }

    public string ShiftCode { get; set; } = null!;

    public string ShiftName { get; set; } = null!;

    public TimeOnly ShiftStartTime { get; set; }

    public TimeOnly ShiftEndTime { get; set; }

    public byte TotalShiftTimeMin { get; set; }

    public bool IsActive { get; set; }
}
