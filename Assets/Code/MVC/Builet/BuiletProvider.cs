using UnityEngine;
namespace MAX.CODE.MVC
{
    public class BuiletProvider : MonoBehaviour, IBuilet
    {
        [SerializeField] private int _damage;

        public int Damage { get => _damage; set => _damage = value; }

        private void OnEnable()
        {
            Destroy(gameObject, 3f);
        }


        void OnTriggerEnter(Collider other)
        {
           
            if (other.gameObject.GetComponent<Collider>() != null && !other.gameObject.GetComponent<Player>())
            {
               
                if (other.gameObject.GetComponent<EnemyProvider>())
                {
                    (int Hp, int Stamina) dm = other.gameObject.GetComponent<EnemyProvider>().GetDamage(Damage);

                    if (dm.Hp <= 0)
                    {
                        Destroy(other.gameObject);
                    }
                  
                }

            }
           
        }

    }

}