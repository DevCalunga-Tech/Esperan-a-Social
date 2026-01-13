using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EsperançaSocialDesktop.Models
{
    public class AtendimentoModel
    {
        // ====== CAMPOS DA TABELA ======
        public int IdAtendimento { get; set; }

        public int IdFamilia { get; set; }
        public string NomeFamilia { get; set; }

        public int? IdIndividuo { get; set; }
        public string NomeIndividuo { get; set; }

        public int IdServico { get; set; }
        public string NomeServico { get; set; }

        public int IdFuncionario { get; set; }
        public string NomeFuncionario { get; set; }

        public DateTime DataAtendimento { get; set; }
        public string TipoAtendimento { get; set; }
        public string Observacoes { get; set; }

    }
}
