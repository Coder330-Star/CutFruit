using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class UIStart : MonoBehaviour {
    

    //开始按钮
    private Button btnPlay;

    //声音按钮
    private Button butSound;

    //背景音乐播放器
    public AudioSource audioSourceBG;

    //声音图片
    public Sprite[] SoundSprites;

    //声音图片
    private Image imgSound;

    //更多模式按钮
    private Button btnMore;

	
	void Start () {
        getComponents();
       btnPlay.onClick.AddListener(onPlayClickFirst);
       butSound.onClick.AddListener(onSoundClick);
       btnMore.onClick.AddListener(onPlayClickSecond);
	}
   
    void onDestory()
    {
        btnPlay.onClick.RemoveListener(onPlayClickFirst);
        butSound.onClick.RemoveListener(onSoundClick);
        btnMore.onClick.RemoveListener(onPlayClickSecond);
    }
        
    //寻找组件
    public void getComponents() 
    {
        btnPlay = transform.Find("btnPlay").GetComponent<Button>();
        butSound = transform.Find("butSound").GetComponent<Button>();
        audioSourceBG = transform.Find("butSound").GetComponent<AudioSource>();
        imgSound = transform.Find("butSound").GetComponent<Image>();
        btnMore = transform.Find("btnMore").GetComponent<Button>();
    }

	// 当开始按钮按下的点击事件
    void onPlayClickFirst() 
    {
        SceneManager.LoadScene("Play",LoadSceneMode.Single);
    }
    void onPlayClickSecond() 
    {
        SceneManager.LoadScene("ModeSelect", LoadSceneMode.Single);
    }

    //当声音按钮点击时调用
    void onSoundClick() 
    {
          if(audioSourceBG.isPlaying)
          {
            //正在播放
              audioSourceBG.Pause();
              imgSound.sprite = SoundSprites[1];
          }else
          {
              //停止播放
              audioSourceBG.Play();
              imgSound.sprite = SoundSprites[0];
          }
    }
}
