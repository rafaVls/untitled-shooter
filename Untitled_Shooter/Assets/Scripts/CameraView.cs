using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraView : MonoBehaviour
{
    public GameObject followThis;

    void LateUpdate()
    {
        transform.position = followThis.transform.position + new Vector3(0, 0, -10);    
    }
}