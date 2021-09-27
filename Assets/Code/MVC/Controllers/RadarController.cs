using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RadarController : IExecute
{
    public RadarData _data;
    public static List<RadarObject> RadObjects = new List<RadarObject>();
    Transform _player;
    public RadarController(RadarData data, Transform player)
    {
        _data = data;
        this._player = player;
    }
    public static void RegisterRadarObject(GameObject o, Image i)
    {
        Image image = UnityEngine.Object.Instantiate(i);
        RadObjects.Add(new RadarObject { Owner = o, Icon = image });
    }
    public static void RemoveRadarObject(GameObject o)
    {
        List<RadarObject> newList = new List<RadarObject>();
        foreach (RadarObject t in RadObjects)
        {
            if (t.Owner == o)
            {
                UnityEngine.Object.Destroy(t.Icon);
                continue;
            }
            newList.Add(t);
        }
        RadObjects.RemoveRange(0, RadObjects.Count);
        RadObjects.AddRange(newList);
    }
    private void DrawRadarDots() // Синхронизирует значки на миникарте с реальными объектами
    {
        foreach (RadarObject radObject in RadObjects)
        {
            Vector3 radarPos = (radObject.Owner.transform.position -
                                _player.position);
            float distToObject = Vector3.Distance(_player.position,
                                     radObject.Owner.transform.position) * _data._mapScale;
            float deltay = Mathf.Atan2(radarPos.x, radarPos.z) * Mathf.Rad2Deg -
                           180 - _player.eulerAngles.y;
            radarPos.x = distToObject * Mathf.Cos(deltay * Mathf.Deg2Rad) * -1;
            radarPos.z = distToObject * Mathf.Sin(deltay * Mathf.Deg2Rad);
            radObject.Icon.transform.SetParent(_data.Radar.transform);
            radObject.Icon.transform.position = new Vector3(radarPos.x,
                                                    radarPos.z, 0) + _data.Radar.transform.position;
        }
    }
    public void Execute(float deltaTime)
    {
        DrawRadarDots();
    }
}

