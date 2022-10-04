using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AssessmentKaiqueCoelho.Models
{
    internal class Amigos
    {
        

        public string Nome { get; set; }
        public string SobreNome { get; set; }
        public DateTime Aniversario { get; set; }


        public void Mostrar()
        {
            DateTime DataAniversario = new DateTime(DateTime.Now.Year + 1, Aniversario.Month, Aniversario.Day);
            var dias = (int)DataAniversario.Subtract(DateTime.Today).TotalDays;
            if (dias > 365) { dias = dias - 365; }

            if (dias == 365)
            {
                Console.WriteLine("Hoje e seu aniversario! Meus Parabens!!!");
                Console.WriteLine($"Nome: {Nome} | {SobreNome} | Data de aniversario é:{Aniversario}\nFalta {dias} Para seu proximo Aniversario\n");

            }
            else
            {
                Console.WriteLine($"Nome: {Nome} | {SobreNome} | Data de aniversario é:{Aniversario}\nFalta {dias} Para seu proximo Aniversario\n");
            }
        }





    }
}
