using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DemoFPS : MonoBehaviour
{
    Vector2 newPos;
    Vector2 tPos;
    public float speed = 0.01f;
    // Start is called before the first frame update
    void Start()
    {
        tPos = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        tPos.x += speed * Time.deltaTime;
        transform.position = tPos;
    }
}
