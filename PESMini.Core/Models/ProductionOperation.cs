using System;
using System.Collections.Generic;

namespace PESMini.Core.Models;

public partial class ProductionOperation
{
    public int OperationId { get; set; }

    public string OperationCode { get; set; } = null!;

    public string OperationName { get; set; } = null!;

    public bool ProdCycleTimeReqd { get; set; }

    public bool IsActive { get; set; }

    public Guid InsertedBy { get; set; }

    public DateTime InsertedOn { get; set; }

    public Guid? UpdatedBy { get; set; }

    public DateTime? UpdatedOn { get; set; }

    public virtual User InsertedByNavigation { get; set; } = null!;

    public virtual ICollection<MachineOperationMapping> MachineOperationMappings { get; set; } = new List<MachineOperationMapping>();

    public virtual ICollection<ProductOperationMappingDetail> ProductOperationMappingDetails { get; set; } = new List<ProductOperationMappingDetail>();

    public virtual User? UpdatedByNavigation { get; set; }
}
