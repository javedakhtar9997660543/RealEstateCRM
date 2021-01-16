using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Diagnostics.CodeAnalysis;
using System.Text;
using DreamWedds.PersistenceLayer.Entities.Common;

namespace DreamWedds.PersistenceLayer.Entities.Entities
{
    public class Image : IAggregateRoot
    {
        [Obsolete("For persistence only.")]
        public @Image()
        {
        }

        public @Image(int id)
        {
            ImageId = id;
        }

        [Column("IMAGEID")]
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int ImageId { get; protected set; }

        [SuppressMessage("Microsoft.Performance", "CA1819:PropertiesShouldNotReturnArrays")]
        [Column("IMAGEDATA")]
        public byte[] ImageData { get; set; }

        [ForeignKey("Id")]
        public virtual ImageDetail Detail { get; set; }
    }

    public class ImageDetail
    {
        [Obsolete("For persistence only.")]
        public ImageDetail() { }

        public ImageDetail(int imageId)
        {
            ImageId = imageId;
        }

        [Column("IMAGEID")]
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int ImageId { get; internal set; }

        [Column("IMAGESTATUS")]
        public int? ImageStatus { get; set; }

        [Column("IMAGEDESC")]
        public string ImageDescription { get; set; }

        [Column("CONTENTTYPE")]
        public string ContentType { get; set; }

        [Column("IMAGEDESC_TID")]
        public int? DescriptionTId { get; set; }
    }

}
