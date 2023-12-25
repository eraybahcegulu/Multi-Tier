﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace ENTITIES.Models
{
    public class Category : BaseEntity
    {
        [JsonPropertyName("categoryId")]
        public string CategoryName { get; set; }
        public string Description { get; set; }

        [JsonIgnore]
        public virtual ICollection<Product> Products { get; set; }

    }
}