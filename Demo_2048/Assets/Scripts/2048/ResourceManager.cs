using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// 资源加载类
/// </summary>
public class ResourceManager : MonoBehaviour
{
    // 使用静态字典读取
    public static Dictionary<int, Sprite> spriteDic;

    // 静态构造函数 主需要加载一次
    static ResourceManager()
    {
        // 初始化 new 不 new 为 空
        spriteDic = new Dictionary<int, Sprite>();
        // 加载精灵 图集
        var loadSprite = Resources.LoadAll<Sprite>("2048Atlas");
        // 遍历精灵图集 到 字典中
        foreach (var item in loadSprite)
        {
            //print(item);
            spriteDic[int.Parse(item.name)] = item;
            //int key = int.Parse(item.name);
            //spriteDic.Add(key, item);
        }
    }
    // 每次 都可以从内存里面读取相应的 图片
    public static Sprite LoadSprite(int number)
    {
        //foreach (var item in sprite)
        //{
        //    if (item.name.ToString()== number.ToString())
        //    {
        //        return item;
        //    }
        //}
        return spriteDic[number];
    }

}
