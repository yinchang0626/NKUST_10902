using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace YC.Models
{
    public class QuestionType
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public long Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public QuestionGroup Group { get; set; }
        public long GroupId { get; set; }


    }
}
