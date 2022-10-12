using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraScrolling : MonoBehaviour {



    public float offset;
    public float speed;
    //x - min y - max
    public Vector2 minMaxXPosition;
    public Vector2 minMaxYPosition;
    private float screenWidth;
    private float screenHeight;
    private Vector3 cameraMove;
    // Use this for initialization
    void Start()
    {
        screenWidth = Screen.width;
        screenHeight = Screen.height;
        cameraMove.x = transform.position.x;
        cameraMove.y = transform.position.y;
        cameraMove.z = transform.position.z;
        //minMaxXPosition.x = minMaxYPosition.x = -Camera.main.orthographicSize;
        //minMaxXPosition.y = minMaxYPosition.y = Camera.main.orthographicSize;
    }
    // Update is called once per frame
    void Update()
    {
        //Move camera, kiểm tra camera có vượt qua cạnh màn hình chưa và nằm trong phạm vi cho phép
        if ((Input.mousePosition.x >= screenWidth - offset) && transform.position.x < minMaxXPosition.y)
        {
            cameraMove.x += MoveSpeed();
        }
        if ((Input.mousePosition.x <= offset) && transform.position.x > minMaxXPosition.x)
        {
            cameraMove.x -= MoveSpeed();
        }
        if ((Input.mousePosition.y >= screenHeight - offset) && transform.position.y < minMaxYPosition.y)
        {
            cameraMove.y += MoveSpeed();
        }
        if ((Input.mousePosition.y <= offset) && transform.position.y > minMaxYPosition.x)
        {
            cameraMove.y -= MoveSpeed();
        }
        transform.position = cameraMove;
        Debug.Log(Time.deltaTime);
    }
    float MoveSpeed()
    {
        return speed * Time.deltaTime;
    }
}
