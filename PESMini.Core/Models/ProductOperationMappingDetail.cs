using System;
using System.Collections.Generic;

namespace PESMini.Core.Models;

public partial class ProductOperationMappingDetail
{
    public int ProdOpMapDetailId { get; set; }

    public int FprodOpMapHeadId { get; set; }

    public int FoperationId { get; set; }

    public int SeqNo { get; set; }

    public bool IsCriticalSetup { get; set; }

    public Guid InsertedBy { get; set; }

    public DateTime InsertedOn { get; set; }

    public Guid? UpdatedBy { get; set; }

    public DateTime? UpdatedOn { get; set; }

    public virtual ProductionOperation Foperation { get; set; } = null!;

    public virtual ProductOperationMappingHead FprodOpMapHead { get; set; } = null!;

    public virtual User InsertedByNavigation { get; set; } = null!;

    public virtual User? UpdatedByNavigation { get; set; }
}
