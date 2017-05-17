﻿using System.ComponentModel.DataAnnotations;

namespace WebApp.Models
{
    class Standard
    {
        public int Standard_ID { get; set; }
        public string StandardName { get; set; }
        public string Description { get; set; }

        [Timestamp]
        public byte[] RowVersion { get; set; }

    }
}
