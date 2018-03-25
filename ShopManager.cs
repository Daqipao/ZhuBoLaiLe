using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using LitJson;

/// <summary>
/// 商城管理器.
/// </summary>
public class ShopManager : MonoBehaviour {

    
	
	void Start () {
        string jsonStr = Resources.Load<TextAsset>("ShopData").text;
        JsonData jsonData = JsonMapper.ToObject(jsonStr);
        for (int i = 0; i < jsonData.Count; i++)
        {
            ShopItem temp = JsonMapper.ToObject<ShopItem>(jsonData[i].ToJson());
            temp.ToString();
        }
	}
	
	//2018年3月25日.

}
