using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace EFCoreDemo.Data
{
    public class tempUser
    {
        [Key]
        public int userid { get; set; }

        public string username { get; set; }
    }
}
