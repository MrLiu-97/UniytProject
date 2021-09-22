using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
///
/// </summary>
public class DoRotation : MonoBehaviour
{
    public float vector3;
    public Camera camera;
    private void Start()
    {
        camera = this.GetComponentInChildren<Camera>();
    }
    private void Update()
    {
        Moves();
    }

    private void FixedUpdate()
    {
        GetMouseMoveXY();
    }

    /// <summary>
    /// 上下左右 移动
    /// </summary>
    private void Moves()
    {
        float leftRight = Input.GetAxisRaw("Horizontal");
        float upDown = Input.GetAxisRaw("Vertical");

        if (leftRight != 0 || upDown != 0)
            this.transform.Translate(leftRight * Time.deltaTime, 0, upDown * Time.deltaTime, Space.World);
    }

    /// <summary>
    /// 旋转的快慢
    /// </summary>
    public float rotateSpeed = 1;
    private void GetMouseMoveXY()
    {
        //Rotate  
        ///X 正值：向下旋转 负值：向上旋转
        ///Y 正值：右旋转 负值：左旋转  
        ///Z 正值：左上 右下（顺时针旋转）  负值：右上 左下（逆时针旋转）
        ///

        float X = Input.GetAxis("Mouse X");
        float Y = Input.GetAxis("Mouse Y");
        X *= rotateSpeed;
        Y *= rotateSpeed;

        /// 限制角度  需要有一个边界  旋转
        if (X != 0 || Y != 0)
        {
            RoateView(X, Y);
        }

    }
    public void RoateView(float x, float y)
    {
        // 以1度/秒的速度围绕其X轴缓慢旋转对象
        //camera.transform.Rotate(-Y, X, 0, Space.World);

        //左右 旋转 沿 世界坐标系 Y轴 Rotate(x, y, z)  space.World
        camera.transform.Rotate(0, x, 0, Space.World);
        // 上下 旋转 沿 自身坐标 X轴 Rotate(x, y, z)
        camera.transform.Rotate(-y, 0, 0);
    }

    private void DemoInput()
    {
        #region 垃圾代码
        //if (Input.GetKey(KeyCode.W))
        //{
        //    this.transform.Translate(0, 0, 1 * Time.deltaTime);
        //}
        //if (Input.GetKey(KeyCode.S))
        //{
        //    vector3 = this.transform.position.z - 1;
        //    this.transform.Translate(0, 0, vector3 * Time.deltaTime);
        //}

        /// 当按下 a 或者 左键头 返回:（-1）  不按 返回: 0   当按下 d  或者 右箭头 返回:（1）  不按 返回: 0
        //vector3 = Input.GetAxis("Horizontal");
        //print(vector3);
        if (Input.GetButton("Horizontal"))
        {
            //GetAxis 从小数 开始 正向： 0.001 0.002 等等直到 1  负向：-0.001 -0.002 等等 直到 -1
            //vector3 = Input.GetAxis("Horizontal");
            //GetAxisRaw  从 整数开始  正向:1  负向: -1
            vector3 = Input.GetAxisRaw("Horizontal");
            // 左右 移动
            this.transform.Translate(vector3 * Time.deltaTime, 0, 0, Space.World);
            print(vector3);
        }
        if (Input.GetButton("Vertical"))
        {
            vector3 = Input.GetAxisRaw("Vertical");
            // 上下移动
            //this.transform.Translate(0, vector3 * Time.deltaTime, 0);
            // 前后移动
            this.transform.Translate(0, 0, vector3 * Time.deltaTime, Space.World);
        }
        #endregion

        float leftRight = Input.GetAxisRaw("Horizontal");
        float upDown = Input.GetAxisRaw("Vertical");

        this.transform.Translate(upDown * Time.deltaTime, 0, leftRight * Time.deltaTime, Space.World);
    }

    private void GetMouseMoveY()
    {

        //vector3 = Input.GetAxisRaw("Mouse Y");

        //camera.transform.Rotate(vector3 * Time.deltaTime, 0, 0, Space.World);
        ////print(res);

    }
}
