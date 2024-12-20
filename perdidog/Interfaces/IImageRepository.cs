using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using perdidog.Models.Domain;

namespace perdidog.Interfaces
{
    public interface IImageRepository
    {
        Task<Image> Upload(Image image);
    }
}