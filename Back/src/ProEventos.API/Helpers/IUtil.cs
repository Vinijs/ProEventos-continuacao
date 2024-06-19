using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;

namespace ProEventos.API.Helpers
{
    public interface IUtil
    {
         Task<string> SaveImage(IFormFile imageFile, string destino);
         void DeleteImage(string imageName, string destino);
    }
}