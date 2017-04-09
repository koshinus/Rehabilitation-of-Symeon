using UnityEngine;
using System.Collections;

public class MouseController : MonoBehaviour
{
    public Camera main_camera;
    void OnGUI()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Ray ray = main_camera.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;

            if (Physics.Raycast(ray, out hit, 100))
            {
                string ObjectName = hit.collider.name;
                Destroy(GameObject.Find(ObjectName));
            }
        }
    }
}