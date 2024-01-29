using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProEventos.Domain
{
    public class Palestrante
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public string Minicurriculo { get; set; }
        public string ImagemURL { get; set; }
        public string Telefone { get; set; }
        public string Email { get; set; }
        public IEnumerable<RedeSocial> RedesSociais { get; set; }

        public IEnumerable<PalestranteEvento> PalestrantesEventos { get; set; }
    }
}