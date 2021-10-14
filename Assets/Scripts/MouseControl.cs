using System.Collections;
using System.Collections.Generic;
using UnityEngine;

   //实现切水果的功能
       // 1 实现刀痕效果
       // 2 实现切水果

public class MouseControl : MonoBehaviour {

    /// <summary>
    /// 直线渲染器
    /// </summary>
    [SerializeField]
    private LineRenderer lineRenderer;

  
    //获取LineRenderer组件的另一种方法【
    //public LineRenderer lineRenderer;
    //void Start() {
    //    getComponents();
    //}
    //private void getComponents() 
    //{
    //    lineRenderer = transform.Find("lineRenderer").GetComponent<LineRenderer>();
    //}】

    [SerializeField]
    private AudioSource AudioSource;

    /// <summary>
    /// 鼠标是否第一次按下
    /// </summary>
    private bool firstMouseDown = false;

    /// <summary>
    /// 是否鼠标一直按下
    /// </summary>
    private bool mouseDown = false;

    void Update() 
    {
        if (Input.GetMouseButtonDown(0)) {
            firstMouseDown = true;
            mouseDown = true;
            this.AudioSource.Play();
        } if (Input.GetMouseButtonUp(0)) {
            mouseDown = false;
        }
        OnDrawLine();
        firstMouseDown = false;      
    }

    /// <summary>
    /// 保存所有坐标
    /// </summary>
    private Vector3[] positions = new Vector3[10];

    /// <summary>
    /// 当前保存的坐标的数量
    /// </summary>
    private int posCount = 0;

    /// <summary>
    /// 代表这一帧的鼠标的位置，就是头的坐标
    /// </summary>
    private Vector3 head;

    /// <summary>
    /// 代表这一帧的鼠标位置，
    /// </summary>
    private Vector3 last;

    /// <summary>
    /// 控制画线
    /// </summary>
    private void OnDrawLine() {
       
        if (firstMouseDown) 
        {
            //先把计数器设为0
            posCount = 0;
            head = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            last = head;                          
        }
        if (mouseDown) 
        {
            head = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            if (Vector3.Distance(head, last) > 0.01f) {   
                //如果距离较远，则保存到数组里面
                savePosition(head);
                posCount++;
                //发射一条射线
                onRayCast(head);
            }
            last = head; 
        }
        else
        {
            this.positions = new Vector3[10];
        }
        changePositions(positions);      
    }
    /// <summary>
    /// 发射射线
    /// </summary>
    /// <param name="pos"></param>
    private void onRayCast(Vector3 Worldpos) 
    {
        Vector3 screenpos = Camera.main.WorldToScreenPoint(Worldpos);
        Ray ray = Camera.main.ScreenPointToRay(screenpos);
        //检测到所有物体
        RaycastHit[] hits = Physics.RaycastAll(ray);
        for (int i = 0; i < hits.Length;i++ )
        {
            
            hits[i].collider.gameObject.SendMessage("OnCut", SendMessageOptions.DontRequireReceiver);
            //Debug.Log(hits[i].collider.gameObject.name);
        }
    }


    /// <summary>
    /// 保存坐标点
    /// </summary>
    private void savePosition(Vector3 pos) 
    {   
        pos.z = 0;
        if (posCount <= 9) {
            for (int i = posCount; i < 10; i++) 
            {
                positions[i] = pos;           
            }
        }
        else
        {
            for (int i = 0; i < 9; i++)
            {
                positions[i] = positions[i + 1];
                positions[9] = pos;
            }
        }     
    }
    /// <summary>
    /// 修改直线渲染器的坐标
    /// </summary>
    /// <param name="positions"></param>
    private void changePositions(Vector3[] positions) 
    {
        lineRenderer.SetPositions(positions);
    }	
}
