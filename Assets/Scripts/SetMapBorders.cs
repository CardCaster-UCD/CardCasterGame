using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using SuperTiled2Unity;

namespace CameraControl
{
    public class SetMapBorders : MonoBehaviour
    {

        Dictionary<string, Direction> directionMap = new Dictionary<string, Direction>()
        {
            { "top", Direction.Top },
            { "bottom", Direction.Bottom },
            { "left", Direction.Left },
            { "right", Direction.Right }
        };

        // Start is called before the first frame update
        void Start()
        {
            foreach (var child in GetComponentsInChildren<Transform>())
            {
                var tiledProperties = child.GetComponent<SuperCustomProperties>().m_Properties;
                foreach (var property in tiledProperties)
                {
                    if ("position" == property.m_Name)
                    {
                        var direction = directionMap[property.m_Value];
                        child.gameObject.AddComponent<RoomCameraBorder>().direction = direction;
                        child.GetComponent<EdgeCollider2D>().isTrigger = true;
                    }

                }
            }
        }

    }
}