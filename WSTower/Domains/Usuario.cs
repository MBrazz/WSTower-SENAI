using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace WSTower.Domains
{
    public partial class Usuario
    {
        public int Id { get; set; }

        // Define que a propriedade é obrigatória
        [Required(ErrorMessage = "O nome do usuário é obrigatório!")]
        [StringLength(50, MinimumLength = 3, ErrorMessage = "O nome deve ter no mínimo 3 caracteres.")]
        public string Nome { get; set; }

        // Define que a propriedade é obrigatória
        [Required(ErrorMessage = "O e-mail do usuário é obrigatório!")]
        // Define o tipo do dado
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }

        // Define que a propriedade é obrigatória
        [Required(ErrorMessage = "O apelido do usuário é obrigatório!")]
        // Define o tipo do dado
        [DataType(DataType.Text)]
        [StringLength(50, MinimumLength = 3, ErrorMessage = "O Apelido deve ter no mínimo 3 caracteres.")]
        public string Apelido { get; set; }

        public byte[] Foto { get; set; }

        // Define que a propriedade é obrigatória
        [Required(ErrorMessage = "Informe a senha do usuário!")]
        // Define que o tipo de dado
        [DataType(DataType.Password)]
        [StringLength(50, MinimumLength = 3, ErrorMessage = "A senha deve ter no mínimo 3 caracteres.")]
        public string Senha { get; set; }
    }
}
