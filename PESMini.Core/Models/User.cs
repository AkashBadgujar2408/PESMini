using System;
using System.Collections.Generic;

namespace PESMini.Core.Models;

public partial class User
{
    public Guid UserId { get; set; }

    public string UserName { get; set; } = null!;

    public string EmployeeName { get; set; } = null!;

    public string ContactNum { get; set; } = null!;

    public string Email { get; set; } = null!;

    public bool HasAdminRights { get; set; }

    public bool IsActive { get; set; }

    public virtual ICollection<Customer> CustomerInsertedByNavigations { get; set; } = new List<Customer>();

    public virtual ICollection<Customer> CustomerUpdatedByNavigations { get; set; } = new List<Customer>();

    public virtual ICollection<DownTimeReason> DownTimeReasonInsertedByNavigations { get; set; } = new List<DownTimeReason>();

    public virtual ICollection<DownTimeReason> DownTimeReasonUpdatedByNavigations { get; set; } = new List<DownTimeReason>();

    public virtual ICollection<JobOrder> JobOrderInsertedByNavigations { get; set; } = new List<JobOrder>();

    public virtual ICollection<JobOrder> JobOrderUpdatedByNavigations { get; set; } = new List<JobOrder>();

    public virtual ICollection<Machine> MachineInsertedByNavigations { get; set; } = new List<Machine>();

    public virtual ICollection<MachineOperationMapping> MachineOperationMappingInsertedByNavigations { get; set; } = new List<MachineOperationMapping>();

    public virtual ICollection<MachineOperationMapping> MachineOperationMappingUpdatedByNavigations { get; set; } = new List<MachineOperationMapping>();

    public virtual ICollection<Machine> MachineUpdatedByNavigations { get; set; } = new List<Machine>();

    public virtual ICollection<Operator> OperatorInsertedByNavigations { get; set; } = new List<Operator>();

    public virtual ICollection<Operator> OperatorUpdatedByNavigations { get; set; } = new List<Operator>();

    public virtual ICollection<Product> ProductInsertedByNavigations { get; set; } = new List<Product>();

    public virtual ICollection<ProductOperationMappingDetail> ProductOperationMappingDetailInsertedByNavigations { get; set; } = new List<ProductOperationMappingDetail>();

    public virtual ICollection<ProductOperationMappingDetail> ProductOperationMappingDetailUpdatedByNavigations { get; set; } = new List<ProductOperationMappingDetail>();

    public virtual ICollection<ProductOperationMappingHead> ProductOperationMappingHeadInsertedByNavigations { get; set; } = new List<ProductOperationMappingHead>();

    public virtual ICollection<ProductOperationMappingHead> ProductOperationMappingHeadUpdatedByNavigations { get; set; } = new List<ProductOperationMappingHead>();

    public virtual ICollection<Product> ProductUpdatedByNavigations { get; set; } = new List<Product>();

    public virtual ICollection<ProductionOperation> ProductionOperationInsertedByNavigations { get; set; } = new List<ProductionOperation>();

    public virtual ICollection<ProductionOperation> ProductionOperationUpdatedByNavigations { get; set; } = new List<ProductionOperation>();

    public virtual ICollection<RejectionReason> RejectionReasonInsertedByNavigations { get; set; } = new List<RejectionReason>();

    public virtual ICollection<RejectionReason> RejectionReasonUpdatedByNavigations { get; set; } = new List<RejectionReason>();

    public virtual ICollection<VerticalSection> VerticalSectionInsertedByNavigations { get; set; } = new List<VerticalSection>();

    public virtual ICollection<VerticalSection> VerticalSectionUpdatedByNavigations { get; set; } = new List<VerticalSection>();
}
