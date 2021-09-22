using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
///
/// </summary>
public class Lifecycle : MonoBehaviour
{

    // 序列化字段 作用：在编辑器显示私有变量
    [SerializeField]
    private float a = 100;

    //作用: 在编译器中隐藏字段
    [HideInInspector]
    public int b;

    [Range(0, 100)]
    public int c;

    //public Lifecycle()
    //{
    //    Debug.Log("1");
    //    //a = Time.time;
    //}

    /// <summary>
    /// 脚本的生命周期
    /// </summary>
    //********** 初始阶段************

    // 执行时机： 创建游戏对象-->先执行
    public void Awake()
    {
        Debug.Log("1--" + Time.time+"--"+this.name);
        this.enabled = false;
    }

    // 执行时机：创建游戏对象--》脚本启用-->才执行
    // 作用：初始化
    public void Start()
    {
        int a = 1;
        int b = 2;
        int c = a + b;
        Debug.Log("2--" + Time.time + "--" + this.name);
    }

    //***********游戏逻辑**************
    /// <summary>
    /// 
    /// </summary>
    /// 执行时机： 渲染帧执行，执行间隔不固定
    /// 适用性：处理游戏逻辑

    private void Update()
    {
        // 单帧调试: 启动调试  运行场景  暂停游戏   加断点  单帧执行  结束调试
        int a = 1;
        int b = 2;
        int c = a + b;

    }
}
