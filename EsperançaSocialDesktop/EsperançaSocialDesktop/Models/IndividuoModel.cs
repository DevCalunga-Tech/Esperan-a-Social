using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EsperançaSocialDesktop.Models
{
    public class IndividuoModel
    {
        public int IdIndividuo { get; set; }
        public int IdFamilia { get; set; }
        public string Nome { get; set; }
        public DateTime DataNascimento { get; set; }
        public string Genero { get; set; }
        public string Escolaridade { get; set; }
        public string Parentesco { get; set; }
        public string CondicaoSaude { get; set; }
        public string Observacoes { get; set; }
    }
}
