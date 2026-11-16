using System;
using System.Collections.Generic;

namespace PESMini.Core.Models;

public partial class Customer
{
    public Guid CustomerId { get; set; }

    public string CustomerCode { get; set; } = null!;

    public string CustomerName { get; set; } = null!;

    public string Address { get; set; } = null!;

    public string City { get; set; } = null!;

    public bool IsActive { get; set; }

    public Guid InsertedBy { get; set; }

    public DateTime InsertedOn { get; set; }

    public Guid? UpdatedBy { get; set; }

    public DateTime? UpdatedOn { get; set; }

    public virtual User InsertedByNavigation { get; set; } = null!;

    public virtual ICollection<JobOrder> JobOrders { get; set; } = new List<JobOrder>();

    public virtual ICollection<Product> Products { get; set; } = new List<Product>();

    public virtual User? UpdatedByNavigation { get; set; }
}
