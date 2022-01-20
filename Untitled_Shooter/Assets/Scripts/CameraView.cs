using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraView : MonoBehaviour
{
    public GameObject followThis;
    Vector3 distanceFromPlayer = new Vector3(0, 0, -10);

    void LateUpdate()
    {
        transform.position = followThis.transform.position + distanceFromPlayer;    
    }
}
