using UnityEngine;

public sealed class BuiletFactory:IBuiletFactory
    {
    private readonly BuiletData _builetyData;
   
      public BuiletFactory(BuiletData builetyData)
    {
        _builetyData = builetyData;
      
    }

    public GameObject CreateBuilet(Transform position)
    {
        var builetProvider = _builetyData.GetBuilet();
        var a = GameObject.Instantiate(builetProvider);
        a.transform.position = position.position;
       // builetProvider.gameObject.AddComponent<Rigidbody>();
            return a;
    }
}

