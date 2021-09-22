using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
///
/// </summary>
public class Bullet : MonoBehaviour
{
    // 当满足碰撞条件
    // 接触的第一帧 执行
    private void OnCollisionEnter(Collision other)  // 在射击 场景中 如果子弹射速过快 则当前被撞击的物体 无法被检测到 碰撞检测将失效
    {
        // 获取对方物体的组件
        print("otherObjectCollision：" + other.collider.name);
        //GameObject.
        //other.collider.GetComponent<任何组件>  获取对方的碰撞器组件

        ContactPoint cp = other.contacts[0];
        //cp.point 接触点的世界坐标
        //cp.normal 接触面法线  如果物体是圆的 就无法确定撞得是哪个 面 所以用到法线 作用：确定撞的方向 / 接触面
        // 适用于一些特效
    }

    // 有时候 想获取对方的攻击范围 就可以用触发去做
    /// 当满足触发条件  触发 不能获取到玩家的具体位置 所以只能用 碰撞
    /// 接触的第一帧执行
    private void OnTriggerEnter(Collider other)   // 在射击 场景中 如果子弹射速过快 则当前被撞击的物体 无法被检测到 碰撞检测将失效
    {
        // 获取对方物体的组件
        print("otherObjectTrigger：" + other.name);

        //other.GetComponent<任何组件>  就是对方的碰撞器组件
    }

    public float moveSpeed = 50;
    private void FixedUpdate()
    {
        Debug.Log(Time.frameCount + "---" + this.transform.position);
        //this.transform.Translate(0, 0, Time.deltaTime * moveSpeed);
    }

    // 当子弹 发射出去 到底想检测到那些层的 物体  就可设置此项  可能前方有障碍物
    public LayerMask mask;
    public Vector3 tragetPos;
    //在射击 场景中 如果子弹射速过快 则当前被撞击的物体 无法被检测到 碰撞检测将失效
    // 解决方案：开始时，使用射线检测
    private void Start()
    {
        RaycastHit hit; // 返回结果：射线检测到==》 目标的具体信息
        // hit.normal  从我的当前物体的位置 发射一根射线 打到另外一个物体身上的 打到的那个 碰撞面 是什么 （就是法线）

        // Physics.Raycast(开始位置，方向，返回检测到的受击物体具体信息，最大距离(射线的距离可发射多远 未填写：无穷远)，层)
        bool res = Physics.Raycast(this.transform.position, this.transform.forward, out hit, 100, mask);
        if (res)
        {
            // 检测到物体
            tragetPos = hit.point;  // 击中物体的 点的坐标
        }
        else
        {
            // 未检测到物体  继续往前飞  直到达到最大距离
            tragetPos = this.transform.position + this.transform.forward * 100;  // 从当前的位置 继续往前飞直到到达最大距离 100
        }
    }

    private void Update()
    {
        this.transform.position = Vector3.MoveTowards(this.transform.position, tragetPos, Time.deltaTime * moveSpeed);
        // 比 Distance 少了 开平方  比如 要 判断 从 a 到 b 的位置 是否 小于 0.1  就可以用 sqrMagnitude 提高性能 
        if ((this.transform.position - tragetPos).sqrMagnitude < 0.1f)  // 从当前物体的位置  到 击中物体目标点的位置 是否小于 0.1f
        {
            print("到达目标点");
            Destroy(this.gameObject);   // 销毁子弹
        }
    }
}
