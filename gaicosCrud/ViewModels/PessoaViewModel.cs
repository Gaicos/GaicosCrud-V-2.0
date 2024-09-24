using gaicosCrud.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace gaicosCrud.ViewModels
{
    public class PessoaViewModel
    {
        public string Nome { get; set; }
        public DateTime DataNascimento { get; set; }
        public string Sexo { get; set; }
        public string EstadoCivil { get; set; }
        public string CPF { get; set; }
        public string CEP { get; set; }
        public string Endereco { get; set; }
        public string Numero { get; set; }
        public string Complemento { get; set; }
        public string Cidade { get; set; }
        public string UF { get; set; }
        public string Bairro { get; set; }

        public void Validar()
        {
            if (string.IsNullOrWhiteSpace(Nome))
                throw new ApplicationException("O campo Nome é obrigatorio.");
            
            if (Nome.Length > 200)
                throw new ApplicationException("Até 200 caracteres.");

            if (DataNascimento == null)
                throw new ApplicationException("Campo obrigatorio.");

            if (DataNascimento > DateTime.Now.Date)
                throw new ApplicationException(string.Format("O Campo não pode ser respondido com 'Hoje'. (0:dd/mm/yyyy", DateTime.Now.Date));

            DateTime DataMinima = new DateTime(1900, 1, 1);

            if (DataNascimento < DataMinima)
                throw new ApplicationException(string.Format("O campo Nao pode" + "ser menor que (0:dd/mm/yyyy", new DateTime(1900, 1, 1)));

            if (string.IsNullOrWhiteSpace(Sexo))
                throw new ApplicationException("O campo Nome é obrigatorio.");

            if (Sexo.Length < 1)
                throw new ApplicationException("Invalido.");

            if (string.IsNullOrWhiteSpace(EstadoCivil))
                throw new ApplicationException("O campo Nome é obrigatorio.");

            if (EstadoCivil.Length > 20)
                throw new ApplicationException("Exedido Limite de Caracteres.");

            if (string.IsNullOrWhiteSpace(CPF))
                throw new ApplicationException("O campo CPF é obrigatorio.");

            if (CPF.Length != 11)
                throw new ApplicationException("Deve Conter 11 Caracteres");

            //nao ta funcionando 
            //if (!ValidarCPF(CPF)) 
                //throw new ApplicationException("CPF INVALIDO!");

            using (Conexao db = new Conexao())
            {
                if (db.Pessoa.Any(c => c.CPF == CPF))
                    throw new ApplicationException("CPF já cadastrado!");
            }

            if (string.IsNullOrWhiteSpace(CEP))
                throw new ApplicationException("O campo Nome é obrigatorio.");

            if (CEP.Length != 8)
                throw new ApplicationException("Deve conter 8 Caracteres.");

            if (string.IsNullOrWhiteSpace(Endereco))
                throw new ApplicationException("O campo Endereco é obrigatorio.");

            if (Endereco.Length > 100)
                throw new ApplicationException("Limite de 100 caracteres.");

            if (string.IsNullOrWhiteSpace(Numero))
                throw new ApplicationException("O campo Nome é obrigatorio.");

            if (Numero.Length > 10)
                throw new ApplicationException("Limite de 100 caracteres.");

            if (!string.IsNullOrWhiteSpace(Complemento))
            {
                if (Complemento.Length > 30)
                    throw new ApplicationException("Limite de 30 caracteres.");
            }

            if (string.IsNullOrWhiteSpace(Bairro))
                throw new ApplicationException("O campo Nome é obrigatorio.");

            if (Bairro.Length > 50)
                throw new ApplicationException("Limite de 50 caracteres.");

            if (string.IsNullOrWhiteSpace(Cidade))
                throw new ApplicationException("O campo Nome é obrigatorio.");

            if (Cidade.Length > 50)
                throw new ApplicationException("Limite de 50 caracteres.");

            if (string.IsNullOrWhiteSpace(UF))
                throw new ApplicationException("O campo Nome é obrigatorio.");

            if (UF.Length > 50)
                throw new ApplicationException("Limite de 50 caracteres.");














        }

        // Função que valida CPF
        /*
        Func<string, bool> ValidarCPF = cpf =>
        {
            int[] multiplicador1 = new int[9] { 10, 9, 8, 7, 6, 5, 4, 3, 2 };
            int[] multiplicador2 = new int[10] { 11, 10, 9, 8, 7, 6, 5, 4, 3, 2 };

            cpf = cpf.Trim().Replace(".", "").Replace("-", "");
            if (cpf.Length != 11)
                return false;

            for (int j = 0; j < 10; j++)
                if (j.ToString().PadLeft(11, char.Parse(j.ToString())) == cpf)
                    return false;

            string tempCpf = cpf.Substring(0, 9);
            int soma = 0;

            for (int i = 0; i < 9; i++)
                soma += int.Parse(tempCpf[i].ToString()) * multiplicador1[i];

            int resto = soma % 11;
            if (resto < 2)
                resto = 0;
            else
                resto = 11 - resto;

            string digito = resto.ToString();
            tempCpf = tempCpf + digito;
            soma = 0;
            for (int i = 0; i < 10; i++)
                soma += int.Parse(tempCpf[i].ToString()) * multiplicador2[i];

            resto = soma % 11;
            if (resto < 2)
                resto = 0;
            else
                resto = 11 - resto;

            digito = digito + resto.ToString();

            return cpf.EndsWith(digito);
        };
        */



    }



}
