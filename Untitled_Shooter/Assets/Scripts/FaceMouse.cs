using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FaceMouse : MonoBehaviour
{
    void Update()
    {
        // Getting the point in the screen where the mouse is located
        Vector3 mousePos = Input.mousePosition - Camera.main.WorldToScreenPoint(transform.position);

        // Getting the angle between the x axis and the mouse position
        float angle = Mathf.Atan2(mousePos.y, mousePos.x) * Mathf.Rad2Deg;

        // Getting the x axis and actually rotating the object
        Vector3 xAxis = Vector3.forward;
        transform.rotation = Quaternion.AngleAxis(angle, xAxis);

        if (PauseMenu.GameIsPaused)
        {
            //Get this script to be disabled while GameIsPaused = true
        }
    }
}
