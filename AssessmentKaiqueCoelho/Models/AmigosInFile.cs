using AssessmentKaiqueCoelho.Interface;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AssessmentKaiqueCoelho.Models
{
    internal class AmigosInFile : ManipuladorDeAmigos
    {

        private List<Models.Amigos> _amigos = new List<Models.Amigos>();

        public AmigosInFile()
        {
            LerArquivo();
        }

        private void LerArquivo()
        {
            using (var file = File.Open("ArquivoComAmigos.json", FileMode.OpenOrCreate, FileAccess.Read))
            {
                using (var stream = new StreamReader(file))
                {
                    var json = stream.ReadToEnd();

                    this._amigos = JsonConvert.DeserializeObject<List<Amigos>>(json);

                    stream.Close();
                }
            }
            if (this._amigos == null)
            {
                this._amigos = new List<Amigos>();
            }
        }

        public void EscreverArquivo()
        {
            if (this._amigos == null)
            {
                return;
            }

            using (var file = File.Open("ArquivoComAmigos.json", FileMode.OpenOrCreate, FileAccess.Write))
            {
                using (var stream = new StreamWriter(file))
                {
                    var json = JsonConvert.SerializeObject(this._amigos);

                    stream.WriteLine(json);

                    stream.Close();
                }
            }
            if (this._amigos == null)
            {
                this._amigos = new List<Amigos>();
            }
        }

        public List<Amigos> MostrarAmigos()
        {
            return _amigos;
        }

        public void Excluir(string userName)
        {
            var amigos = _amigos.Find(x => x.Nome == userName);
            _amigos.Remove(amigos);
        }

        public List<Amigos> ProcurarAmigo(string userName)
        {
            return _amigos.Where(x => x.Nome == userName).ToList();
        }


        public void Dispose()
        {
            throw new NotImplementedException();
        }

        public void CadastrarAmigo(Amigos obj)
        {
            _amigos.Add(obj);
        }

        public void ExcluirAmigo(string Nome)
        {
            throw new NotImplementedException();
        }

        public void AtualizarAmigo(Amigos conta)
        {
            throw new NotImplementedException();
        }
        public void ExibirAniversario()
        {
            List<String> addpessoas = new List<String>();
            foreach (var x in _amigos)
            {
                if (x.Aniversario.ToString("dd-MM") == DateTime.Now.ToString("dd-MM"))
                {
                    addpessoas.Add(x.Nome);
                }
            }
            foreach (var y in addpessoas)
            {
                Console.WriteLine($"Hoje é aniversário de: {y}");
            }
        }
    }
}
