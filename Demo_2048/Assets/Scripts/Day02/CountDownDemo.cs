using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;
using UnityEngine.UI;

/// <summary>
///
/// </summary>
public class CountDownDemo : MonoBehaviour
{
    // 在编译器中隐藏字段
    [HideInInspector]
    public Text textString;
    //[HideInInspector]
    public int Second = 31;
    // 下次修改时间
    private float nextTime = 1;

    private void Start()
    {
        textString = this.GetComponent<Text>();

        // 方法三
        // 重复调用  InvokeRepeating（被执行的方法名称，第一次执行时间，每次执行间隔）
        // InvokeRepeating("Timer", 5, 1); // Timer 方法 会在5秒后 开始执行  每次执行间隔时间为 1秒
        InvokeRepeating("Timer", 1, 1);
    }
    private void Update()
    {
        //Timer();

    }
    private float totalTime;

    // 方法三  Invoke
    // 每隔固定时间 重复去执行的需求 适合 用Invoke
    private void Timer()
    {
        Second--;
        textString.text = string.Format("{0:d2}:{1:d2}", Second / 60, Second % 60);
        if (Second <= 10)
            textString.color = Color.red;
        if (Second <= 0)
        {
            // 取消调用此方法
            CancelInvoke("Timer");
        }
    }

    // 方法一 Time.time
    // 适合 时间间隔不固定的次数 Time.time + 1; Time.time + 1.5;----等等 必须用在 Update里面执行
    private void Timer1()
    {
        // 方案一 时间间隔 1S
        // 先判断条件去执行  无需等待   适合做 发射子弹
        if (Time.time >= nextTime) // nextTime 可以设置为 0
        {
            Second--;
            textString.text = string.Format("{0:d2}:{1:d2}", Second / 60, Second % 60);
            //Thread.Sleep(1000);
            // 执行完后在等待
            nextTime = Time.time + 1;
            if (Second <= 10)
            {
                textString.color = Color.red;
            }
            //if (Second <= 0)
            //{
            //    // 取消调用此方法
            //    CancelInvoke("Timer");
            //}
        }
    }

    // 方法二 Time.deltaTime
    // 适合 时间间隔不固定的次数 Time.time + 1; Time.time + 1.5;----等等  必须用在 Update里面执行
    private void Timer2()
    {
        //方案二 时间间隔 1S
        // Time.deltaTime; 代表每帧消耗的时间  每帧消耗的时间都累加起来 到 1s 时 就用了1s  
        // 累加间隔 置一秒 有误差
        totalTime += Time.deltaTime; // 有可能会超过1
       
        if (totalTime >= 1)   // 先等待（totalTime 时间累加够了才会进去执行）  后判断条件 去执行  相当于 到终点了  得等一会 才能去下个终点
        {
            Second--;
            textString.text = string.Format("{0:d2}:{1:d2}", Second / 60, Second % 60);
            if (Second <= 10)
            {
                textString.color = Color.red;
            }
            totalTime = 0; // 随后归零  重新累加
        }
    }
}
