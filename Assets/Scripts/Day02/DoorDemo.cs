using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
///
/// </summary>
public class DoorDemo : MonoBehaviour
{
    /// <summary>
    /// 门的状态  
    /// 多种状态可以用枚举
    /// </summary>
    public bool doorStart = false;
    // 当鼠标按下时   这个也适合 触摸 按下  
    private Animation animation;
    // 动画名称
    private string animaName = "OpenDoor";
    private void Start()
    {
        // 一开始就获取到 animation 组件
        // 获取  Animation 组件
        animation = GetComponent<Animation>();
    }
    private void OnMouseDown()
    {
        // 刚开始 进来 门关着 为 false  所以要开门
        if (doorStart)
        {
            doorStart = false;
             //当前动画是否正在播放
            if (!animation.isPlaying)
            {
                // 从动画的最后面开始播放 
                //animation[animaName].time 当前动画播放时间   animation[animaName].time=1 则为 1 秒
                animation[animaName].time = animation[animaName].length;
            }

            // 动画倒放 关门
            animation[animaName].speed = -1;
        }
        else
        {
            doorStart = true;
            // 正常播放 /正着播放  开门  默认 0---》1
            animation[animaName].speed = 1;
        }

        // 播放动画
        animation.Play(animaName);
    }

}
