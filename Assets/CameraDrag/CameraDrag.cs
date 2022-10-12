using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraDrag : MonoBehaviour {
    public float speed = 2.0f;

    Vector2 click_position = Vector2.zero;
    Vector2 current_position = Vector2.zero;

    private void Update()
    {
        if(Input.GetMouseButtonDown(0))
        {
            click_position = Input.mousePosition;
        }

        if (Input.GetMouseButton(0))
        {
            current_position = Input.mousePosition;
            Dragging();
        }
    }

    void Dragging()
    {
        Vector2 direction = Camera.main.ScreenToWorldPoint(current_position) - Camera.main.ScreenToWorldPoint(click_position);
        direction = direction * -1;
        Vector2 move = new Vector2(direction.x * speed, direction.y * speed);       
        transform.Translate(move, Space.World);
    }
}
