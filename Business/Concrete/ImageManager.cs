using Business.Abstract;
using Business.Constants;
using Core.Utilities.Business;
using Core.Utilities.Helper;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace Business.Concrete
{
    public class ImageManager : IImageService
    {
        IImageDal _imageDal;

        public ImageManager(IImageDal imageDal)
        {
            _imageDal = imageDal;
        }

        public IResult Add(IFormFile file, Image ımage)
        {
            IResult result = BusinessRules.Run(CheckIfImageNull(ımage.ProductId),CheckProductImageLimit(ımage.ProductId));
            if (result != null)
            {
                return result;
            }
            var imageResult = FileHelper.Upload(file);

            if (!imageResult.Success)
            {
                return new ErrorResult(imageResult.Message);
            }

            ımage.ImagePath = imageResult.Message;
            ımage.Date = DateTime.Now;
            _imageDal.Add(ımage);
            return new SuccessResult();
        }

        public IResult Delete(Image ımage)
        {
            IResult result = BusinessRules.Run(ImageDelete(ımage));
            if (result != null)
            {
                return result;
            }
            var allImages = _imageDal.Get(x => x.ImageId == ımage.ImageId);
            if (allImages == null)
            {
                return new ErrorResult();
            }
            FileHelper.Delete(ımage.ImagePath);
            _imageDal.Delete(ımage);
            return new SuccessResult();
        }

        public IDataResult<List<Image>> GetAll()
        {
            return new SuccessDataResult<List<Image>>(_imageDal.GetAll());
        }

        public IDataResult<Image> GetById(int id)
        {
            return new SuccessDataResult<Image>(_imageDal.Get(x => x.ImageId == id));
        }

        public IResult Update(IFormFile file, Image ımage)
        {
            var isImage = _imageDal.Get(x => x.ImageId == ımage.ImageId);
            if (isImage == null)
            {
                return new ErrorResult();
            }
            var updateFile = FileHelper.Update(file, isImage.ImagePath);
            if (!updateFile.Success)
            {
                return new ErrorResult(updateFile.Message);
            }
            ımage.ImagePath = updateFile.Message;
            _imageDal.Update(ımage);
            return new SuccessResult();
        }
        private IDataResult<List<Image>> CheckIfImageNull(int id)
        {
            try
            {
                string path = @"\images\default.jpg";
                var result = _imageDal.GetAll(x => x.ImageId == id);
                if (result.Count>=1)
                {
                    List<Image> image = new List<Image>();
                    image.Add(new Image { ImageId = id, ImagePath = path, Date = DateTime.Now });
                    return new SuccessDataResult<List<Image>>(image);
                }
            }
            catch (Exception e)
            {
                return new ErrorDataResult<List<Image>>(e.Message);
            }
            return new SuccessDataResult<List<Image>>(_imageDal.GetAll(x => x.ImageId == id).ToList());
        }
        private IResult ImageDelete(Image image)
        {
            try
            {
                File.Delete(image.ImagePath);
            }
            catch (Exception e)
            {
                return new ErrorResult(e.Message);
            }
            return new SuccessResult();
        }
        private IResult CheckProductImageLimit(int prodcutId)
        {
            var result = _imageDal.GetAll(x => x.ProductId == prodcutId);
            if (result.Count>=5)
            {
                return new ErrorResult(Messages.ImageLimitExceeded);
            }
            return new SuccessResult();
        }
    }
}
