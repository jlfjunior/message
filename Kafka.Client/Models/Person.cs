using System;
using System.Text.Json;

namespace Kafka.Client.Models
{
    public class Person
    {
        public Person()
        {

            Id = new Random().Next(1, int.MaxValue);
            CreatedAt = DateTime.Now;
        }

        public int Id { get; set; }
        public DateTime CreatedAt { get; set; }

        public override string ToString() => JsonSerializer.Serialize(this);
    }
}
