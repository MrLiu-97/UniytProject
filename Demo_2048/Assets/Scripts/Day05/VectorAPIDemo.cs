using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
///
/// </summary>
public class VectorAPIDemo : MonoBehaviour
{
    /// <summary>
    /// 根据曲线移动
    /// </summary>
    public AnimationCurve animation;

    private float x;
    /// <summary>
    /// 持续时间   控制移动速度
    /// </summary>
    private float longTime = 3;
    private void OnGUI()
    {

        if (GUILayout.RepeatButton("MoveTowards"))
        {
            //MoveTowards 移向  将当前 物体缓慢移动到 目标位置
            this.transform.position = Vector3.MoveTowards(this.transform.position, new Vector3(0, 0, 10), 0.1f);
        }
        if (GUILayout.RepeatButton("Lerp"))
        {
            //速度 先快 到慢 (无线接近)
            // 终点 与 比例 固定 现象 快 到慢 (无线接近)
            this.transform.position = Vector3.Lerp(this.transform.position, new Vector3(0, 0, 10), 0.1f);
        }
        if (GUILayout.RepeatButton("Lerp1"))
        {
            // 时间 加上 每帧的间隔  longTime 除以 2 就是 两秒 到终点 除以 3 就是 3秒到终点
            x += Time.deltaTime / longTime; // 累加多长时间 为 1秒？  答案是 1 累加 1秒
            // 自然运动 起点固定 终点 固定 比例根据曲线变化
            this.transform.position = Vector3.Lerp(Vector3.zero, new Vector3(0, 0, 10), animation.Evaluate(x));
        }

        //// 轴 / 角 的旋转  
        /// 将当前 物体 沿 Y轴 旋转 50度  比较适合绕着一个轴 开始转
        //this.transform.rotation= Quaternion.AngleAxis(50,Vector3.up);
        // 让相机注视旋转 目标物体

        if (GUILayout.Button("1"))
        {
            // 让 当前物体注释 tf
            Vector3 dir = tf.position - this.transform.position;
            this.transform.rotation = Quaternion.LookRotation(dir);

            //this.transform.LookAt(tf);
        }
        if (GUILayout.RepeatButton("Lerp"))
        {
            // 慢慢移动  返回一个转向的结果
            Quaternion dir = Quaternion.LookRotation(tf.position - this.transform.position);

            // 再将结果 通过  Lerp 分成 多针 给到当前物体
            //this.transform.rotation = Quaternion.Lerp(this.transform.rotation, dir, 0.1f);

            // RotateTowards 匀速旋转
            this.transform.rotation = Quaternion.RotateTowards(this.transform.rotation, dir, 0.1f);
        }
        if (GUILayout.RepeatButton("RotateTowards"))
        {
            Quaternion dir = Quaternion.Euler(0, 90, 0);
            this.transform.rotation = Quaternion.Lerp(this.transform.rotation, dir, 0.1f);
            // 如果当前旋转角度 接近目标旋转角度
            // Quaternion.Angle() 告诉你 当前旋转角度 与目标旋转角度 差多少度
            if (Quaternion.Angle(this.transform.rotation, dir) < 1)
            {
                this.transform.rotation = dir;
            }
        }

        if (GUILayout.RepeatButton("RotateTowards1"))
        {
            // X轴 注释旋转
            //this.transform.right = tf.position - this.transform.position;
            // X 轴 正方向==》 注视目标位置的方向
            Quaternion dir = Quaternion.FromToRotation(Vector3.right, tf.position - this.transform.position);
            float angle = Quaternion.Angle(this.transform.rotation, dir);
            print(angle);
            this.transform.rotation = dir;

            if (Quaternion.Angle(this.transform.rotation, dir) < 1)
            {
                this.transform.rotation = dir;
            }
            //this.transform.rotation = Quaternion.Lerp(this.transform.rotation, dir, 0.1f);
        }
    }

    private void Update()
    {
        Demo01();
    }
    // 注视旋转
    public Transform tf;
    private void Demo01()
    {
        //// 轴 / 角 的旋转  
        /// 将当前 物体 沿 Y轴 旋转 50度
        //this.transform.rotation= Quaternion.AngleAxis(50,Vector3.up);
        // 让相机注视旋转 目标物体
        //Vector3 dir = transform.position - this.transform.position;
        //if (GUILayout.Button("1"))
        //{
        //    this.transform.rotation = Quaternion.LookRotation(dir);
        //}

    }

}
