 using UnityEngine;
 using System.Collections;
 
 public class Box : MonoBehaviour 
 {
     public string label = "Это ящик, интересно, что он здесь делает";
     Ray ray;
     RaycastHit hit;
     bool showLabel = false;
     
     void Update()
     {
         ray = Camera.main.ScreenPointToRay(Input.mousePosition);
         if(Physics.Raycast(ray, out hit, Mathf.Infinity) && Input.GetMouseButtonDown(0))
         {
             if(hit.GetComponent<Collider>() == this.GetComponent<Collider>())
             {
                 showLabel = true;    
             }
             else
                 showLabel = false;
         }
     }
     
     void OnGUI()
     {
         if(showLabel)
             GUI.Label(new Rect(0, 0, Screen.width, 256), label);
     }
 }