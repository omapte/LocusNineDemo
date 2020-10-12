using System;

namespace lNineApi.Models
{
    public class NineUser
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string Role { get; set; }
        public string Status { get; set; }
        public string ContactNumber { get; set; }
        public bool isDeleted { get; set; }
    }
}