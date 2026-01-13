using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EsperançaSocialDesktop.Models
{
    internal class DoacaoModel
    {

        public int IdDoacao { get; set; }              // ID da doação (auto-incremento no banco)
        public int IdDoador { get; set; }             // FK para o doador
        public string TipoDoacao { get; set; }        // Tipo de doação (dinheiro, alimento, etc.)
        public string Descricao { get; set; }         // Descrição da doação
        public int? Quantidade { get; set; }          // Quantidade (opcional)
        public decimal? ValorEstimado { get; set; }   // Valor estimado (opcional)
        public DateTime DataDoacao { get; set; }      // Data da doação

        // Opcional: Nome do doador para exibir no DataGridView
        public string NomeDoador { get; set; }
    }
}
