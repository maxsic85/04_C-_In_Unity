using System.Collections;

namespace Max.Generetion
{

    public static class ShuffleArray
    {
        public static T[] ShuffleArr<T>(T[] array, int seed)
        {
            System.Random prng = new System.Random(seed);
            for (int i = 0; i < array.Length; i++)
            {
                int _rndIndex = prng.Next(i,array.Length);
                T _tempItem = array[_rndIndex];
                array[_rndIndex] = array[i];
                array[i] = _tempItem;
            }

            return array;
        }
    }
}