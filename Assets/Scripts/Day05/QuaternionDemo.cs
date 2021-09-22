using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
///
/// </summary>
public class QuaternionDemo : MonoBehaviour
{

    private void OnGUI()
    {
        if (GUILayout.Button("设置物体旋转角度"))
        {

            // 四元数 要想旋转 必须要告诉我
            // 旋转轴 
            Vector3 axis = Vector3.up;  //  沿Y轴 旋转
            // 旋转角度/ 弧度 
            float rad = 50 * Mathf.Deg2Rad; //  角度转弧度

            // 四元数公式  
            Quaternion quaternion = new Quaternion();
            quaternion.x = Mathf.Sin(rad / 2) * axis.x;
            quaternion.y = Mathf.Sin(rad / 2) * axis.y;
            quaternion.z = Mathf.Sin(rad / 2) * axis.z;
            quaternion.w = Mathf.Cos(rad / 2);
            this.transform.rotation = quaternion;
            // 四元数 如何旋转 是从 四个公式 X Y Z W 里面算出来的
            // 但是 公式通常来讲 我们不用公式去 设置 但是极个别 需要用到公式

            // 现成 API
            this.transform.rotation = Quaternion.Euler(0, 50, 0);   // 沿 Y轴旋转 50度
        }

        if (GUILayout.RepeatButton("沿X轴旋转"))
        {
            // 四元数 不能相加 只能相乘
            this.transform.rotation *= Quaternion.Euler(1, 0, 0);
            // 在四元数里面 相乘 表示可以组合旋转效果   相当于 两个数相加
            Quaternion quaternion1 = Quaternion.Euler(0, 30, 0) * Quaternion.Euler(0, 20, 0);

            Quaternion quaternion2 = Quaternion.Euler(0, 50, 0);
            // quaternion1 与 quaternion2 相同

        }
        if (GUILayout.RepeatButton("沿Y轴旋转"))
        {
            //this.transform.Rotate(0, 1, 0); 内部也是四元数
            this.transform.rotation *= Quaternion.Euler(0, 1, 0);
        }
        if (GUILayout.RepeatButton("沿Z轴旋转"))
        {

            this.transform.rotation *= Quaternion.Euler(0, 0, 1);
        }
    }

    public Vector3 vector3;
    private void Update()
    {
        Demo02();
        //Demo01();

        //Debug.DrawLine(this.transform.position, vector3);
        if (Input.GetMouseButtonDown(0))
        {
            // 从 世界的坐标 基础之上 加上 当前物体的 自身坐标
            // 此时 就变成了 当前物体的 正前方 10米处 //的位置
            vector3 = this.transform.position + new Vector3(0, 0, 10);

            // Quaternion.Euler(0, 30, 0) * new Vector3(0, 0, 10)： 此时就代表了 正前方 10米 被旋转 了30度 然后 有了 这么一根向量
            // 在吧 这个向量 加上 我的位置（this.transform.position）
            //就代表了 我的 正前方 偏了 30 度   // 但此时  不能打到理想的结果  以为 我要 线 随着物体的 旋转角度 而跟着变化
            vector3 = this.transform.position + Quaternion.Euler(0, 30, 0) * new Vector3(0, 0, 10);

            // Quaternion.Euler(0, 30, 0) * this.transform.rotation 此时的 旋转 与 当前物体自身的角度 先叠加一下
            // 叠加 完之后 再和 向量(new Vector3(0, 0, 10)) 相乘
            // 此时 这个向量(new Vector3(0, 0, 10)) 就可以 按照 物体的旋转 而 旋转
            // 在吧 组合完 的向量 给到 物体自身的位置（this.transform.position）
            vector3 = this.transform.position + Quaternion.Euler(0, 30, 0) * this.transform.rotation * new Vector3(0, 0, 10);


            // 0 0 10 根据 当前物体 自身的 角度 旋转 而旋转
            vector3 = this.transform.rotation * new Vector3(0, 0, 10);
            //  vector3 向量 沿 Y轴 旋转 30度
            vector3 = Quaternion.Euler(0, 30, 0) * vector3;
            // vector3 向量 移动 到当前物体的 位置
            vector3 = this.transform.position + vector3;

        }
    }
    // 获取玩家标签
    private string playerTag = "Player";

    // 获取 玩家组件
    private Transform playerTF;
    // 获取 半径
    private float radius;
    private void Start()
    {
        GameObject gameObject = GameObject.FindGameObjectWithTag(playerTag);
        playerTF = gameObject.transform;
        // 获取 CapsuleCollider 组件
        radius = playerTF.GetComponent<CapsuleCollider>().radius;
    }

    private Vector3 right, left;
    /// <summary>
    ///  计算切点
    /// </summary>
    private void CalculateTangent()
    {
        // 计算 爆炸点 与 玩家的 向量 Distance 只能求长度
        //float spaning = Vector3.Distance(this.transform.position, playerTF.position);
        Vector3 playerToExplosion = this.transform.position - playerTF.position;


        // 获取 半径向量
        // playerToExplosion.normalized 模长 1 * 0.5 = 0.5; 对呀 标准化向量始终 为 1
        Vector3 radiusDirectgion = playerToExplosion.normalized * radius;

        //print(playerToExplosion.magnitude);
        // 计算夹角  临边 比 斜边  radius / playerToExplosion.magnitude （模长）
        float angle = Mathf.Acos(radius / playerToExplosion.magnitude) * Mathf.Rad2Deg;
        // 四元数相乘 给再到 当前玩家的位置
        right = playerTF.position + Quaternion.Euler(0, angle, 0) * radiusDirectgion;
        left = playerTF.position + Quaternion.Euler(0, -angle, 0) * radiusDirectgion;
        //print(angle);
        //// 计算 叉乘
        //Vector3.Cross()
        //// 旋转角度
        //Vector3 euler = playerTF + Quaternion.Euler();
    }

    public Transform t1, t2;
    private void Demo01()
    {
        CalculateTangent();
        Debug.DrawLine(this.transform.position, left);
        Debug.DrawLine(this.transform.position, right);
    }

    public Vector3 planeNorm;
    private void Demo02()
    {
        Vector3 result = Vector3.ProjectOnPlane(t1.position, planeNorm);
        Debug.DrawLine(Vector3.zero, result);
        Debug.DrawLine(Vector3.zero, t1.position);

    }
}
