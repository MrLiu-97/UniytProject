using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
///
/// </summary>
public class TransformDemo : MonoBehaviour
{
    public Transform tf;
    private void OnGUI()
    {
        
        if (GUILayout.Button("foreach-Transform"))
        {
            foreach (Transform child in this.transform)
            {
                //child 获取子物体的变换组件 不能获取子物体里面的变换组件
                print(child.name); // 结果： Cube(1) Cube(2)

                // 物体相对于世界坐标系的原点位置
                //this.transform.position

                // 物体相对于父物体轴心点的位置 
                // 如果 父物体 是 0 0 5 子物体是 0 0 10 那么 子物体就相对于 世界坐标是 0 0 15
                //this.transform.localPosition
                //child.transform.localScale = new Vector3(1, 2, 3);
                //相对于 父物体缩放的比例 如果 父物体的 缩放比例为 1 2 1 子物体也设置为 1 2 1    那么子物体就是父物体的两倍 
                //this.transform.localScale = new Vector3(1, 2, 3);

                // 物体与模型缩放比例（自身缩放比例额 * 父物体缩放比例）
                // 比如 ： 父物体 localScale 为 3 当前子物体 localScale 为 2; lossyScale 则为 6
                //this.transform.lossyScale

            }
        }
        if (GUILayout.Button("Translate"))
        {
            // 向自身坐标系 Z轴 移动 1 米
            //this.transform.Translate(0, 0, 1);
            // 向世界坐标系 Z轴 移动 1 米
            //this.transform.Translate(0, 0, 1, Space.World);

            // 沿自身坐标系 Z轴 旋转 10度
            this.transform.Rotate(0, 0, 1);
            // 沿世界坐标系 Y轴 旋转 10度
            this.transform.Rotate(0, 10, 0, Space.World);
        }
        if (GUILayout.Button("setParent"))
        {
            // 设置父物体
            // 当前物体的位置 视为 Position（ 世界坐标）
            //this.transform.SetParent(tf); 默认为 true

            // 当前物体的位置 视为 localPosition （自身坐标）
            this.transform.SetParent(tf, false);

            // 解除父子关系
            this.transform.DetachChildren();
        }
        if (GUILayout.Button("root"))
        {
            // 获取当前物体 跟物体的变换组件
            Transform rootTransform = this.transform.root;

            // 获取 当前物体的 父物体的变换组件 就是当前物体的上一层组件
            Transform parentTransform = this.transform.parent;
        }
        /// 围绕旋转
        if (GUILayout.RepeatButton("RotateAround"))
        {

            //public void RotateAround(Vector3 point, Vector3 axis, float angle);
            // Vector3 point：点 ； Vector3 axis:轴 ； float angle：角度
            // Vector3.zero, 世界的零点  0 0 0
            // Vector3.up 世界的 Y轴   Vector3.forward 向 Z轴旋转 
            // 1 转 1 度
            this.transform.RotateAround(Vector3.zero, Vector3.forward, 1);
        }

        if (GUILayout.Button("Find"))
        {
            // 根据名称获取子物体
            //Transform childTF = this.transform.Find("子物体名称");

            int count = this.transform.childCount;
            print(count);
            // 根据索引 获取子物体
            for (int i = 0; i < count; i++)
            {
                Transform tfs = this.transform.GetChild(i);
                print(tfs.name);

            }
        }


        // 练习  在层级未知情况下 查找子物体
        // 递归

    }

}
