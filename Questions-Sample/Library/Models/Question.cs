using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;
using System.Web.Mvc;

namespace YC.Models
{
    public class Question
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public long Id { get; set; }
        public int Seq { get; set; }
        public string Text { get; set; }
        public string Answer { get; set; }
        public ICollection<QuestionOption> Options { get; set; }
        public QuestionType QuestionType { get; set; }
        [HiddenInput]
        public long QuestionTypeId { get; set; }
    }
}
