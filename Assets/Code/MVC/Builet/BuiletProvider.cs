using System;
using Max.Core;
using UnityEngine;

public class BuiletProvider : MonoBehaviour,IBuilet
{
   


    void Start() 
    {
     
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.GetComponent<Collider>() != null && !other.gameObject.GetComponent<Player>())
        {
            if (other.gameObject.GetComponent<EnemyProvider>())
            {


                // other.GetComponent<CompositeMove>().RemoveUnit(other.GetComponent<Imove>());   
               Destroy(other.gameObject);
               // other.gameObject.SetActive(false);
            }
        }
    }

}

