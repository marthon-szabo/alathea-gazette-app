using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace AlatheaGazette.Models
{
    public class SessionModel
    {
        [Key]
        public int Id { get; set; }
        public string UserSessionId { get; set; }
        public int UserId { get; set; }
        public UserModel User { get; set; }
    }
}
