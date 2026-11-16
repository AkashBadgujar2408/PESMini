using System;
using System.Collections.Generic;

namespace PESMini.Core.Models;

public partial class Product
{
    public Guid ProductId { get; set; }

    public string ProductCode { get; set; } = null!;

    public string ProductName { get; set; } = null!;

    public string ProductSpec { get; set; } = null!;

    public Guid FcustomerId { get; set; }

    public bool IsActive { get; set; }

    public Guid InsertedBy { get; set; }

    public DateTime InsertedOn { get; set; }

    public Guid? UpdatedBy { get; set; }

    public DateTime? UpdatedOn { get; set; }

    public virtual Customer Fcustomer { get; set; } = null!;

    public virtual User InsertedByNavigation { get; set; } = null!;

    public virtual ICollection<JobOrder> JobOrders { get; set; } = new List<JobOrder>();

    public virtual ICollection<ProductOperationMappingHead> ProductOperationMappingHeads { get; set; } = new List<ProductOperationMappingHead>();

    public virtual User? UpdatedByNavigation { get; set; }
}
