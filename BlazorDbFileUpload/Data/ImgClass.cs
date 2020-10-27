using System.ComponentModel.DataAnnotations;

namespace BlazorDbFileUpload.Data
{
    public class ImgClass
    {
        [Key]
        public int ImgId { get; set; }

        //[StringLength(250), Required, DataType(DataType.Text)]
        public string Imgname { get; set; }
        public byte[] Img { get; set; }
    }
}