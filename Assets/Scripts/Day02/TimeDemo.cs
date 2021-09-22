using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
///
/// </summary>
public class TimeDemo : MonoBehaviour
{
    //public float T;
    public float Speed = 100;
    public float a, b, c;
    // Update() 的执行效率 仅仅只受 渲染的影响 而 渲染 受 机器性能的影响 不受 TimeScale 影响
    // 渲染场景时执行，不受 TimeScale 影响 但 里面调用的 帧时间（Time.deltaTime） 会受 TimeScale 影响
    private void Update()
    {
        // 每渲染帧 执行 1次，旋转1度
        //T = Time.time;
        //this.transform.Rotate(0, 1, 0);

        // 在 UPdate 里面坐旋转 为了让速度恒定 就是  快的 可以慢点 慢的可以快点 就可以用 (旋转速度 * Time.deltaTime)

        // 当帧多事 1秒旋转速度快   希望 1帧旋转量小（1*Time.deltaTime）;
        this.transform.Rotate(0, Speed * Time.deltaTime, 0); // 要想速度恒定 就必须 * Time.deltaTime  可以保证(旋转/移动)速度 不受 渲染 影响
        // 旋转速度*每帧消耗时间，可以保证旋转速度 不受机器性能 以及 渲染 影响；
        // 很多时候 游戏移动的速度 都放在 Update 里面调用
        // Time.unscaledDeltaTime 不受缩放时间的影响  不受缩放影响的每帧间隔
        //this.transform.Rotate(0, 10 * Time.unscaledDeltaTime, 0);

        a = Time.time;  // 受缩放影响的游戏运行时间
        a = Time.unscaledTime;      // 不受 缩放影响的游戏运行时间 
        c = Time.realtimeSinceStartup;  // 实际游戏运行时间
    }

    // 固定 0.02秒 执行一次，与渲染无关  可以使速度恒定
    private void FixedUpdate()
    {
        //this.transform.Rotate(0, Speed, 0);
    }
    private void OnGUI()
    {
        if (GUILayout.Button("暂停"))
        {
            // 只会对 FixedUpdate 造成影响 Update（） 不受影响
            Time.timeScale = 0;
        }
        if (GUILayout.Button("开始"))
        {
            Time.timeScale = 1;

        }
    }

}
