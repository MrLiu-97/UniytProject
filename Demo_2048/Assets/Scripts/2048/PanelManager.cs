using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
///
/// </summary>
public class PanelManager : MonoBehaviour
{
    //static PanelManager()
    //{
        
    //}
    public Transform[] panelTFS;

    public static Dictionary<string, Transform> keyValuesTF;
    /// <summary>
    /// 记录原来的位置
    /// </summary>
    public static Dictionary<string, Vector3> keyValuesPos;
    private void Awake()
    {
        // 初始化静态字典 避免new的时候取不到值  重新加载场景也是一样
        keyValuesTF = new Dictionary<string, Transform>();
        keyValuesPos = new Dictionary<string, Vector3>();
        // 将所有Transform 存入字典
        for (int i = 0; i < panelTFS.Length; i++)
        {
            //print(panelTFS[i].name);
            keyValuesTF.Add(panelTFS[i].name, panelTFS[i]);
            keyValuesPos.Add(panelTFS[i].name, panelTFS[i].position);
        }
    }

    /// <summary>
    ///  通过名字获取对应的Transform面板
    /// </summary>
    /// <param name="name">面板名</param>
    /// <returns></returns>
    public static Transform GetTransformByName(string name)
    {
        return keyValuesTF[name];
    }
    /// <summary>
    /// 通过面板名获取原来的位置
    /// </summary>
    /// <returns></returns>
    public static Vector3 GetPanelPostionByName(string name)
    {
        return keyValuesPos[name];
    }
}
