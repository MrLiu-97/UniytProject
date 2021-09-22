using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
///
/// </summary>
public class DirectRotateDemo : MonoBehaviour
{
    private float rotate;
    private void Update()
    {
        float leftRight = Input.GetAxisRaw("Horizontal");
        float upDown = Input.GetAxisRaw("Vertical");
        if (leftRight != 0 || upDown != 0)
        {
            MoveRotateion(leftRight, upDown);
        }

        //Demo01();
    }
    private Camera GetCamera;
    private void Start()
    {
        GameObject camera = GameObject.FindGameObjectWithTag("MainCamera");//Camera.main;
        GetCamera = camera.GetComponent<Camera>();
    }
    /// <summary>
    /// 自己做的
    /// </summary>
    private void Demo01()
    {
        float leftRight = Input.GetAxisRaw("Horizontal");
        float upDown = Input.GetAxisRaw("Vertical");
        print(upDown);
        if (leftRight != 0)
        {
            rotate = 90 * -leftRight;
        }
        if (upDown != 0)
        {
            rotate = upDown < 0 ? 0 : upDown * 180;
        }
        Quaternion dir = Quaternion.AngleAxis(rotate, Vector3.up);
        this.transform.rotation = Quaternion.Lerp(this.transform.rotation, dir, 0.1f);
        this.transform.Translate(-leftRight * Time.deltaTime, 0, -upDown * Time.deltaTime, Space.World);
    }

    private float moveSpeed = 1;
    public Vector3 screenPoint;
    private void MoveRotateion(float leftRight, float upDown)
    {
        leftRight *= moveSpeed * Time.deltaTime;
        upDown *= moveSpeed * Time.deltaTime;
        Quaternion dir = Quaternion.LookRotation(new Vector3(leftRight, 0, upDown));

        this.transform.rotation = Quaternion.Lerp(this.transform.rotation, dir, 0.1f);
        // 世界坐标转换屏幕坐标
        Vector3 WorldToScreen = screenPoint = Camera.main.WorldToScreenPoint(this.transform.position);
        // 如果超过屏幕，停止运动
        if ((WorldToScreen.x <= 0 && leftRight < 0) || (WorldToScreen.x >= Screen.width && leftRight > 0))
        {
            //leftRight = 0;

        }

        if (WorldToScreen.x > Screen.width)  // 右出左进   
        {
            WorldToScreen.x = 0;
        }
        else if (WorldToScreen.x < 0)       // 左出右进
        {
            WorldToScreen.x = Screen.width;
        }
        else if (WorldToScreen.y > Screen.height)
        {
            WorldToScreen.y = 0;
        }
        else if (WorldToScreen.y < 0)
        {
            WorldToScreen.y = Screen.height;
        }
        // 将屏幕坐标转换为 世界坐标
        screenPoint = Camera.main.ScreenToWorldPoint(WorldToScreen);

        this.transform.position = screenPoint;
        this.transform.Translate(leftRight, 0, upDown, Space.World);



        //if (WorldToScreen.x > 0 && WorldToScreen.x <= Screen.width)
        //{
        //    this.transform.Translate(leftRight, 0, upDown,Space.World);
        //}

        int w = Screen.width;
        int h = Screen.height;
        print(w + "---" + h);
        //this.transform.Translate(0, 0, Time.deltaTime * moveSpeed);
    }
}
