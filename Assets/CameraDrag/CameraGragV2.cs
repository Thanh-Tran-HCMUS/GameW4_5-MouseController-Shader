using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraGragV2 : MonoBehaviour {

   
    public float speed = 2.0f;

    Vector2 click_position = Vector2.zero;
    Vector2 current_position = Vector2.zero;
    Vector2 camera_position = Vector2.zero;
    Vector2 target_position;
    bool flag = false;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		if(Input.GetMouseButtonDown(0))
        {
            click_position = Input.mousePosition;
            camera_position = transform.position;
        }

        if(Input.GetMouseButton(0))
        {
            current_position = Input.mousePosition;
            DragFloat();
            flag = true;
            
        }

        if(flag)
        {
            transform.position = Vector2.Lerp(transform.position, target_position, Time.deltaTime * speed);
            Vector3 temp = transform.position;
            temp.z = -10;
            transform.position = temp;
            if ((transform.position.x == target_position.x) && (transform.position.y == target_position.y))//reached?
            {
                flag = false;// stop moving
            }
        }
	}

    void DragFloat()
    {
        Vector2 direction = Camera.main.ScreenToWorldPoint(current_position) - Camera.main.ScreenToWorldPoint(click_position);
        direction = direction * -1;

        target_position = camera_position + direction;
    }
}
