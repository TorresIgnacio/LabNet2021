using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace TP8_MVC.Models
{
    public class CustomerView
    {
        [Required]
        [StringLength(5)]
        public string ID { get; set; }
        [StringLength(30,ErrorMessage = "El campo Nombre debe ser una cadena con una longitud máxima de 30.")]
        public string contactName { get; set; }
        [Required(ErrorMessage = "El campo Compañía es obligatorio.")]
        [StringLength(40, ErrorMessage = "El campo Compañía debe ser una cadena con una longitud máxima de 40.")]
        public string companyName { get; set; }

    }
}