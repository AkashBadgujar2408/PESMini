using System;
using System.Collections.Generic;

namespace PESMini.Core.Models;

public partial class Machine
{
    public int MachineId { get; set; }

    public string MachineCode { get; set; } = null!;

    public int FverticalSectionId { get; set; }

    public bool ProdCycleTimeReqd { get; set; }

    public bool IsActive { get; set; }

    public Guid InsertedBy { get; set; }

    public DateTime InsertedOn { get; set; }

    public Guid? UpdatedBy { get; set; }

    public DateTime? UpdatedOn { get; set; }

    public virtual VerticalSection FverticalSection { get; set; } = null!;

    public virtual User InsertedByNavigation { get; set; } = null!;

    public virtual ICollection<MachineOperationMapping> MachineOperationMappings { get; set; } = new List<MachineOperationMapping>();

    public virtual User? UpdatedByNavigation { get; set; }
}
