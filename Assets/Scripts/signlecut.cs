using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class signlecut : MonoBehaviour {

    public ToggleGroup toggleGroup;    
    public  LineRenderer lineRenderer;
    public  AudioSource AudioSource;
    public  bool firstMouseDown = false;
    public  bool mouseDown = false;

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            firstMouseDown = true;
            mouseDown = true;
            this.AudioSource.Play();
        } if (Input.GetMouseButtonUp(0))
        {
            mouseDown = false;
        }
        OnDrawLine();
        firstMouseDown = false;
    }
    private Vector3[] positions = new Vector3[10];
    private int posCount = 0;
    private Vector3 head;
    private Vector3 last;
    private void OnDrawLine()
    {
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
            if (Vector3.Distance(head, last) > 0.01f)
            {
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


    private void savePosition(Vector3 pos)
    {
        pos.z = 0;
        if (posCount <= 9)
        {
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

    private void changePositions(Vector3[] positions)
    {
        lineRenderer.SetPositions(positions);
    }

    public void onRayCast(Vector3 Worldpos)
    {
        IEnumerable<Toggle> tog = toggleGroup.ActiveToggles();
        foreach (var v in tog)
        {
            Vector3 screenpos = Camera.main.WorldToScreenPoint(Worldpos);
            Ray ray = Camera.main.ScreenPointToRay(screenpos);

            //检测到所有物体
            RaycastHit[] hits = Physics.RaycastAll(ray);
            if (v.isOn && v.name == "apple")
            {
                               
                for (int i = 0; i < hits.Length; i++)
                {

                    if (hits[i].collider.gameObject.tag == "Apple")
                    {
                        hits[i].collider.gameObject.SendMessage("OnCut", SendMessageOptions.DontRequireReceiver);
                    }
                    else
                    {
                        SceneManager.LoadScene(2);
                    }
                }
            }
            else if (v.isOn && v.name == "lemon")
            {

                for (int i = 0; i < hits.Length; i++)
                {
                    if (hits[i].collider.gameObject.tag == "Lemon")
                    {
                        hits[i].collider.gameObject.SendMessage("OnCut", SendMessageOptions.DontRequireReceiver);
                    }
                    else
                    {
                        SceneManager.LoadScene(2);
                    }
                }
            }
            else if (v.isOn && v.name == "watermelon")
            {
             
                for (int i = 0; i < hits.Length; i++)
                {                  
                    if (hits[i].collider.gameObject.tag == "Watermelon")
                    {
                        hits[i].collider.gameObject.SendMessage("OnCut", SendMessageOptions.DontRequireReceiver);
                    }
                    else
                    {
                        SceneManager.LoadScene(2);
                    }
                }
            }
            
        }
        
    }
     
}
