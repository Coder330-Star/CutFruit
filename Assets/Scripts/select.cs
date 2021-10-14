using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class select : MonoBehaviour {

  
    public Button ButtonOk;

    public Button ButtonOK;

	// Use this for initialization
	void Start () {
        ButtonOk.onClick.AddListener(OnOK);
        ButtonOK.onClick.AddListener(OnOK2);
        OnCancel();
	}
    public void OnOK()
    {
          SceneManager.LoadScene("start");
    }
    public void OnCancel() 
    {
        GameObject.Find("UI").transform.Find("Panel").gameObject.SetActive(false);
    }
    public void OnShow()
    {
        GameObject.Find("UI").transform.Find("Panel").gameObject .SetActive(true);
    }
    public void OnOK2() 
    {
        SceneManager.LoadScene(3);
    }
}
