using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Diagnostics.CodeAnalysis;
using AdminProject.CommonLayer.Aspects.Utitlities;
using AdminProject.PersistenceLayer.Entities.Common;
using JetBrains.Annotations;

namespace AdminProject.PersistenceLayer.Entities.Entities.RealEstate
{
    public class PropertyMaster : BaseEntity, IAggregateRoot
    {
        public PropertyMaster()
        {
            this.PropertyCertifications = new HashSet<PropertyCertification>();
            this.Towers = new HashSet<PropertyTower>();
            this.Images = new HashSet<PropertyImage>();
        }
        [Required]
        [StringLength(250)]
        public string PropertyName { get; set; }
        public int AreaSize { get; set; }
        public int ConstructionStatus { get; set; } = (int)AspectEnums.ConstructionStage.InProgress;
        [ForeignKey("PropertyId")]
        public PropertyType PropertyType { get; set; }
        [ForeignKey("PropertyId")]
        public virtual ICollection<PropertyCertification> PropertyCertifications { get; set; }
        [ForeignKey("PropertyId")]
        [AllowNull]
        public virtual ICollection<PropertyImage> Images { get; set; }
        [ForeignKey("PropertyId")]
        [AllowNull]
        public virtual ICollection<PropertyTower> Towers { get; set; }
    }

    public class PropertyType : IAggregateRoot
    {
        public int PropertyTypeId { get; set; }
        [Required]
        [StringLength(100)]
        public string Name { get; set; }
        [StringLength(500)]
        public string Description { get; set; }
        [StringLength(50)]
        public string Direction { get; set; }
    }

    public class PropertyTower : BaseEntity, IAggregateRoot
    {
        public PropertyTower()
        {
            this.TowerFloors = new HashSet<PropertyTowerFloor>();
        }
        [Required]
        [StringLength(150)]
        public string TowerName { get; set; }
        public int TowerNumber { get; set; }
        public int ConstructionStatus { get; set; }
        [StringLength(500)]
        public string Description { get; set; }
        public int Floors { get; set; }
        [ForeignKey("TowerId")]
        [AllowNull]
        public virtual ICollection<PropertyTowerFloor> TowerFloors { get; set; }
    }

    public class PropertyTowerFloor : BaseEntity, IAggregateRoot
    {
        public PropertyTowerFloor()
        {
            this.TowerFlats = new HashSet<PropertyFlat>();
        }
        [StringLength(50)]
        public string FloorName { get; set; }
        [Required]
        public int FloorNumber { get; set; }
        public int TotalFlats { get; set; }
        public int TowerId { get; set; }
        public bool IsRoof { get; set; }
        public bool IsGroundFloor { get; set; }
        [ForeignKey("FloorId")]
        [CanBeNull]
        public virtual ICollection<PropertyFlat> TowerFlats { get; set; }
    }

    public class PropertyFlat : IAggregateRoot
    {
        public PropertyFlat()
        {
            this.Rooms = new HashSet<PropertyRoomDetail>();
        }
        public int Id { get; set; }
        public int FlatNumber { get; set; }
        public int TotalRooms { get; set; }
        public int? TotalWashrooms { get; set; }
        public int? TotalBalcony { get; set; }
        public int SuperArea { get; set; }
        public int Cost { get; set; }
        public int? CarpetArea { get; set; }
        public int? AreaMeasurementUnit { get; set; }
        public bool IsStudyRoomIncluded { get; set; }
        public bool IsStoreRoomIncluded { get; set; }
        [ForeignKey("FlatId")]
        [CanBeNull]
        public virtual ICollection<PropertyRoomDetail> Rooms { get; set; }
    }

    public class PropertyRoomDetail
    {
        [Key]
        public int Id { get; set; }
        [StringLength(100)]
        public string Name { get; set; }
        public int RoomType { get; set; } = (int)AspectEnums.RoomType.Master;
        public int? ImageId { get; set; }
        public int? RoomLengthSize { get; set; }
        public int? RoomWidthSize { get; set; }
        public int? RoomHeightSize { get; set; }
        public int TotalSize { get; set; }
        public bool IsAttachedWashRoom { get; set; }
        public bool IsFurnished { get; set; }
        public bool IsAttachedBalcony { get; set; }
    }

    public class PropertyImage : BaseEntity, IAggregateRoot
    {
        [Required]
        [StringLength(150)]
        public string Name { get; set; }
        [StringLength(250)]
        public string Description { get; set; }
        [Required]
        public string Image { get; set; }
    }

    public class PropertyCertification : IAggregateRoot
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        [Required]
        [StringLength(100)]
        public string Name { get; set; }
        public int PropertyId { get; set; }
        public DateTime ValidFrom { get; set; }
        public DateTime ValidUntil { get; set; }
        [StringLength(150)]
        public string IssuedBy { get; set; }
        [StringLength(50)]
        public string CertificationNumber { get; set; }
    }

    public class BuilderProperties
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        [ForeignKey("BuilderId")]
        public BuilderMaster BuilderMaster { get; set; }
        [ForeignKey("PropertyId")]
        public PropertyMaster Property { get; set; }
    }
}
