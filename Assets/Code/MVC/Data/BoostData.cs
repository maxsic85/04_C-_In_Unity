namespace MAX.CODE.MVC
{

    public class BoostData
    {

        public string _path { get; private set; } = "Prefabs/Meta/Boost";
        public int _value { get; private set; } = 1;
        public BoostType _type { get; private set; } = BoostType.GOOD;

        public BoostData()
        {

        }
        public BoostData(string path, int value, BoostType type)
        {
            _path = path;
            _value = value;
            _type = type;
        }

    }
}
