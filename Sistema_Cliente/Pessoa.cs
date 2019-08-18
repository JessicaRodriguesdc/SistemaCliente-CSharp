using System;
using System.Collections.Generic;
using System.Collections;
using System.Text;

namespace Sistema_Cliente
{
    public class Pessoa
    {
        public string nome { get; set; }
        public ArrayList DadosPessoas { get; set; }

        public Pessoa()
        {
            DadosPessoas = new ArrayList();
        }
    }
}
