using System;
using Adventure.Data;

namespace Adventure.Data
{
    public interface IGameObjectQueries
    {
        GameObject FindNearPlayer(IRepository repo, Player player, string name);
        GameObject FindInLocation(IRepository repo, GameObject location, string name);
        Player GetPlayer(IRepository repo);
        Room GetMapRoom(IRepository repo);
    }
}
