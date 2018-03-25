using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

/// <summary>
/// 开始界面UI控制脚本.
/// </summary>
public class StartUIManager : MonoBehaviour {
    //获取自身Transform组件
    private Transform m_Transform;

    //获取开始界面所有按钮.
    private Button button_Start;
    private Button button_Quit;
    private Button button_Store;
    private Button button_Seting;

	void Start () {
        
        m_Transform = gameObject.GetComponent<Transform>();

        button_Start = m_Transform.Find("Start").gameObject.GetComponent<Button>();
        button_Quit = m_Transform.Find("Quit").gameObject.GetComponent<Button>();
        button_Store = m_Transform.Find("Store").gameObject.GetComponent<Button>();
        button_Seting = m_Transform.Find("Seting").gameObject.GetComponent<Button>();

        //给开始按钮添加点击事件.
        button_Start.onClick.AddListener(Btn_Start_Click);
        
	}

    /// <summary>
    /// 点击开始按钮，跳转游戏场景.
    /// </summary>
    private void Btn_Start_Click()
    {
        SceneManager.LoadScene("Game");
        
    }
}
