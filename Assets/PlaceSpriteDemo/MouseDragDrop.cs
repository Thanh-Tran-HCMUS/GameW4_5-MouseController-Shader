using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseDragDrop : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(isDown)
        {
            Vector2 newPos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            transform.position = newPos;
            //transform.position = Input.mousePosition / 400f;
        }
    }

    bool isDown = false;

    /*void OnMouseDown()
    {
        isDown = true;
    }

    void OnMouseUp()
    {
        isDown = false;
    }*/

    public void SetState(bool state)
    {
        isDown = state;
    }
}
