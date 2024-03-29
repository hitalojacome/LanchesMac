﻿using System.ComponentModel.DataAnnotations;

namespace LanchesMac.ViewModels;
public class LoginViewModel
{
    [Required(ErrorMessage = "Informe o nome de usuário")]
    [Display(Name = "Usuário")]
    public string UserName { get; set; }

    [Required(ErrorMessage = "Informe a senha de usuário")]
    [DataType(DataType.Password)]
    [Display(Name = "Senha")]
    public string Password { get; set; }

    public string? ReturnUrl { get; set; }
}