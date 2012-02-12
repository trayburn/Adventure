using System;
using System.Linq;
using Adventure.Data;

namespace Adventure.Data
{
    public class GameObjectQueries : IGameObjectQueries
    {
        public Player GetPlayer(IRepository repo)
        {
            var player = repo.AsQueryable<GameObject>().OfType<Player>().FirstOrDefault();
            if (player == null)
            {
                player = new Player();
                player.Name = "Player";
                player.Location = GetMapRoom(repo);
                player.Aliases.Add(new Tag { Value = "Me" });
                player.Aliases.Add(new Tag { Value = "Myself" });
                repo.Add<GameObject>(player);
                repo.UnitOfWork.SaveChanges();
            }
            return player;
        }

        public Room GetMapRoom(IRepository repo)
        {
            var room = repo.AsQueryable<GameObject>().OfType<Room>().FirstOrDefault();
            if (room == null)
            {
                room = new Room();
                room.Name = "The Map Room";
                repo.Add<GameObject>(room);
                repo.UnitOfWork.SaveChanges();
            }
            return room;
        }

        public GameObject Find(IRepository repo, string name)
        {
            return repo.AsQueryable<GameObject>().FirstOrDefault(m => m.Name == name);
        }

        public GameObject FindInLocation(IRepository repo, GameObject location, string name)
        {
            return repo.AsQueryable<GameObject>().FirstOrDefault(m => (m.Name == name || m.Aliases.Any(r => r.Value == name)) && m.Location.Id == location.Id);
        }

        public GameObject FindNearPlayer(IRepository repo, Player player, string name)
        {
            return repo.AsQueryable<GameObject>().FirstOrDefault(m => (m.Name == name || m.Aliases.Any(r => r.Value == name)) && (m.Location.Id == player.Id || m.Location.Id == player.Location.Id));
        }
    }
}
