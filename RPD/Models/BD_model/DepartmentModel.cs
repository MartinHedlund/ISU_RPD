using Microsoft.EntityFrameworkCore;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace RPD.Models.BD_model
{
    [Table("Department", Schema = "dbo")]
    
    public class DepartmentModel
    {
        [Key]
        public int IdDepartment { get; set; }
        public string? NDepartment { get; set; }
        public string? DepartmentSokr { get; set; }
        public byte IdDepartmentType { get; set; }
    }
}
