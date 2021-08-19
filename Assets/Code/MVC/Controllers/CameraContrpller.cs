using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraContrpller : IExecute
{

    private const float smooth = 5.0f;
    [SerializeField]
    private  Vector3 offset = new Vector3(0, 2, -0);
    private Transform _player;
    private Transform _camera;
    private const float V = 6f;
    private Vector3 _mov;
    // Start is called before the first frame update
    public CameraContrpller(Transform player, Transform camera)
    {
        _player = player;
        _camera = camera;
        _mov = new Vector3();
    }

    // Update is called once per frame
    void MoveToPlayer()
    {
        //  Debug.Log(Vector3.Distance(transform.position, _player.transform.position));

        if (Vector3.Distance(_camera.transform.position, _player.transform.position) > V)
        {
            _mov.x = _player.transform.position.x + offset.x;
            _mov.y = _camera.transform.position.y;
            _mov.z = _player.transform.position.z + offset.z;
            _camera.transform.position = Vector3.Lerp(_camera.transform.position, _mov, Time.deltaTime * smooth);
        }
    }
    public void Execute(float deltaTime)
    {
        MoveToPlayer();
    }
}
