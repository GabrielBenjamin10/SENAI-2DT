using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace EFCore.Utills
{
    // classes estaticas não instancia-se
    public static class Upload
    {
        public static string Local(IFormFile file)
        {
            // Gero o nome do arquivo unico
            // Gero a extensao do arquivo
            // Concateno o nome do arquivo com sua extensao
            // 8fhw78wy87ftw8fhun.png
            var nomeArquivo = Guid.NewGuid().ToString().Replace("-", " ") + Path.GetExtension(file.FileName);

            // GetCurrentDirectory - Pega o caminho do diretório atual, aplicação esta
            var caminhoArquivo = Path.Combine(Directory.GetCurrentDirectory(), @"wwwroot/upload/imagens", nomeArquivo);

            // Cria um objeto do tipo FileStream passando o caminho do arquivo
            // Passa para criar esse arquivo
            using var streamImagem = new FileStream(caminhoArquivo, FileMode.Create);

            // Faz a mesma função do save changes
            // Executando o comando de criação do arquivo no local informado
            file.CopyTo(streamImagem);

            // Atribuimos um valor a nossa url imagem
            return "https://localhost:44338/upload/imagens/" + nomeArquivo;
        }
    }

}
