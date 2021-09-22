using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// 镜头的缩放
/// </summary>
public class CareamZoom : MonoBehaviour
{
    public bool IsDown;
    public Camera camera;
    private float maxValue;
    private float minValue = 20;
    private void Start()
    {
        camera = this.GetComponent<Camera>();
        maxValue = camera.fieldOfView;
    }
    private void Update()
    {
        //GetKeyInput();
        //GetMouseInput();.
        Partice3();
        //Partice1();
        //Partice();
    }
    // 默认远距离
    private bool isFar = true;
    private int level = 2;
    /// <summary>
    /// 练习1  瞄准镜  做的跟屎一样
    /// </summary>
    private void Partice()
    {
        // 练习1  瞄准镜
        // 通过鼠标右键  时间摄像机镜头缩放  设置 摄像机的 Field of View 即可
        //if (Input.GetMouseButtonDown(1))
        //{
        //    camera.fieldOfView = 20;
        //}

        #region 1按下镜头 拉近(20)，再次按下镜头拉远(60)

        // 1按下镜头 拉近(20)，再次按下镜头拉远(60)
        if (Input.GetMouseButtonDown(1))
        {
            if (isFar)
            {
                camera.fieldOfView = 20;
                //isFar = false;
            }
            else
            {
                camera.fieldOfView = 60;
                //isFar = true;
            }
            isFar = !isFar;

            //if (maxValue > minValue)
            //{
            //    maxValue = camera.fieldOfView = minValue;
            //    //max = min;
            //}
            //else
            //{
            //    maxValue = camera.fieldOfView = 60;
            //}
            print(maxValue);
        }

        #endregion

        #region 3 缩放等级经常变换  

        //3 缩放等级经常变换  可以 做个数组
        //if (Input.GetMouseButtonDown(1))
        //{
        //    //float max = max / count;
        //    if (maxValue > minValue)
        //    {
        //        maxValue = camera.fieldOfView = minValue * level;
        //        level--;
        //    }
        //    else
        //    {
        //        maxValue = camera.fieldOfView = 60;
        //        level = 2;
        //    }
        //    print(level);
        //}

        #endregion
    }

    /// <summary>
    /// 逐渐拉近（分到多针去做） 有个变近的过程
    /// </summary>
    private void Partice1()
    {
        #region 2 逐渐拉近（分到多针去做） 有个变近的过程
        // 2 逐渐拉近（分到多针去做） 有个变近的过程
        //if (Input.GetMouseButton(1))
        //{
        //    if (maxValue >= minValue)
        //    {
        //        camera.fieldOfView = maxValue--;
        //    }
        //}
        //else
        //{
        //    maxValue = camera.fieldOfView = 60;
        //}

        #endregion

        #region 过度的版本  不是很好  最原始的方法 
        // 过度的版本  不是很好  最原始的方法
        //if (Input.GetMouseButtonDown(1))
        //{
        //    isFar = !isFar;
        //}
        //if (isFar)
        //{
        //    if (camera.fieldOfView < 60)
        //        camera.fieldOfView += 2;

        //}
        //else
        //{
        //    if (camera.fieldOfView > 20)
        //    {
        //        camera.fieldOfView -= 2;
        //    }
        //}
        #endregion

        if (Input.GetMouseButtonDown(1))
        {
            isFar = !isFar;
        }
        if (isFar)
        {
            if (camera.fieldOfView < 60)    // Mathf.Lerp 越到跟前越慢  
                camera.fieldOfView = Mathf.Lerp(camera.fieldOfView, 60, 0.1f);
            //  返回 起点 到 终点的 十分之一   由快到慢 无线接近终点(但不能等于终点) 叫做近似存储
            // 所以 要判断  camera.fieldOfView - 60 取绝对值  整数  如果小于  说明接近
            if (Mathf.Abs(camera.fieldOfView - 60) < 0.1f)
            {
                camera.fieldOfView = 60;
            }
        }
        else
        {
            if (camera.fieldOfView > 20)
            {
                camera.fieldOfView = Mathf.Lerp(camera.fieldOfView, 20, 0.1f);
                if (Mathf.Abs(camera.fieldOfView - 20) < 0.1f)
                {
                    camera.fieldOfView = 20;
                }
            }
        }
    }

    /// <summary>
    /// 缩放等级 
    /// </summary>
    public float[] levels;
    private int index;
    /// <summary>
    /// 缩放等级经常变换  
    /// </summary>
    private void Partice2()
    {
        if (Input.GetMouseButtonDown(1))
        {

            /// 方案一  垃圾
            //if (index < levels.Length - 1)
            //    index++;
            //else
            //    index = 0;

            /// 方案二  还可以
            //index = index < levels.Length - 1 ? index + 1 : 0;

            /// 方案三  精简 取余  第一次 （0+1） %3 = 1  | 第二次 （1+1） % 3=2   | 第三次（2+1） %3 = 0
            index = (index + 1) % levels.Length;

        }

        camera.fieldOfView = Mathf.Lerp(camera.fieldOfView, levels[index], 0.1f);
        if (Mathf.Abs(camera.fieldOfView - levels[index]) < 0.1f)
        {
            camera.fieldOfView = levels[index];
        }
    }
    /// <summary>
    /// 获取键盘输入
    /// </summary>
    private void GetKeyInput()
    {
        // 获取 按键A 输入 每帧 都返回 true 松开 返回 false
        //IsDown = Input.GetKey(KeyCode.A);

        // 当键盘 按下时 第一帧 返回true  之后变为 false
        //IsDown = Input.GetKeyDown(KeyCode.A);

        // 当键盘 按键 A 按下 在松开时  返回 true
        //IsDown = Input.GetKeyUp(KeyCode.A);
        print(IsDown);

        // 检测 按下 C 键 同时 在 按下 D 键
        if (Input.GetKey(KeyCode.C) && Input.GetKeyDown(KeyCode.D))
        {
            print("开挂模式已启动");
        }

    }

    /// <summary>
    /// 获取 鼠标输入
    /// </summary>
    private void GetMouseInput()
    {
        // 0 左键  1 右键  2 中键
        // 按下 的每帧 都返回 true
        //IsDown = Input.GetMouseButton(0);

        // 在 按下的第一针返回 true 松开 变回 false
        //IsDown = Input.GetMouseButtonDown(0);

        /// 当鼠标 按下 在松开时 返回 true
        IsDown = Input.GetMouseButtonUp(0);
        print(IsDown);
    }

    private void Partice3()
    {
        // 计算物体右前方 30 度， 10m 远的坐标
        float c = 10;
        float jiao = 30;
        float b =Mathf.Cos(jiao * c) ;
        print(b);
    }
}
