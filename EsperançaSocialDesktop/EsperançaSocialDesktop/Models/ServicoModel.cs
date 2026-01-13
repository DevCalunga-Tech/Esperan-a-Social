using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EsperançaSocialDesktop.Models
{
    internal class ServicoModel
    {

        public int IdServico { get; set; }

        public string NomeServico { get; set; }

        public string Descricao { get; set; }

        public string Categoria { get; set; }

        public string Periodicidade { get; set; }

        public bool Ativo { get; set; }

        public int IdProjecto { get; set; }  // referência ao projeto
        public string NomeProjecto { get; set; }  // usado para exibir no DataGrid
    }
}
