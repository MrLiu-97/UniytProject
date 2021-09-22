using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
///
/// </summary>
public class ComponentDemo : MonoBehaviour
{
    private void OnGUI()
    {
        // C# 类想要 改变 游戏场景中物体的位置  就要找到 TransForm 引用
        // TransForm 是对类的引用
        if (GUILayout.Button("按钮"))
        {
            this.tag = "liu";
            // this 指 ComponentDemo 类
            // transform TransForm组件的引用
            // position 因为类型是 transform 的  它里面有 position 属性
            this.transform.position = new Vector3(0, 0, 11);

            //this.GetComponent<MeshRenderer>().material.color = Color.red;
            print("ok");
        }
        if (GUILayout.Button("GetComponent"))
        {
            this.GetComponent<MeshRenderer>().material.color = Color.red;


            var arr = this.GetComponents<Component>();
            foreach (var item in arr)
            {
                print(item.GetType());
            }
            print("ok");
        }
        if (GUILayout.Button("GetComponentsInChildren"))
        {
            var itemComponent = this.GetComponentsInChildren<MeshRenderer>();

            // GetComponentsInChildren 获取多个 获取后代物体的指定类型组件（ 是从自身开始查找）自身及后面的子物体都会红  
            // GetComponentInChildren  获取一个  获取后代物体的指定类型组件（ 是从自身开始查找） 所以自身会红 再没了
            foreach (var item in itemComponent)
            {
                item.material.color = Color.red;
                //print();
                bool res = item.CompareTag("player");
            }
            //GetComponentsInParent 获取父物体的指定类型组件
            var itemComponentParent = this.GetComponentsInParent<MeshRenderer>();

            print("ok");
        }

    }

}
