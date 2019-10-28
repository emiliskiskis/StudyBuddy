using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudyBuddy.Models
{
    public class ChatHistory
    {
        public DateTime SentAt { get; set; }
        public string Text { get; set; }
        public User User { get; set; }
    }
}
