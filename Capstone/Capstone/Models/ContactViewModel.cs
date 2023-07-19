﻿using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;

public class Contact
{
    [Required]
    public int Id { get; set; }

    [Required]
    public string Name { get; set; }

    [Required]
    [EmailAddress]
    public string Email { get; set; }

    [Required]
    public string Message { get; set; }
}

