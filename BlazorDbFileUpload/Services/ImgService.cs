using BlazorDbFileUpload.Data;

namespace BlazorDbFileUpload.Services
{
    public class ImgService
    {
        private readonly ImageDbContext _dbContext;

        public ImgService(ImageDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public bool Uploadimg(ImgClass imgClass)
        {
            _dbContext.ImgClasses.Add(imgClass);
            _dbContext.SaveChanges();
            return true;
        }
    }
}