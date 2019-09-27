using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;


//Criação da Classe com GET e SET referente aos Estabelecimentos
namespace CrudSistemaFitcard.Models
{
    public class Estabelecimentos
    {
        public string cnpj
        {
            get;
            set;
        }

        public int id_categoria
        {
            get;
            set;
        }

        public string razao_social
        {
            get;
            set;
        }

        public string nome_fantasia
        {
            get;
            set;
        }

        public string categoria
        {
            get;
            set;
        }

        public string email
        {
            get;
            set;
        }

        public string endereco
        {
            get;
            set;
        }

        public string cidade
        {
            get;
            set;
        }
        
        public string estado
        {
            get;
            set;
        }

        public string telefone
        {
            get;
            set;
        }
        
        public string data_cadastro
        {
            get;
            set;
        }

        public string status
        {
            get;
            set;
        }

        public string agencia
        {
            get;
            set;
        }

        public string conta
        {
            get;
            set;
        }
    }
}