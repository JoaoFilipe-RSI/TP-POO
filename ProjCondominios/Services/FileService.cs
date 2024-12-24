using System;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using ProjCondominios.Models;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace ProjCondominios.Services
{
    public class FileService
    {
        #region Propriedades privadas
        // Caminhos completos dos arquivos JSON
        private string _diretorioBase = @"C:\CLONE\ProjCondominios\Data";
        private string _caminhoArquivoCondominios;
        private string _caminhoArquivoCondominos;
        private string _caminhoArquivoFracoes;
        #endregion

        #region Construtor
        public FileService()
        {
            // Definindo os caminhos dos arquivos JSON
            _caminhoArquivoCondominios = Path.Combine(_diretorioBase, "condominios.json");
            _caminhoArquivoCondominos = Path.Combine(_diretorioBase, "condominos.json");
            _caminhoArquivoFracoes = Path.Combine(_diretorioBase, "fracoes.json");

            // Garantir que o diretório exista
            if (!Directory.Exists(_diretorioBase))
            {
                Directory.CreateDirectory(_diretorioBase);
            }
        }
        #endregion

        #region metodos
        // Salva os dados dos condomínios num arquivo JSON
        public void SalvarCondominios(List<Condominio> condominios)
        {
            var json = JsonConvert.SerializeObject(condominios, Formatting.Indented);
            File.WriteAllText(_caminhoArquivoCondominios, json);
        }

        // Carrega os dados dos condomínios a partir de um arquivo JSON
        public List<Condominio> CarregarCondominios()
        {
            if (File.Exists(_caminhoArquivoCondominios))
            {
                var json = File.ReadAllText(_caminhoArquivoCondominios);
                return JsonConvert.DeserializeObject<List<Condominio>>(json);
            }
            return new List<Condominio>();
        }

        // Salva os dados dos condóminos num arquivo JSON
        public void SalvarCondominos(List<Condomino> condominos)
        {
            var json = JsonConvert.SerializeObject(condominos, Formatting.Indented);
            File.WriteAllText(_caminhoArquivoCondominos, json);
        }

        // Carrega os dados dos condóminos a partir de um arquivo JSON
        public List<Condomino> CarregarCondominos()
        {
            if (File.Exists(_caminhoArquivoCondominos))
            {
                var json = File.ReadAllText(_caminhoArquivoCondominos);
                return JsonConvert.DeserializeObject<List<Condomino>>(json);
            }
            return new List<Condomino>();
        }

        // Salva os dados das frações num arquivo JSON
        public void SalvarFracoes(List<FracaoAutonoma> fracoes)
        {
            try
            {
                var settings = new JsonSerializerSettings
                {
                    NullValueHandling = NullValueHandling.Ignore, // Ignorar valores nulos
                    Formatting = Formatting.Indented
                };

                string json = JsonConvert.SerializeObject(fracoes, Formatting.Indented);
                File.WriteAllText(_caminhoArquivoFracoes, json);
            }
            catch (Exception ex)
            {
                throw new Exception("Erro ao salvar frações: " + ex.Message);
            }
        }

        // Carrega os dados das frações a partir de um arquivo JSON
        public List<FracaoAutonoma> CarregarFracoes()
        {
            try
            {
                if (!File.Exists(_caminhoArquivoFracoes))
                    return new List<FracaoAutonoma>();

                string json = File.ReadAllText(_caminhoArquivoFracoes);
                return JsonConvert.DeserializeObject<List<FracaoAutonoma>>(json);
            }
            catch (Exception ex)
            {
                throw new Exception("Erro ao carregar frações: " + ex.Message);
            }
        }
        #endregion
    }
}
