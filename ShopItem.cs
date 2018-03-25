using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// 商城歌曲物品实体类.
/// </summary>
public class ShopItem {

    private string name;
    public string Name
    {
        get { return name; }
        set { value = name; }
    }

    private string lyric;
    public string Lyric
    {
        get { return lyric; }
        set { lyric = value; }
    }

    private float time;
    public float Time 
    {
        get { return time; }
        set { time = value; }
    }

    public ShopItem() { }
    public ShopItem(string name, string lyric, float time)
    {
        this.name = name;
        this.lyric = lyric;
        this.time = time;
    }

    public override string ToString()
    {
        return string.Format("{0}:{1}:{2}", name, lyric, time);
    }
}
