using Core.Utilities.Results;
using Entities.Concrete;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Abstract
{
    public interface IImageService
    {
        IResult Add(IFormFile file, Image ımage);
        IResult Update(IFormFile file, Image ımage);
        IResult Delete(Image ımage);
        IDataResult<Image> GetById(int id);
        IDataResult<List<Image>> GetAll();
    }
}
