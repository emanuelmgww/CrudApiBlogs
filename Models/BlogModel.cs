using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CrudApiBlogs.Models
{
    public class BlogModel
    {
        public Guid Id { get; private set; }
        public string NomeUsusario { get; set; }
        public string Titulo { get; set; }
        public string Conteudo { get; set; }
        public DateTime DataCriacao { get; private set; } 
        public DateTime DataEdicao { get; private set; } 
        public DateTime? DataDelecao { get; private set; } 
        public bool BlogAtivo { get; set; } = true;

        public BlogModel(string nomeUsusario, string titulo, string conteudo)
        {
            Id = Guid.NewGuid();
            NomeUsusario = nomeUsusario;
            Titulo = titulo;
            Conteudo = conteudo;
            DataCriacao = DateTime.UtcNow; 
            DataEdicao = DateTime.UtcNow; 
        }

        public void EditarBlog(string novoTitulo, string novoConteudo)
        {
            Titulo = novoTitulo;
            Conteudo = novoConteudo;
            DataEdicao = DateTime.UtcNow; // Atualiza a data de edição
        }

        public void DeletarBlog()
        {
            BlogAtivo = false; 
            DataDelecao = DateTime.UtcNow; 
        }
    }
}