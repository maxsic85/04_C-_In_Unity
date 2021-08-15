using System;
using UnityEngine;
using Random = UnityEngine.Random;
namespace Max.Meta
{
    public enum BoostType
    {
        ADDSPEED = 1,
        ADDHEALTH = 2
    }

    public class Boost : MonoBehaviour, IDropBoost
    {

        BoostType _boost = new BoostType();

        event Action IBoost.Boost
        {
            add
            {
                throw new NotImplementedException();
            }

            remove
            {
                throw new NotImplementedException();
            }
        }

        public void Dispose()
        {
            throw new NotImplementedException();
        }

        public void GeneretionBoost()
        {
            throw new NotImplementedException();
        }

        public void UseBonus()
        {
            switch (_boost)
            {
                case BoostType.ADDSPEED: Debug.Log("use addspeed");
                    break;
                case BoostType.ADDHEALTH:
                    Debug.Log("use addhealth");
                    break;
                default:
                    break;
            }

        }

        // Start is called before the first frame update
        void Start()
        {

        }

        // Update is called once per frame
        void Update()
        {

        }
    }
}