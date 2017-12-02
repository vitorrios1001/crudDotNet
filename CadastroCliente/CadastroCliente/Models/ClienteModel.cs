using System.ComponentModel.DataAnnotations;

namespace CadastroCliente.Models
{
    public class ClienteModel
    {
        [Key]
        public int ID { get; set; }
        
        [StringLength(40)]
        public string Nome { get; set; }
        
        [StringLength(10)]
        public string CEP { get; set; }
        
        [StringLength(40)]
        public string Endereco { get; set; }
        
        [StringLength(30)]
        public string Bairro { get; set; }
        
        [StringLength(40)]
        public string Cidade { get; set; }
        
        [StringLength(2)]
        public string Uf { get; set; }
        
        public bool Status { get; set; }
        

    }
}