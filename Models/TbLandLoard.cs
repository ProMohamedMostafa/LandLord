using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

#nullable disable

namespace GenieLandLoardSolution.Models
{
    public partial class TbLandLoard
    {
        //[DatabaseGenerated(DatabaseGeneratedOption.None)]
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public string Name { get; set; }
        public string Domain { get; set; }
        public string ConnectionString { get; set; }
    }
}
