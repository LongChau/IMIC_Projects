using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public GameObject explosion; // thêm gameobject explosion(thêm hiêu ứng nổ)
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "bd_bottom") // nếu enemy va chạm với rào chắn dưới
        {
            // tạo ra gameobjecy nổ
            GameObject g  = Instantiate(explosion,transform.position,Quaternion.identity);

            Destroy(g, 0.5f); // xóa gameOject Explosion sau 0.5 giây;

            Destroy(gameObject); // xóa gameOject Enemy
        }
        if(collision.gameObject.tag == "player")// nếu enemy va chạm với player
        {
            GameObject g = Instantiate(explosion, transform.position, Quaternion.identity);
            Destroy(g, 0.5f);
            Destroy(gameObject);
        }
    }
}
