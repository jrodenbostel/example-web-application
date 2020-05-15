using System;
using System.ComponentModel.DataAnnotations;

namespace ExampleWebApplication.Models
{
    public class TestModel
    {
        public int Id { get; set; }

        [Required]
        public string Description { get; set; }
        
    }
}