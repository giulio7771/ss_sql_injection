﻿namespace projeto_mvc.Models
{
    public class UsuarioViewModel: Entity
    {
        public UsuarioViewModel()
        {
        }
        public string Nome { get; set; }
        public string Login { get; set; }
        public string Senha { get; set; }
    }
}
