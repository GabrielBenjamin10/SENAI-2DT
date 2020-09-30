using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace Api_ORM.Utils
{
    public static class Upload
    {
        public static string Local(IFormFile file)
        {
            var nomeArquivo = Guid.NewGuid().ToString().Replace("-", "") + Path.GetExtension(file.FileName);

            var caminhoArquivo = Path.Combine(Directory.GetCurrentDirectory(), @"wwwRoot\upload\imagens", nomeArquivo);

            //crio um objeto do tipo de filestream passando o caminho do arquivo
            using var streamImagem = new FileStream(caminhoArquivo, FileMode.Create);

            //criando o arquivo no local selecionado
            file.CopyTo(streamImagem);

            return "http://localhost:55745/upload/imagens/" + nomeArquivo;
        } 
    }
}
