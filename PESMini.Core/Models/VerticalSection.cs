using System;
using System.Collections.Generic;

namespace PESMini.Core.Models;

public partial class VerticalSection
{
    public int VerticalSectionId { get; set; }

    public string VerticalSectionCode { get; set; } = null!;

    public string VerticalSectionName { get; set; } = null!;

    public bool IsActive { get; set; }

    public Guid InsertedBy { get; set; }

    public DateTime InsertedOn { get; set; }

    public Guid? UpdatedBy { get; set; }

    public DateTime? UpdatedOn { get; set; }

    public virtual User InsertedByNavigation { get; set; } = null!;

    public virtual ICollection<Machine> Machines { get; set; } = new List<Machine>();

    public virtual User? UpdatedByNavigation { get; set; }
}
