﻿using System;
using System.Collections.Generic;

#nullable disable

namespace spm_group.Domains
{
    public partial class Consulta
    {
        public int IdConsulta { get; set; }
        public int IdPaciente { get; set; }
        public int IdMedico { get; set; }
        public int? IdSituacao { get; set; }
        public DateTime DataAgendamento { get; set; }
        public string Descricao { get; set; }

        public virtual Medico IdMedicoNavigation { get; set; }
        public virtual Paciente IdPacienteNavigation { get; set; }
        public virtual Situaco IdSituacaoNavigation { get; set; }
    }
}
