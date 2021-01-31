using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow2 : MonoBehaviour
{
    GameObject player;
    public Transform target;

    public float smoothSpeed = 0.125f;

    void LateUpdate()
    {
       /* gameObject.transform.position = Vector3(player.transform.position.x,
                              this.transform.position.y,
                             player.transform.position.z);*/
    }
}
