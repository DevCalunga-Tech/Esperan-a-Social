using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EsperançaSocialDesktop.Models
{
    internal class ProjectoModel
    {
        public int IdProjecto { get; set; }          // id_projecto

        public string NomeProjecto { get; set; }     // nome_projecto

        public DateTime DataInicio { get; set; }     // data_inicio

        public DateTime? DataFim { get; set; }       // data_fim (pode ser NULL)

        public string Descricao { get; set; }        // descrição

        public string Status { get; set; }           // status
    }
}
