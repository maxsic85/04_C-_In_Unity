using UnityEngine;
namespace Labirint.Generation
{
    public interface IMapGeneretion
    {
        public void GeneretMap();
        public Transform GetRandomOpenTile();
    }
}