using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CrudApiBlogs.Models;

public record BlogRequest(string NomeUsusario, string Titulo, string Conteudo);
