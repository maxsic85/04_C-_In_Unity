using Labirint.Core;
using Labirint.View;
using UnityEngine;

namespace Labirint.Bullet
{
    public class BuiletProvider : MonoBehaviour, IBuilet
    {
        void OnTriggerEnter(Collider other)
        {
            if (other.gameObject.GetComponent<Collider>() != null && !other.gameObject.GetComponent<PlayerProvider>())
            {
                if (other.gameObject.GetComponent<EnemyProvider>())
                {
                    if (other is Imoveble imoveble)
                        imoveble.RemoveUnit(imoveble);
                    Destroy(other.gameObject);
                }
            }
        }

    }
}