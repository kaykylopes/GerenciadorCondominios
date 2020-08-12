﻿using System;
using System.Collections.Generic;
using System.Text;

namespace GerenciadorCondominios.BLL.Models
{
   public class Servico
    {
        public int ServicoId { get; set; }
        public string Nome { get; set; }

        public decimal Valor { get; set; }
        public StatusServico Status { get; set; }
        public string usuarioId { get; set; }

        public Usuario Usuario { get; set; }

        public ICollection<ServicoPredio> ServicoPredios { get; set; }
    }

    public enum StatusServico
    {
        Pendente,
        Recusado,
        Aceito
    }
}
