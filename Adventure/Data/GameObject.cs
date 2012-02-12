using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Adventure.Data
{
    public class GameObject
    {
        public GameObject()
        {
            Inventory = new List<GameObject>();
            Aliases = new List<Tag>();
            Statuses = new List<Tag>();
        }

        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public virtual List<GameObject> Inventory { get; set; }
        public virtual GameObject Location { get; set; }
        public virtual List<Tag> Aliases { get; set; }
        public virtual List<Tag> Statuses { get; set; }
    }
}