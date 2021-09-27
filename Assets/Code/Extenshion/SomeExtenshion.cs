using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class SomeExtenshion : MonoBehaviour
{
    string _testText = "hello world from the Earth ep";
    char _key = 'l';
    int _charCount;

    private void Start()
    {
        _testText.CountBy(_key, out _charCount);
        ($"TestCountBy=  { _charCount}").DebugLog(); ;

        _charCount = _testText.CountByLinq(_key);
        ($"TestCountByLinq=  {_charCount}").DebugLog(); ;


        List<int> _list = new List<int>();
        _charCount.AddTo(_list);
        5.AddTo(_list);
        ($"TestAddTo=  {_list.Count()}").DebugLog();

        int _testRepeat = 5;
        int cnt = _testRepeat.CountByKeyInInt(_list);
        ($"TestCountByKeyInInt=  {cnt}").DebugLog();

        testStruct z = new testStruct(1, "zzzz");
        testStruct y = new testStruct(2, "yyyy");
        testStruct x = new testStruct(1, "zzzz");
        List<testStruct> _listT = new List<testStruct>(5);
        z.AddTo(_listT);
        y.AddTo(_listT);
        x.AddTo(_listT);

        cnt = z.CountByKey(_listT);
        ($"TestCountByKey=  { cnt}").DebugLog();

        int zxc = z.CountByKeyWithLinQ(_listT);
        ($"CountByKeyWithLinQ= {zxc}").DebugLog();

        TestDictionary.test();

    }
    public struct testStruct
    {
        public int a;
        public string b;

        public testStruct(int _a, string _b)
        {
            a = _a;
            b = _b;
        }
    }
}

public static class String
{
    public static int CountBy(this string str, char c, out int counter)
    {
        counter = 0;
        for (int i = 0; i < str.Length; i++)
        {
            counter = (str[i] == c) ? counter += 1 : counter;
        }
        return counter;
    }

    public static int CountByLinq(this string str, char c)
    {
        var netAddrs = from n in str
                       where n == c
                       select str.IndexOf(n);
        return netAddrs.Count();
    }

}

public static class TestListT
{
    public static T AddTo<T>(this T self, ICollection<T> coll)
    {
        coll.Add(self);
        return self;
    }
    public static int CountByKeyInInt(this int self, ICollection<int> coll)
    {
        var i = 0;
        foreach (var item in coll)
        {
            i = (item.Equals(self)) ? i += 1 : i;
        }
        return i;
    }
    public static int CountByKey<T>(this T self, ICollection<T> coll)
    {
        int i = 0;
        foreach (var item in coll)
        {
            i = (item.Equals(self)) ? i += 1 : i;
        }
        return i;
    }

    public static int CountByKeyWithLinQ<T>(this T self, ICollection<T> coll) where T : struct
    {
        int number = (from t in coll where t.Equals(self) select t).Count();
        return number;
    }


}

public static class TestDictionary
{
    public static void test()
    {
        Dictionary<string, int> dict = new Dictionary<string, int>()
            {
                {"four",4 },
                {"two",2 },
                { "one",1 },
                {"three",3 },
            };
        /* FROM TASK
          var d = dict.OrderBy(delegate (KeyValuePair<string, int> pair)
          {
              return pair.Value;
          });
        */
        OrderToLyambda(dict);
        int a = 3.ReturnValByKey(dict);
    }

    private static void OrderToLyambda(Dictionary<string, int> dict)
    {
        var l1 = dict.Where(u => u.Value > 2).ToList();
        foreach (var pair in l1)
        {
            Debug.Log($"{pair.Key} - {pair.Value}");
        }
    }

    public static int ReturnValByKey(this int self, Dictionary<string, int> dict)
    {
        var l1 = dict.Where(u => u.Value > self).ToList();
        var val = 0;
        foreach (var pair in l1)
        {
            val = pair.Value;
        }
        Debug.Log($"ReturnValByKey" + self + "is" + val);
        return val;
    }
}

public static class OtherExtenshions
{
    [ExecuteInEditMode]
    public static void DebugLog(this string self)
    {
        Debug.Log(self);
    }

    public static T GetOrAddComponent<T>(this GameObject child) where T : Component
    {
        T result = child.GetComponent<T>();
        if (result == null)
        {
            result = child.AddComponent<T>();
        }

        return result;
    }
}
