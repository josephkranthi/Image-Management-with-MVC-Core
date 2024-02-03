using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel;

namespace Crud_Images.Models;

public partial class Image
{
    public int ImageId { get; set; }

    [DisplayName("Uploaded Image")]
    public string? ImageName { get; set; }

    // Property to store the image data as binary (BLOB)
    public byte[]? ImageData { get; set; }

    [NotMapped]
    [DisplayName("Upload Image")]
    public IFormFile? ImageFile { get; set; }
}