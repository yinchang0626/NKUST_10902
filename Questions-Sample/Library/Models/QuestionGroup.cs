using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace YC.Models
{
    public class QuestionGroup
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public long Id { get; set; }
        [DisplayName("題組")]
        public string Name { get; set; }
        public ICollection<QuestionType> QuestionTypes { get; set; }

    }
}
