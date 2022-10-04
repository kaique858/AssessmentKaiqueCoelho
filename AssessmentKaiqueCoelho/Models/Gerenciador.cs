using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AssessmentKaiqueCoelho.Models
{
    internal class Gerenciador
    {
        List<Amigos> _amigos = new List<Amigos>();
        public List<Amigos> MostrarAmigos()
        {
            return _amigos;
        }
        public void CadastrarAmigo(Amigos amigos)
        {
            _amigos.Add(amigos);
        }
        public void Excluir(string userName)
        {
            var amigos = _amigos.Find(x => x.Nome == userName);
            _amigos.Remove(amigos);
        }
        public List<Amigos> ProcurarAmigo(string username)
        {
            return _amigos.Where(x => x.Nome == username).ToList();
        }

    }
}
