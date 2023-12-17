using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TheTwilightOrder.Shared.Models.Game
{
    public class Card
    {
        public Card(int id, string name, string description, int points)
        {
            Id = id;
            Name = name;
            Description = description;
            Points = points;
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public int Points { get; set; }
    }
}
