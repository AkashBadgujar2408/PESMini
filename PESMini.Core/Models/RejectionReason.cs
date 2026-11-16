using System;
using System.Collections.Generic;

namespace PESMini.Core.Models;

public partial class RejectionReason
{
    public int RejReasonId { get; set; }

    public string RejReasonCode { get; set; } = null!;

    public string RejReasonDesc { get; set; } = null!;

    public bool IsActive { get; set; }

    public Guid InsertedBy { get; set; }

    public DateTime InsertedOn { get; set; }

    public Guid? UpdatedBy { get; set; }

    public DateTime? UpdatedOn { get; set; }

    public virtual User InsertedByNavigation { get; set; } = null!;

    public virtual User? UpdatedByNavigation { get; set; }
}
