using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour {
    Vector2 mouselook;
    Vector2 smoothing;
    public float sensitivity = 5.0f;
    public float smoothingamt = 2.0f;

    GameObject character;

	// Use this for initialization
	void Start () {
        character = this.transform.parent.gameObject;
	}
	
	// Update is called once per frame
	void Update () {

    
            var mousedirection = new Vector2(Input.GetAxisRaw("Mouse X"), Input.GetAxisRaw("Mouse Y"));

            mousedirection = Vector2.Scale(mousedirection, new Vector2(sensitivity * smoothingamt, sensitivity * smoothingamt));
            smoothing.x = (Mathf.Lerp(smoothing.x, mousedirection.x, 1f / smoothingamt));
            smoothing.y = (Mathf.Lerp(smoothing.y, mousedirection.y, 1f / smoothingamt));
            mouselook += smoothing;
            mouselook.y = Mathf.Clamp(mouselook.y, -90f, 90f);

            transform.localRotation = Quaternion.AngleAxis(-mouselook.y, Vector3.right);
            character.transform.localRotation = Quaternion.AngleAxis(mouselook.x, character.transform.up);
        }

}
