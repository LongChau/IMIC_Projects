using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class UIManager : MonoBehaviour
{
    public Text txt_coin; // thêm text hiển thị coin vào;
    void Start()
    {
        
    }
    
    void Update()
    {
        txt_coin.text = GameManager._instance.coins.ToString(); // set text hiển thị coin số coin mà player có được
    }
    public void OnClickStartGame()  // hàm này hoạt động khi click vào button start
    {
        GameManager._instance.startGame = true;
    }
}
