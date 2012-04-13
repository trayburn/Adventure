using System;

namespace Adventure.Data
{
    public class Exit : GameObject
    {
        public virtual Room Destination { get; set; }
    }
}
