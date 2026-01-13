using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EsperançaSocialDesktop.Models
{
    internal class AgendamentoModel
    {
        public int IdAgendamento { get; set; } // corresponde a id_agendamento
        public int IdFamilia { get; set; } // corresponde a id_familia
        public string NomeFamilia { get; set; } // nome da família, para exibição
        public int IdFuncionario { get; set; } // corresponde a id_funcionario
        public string NomeFuncionario { get; set; } // nome do funcionário, para exibição
        public DateTime DataAgendada { get; set; } // data_agendada
        public string TipoServico { get; set; } // tipo_servico
        public string Status { get; set; } // status (Pendente/Concluído/Cancelado)
    }
}
