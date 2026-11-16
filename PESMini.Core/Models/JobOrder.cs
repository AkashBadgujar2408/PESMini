using System;
using System.Collections.Generic;

namespace PESMini.Core.Models;

public partial class JobOrder
{
    public Guid JobId { get; set; }

    public string JobNo { get; set; } = null!;

    public DateOnly JobDate { get; set; }

    public byte JobQty { get; set; }

    public Guid? FcustomerId { get; set; }

    public Guid? FproductId { get; set; }

    public DateOnly JobEndDate { get; set; }

    public Guid InsertedBy { get; set; }

    public DateTime InsertedOn { get; set; }

    public Guid? UpdatedBy { get; set; }

    public DateTime? UpdatedOn { get; set; }

    public virtual Customer? Fcustomer { get; set; }

    public virtual Product? Fproduct { get; set; }

    public virtual User InsertedByNavigation { get; set; } = null!;

    public virtual User? UpdatedByNavigation { get; set; }
}
