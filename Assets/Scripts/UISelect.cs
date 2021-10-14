using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class UISelect : MonoBehaviour {

    //单一模式
    private Button btnSignle;

    //计时模式
    private Button btnTime;

    //主菜单
    private Button mainmenue;

    //音乐按钮
    private Button btnSound;

    //音乐播放器
    public  AudioSource audiosource;

    //声音图片
    public Sprite[] selfSprite;
    private Image imgSound;

	// Use this for initialization
	void Start () {
        getComponent();
        btnSignle.onClick.AddListener(ModeFirst);       
        btnTime.onClick.AddListener(ModeThird);
        mainmenue.onClick.AddListener(playClick);
        btnSound.onClick.AddListener(onSoundClick);
	}

    //寻找组件
    public void getComponent() 
    {
        btnSignle = transform.Find("btnSignle").GetComponent<Button>();      
        btnTime = transform.Find("btnTime").GetComponent<Button>();    
        mainmenue = transform.Find("mainmenue").GetComponent<Button>();
        imgSound = transform.Find("btnSound").GetComponent<Image>();
        btnSound = transform.Find("btnSound").GetComponent<Button>();
    }
    //方法，单一模式按钮点击后，执行
    public void ModeFirst() 
    {
        SceneManager.LoadScene("Single", LoadSceneMode.Single);
    } 

    //方法，计时模式按钮点击后，执行
    public void ModeThird()
    {
        SceneManager.LoadScene("Time", LoadSceneMode.Single);
    }

    public void playClick() 
    {
        SceneManager.LoadScene("Start",LoadSceneMode.Single);
    }

    public void onSoundClick() 
    {
        if (audiosource.isPlaying)
        {
            audiosource.Pause();
            imgSound.sprite = selfSprite[1];
        }
        else 
        {
            audiosource.Play();
            imgSound.sprite = selfSprite[0];
        }
    }
}
