﻿using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace Labirint.Core
{
    public sealed class RadarController : IExecute
    {
        public RadarData _data;
        public static List<RadarObject> RadObjects = new List<RadarObject>();
        Transform _player;
        public RadarController(RadarData data, Transform player)
        {
            _data = data;
            _player = player;
        }
        public static void RegisterRadarObject(GameObject gameObj, Image RegImage)
        {
            Image image = Object.Instantiate(RegImage);
            RadObjects.Add(new RadarObject { Owner = gameObj, Icon = image });
        }
        public static void RemoveRadarObject(GameObject gameObj)
        {
            List<RadarObject> newList = new List<RadarObject>();
            foreach (RadarObject radar in RadObjects)
            {
                if (radar.Owner == gameObj)
                {
                    Object.Destroy(radar.Icon);
                    continue;
                }
                newList.Add(radar);
            }
            RadObjects.RemoveRange(0, RadObjects.Count);
            RadObjects.AddRange(newList);
        }
        private void DrawRadarDots()
        {
            foreach (RadarObject radObject in RadObjects)
            {
                Vector3 radarPos = radObject.Owner.transform.position -
                                    _player.position;
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
}