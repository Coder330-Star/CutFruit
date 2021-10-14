using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class UIScore : MonoBehaviour {
   
    /// <summary>
    /// 单例对象
    /// </summary>
    public static UIScore Instance = null;

    void Awake() {

        Instance = this;
    }

    [SerializeField]
    private Text txtScore;

    private int score = 0;

    /// <summary>
    /// 加分
    /// </summary>
    /// <param name="Score"></param>
        public void Add(int score)
    {          
        this.score += score;
        txtScore.text = this.score.ToString();
    }

    /// <summary>
    /// 扣分
    /// </summary>
        public void Remove(int score) 
        {
           this.score -= score;
            //分数小于0，游戏结束
            if(this.score<0)
            {
                SceneManager.LoadScene(2);
                return;
            }
            txtScore.text = this.score.ToString();        
        }

     
     public Slider selfSlider;

    //满血量
     public int  fullHP = 300;

    //实时血量
     public int tempHP;

    //设置时间间隔
     public float time = 1f;

    //每次掉血的值
     public int diaoHP = 10;

    //计时器
     public float timer;
     public GameObject Panel;
     public Button ButtonOK;

     void Start() 
     {
         //设置最大值最小值
         selfSlider.maxValue = fullHP;
         selfSlider.minValue = 0;

         timer = 0;

         tempHP = fullHP;

         ButtonOK.onClick.AddListener(OnButtonOK);
     }
     void Update() 
     {
         if (tempHP > 0)
         {
             timer += Time.deltaTime;
             if (timer >= time)
             {
                 timer = 0;
                 tempHP -= diaoHP;
             }
             if (tempHP <= 0)
             {
                 tempHP = 0;
                 //游戏结束
                 selfSlider.value = 0;
                 OnShow();
                 //GameObject.Find("UI").transform.Find("Panel").gameObject.SetActive(true);
             }
             else
             {
                 selfSlider.value = tempHP;
             }
         }       
     }
    public void OnButtonOK() 
    {
        SceneManager.LoadScene(3);
    }
    public void OnShow()
    {
        //Debug.Log("111");
        GameObject.Find("Canvas").transform.Find("Panel").gameObject.SetActive(true);
        GameObject.Find("cut").gameObject.SetActive(false);
        Destroy(GameObject.Find("producefruit"));
    }
}
