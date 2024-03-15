using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CursorRotate : MonoBehaviour
{
    public Camera cam; // Oyun kamerası referansı

    void Update()
    {
        // Mouse tıklandığında
        if (Input.GetMouseButtonDown(0))
        {
            Ray ray = cam.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;

            if (Physics.Raycast(ray, out hit))
            {
                // Tıklanan yere bakacak şekilde karakteri döndür
                Vector3 targetPosition = new Vector3(hit.point.x, transform.position.y, hit.point.z);
                transform.LookAt(targetPosition);
            }
        }
    }
}