using System;
using System.Collections.Generic;

namespace PESMini.Core.Models;

public partial class ProductOperationMappingHead
{
    public int ProdOpMapHeadId { get; set; }

    public Guid FproductId { get; set; }

    public Guid InsertedBy { get; set; }

    public DateTime InsertedOn { get; set; }

    public Guid? UpdatedBy { get; set; }

    public DateTime? UpdatedOn { get; set; }

    public virtual Product Fproduct { get; set; } = null!;

    public virtual User InsertedByNavigation { get; set; } = null!;

    public virtual ICollection<ProductOperationMappingDetail> ProductOperationMappingDetails { get; set; } = new List<ProductOperationMappingDetail>();

    public virtual User? UpdatedByNavigation { get; set; }
}
