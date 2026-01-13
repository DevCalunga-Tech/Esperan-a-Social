using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EsperançaSocialDesktop.Models
{
    public class FuncionarioModel
    {
        public int IdFuncionario { get; set; }         // id_funcionario
        public string Nome { get; set; }               // nome
        public string Cargo { get; set; }              // cargo
        public string Telefone { get; set; }           // telefone
        public string Email { get; set; }              // email
        public DateTime DataEntrada { get; set; }      // data_entrada
    }
}
