using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    // Start is called before the first frame update  
    public float speed;
    private Rigidbody2D rb;
    private Vector3 bound;
    private float minX, maxX;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();

        // lấy kích thước màn hình
        bound = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width, Screen.height, 0));
        minX = -bound.x;
        maxX = bound.x;
    }

    // Update is called once per frame
    void Update()
    {
        if (!GameManager._instance.startGame) return;
        //Move();
        MoveByTransform();
    }

    private void Move()
    {
        float x = Input.GetAxisRaw("Horizontal") * speed; // nhận tín hiệu truyền vào từ bàn phím  
        
        rb.velocity = new Vector2(x, 0); // cho player di chuyển 

        BoundPlayerPosition(transform.position); // check vị trí của player có ra khỏi màn hình hay ko
    }

    private void MoveByTransform()
    {
        var speed = 10f;
        if (Input.GetKey(KeyCode.LeftArrow))
        {
            transform.Translate(Vector2.left * speed * Time.deltaTime);
        }
        else if (Input.GetKey(KeyCode.RightArrow))
        {
            transform.Translate(Vector2.right * speed * Time.deltaTime);
        }
        BoundPlayerPosition(transform.position); // check vị trí của player có ra khỏi màn hình hay ko
    }

    private void BoundPlayerPosition(Vector2 input) // ko có player di chuyển ra khỏi màn hình
    {
        if (input.x < minX) // vị trí tọa độ x của vector input bé hơn giới hạn MinX (input = vi trí hiện tại của player)_
        {
            input.x = minX;
        }
        if(input.x > maxX) 
        {
            input.x = maxX;
        }

        transform.position = input; // set vi trị của player = vị trí input
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "enemy") // nếu player chạm enemy
        {
            GameManager._instance.coins += 10; // coin được cộng dồn thêm 10;
        }
    }
}
