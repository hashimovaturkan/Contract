﻿// <auto-generated />
using System;
using Contract.Domain.Models.DataContexts;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace Contract.Domain.Migrations
{
    [DbContext(typeof(ContractDbContext))]
    [Migration("20220313140107_AddTables")]
    partial class AddTables
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.9")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("Contract.Domain.Models.Entities.Amount", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("GuaranteeAmountCurrency")
                        .HasColumnType("nvarchar(max)");

                    b.Property<double>("GuaranteeAmountValue")
                        .HasColumnType("float");

                    b.HasKey("Id");

                    b.ToTable("Amounts");
                });

            modelBuilder.Entity("Contract.Domain.Models.Entities.ContractModel", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("nvarchar(450)");

                    b.Property<int?>("AmountId")
                        .HasColumnType("int");

                    b.Property<string>("CurrentBalanceCurrency")
                        .HasColumnType("nvarchar(max)");

                    b.Property<double>("CurrentBalanceValue")
                        .HasColumnType("float");

                    b.Property<DateTime>("DateAccountOpened")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("DateOfLastPayment")
                        .HasColumnType("datetime2");

                    b.Property<string>("InstallmentAmountCurrency")
                        .HasColumnType("nvarchar(max)");

                    b.Property<double>("InstallmentAmountValue")
                        .HasColumnType("float");

                    b.Property<DateTime>("NextPaymentDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("OriginalAmountCurrency")
                        .HasColumnType("nvarchar(max)");

                    b.Property<double>("OriginalAmountValue")
                        .HasColumnType("float");

                    b.Property<string>("OverdueBalanceCurrency")
                        .HasColumnType("nvarchar(max)");

                    b.Property<double>("OverdueBalanceValue")
                        .HasColumnType("float");

                    b.Property<string>("PhaseOfContract")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("RealEndDate")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.HasIndex("AmountId");

                    b.ToTable("ContractModels");
                });

            modelBuilder.Entity("Contract.Domain.Models.Entities.Individual", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("nvarchar(450)");

                    b.Property<DateTime>("DateOfBirth")
                        .HasColumnType("datetime2");

                    b.Property<string>("FirstName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Gender")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("LastName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("NationalId")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Individuals");
                });

            modelBuilder.Entity("Contract.Domain.Models.Entities.IndividualRoleRelation", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("IndividualId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<int>("RoleId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("IndividualId");

                    b.HasIndex("RoleId");

                    b.ToTable("IndividualRoleRelation");
                });

            modelBuilder.Entity("Contract.Domain.Models.Entities.IndividualRoleRelationContractRelation", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("ContractModelId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<int>("IndividualRoleRelationId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("ContractModelId");

                    b.HasIndex("IndividualRoleRelationId");

                    b.ToTable("IndividualRoleRelationContractRelation");
                });

            modelBuilder.Entity("Contract.Domain.Models.Entities.Role", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("RoleName")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Roles");
                });

            modelBuilder.Entity("Contract.Domain.Models.Entities.ContractModel", b =>
                {
                    b.HasOne("Contract.Domain.Models.Entities.Amount", "Amount")
                        .WithMany()
                        .HasForeignKey("AmountId");

                    b.Navigation("Amount");
                });

            modelBuilder.Entity("Contract.Domain.Models.Entities.IndividualRoleRelation", b =>
                {
                    b.HasOne("Contract.Domain.Models.Entities.Individual", "Individual")
                        .WithMany("IndividualRoleRelation")
                        .HasForeignKey("IndividualId");

                    b.HasOne("Contract.Domain.Models.Entities.Role", "Role")
                        .WithMany("IndividualRoleRelation")
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Individual");

                    b.Navigation("Role");
                });

            modelBuilder.Entity("Contract.Domain.Models.Entities.IndividualRoleRelationContractRelation", b =>
                {
                    b.HasOne("Contract.Domain.Models.Entities.ContractModel", "ContractModel")
                        .WithMany("IndividualRoleRelationContractRelation")
                        .HasForeignKey("ContractModelId");

                    b.HasOne("Contract.Domain.Models.Entities.IndividualRoleRelation", "IndividualRoleRelation")
                        .WithMany("IndividualRoleRelationContractRelation")
                        .HasForeignKey("IndividualRoleRelationId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("ContractModel");

                    b.Navigation("IndividualRoleRelation");
                });

            modelBuilder.Entity("Contract.Domain.Models.Entities.ContractModel", b =>
                {
                    b.Navigation("IndividualRoleRelationContractRelation");
                });

            modelBuilder.Entity("Contract.Domain.Models.Entities.Individual", b =>
                {
                    b.Navigation("IndividualRoleRelation");
                });

            modelBuilder.Entity("Contract.Domain.Models.Entities.IndividualRoleRelation", b =>
                {
                    b.Navigation("IndividualRoleRelationContractRelation");
                });

            modelBuilder.Entity("Contract.Domain.Models.Entities.Role", b =>
                {
                    b.Navigation("IndividualRoleRelation");
                });
#pragma warning restore 612, 618
        }
    }
}
