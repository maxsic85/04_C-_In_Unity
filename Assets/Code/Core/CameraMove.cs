using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Max.Core
{
    public class CameraMove : MonoBehaviour
    {
        public float smooth = 5.0f;
        public Vector3 offset = new Vector3(0, 2, -5);
        private GameObject _player;
      [SerializeField]  private float V = 6f;
        Vector3 _mov;
        // Start is called before the first frame update
        void Start()
        {
            _player = FindObjectOfType<Player>().gameObject;
            _mov = new Vector3();
        }

        // Update is called once per frame
        void LateUpdate()
        {
            Debug.Log(Vector3.Distance(transform.position, _player.transform.position));
          
            if (Vector3.Distance(transform.position, _player.transform.position) > V)
            {
                _mov.x = _player.transform.position.x + offset.x;
                _mov.y = transform.position.y;
                _mov.z = _player.transform.position.z + offset.z;
                transform.position = Vector3.Lerp(transform.position, _mov, Time.deltaTime * smooth);
            }
        }
    }
}