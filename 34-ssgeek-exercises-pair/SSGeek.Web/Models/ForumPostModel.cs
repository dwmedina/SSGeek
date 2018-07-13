using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace SSGeek.Web.Models
{
    public class ForumPostModel
    {   
       [Required(ErrorMessage ="Username Required")]
       [StringLength(20,ErrorMessage ="Username Cannot Excede 20 Characters")]
        public string Username { get; set; }

        [Required(ErrorMessage ="Subject Required")]
        [StringLength(20, MinimumLength =2,ErrorMessage ="Subject Must Be Between 2 and 20 Characters")]
        public string Subject { get; set; }

        [Required(ErrorMessage ="Post cannot be blank")]
        public string Message { get; set; }
        public DateTime PostDate { get; set; }
    }
}