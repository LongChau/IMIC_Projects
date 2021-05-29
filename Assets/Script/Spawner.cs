using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    public GameObject[] enemy; // tao mảng chứa các loại gameObject enemy
    private bool check_spaw = true;

    void Update()
    {
        if(GameManager._instance.startGame) // nếu gamestart == true 
        {
            if (check_spaw)
                StartCoroutine(Spaw()); // tạo ra enemy
        }      
    }

    IEnumerator Spaw()
    {
        check_spaw = false;
        float x = Random.Range(-8, 8); // lấy random vị trí tạo enemy dựa trên độ dài của spawner

        //enemy[Random.Range(0, enemy.Length)] : lựa chon ngẫu nhiên các enemy trong mảng để tạo ra;
        Instantiate(enemy[Random.Range(0, enemy.Length)],new Vector3(x,transform.position.y,0),Quaternion.identity);

        yield return new WaitForSeconds(Random.Range(0.2f , 1.2f)); // đợi 1 khoản thời gian cho việc tạo ra enemy tiếp theo
        check_spaw = true;
    }
}
