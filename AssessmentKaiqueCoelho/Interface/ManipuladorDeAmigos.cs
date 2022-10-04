using AssessmentKaiqueCoelho.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AssessmentKaiqueCoelho.Interface
{
    internal interface ManipuladorDeAmigos : IDisposable
    {
        void CadastrarAmigo(Models.Amigos obj);
        void ExcluirAmigo(string Nome);
        List<Models.Amigos> ProcurarAmigo(string Nome);
        void AtualizarAmigo(Models.Amigos conta);
        List<Amigos> MostrarAmigos();
        void ExibirAniversario();
    }
}
