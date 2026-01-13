using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EsperancaSocial.Desktop.Models
{
    public class FamiliaModel
    {
        public int IdFamilia { get; set; }
        public string NomeResponsavel { get; set; }
        public string Telefone { get; set; }
        public string Endereco { get; set; }
        public string Bairro { get; set; }
        public int NumeroMembros { get; set; }
        public decimal RendaFamiliar { get; set; }
        public DateTime DataCadastro { get; set; }
        public string Situacao { get; set; }
    }
}