using Core.Entitites;
using System;

namespace Entities.Concrete
{
    public class Image : IEntity
    {
        public int ImageId { get; set; }
        public string ImagePath { get; set; }
        public int ProductId { get; set; }
        public DateTime Date { get; set; }
    }
}
