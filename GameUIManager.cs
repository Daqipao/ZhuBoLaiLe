using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

/// <summary>
/// 游戏界面UI管理器.
/// </summary>
public class GameUIManager : MonoBehaviour {
    //自身Transform组件.
    private Transform m_Transform;

    //协程，用于使滑块不断上升.
    //private IEnumerator AddSliderValue;

    //滑块组件.
    private Slider slider;

    //标志位,用于限制滑块一次上升的高度.
    private float index;

    //Camera相机上的声音控制脚本引用.
    private AudioManager m_AudioManager;

    //歌曲开始播放的时间.
    private float startTime = 0;

    //实时时间.
    private float currentTime;

    //歌曲是否正在播放.
    private bool isPlay;

    private Scrollbar lyric_Scrollbar;

    //0.62,0.86
	
	void Start () {
        //查找Camera相机上的声音控制脚本.
        m_AudioManager = GameObject.Find("Camera").GetComponent<AudioManager>();
        //查找Transform.
        m_Transform = gameObject.GetComponent<Transform>();
        //查找滑块.
        slider = m_Transform.Find("Slider").GetComponent<Slider>();
        //查找歌词滑块.
        lyric_Scrollbar = m_Transform.Find("Lyric/Scrollbar").GetComponent<Scrollbar>();
        //默认滑块处于最上方；
        slider.value = 1;
        //默认开启协程，实现滑块不断下落.
        StartCoroutine("ReduceSliderValue");
        //默认isPlay为false.
        isPlay = false;

        
	}

    void Update()
    {
        //按下空格键
        if (Input.GetKeyDown(KeyCode.Space))
        {
            //停止协程，滑块停止下落.
            StopCoroutine("ReduceSliderValue");
            //滑块上升一小段距离.
            InvokeRepeating("AddSliderValue", 0, 0.01f);
        }
        Stop_AddSliderValue();

        if (Input.GetKeyDown(KeyCode.F))
        {
            m_AudioManager.m_AudioSource.Play();
            isPlay = true;
            //播放音乐时，记录音乐开始时间.
            startTime = Time.time;
        }
        if (slider.value < 0.62f)//当滑块处于蓝色区域下方时，播放速度减半.
        {
            m_AudioManager.m_AudioSource.pitch = 0.5f;
        }
        else if (slider.value > 0.86f)//当滑块处于蓝色区域下方时，播放速度加快一倍.
        {
            m_AudioManager.m_AudioSource.pitch = 2;
        }
        else//当滑块处于蓝色区域时，播放速度正常.
        {
            m_AudioManager.m_AudioSource.pitch = 1;
        }
        //歌词滚动.
        Scrolling();
    }


    /// <summary>
    /// 滑块下落.
    /// </summary>
    /// <returns></returns>
    IEnumerator ReduceSliderValue()
    {
        while (true)
        {
            //当滑块不处于底端时，滑块一直下落.
            yield return new WaitForSeconds(0.03f);
            if (slider.value > 0)
            {
                slider.value -= 0.01f;
            }
        }
    }

    /// <summary>
    /// 滑块上升.
    /// </summary>
    private void AddSliderValue()
    {
        slider.value += 0.005f;
        index += 0.005f;
    }

    /// <summary>
    /// 检测滑块是否上升结束.
    /// </summary>
    private void Stop_AddSliderValue()
    {
        if (index >= 0.1)
        {
            //滑块上升完，
            CancelInvoke();
            //标志位清零.
            index = 0;
            //开启协程，滑块继续下落.
            StartCoroutine("ReduceSliderValue");
        }
    }

    /// <summary>
    /// 歌词滚动.
    /// </summary>
    private void Scrolling()
    {
        //当歌曲正在播放时，才让歌词滚动.
        if (isPlay)
        {
            currentTime = Time.time;
            //歌词滑块的值.
            float value;
            value = m_AudioManager.CalcScrollValue(currentTime - startTime);
            //设置歌词滑块的位置.
            lyric_Scrollbar.value = value;
        } 
    }
}
