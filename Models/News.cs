using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace tclk.Models
    {
        public class News
        {
            public int Id { get; set; }
            [Column(TypeName = "varchar(100)")]
            [Comment("Заголовок новости")]
            public string Title { get; set; }
            public DateTime CreatedDate { get; set; }
            [MinLength(5)]
            [MaxLength(1024)]
            public string Text { get; set; }

            public List<TypesNews> TypeNews { get; set; }
        }

        public class TypesNews
        {
            public int TypeId { get; set; }
            [Column(TypeName = "varchar(50)")]
            public string Type { get; set; }

            public int Id { get; set; }
            public News News { get; set; }
        }
    }
