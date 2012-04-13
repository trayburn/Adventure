using System;
using Adventure.Data;

namespace Adventure.Data
{
    public interface IGameObjectQueries
    {
        T Find<T>(IRepository repo, string name)
    where T : GameObject;
        GameObject Find(IRepository repo, string name);
        T FindNearPlayer<T>(IRepository repo, Player player, string name)
    where T : GameObject;
        GameObject FindNearPlayer(IRepository repo, Player player, string name);
        GameObject FindInLocation(IRepository repo, GameObject location, string name);
        Player GetPlayer(IRepository repo);
        Room GetMapRoom(IRepository repo);
    }
}
