using System;
using System.Collections.Generic;

namespace EventosInclusivos.Models
{
    public class Evento
    {
        public int IdEvento { get; set; }
        public string Titulo { get; set; }
        public DateTime DataRealizacao { get; set; }
        public bool SuporteLibras { get; set; }
        
        // Relacionamentos
        public List<Atividade> Atividades { get; set; } = new List<Atividade>();
    }

    public class Atividade
    {
        public int IdAtividade { get; set; }
        public string NomePalestra { get; set; }
        public int VagasDisponiveis { get; set; }
    }

    public class Inscricao
    {
        public int IdInscricao { get; set; }
        public UsuarioParticipante Participante { get; set; }
        public Atividade AtividadeEscolhida { get; set; }
        public DateTime DataInscricao { get; set; }
    }
}