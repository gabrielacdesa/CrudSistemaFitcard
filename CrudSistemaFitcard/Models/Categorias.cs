using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

//Criação da Classe com GET e SET referente as Categorias
namespace CrudSistemaFitcard.Models
{
    public class Categorias
    {
        public string id_categoria
        {
            get;
            set;
        }

        public string nome
        {
            get;
            set;
        }
    }
}