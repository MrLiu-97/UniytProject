using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// 三角函数
/// </summary>
public class Trigonometric : MonoBehaviour
{
    private void Update()
    {
        Partice3();
        //Demo01();
    }
    private void Demo01()
    {
        // 角度 ==》 弧度  公式: 弧度 = 角度数 * PI / 180
        // 60 角度 等于 多少 弧度？
        float d1 = 60;
        float r1 = d1 * Mathf.PI / 180;
        // api
        float r2 = d1 * Mathf.Deg2Rad;
        print(r1 + "___" + r2);
        // 弧度 ==》 角度  公式: 角度 = 弧度数 * 180 / PI
        float h1 = 3;

        float j1 = h1 * 180 / Mathf.PI;
        // api
        float j2 = h1 * Mathf.Rad2Deg;

        print(j1 + ":::::" + j2);
    }


    private void Demo02()
    {
        // 已知：角度 x  边长 b  正切：tan x = a/b;
        // 求： 边长 a
        // 公式： a=tan x * b;
        float x = 50, b = 20;
        float a = Mathf.Tan(x * Mathf.Deg2Rad) * b;

        float a1 = (x * Mathf.PI / 180) * b;

        // 已知：边长 a  边长 b
        // 求：角度 angle
        // 公式：反正切（arctan a / b = x）==》  x =  arctan a / b
        //Mathf.Atan(a / b)  返回的是弧度
        float angle = Mathf.Atan(a / b) * Mathf.Rad2Deg;

    }
    private void Partice3()
    {
        // 计算物体右前方 30 度， 10m 远的坐标
        Vector3 worldPint = transform.TransformPoint(0, 0, 10);
        float c = 10;
        float jiao = 30;
        // 余弦
        float b = Mathf.Cos(jiao * Mathf.Deg2Rad) * worldPint.z;
        // 正弦
        float b1 = Mathf.Sin(jiao * Mathf.Deg2Rad) * worldPint.z;
        print("坐标：" + b + "," + b1);

        // 计算物体 左前方 60 度，20m远的坐标
        //worldPint = transform.TransformPoint(20, 0, 0);
        jiao = 60;
        b = Mathf.Cos(jiao * Mathf.Deg2Rad) * 20;
        b1 = Mathf.Sin(jiao * Mathf.Deg2Rad) * 20;
        worldPint = transform.TransformPoint(b, 0, b1);
        Debug.DrawLine(this.transform.position, worldPint);


    }
}
