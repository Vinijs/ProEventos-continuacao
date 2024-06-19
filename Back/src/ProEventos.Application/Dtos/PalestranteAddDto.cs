using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProEventos.Application.Dtos
{
    public class PalestranteAddDto
    {
        public int Id { get; set; }
        public string Minicurriculo { get; set; }
        public int UserId { get; set; }
    }
}