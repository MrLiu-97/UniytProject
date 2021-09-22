using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
///
/// </summary>
public class VectorDemo : MonoBehaviour
{
    private void Update()
    {
        Demo04();
    }

    /// <summary>
    /// 计算 模长（大小）
    /// </summary>
    private void Demo01()
    {
        // 任何 物体的 世界 坐标 都是 从 （世界坐标原点）零点 到  当前 物体位置 的 点
        // 三维向量
        Vector3 vector3 = this.transform.position;

        // 根据模长公式 获取 模长
        float m01 = Mathf.Sqrt(Mathf.Pow(vector3.x, 2) + Mathf.Pow(vector3.y, 2) + Mathf.Pow(vector3.z, 2));

        // 直接 获取模长  现成的 API
        float m02 = vector3.magnitude;
        // 从 0 点 到 当前 vector3 点 的位置 Distance 可以 求 任意 两点间距
        float m03 = Vector3.Distance(Vector3.zero, vector3);
        Debug.LogFormat("{0}----{1}----{2}", m01, m02, m03);
    }

    /// <summary>
    /// 计算方向
    /// </summary>
    private void Demo02()
    {
        Vector3 vector3 = this.transform.position;

        Vector3 n01 = vector3 / vector3.magnitude;
        // API: 获取向量的方向  归一化  标准化==》计算单位向量
        Vector3 n02 = vector3.normalized;

        // 两者 空间的 指向 是一样的  但长度 都是 1

        Debug.DrawLine(Vector3.zero, n01);
        Debug.DrawLine(Vector3.zero, n02, Color.red);

    }

    public Transform t1, t2, t3;
    public float angle;
    /// <summary>
    /// 向量计算
    /// </summary>
    private void Demo03()
    {
        Vector3 relativeDirection = t1.position - t2.position;

        // 方向：指向被减向量（前面的）   被减数 - 减数 = 差
        // 大小： 两点 间距
        // 注意：实际位置 要平移到 世界 坐标原点
        if (Input.GetKeyDown(KeyCode.A))
        {
            // 朝着一个 方向飞  （获取标准化方向）给的 方向 就 长度 为一 
            // t3 沿着 relativeDirection 方向 移动 
            // 把 两个 方向 相减 减完 之后 要  normalized 或者说 给的 那个 方向长度 为 1 
            //t3.Translate(relativeDirection.normalized);   // 不能确定内部是如何工作的

            // relativeDirection.normalized : 获取 方向，避免两个物体间距对速度造成影响
            //这里只是给个长度为1的单位向量，只需要在移动时加入速度，时间等变量，这个单位向量就只有方向起作用了
            t3.position = t3.position + relativeDirection.normalized;
        }
        Debug.DrawLine(Vector3.zero, relativeDirection);
    }

    /// <summary>
    /// 点乘 和 叉乘
    /// </summary>
    private void Demo04()
    {
        // 向量 +- 向量
        // 向量 */ 数字
        // 向量 x * 向量
        // 向量 和 向量 之间的==》 Dot 点乘   Cross 叉乘  Vector3
        // 所谓 对向量的操作 都是要找 三维向量的 结构体

        //Vector3 vector3 = new Vector3();
        //vector3 = vector3 * 2;
        //vector3 = vector3 / 2;
        //vector3 = 2 / vector3  ;
        Vector3 v1 = t1.position / t1.position.magnitude;
        Vector3 v2 = t2.position / t2.position.magnitude;
        //Vector3 n01 = v1 / v1.magnitude;
        //Vector3 n02 = v2 / v2.magnitude;

        // 在 Dot 里面 就能求出 两个向量的 余弦值
        float dot = Vector3.Dot(v1, v2);

        Debug.DrawLine(Vector3.zero, t1.position);
        Debug.DrawLine(Vector3.zero, t2.position);
        // 再把余弦值 反余弦 再转角度 就 求出 所得结果  夹角
        angle = Mathf.Acos(dot) * Mathf.Rad2Deg;    // 消耗性能

        // 可读性高 消耗性能
        if (angle > 60) // 如果 向量夹角 大于 60 度 则....
        {

        }
        // 提高性能 可读性 低
        if (dot < 0.5f) //  0.5f :60 度 的反余弦值 此时 可以省略  angle = Mathf.Acos(dot) * Mathf.Rad2Deg; 提高性能
        {

        }


        // 点乘 和叉乘 结合 在 一起 使用 就可以 求的 一圈的夹角
        Vector3 cross = Vector3.Cross(t1.position, t2.position);
        if (cross.y < 0)
        {
            angle = 360 - angle;
        }
        Debug.DrawLine(Vector3.zero, cross, Color.red);
        print(angle + ":::::::" + cross.x + ":::::::" + cross.y + ":::::::" + cross.z);
    }

    public Vector3 euler;
    private void OnGUI()
    {
        euler = this.transform.eulerAngles;
        if (GUILayout.RepeatButton("沿X轴旋转"))
        {
            // 此处 才是有方向 有大小
            //Vector3 pos = this.transform.position;

            Vector3 euler = this.transform.eulerAngles; // 返回类型是向量 但是 欧拉角，没有方向，没有大小的概念
            // 注意：欧拉角，没有方向，没有大小的概念
            // 因为 三维向量 包含 x y z ，所以在 Unity 中，欧拉角的数据类型 为 Vector3
            // 欧拉角的 x y z ，表示各个轴向上的旋转角度

            // 个分量相加： 就是(欧拉角的) x 和 x 相加，y 和 y 相加，z 和 z 相加
            this.transform.eulerAngles += new Vector3(1, 0, 0);

        }


        // 此时 X 和 Y 只能 沿一个轴(Z轴)去转  这个 现象 称为 万向节死锁
        if (GUILayout.RepeatButton("沿Y轴旋转"))
        {
            //this.transform.eulerAngles += new Vector3(0, 1, 0);
            // Vector3.up 里面 内部的向量 就是 0 1 0
            this.transform.eulerAngles += Vector3.up;
        }

        //加上之前所说的欧拉角的y是沿世界y轴转动
        //从自身坐标系来看，沿世界y即为沿自身z，自身y不变，自身z变化
        //因此，自身的y轴丢失，归于自身z轴，或有疏漏，仅作参考
        if (GUILayout.RepeatButton("沿Z轴旋转"))
        {
            //this.transform.eulerAngles += new Vector3(0, 0, 1);
            // Vector3.forward 里面 内部的向量 就是 0 0 1
            this.transform.eulerAngles += Vector3.forward;
        }
    }
}
