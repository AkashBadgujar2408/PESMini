using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace PESMini.Core.Models;

public partial class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Customer> Customers { get; set; }

    public virtual DbSet<DownTimeReason> DownTimeReasons { get; set; }

    public virtual DbSet<JobOrder> JobOrders { get; set; }

    public virtual DbSet<Machine> Machines { get; set; }

    public virtual DbSet<MachineOperationMapping> MachineOperationMappings { get; set; }

    public virtual DbSet<Operator> Operators { get; set; }

    public virtual DbSet<Product> Products { get; set; }

    public virtual DbSet<ProductOperationMappingDetail> ProductOperationMappingDetails { get; set; }

    public virtual DbSet<ProductOperationMappingHead> ProductOperationMappingHeads { get; set; }

    public virtual DbSet<ProductionOperation> ProductionOperations { get; set; }

    public virtual DbSet<ProductionShift> ProductionShifts { get; set; }

    public virtual DbSet<RejectionReason> RejectionReasons { get; set; }

    public virtual DbSet<User> Users { get; set; }

    public virtual DbSet<VerticalSection> VerticalSections { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Customer>(entity =>
        {
            entity.HasKey(e => e.CustomerId).HasName("PK__Customer__A4AE64D8A90A6659");

            entity.HasIndex(e => e.CustomerCode, "UQ__Customer__066785210423C05E").IsUnique();

            entity.Property(e => e.CustomerId).HasDefaultValueSql("(newsequentialid())");
            entity.Property(e => e.Address)
                .HasMaxLength(200)
                .IsUnicode(false);
            entity.Property(e => e.City)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.CustomerCode)
                .HasMaxLength(20)
                .IsUnicode(false);
            entity.Property(e => e.CustomerName)
                .HasMaxLength(80)
                .IsUnicode(false);
            entity.Property(e => e.InsertedOn).HasPrecision(3);
            entity.Property(e => e.IsActive).HasDefaultValue(true);
            entity.Property(e => e.UpdatedOn).HasPrecision(3);

            entity.HasOne(d => d.InsertedByNavigation).WithMany(p => p.CustomerInsertedByNavigations)
                .HasForeignKey(d => d.InsertedBy)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Customers__Inser__534D60F1");

            entity.HasOne(d => d.UpdatedByNavigation).WithMany(p => p.CustomerUpdatedByNavigations)
                .HasForeignKey(d => d.UpdatedBy)
                .HasConstraintName("FK__Customers__Updat__5441852A");
        });

        modelBuilder.Entity<DownTimeReason>(entity =>
        {
            entity.HasKey(e => e.DownTimeReasonId).HasName("PK__DownTime__406FB3AEEC4969D2");

            entity.HasIndex(e => e.DownTimeReasonCode, "UQ__DownTime__94E7A0D4254E201D").IsUnique();

            entity.Property(e => e.DownTimeDesc)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.DownTimeReasonCode)
                .HasMaxLength(20)
                .IsUnicode(false);
            entity.Property(e => e.InsertedOn).HasPrecision(3);
            entity.Property(e => e.IsActive).HasDefaultValue(true);
            entity.Property(e => e.UpdatedOn).HasPrecision(3);

            entity.HasOne(d => d.InsertedByNavigation).WithMany(p => p.DownTimeReasonInsertedByNavigations)
                .HasForeignKey(d => d.InsertedBy)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__DownTimeR__Inser__7B5B524B");

            entity.HasOne(d => d.UpdatedByNavigation).WithMany(p => p.DownTimeReasonUpdatedByNavigations)
                .HasForeignKey(d => d.UpdatedBy)
                .HasConstraintName("FK__DownTimeR__Updat__7C4F7684");
        });

        modelBuilder.Entity<JobOrder>(entity =>
        {
            entity.HasKey(e => e.JobId).HasName("PK__JobOrder__056690C2DCDAC5C6");

            entity.Property(e => e.JobId).HasDefaultValueSql("(newsequentialid())");
            entity.Property(e => e.FcustomerId).HasColumnName("FCustomerId");
            entity.Property(e => e.FproductId).HasColumnName("FProductId");
            entity.Property(e => e.InsertedOn).HasPrecision(3);
            entity.Property(e => e.JobNo)
                .HasMaxLength(20)
                .IsUnicode(false);
            entity.Property(e => e.UpdatedOn).HasPrecision(3);

            entity.HasOne(d => d.Fcustomer).WithMany(p => p.JobOrders)
                .HasForeignKey(d => d.FcustomerId)
                .HasConstraintName("FK__JobOrders__FCust__25518C17");

            entity.HasOne(d => d.Fproduct).WithMany(p => p.JobOrders)
                .HasForeignKey(d => d.FproductId)
                .HasConstraintName("FK__JobOrders__FProd__2645B050");

            entity.HasOne(d => d.InsertedByNavigation).WithMany(p => p.JobOrderInsertedByNavigations)
                .HasForeignKey(d => d.InsertedBy)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__JobOrders__Inser__2739D489");

            entity.HasOne(d => d.UpdatedByNavigation).WithMany(p => p.JobOrderUpdatedByNavigations)
                .HasForeignKey(d => d.UpdatedBy)
                .HasConstraintName("FK__JobOrders__Updat__282DF8C2");
        });

        modelBuilder.Entity<Machine>(entity =>
        {
            entity.HasKey(e => e.MachineId).HasName("PK__Machines__44EE5B38C77F67FC");

            entity.HasIndex(e => e.MachineCode, "UQ__Machines__DB84B5B8CDE62FFB").IsUnique();

            entity.Property(e => e.FverticalSectionId).HasColumnName("FVerticalSectionId");
            entity.Property(e => e.InsertedOn).HasPrecision(3);
            entity.Property(e => e.IsActive).HasDefaultValue(true);
            entity.Property(e => e.MachineCode)
                .HasMaxLength(20)
                .IsUnicode(false);
            entity.Property(e => e.ProdCycleTimeReqd).HasDefaultValue(true);
            entity.Property(e => e.UpdatedOn).HasPrecision(3);

            entity.HasOne(d => d.FverticalSection).WithMany(p => p.Machines)
                .HasForeignKey(d => d.FverticalSectionId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Machines__FVerti__00200768");

            entity.HasOne(d => d.InsertedByNavigation).WithMany(p => p.MachineInsertedByNavigations)
                .HasForeignKey(d => d.InsertedBy)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Machines__Insert__02FC7413");

            entity.HasOne(d => d.UpdatedByNavigation).WithMany(p => p.MachineUpdatedByNavigations)
                .HasForeignKey(d => d.UpdatedBy)
                .HasConstraintName("FK__Machines__Update__03F0984C");
        });

        modelBuilder.Entity<MachineOperationMapping>(entity =>
        {
            entity.HasKey(e => new { e.FmachineId, e.FoperationId });

            entity.ToTable("MachineOperationMapping");

            entity.HasIndex(e => e.MacOpMapId, "UQ__MachineO__63635F376948A190").IsUnique();

            entity.Property(e => e.FmachineId).HasColumnName("FMachineId");
            entity.Property(e => e.FoperationId).HasColumnName("FOperationId");
            entity.Property(e => e.InsertedOn).HasPrecision(3);
            entity.Property(e => e.IsActive).HasDefaultValue(true);
            entity.Property(e => e.MacOpMapId).ValueGeneratedOnAdd();
            entity.Property(e => e.UpdatedOn).HasPrecision(3);

            entity.HasOne(d => d.Fmachine).WithMany(p => p.MachineOperationMappings)
                .HasForeignKey(d => d.FmachineId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__MachineOp__FMach__07C12930");

            entity.HasOne(d => d.Foperation).WithMany(p => p.MachineOperationMappings)
                .HasForeignKey(d => d.FoperationId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__MachineOp__FOper__08B54D69");

            entity.HasOne(d => d.InsertedByNavigation).WithMany(p => p.MachineOperationMappingInsertedByNavigations)
                .HasForeignKey(d => d.InsertedBy)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__MachineOp__Inser__0A9D95DB");

            entity.HasOne(d => d.UpdatedByNavigation).WithMany(p => p.MachineOperationMappingUpdatedByNavigations)
                .HasForeignKey(d => d.UpdatedBy)
                .HasConstraintName("FK__MachineOp__Updat__0B91BA14");
        });

        modelBuilder.Entity<Operator>(entity =>
        {
            entity.HasKey(e => e.OperatorId).HasName("PK__Operator__7BB12FAEC9FDC65C");

            entity.HasIndex(e => e.OperatorCode, "UQ__Operator__8C70C4277BF5ED11").IsUnique();

            entity.Property(e => e.EmpCode)
                .HasMaxLength(20)
                .IsUnicode(false);
            entity.Property(e => e.InsertedOn).HasPrecision(3);
            entity.Property(e => e.IsActive).HasDefaultValue(true);
            entity.Property(e => e.MobileNum)
                .HasMaxLength(20)
                .IsUnicode(false);
            entity.Property(e => e.OperatorCode)
                .HasMaxLength(20)
                .IsUnicode(false);
            entity.Property(e => e.OperatorName)
                .HasMaxLength(80)
                .IsUnicode(false);
            entity.Property(e => e.UpdatedOn).HasPrecision(3);

            entity.HasOne(d => d.InsertedByNavigation).WithMany(p => p.OperatorInsertedByNavigations)
                .HasForeignKey(d => d.InsertedBy)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Operators__Inser__6FE99F9F");

            entity.HasOne(d => d.UpdatedByNavigation).WithMany(p => p.OperatorUpdatedByNavigations)
                .HasForeignKey(d => d.UpdatedBy)
                .HasConstraintName("FK__Operators__Updat__70DDC3D8");
        });

        modelBuilder.Entity<Product>(entity =>
        {
            entity.HasKey(e => e.ProductId).HasName("PK__Products__B40CC6CDA44896A8");

            entity.HasIndex(e => e.ProductCode, "UQ__Products__2F4E024F3B29F660").IsUnique();

            entity.Property(e => e.ProductId).HasDefaultValueSql("(newsequentialid())");
            entity.Property(e => e.FcustomerId).HasColumnName("FCustomerId");
            entity.Property(e => e.InsertedOn).HasPrecision(3);
            entity.Property(e => e.IsActive).HasDefaultValue(true);
            entity.Property(e => e.ProductCode)
                .HasMaxLength(20)
                .IsUnicode(false);
            entity.Property(e => e.ProductName)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.ProductSpec)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.UpdatedOn).HasPrecision(3);

            entity.HasOne(d => d.Fcustomer).WithMany(p => p.Products)
                .HasForeignKey(d => d.FcustomerId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Products__FCusto__59063A47");

            entity.HasOne(d => d.InsertedByNavigation).WithMany(p => p.ProductInsertedByNavigations)
                .HasForeignKey(d => d.InsertedBy)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Products__Insert__5AEE82B9");

            entity.HasOne(d => d.UpdatedByNavigation).WithMany(p => p.ProductUpdatedByNavigations)
                .HasForeignKey(d => d.UpdatedBy)
                .HasConstraintName("FK__Products__Update__5BE2A6F2");
        });

        modelBuilder.Entity<ProductOperationMappingDetail>(entity =>
        {
            entity.HasKey(e => new { e.FprodOpMapHeadId, e.FoperationId }).HasName("PK_ProductOperationUniqueMap");

            entity.Property(e => e.FprodOpMapHeadId).HasColumnName("FProdOpMapHeadId");
            entity.Property(e => e.FoperationId).HasColumnName("FOperationId");
            entity.Property(e => e.InsertedOn).HasPrecision(3);
            entity.Property(e => e.ProdOpMapDetailId).ValueGeneratedOnAdd();
            entity.Property(e => e.UpdatedOn).HasPrecision(3);

            entity.HasOne(d => d.Foperation).WithMany(p => p.ProductOperationMappingDetails)
                .HasForeignKey(d => d.FoperationId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__ProductOp__FOper__1BC821DD");

            entity.HasOne(d => d.FprodOpMapHead).WithMany(p => p.ProductOperationMappingDetails)
                .HasForeignKey(d => d.FprodOpMapHeadId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__ProductOp__FProd__1AD3FDA4");

            entity.HasOne(d => d.InsertedByNavigation).WithMany(p => p.ProductOperationMappingDetailInsertedByNavigations)
                .HasForeignKey(d => d.InsertedBy)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__ProductOp__Inser__1DB06A4F");

            entity.HasOne(d => d.UpdatedByNavigation).WithMany(p => p.ProductOperationMappingDetailUpdatedByNavigations)
                .HasForeignKey(d => d.UpdatedBy)
                .HasConstraintName("FK__ProductOp__Updat__1EA48E88");
        });

        modelBuilder.Entity<ProductOperationMappingHead>(entity =>
        {
            entity.HasKey(e => e.ProdOpMapHeadId).HasName("PK__ProductO__24D5C22C3716FED0");

            entity.Property(e => e.FproductId).HasColumnName("FProductId");
            entity.Property(e => e.InsertedOn).HasPrecision(3);
            entity.Property(e => e.UpdatedOn).HasPrecision(3);

            entity.HasOne(d => d.Fproduct).WithMany(p => p.ProductOperationMappingHeads)
                .HasForeignKey(d => d.FproductId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__ProductOp__FProd__160F4887");

            entity.HasOne(d => d.InsertedByNavigation).WithMany(p => p.ProductOperationMappingHeadInsertedByNavigations)
                .HasForeignKey(d => d.InsertedBy)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__ProductOp__Inser__17036CC0");

            entity.HasOne(d => d.UpdatedByNavigation).WithMany(p => p.ProductOperationMappingHeadUpdatedByNavigations)
                .HasForeignKey(d => d.UpdatedBy)
                .HasConstraintName("FK__ProductOp__Updat__17F790F9");
        });

        modelBuilder.Entity<ProductionOperation>(entity =>
        {
            entity.HasKey(e => e.OperationId).HasName("PK__Producti__A4F5FC441E586419");

            entity.HasIndex(e => e.OperationCode, "UQ__Producti__8BE3D7B04DA91AE0").IsUnique();

            entity.Property(e => e.InsertedOn).HasPrecision(3);
            entity.Property(e => e.IsActive).HasDefaultValue(true);
            entity.Property(e => e.OperationCode)
                .HasMaxLength(20)
                .IsUnicode(false);
            entity.Property(e => e.OperationName)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.ProdCycleTimeReqd).HasDefaultValue(true);
            entity.Property(e => e.UpdatedOn).HasPrecision(3);

            entity.HasOne(d => d.InsertedByNavigation).WithMany(p => p.ProductionOperationInsertedByNavigations)
                .HasForeignKey(d => d.InsertedBy)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Productio__Inser__6A30C649");

            entity.HasOne(d => d.UpdatedByNavigation).WithMany(p => p.ProductionOperationUpdatedByNavigations)
                .HasForeignKey(d => d.UpdatedBy)
                .HasConstraintName("FK__Productio__Updat__6B24EA82");
        });

        modelBuilder.Entity<ProductionShift>(entity =>
        {
            entity.HasKey(e => e.ShiftId).HasName("PK__Producti__C0A8388105A51456");

            entity.Property(e => e.IsActive).HasDefaultValue(true);
            entity.Property(e => e.ShiftCode)
                .HasMaxLength(20)
                .IsUnicode(false);
            entity.Property(e => e.ShiftName)
                .HasMaxLength(50)
                .IsUnicode(false);
        });

        modelBuilder.Entity<RejectionReason>(entity =>
        {
            entity.HasKey(e => e.RejReasonId).HasName("PK__Rejectio__2A9974F4F84D4C6A");

            entity.HasIndex(e => e.RejReasonCode, "UQ__Rejectio__AFBC671F85634730").IsUnique();

            entity.Property(e => e.InsertedOn).HasPrecision(3);
            entity.Property(e => e.IsActive).HasDefaultValue(true);
            entity.Property(e => e.RejReasonCode)
                .HasMaxLength(20)
                .IsUnicode(false);
            entity.Property(e => e.RejReasonDesc)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.UpdatedOn).HasPrecision(3);

            entity.HasOne(d => d.InsertedByNavigation).WithMany(p => p.RejectionReasonInsertedByNavigations)
                .HasForeignKey(d => d.InsertedBy)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Rejection__Inser__75A278F5");

            entity.HasOne(d => d.UpdatedByNavigation).WithMany(p => p.RejectionReasonUpdatedByNavigations)
                .HasForeignKey(d => d.UpdatedBy)
                .HasConstraintName("FK__Rejection__Updat__76969D2E");
        });

        modelBuilder.Entity<User>(entity =>
        {
            entity.HasKey(e => e.UserId).HasName("PK__Users__1788CC4CC569C32C");

            entity.HasIndex(e => e.UserName, "UQ__Users__C9F2845692140162").IsUnique();

            entity.Property(e => e.UserId).HasDefaultValueSql("(newsequentialid())");
            entity.Property(e => e.ContactNum)
                .HasMaxLength(20)
                .IsUnicode(false);
            entity.Property(e => e.Email)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.EmployeeName)
                .HasMaxLength(80)
                .IsUnicode(false);
            entity.Property(e => e.IsActive).HasDefaultValue(true);
            entity.Property(e => e.UserName)
                .HasMaxLength(20)
                .IsUnicode(false);
        });

        modelBuilder.Entity<VerticalSection>(entity =>
        {
            entity.HasKey(e => e.VerticalSectionId).HasName("PK__Vertical__FCB2D0E7EE61D8CA");

            entity.HasIndex(e => e.VerticalSectionCode, "UQ__Vertical__EB380965560607CB").IsUnique();

            entity.Property(e => e.InsertedOn).HasPrecision(3);
            entity.Property(e => e.IsActive).HasDefaultValue(true);
            entity.Property(e => e.UpdatedOn).HasPrecision(3);
            entity.Property(e => e.VerticalSectionCode)
                .HasMaxLength(20)
                .IsUnicode(false);
            entity.Property(e => e.VerticalSectionName)
                .HasMaxLength(80)
                .IsUnicode(false);

            entity.HasOne(d => d.InsertedByNavigation).WithMany(p => p.VerticalSectionInsertedByNavigations)
                .HasForeignKey(d => d.InsertedBy)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__VerticalS__Inser__60A75C0F");

            entity.HasOne(d => d.UpdatedByNavigation).WithMany(p => p.VerticalSectionUpdatedByNavigations)
                .HasForeignKey(d => d.UpdatedBy)
                .HasConstraintName("FK__VerticalS__Updat__619B8048");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
