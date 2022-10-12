using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClickToMove : MonoBehaviour {

    public float speed = 6f;
    Vector2 targetPos;

    private void Start()
    {
        targetPos = transform.position; 
    }

    void Update()
    {
        //GetComponent<Animator>().SetBool("CheckMove", false);
        //hàm gọi click chuột trái 1 lần, GetMouseButton() là giữ liên tục
        if (Input.GetMouseButtonDown(0))
        {
            targetPos = (Vector2)Camera.main.ScreenToWorldPoint(Input.mousePosition); // chuyển từ tọa độ màn hình sang tọa độ world từ vị trí trỏ chuột
        }
        if ((Vector2)transform.position != targetPos) // kiểm tra vị trí hiện tại của sprite khác với vị trí click chuột
        {
            //kiểm tra xoay sprite dựa trên giá trị x hiện tại so với x tọa độ click chuột
            if (transform.position.x < targetPos.x)
                GetComponent<SpriteRenderer>().flipX = true;
            else
                GetComponent<SpriteRenderer>().flipX = false;

            //kiểm tra nếu có di chuyển sẽ bật animation di chuyển lên
            GetComponent<Animator>().SetBool("CheckMove", true);

            //di chuyển sang vị trí click chuột với vận tốc speed * thời gian
            transform.position = Vector2.MoveTowards(transform.position, targetPos, speed * Time.deltaTime);
        }
        else //khi đã di chuyển trùng với tọa độ chuột thì dừng lại
        {
            GetComponent<Animator>().SetBool("CheckMove", false);
        }
    }
}
