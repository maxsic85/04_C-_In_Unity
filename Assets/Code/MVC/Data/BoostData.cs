namespace Labirint.Data
{

    public enum BoostType
    {
        GOOD = 0,
        BAD = 1
    }

    public class BoostData
    {
        public string _path { get; private set; } = "Prefabs/Meta/Boost";
        public int _value { get; private set; } = 1;
        public BoostType _type { get; private set; } = BoostType.GOOD;

        public BoostData()
        {

        }
    }
}
