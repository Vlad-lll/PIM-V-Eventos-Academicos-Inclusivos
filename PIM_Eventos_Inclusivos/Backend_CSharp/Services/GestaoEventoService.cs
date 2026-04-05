using System;
using System.Collections.Generic;
using System.Linq;
using EventosInclusivos.Models;

namespace EventosInclusivos.Services
{
    public class GestaoEventoService
    {
        // Coleção genérica para armazenar inscrições na memória
        private List<Inscricao> bancoDeInscricoes = new List<Inscricao>();

        public void RealizarInscricao(UsuarioParticipante usuario, Atividade atividade)
        {
            try
            {
                if (atividade.VagasDisponiveis <= 0)
                {
                    throw new InvalidOperationException("Não há vagas disponíveis para esta atividade.");
                }

                var novaInscricao = new Inscricao
                {
                    IdInscricao = bancoDeInscricoes.Count + 1,
                    Participante = usuario,
                    AtividadeEscolhida = atividade,
                    DataInscricao = DateTime.Now
                };

                bancoDeInscricoes.Add(novaInscricao);
                atividade.VagasDisponiveis--;
                
                Console.WriteLine("Inscrição efetuada com sucesso!");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Erro ao processar inscrição: {ex.Message}");
            }
        }

        // Uso prático do LINQ para buscar inscritos que necessitam de Libras
        public List<Inscricao> FiltrarInscricoesComNecessidadeLibras()
        {
            return bancoDeInscricoes
                .Where(inscricao => inscricao.Participante.NecessitaLibras == true)
                .OrderBy(inscricao => inscricao.DataInscricao)
                .ToList();
        }
    }
}