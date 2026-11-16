using System;
using System.Collections.Generic;

namespace PESMini.Core.Models;

public partial class MachineOperationMapping
{
    public int MacOpMapId { get; set; }

    public int FmachineId { get; set; }

    public int FoperationId { get; set; }

    public bool IsActive { get; set; }

    public Guid InsertedBy { get; set; }

    public DateTime InsertedOn { get; set; }

    public Guid? UpdatedBy { get; set; }

    public DateTime? UpdatedOn { get; set; }

    public virtual Machine Fmachine { get; set; } = null!;

    public virtual ProductionOperation Foperation { get; set; } = null!;

    public virtual User InsertedByNavigation { get; set; } = null!;

    public virtual User? UpdatedByNavigation { get; set; }
}
