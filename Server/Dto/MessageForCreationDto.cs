using System;
using Microsoft.AspNetCore.Http;

namespace DatingApp.Dto
{
    public class MessageForCreationDto
    {
        public int SenderId { get; set; }
        public int RecipientId { get; set; }
        public DateTime MessageSent { get; set; }
        public string Content { get; set; }

        public MessageForCreationDto()
        {
            MessageSent = DateTime.Now;
        }
    }
}