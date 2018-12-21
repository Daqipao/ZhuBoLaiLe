using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour {

    public AudioSource m_AudioSource;

    //3分钟47秒.
    //音频时间总长.
    private float time = 227.0f;

    private AudioClip m_AudioClip;

	void Awake () {
        m_AudioSource = gameObject.GetComponent<AudioSource>();
        m_AudioClip = Resources.Load("Camila Cabello - Never Be the Same") as AudioClip;
        m_AudioSource.clip = m_AudioClip;
        m_AudioSource.loop = true;
        m_AudioSource.volume = 0.3f;
        m_AudioSource.playOnAwake = false;
        //m_AudioSource.Play();
	}
    /// <summary>
    /// 计算歌词滚动条的位置.
    /// </summary>
    /// <param name="runTime">歌曲已播放时间</param>
    public float CalcScrollValue(float runTime)
    {
        if (runTime <= time)
        {
            //进度条系数.
            float index = (time - runTime) / time;
            return index;
        }
        else
        {
            return 0;
        }
    }

    //AudioManager.
}
