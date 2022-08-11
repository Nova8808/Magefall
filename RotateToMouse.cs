using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateToMouse : MonoBehaviour
{

    public Camera main_camera;
    public static Ray rayMouse;
    private Vector3 direction;
    private Quaternion rotation;
    public float maximumLength;
    //public Ray rayPoint;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
   
        var mousePos = Input.mousePosition;
        rayMouse = main_camera.ScreenPointToRay(mousePos);
        rotation = Quaternion.LookRotation(rayMouse.direction);
        this.transform.rotation = Quaternion.Lerp(this.transform.rotation, rotation, 1);

        //if (Physics.Raycast(rayMouse.origin, rayMouse.direction, out hit, maximumLength))
        //{
        //   // RotateToMouseDirection(gameObject, hit.point);
        //}
        //else
        //{
        //    var pos = rayMouse.GetPoint(maximumLength);
        //    RotateToMouseDirection(gameObject, hit.point);
        //}
    }

    void RotateToMouseDirection(GameObject obj, Vector3 destination)
    {
        direction = destination - obj.transform.position;
        rotation = Quaternion.LookRotation(rayMouse.direction);
        obj.transform.rotation = Quaternion.Lerp(obj.transform.rotation, rotation, 1);
    }

    public Quaternion GetRotation()
    {
        return rotation;
    }
}
