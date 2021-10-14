using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//物体控制脚本
public class ObjectControl : MonoBehaviour {

    /// <summary>
    /// 水果的一半
    /// </summary>
    public GameObject halfFruit;
    public GameObject Splash;
    public GameObject SplashFlat;

    private bool dead = false;
    public AudioClip ac;
    /// <summary>
    /// 被切割的时候调用
    /// </summary>
    public void OnCut() 
    {
        //防止被重复调用
        if (dead)
            return;

        if (gameObject.name.Contains( "Bomb"))
        {
            Instantiate<GameObject>(Splash, transform.position, Random.rotation);
            
            UIScore.Instance.Remove(20);
        }
        else 
        {
            //生成被切割的水果           
            for (int i = 0; i < 2; i++)
            {
                GameObject go = Instantiate<GameObject>(halfFruit, transform.position, Random.rotation);
                go.GetComponent<Rigidbody>().AddForce(Random.onUnitSphere * 5f, ForceMode.Impulse);               
            }            
            //产生特效
            Instantiate<GameObject>(Splash, transform.position, Quaternion.identity);
            Instantiate<GameObject>(SplashFlat, transform.position, Quaternion.identity);            
            //加分
            UIScore.Instance.Add(Random.Range(0,10));
            
        }
        AudioSource.PlayClipAtPoint(ac,transform.position);
        //销毁物体
        Destroy(gameObject);
        dead = true;
    }
}
