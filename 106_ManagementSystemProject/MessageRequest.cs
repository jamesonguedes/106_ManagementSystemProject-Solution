using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _106_ManagementSystemProject
{
    internal class MessageRequest
    {
        public int MessageId { get; set; }
        public int Id { get; set; }
        public string Name { get; set; }
        public string MessageType { get; set; }
        public string Subject { get; set; }
        public string Description { get; set; }
    }
}
