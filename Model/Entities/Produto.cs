using Api.Core.Dto.Enums;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using WebApi.Model.Entities;

namespace WebApi.Model
{
    public class Produto: Entity
    {
       
        public Guid DepartamentoId { get; set; }

        [ForeignKey("DepartamentoId")]

        [Required(ErrorMessage = "O departamento do produto obrigatóro")]
        public Departamento Departamento { get; set; }


        [MinLength(1, ErrorMessage = "O código do produto deve conter no minimo 1 caracter")]
        [MaxLength(15, ErrorMessage = "O código do produto deve conter no minimo 15 caracter")]
        [Required(ErrorMessage = "O código do produto obrigatóro")]
        public string Codigo { get; set; }


        [MinLength(1,ErrorMessage ="A descrição do produto deve conter no minimo 1 caracter")]
        [MaxLength(250, ErrorMessage = "A descrição do produto deve conter no minimo 250 caracter")]
        [Required(ErrorMessage ="A descrição do produto obrigatóro")]
        public string Descricao { get; set; }

        [Required(ErrorMessage = "O preço do produto obrigatóro")]
        [Range(0,9999999999999.99999)]
        public decimal Preco { get; set; }

        public ProdutoStatus Status { get; set; }


    }
}
