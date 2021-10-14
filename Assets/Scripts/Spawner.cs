using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour {



    //用来产生水果和炸弹
    public GameObject[] Fruits;
    public GameObject Bomb;

    public AudioSource AudioSource;

    float spawnTime = 2f;  //产生时间
    bool isPlaying = true;

    void Update() 
    {
        if (!isPlaying) {
            return;
        } 
            spawnTime -=Time.deltaTime;
            if (0 > spawnTime) 
            {
                //多个水果出现
                int fruitCout = Random.Range(1, 4);
                for (int i = 0; i < fruitCout;i++ )
                    onSpawn(true);
                spawnTime = 2f;

                //控制炸弹的出现
                int bombNum = Random.Range(0, 100);
                if (bombNum > 70)
                {
                    onSpawn(false);
                } 
             }      
    }
    //临时存储当前水果的z坐标
    private int tempz = 0;

    public void onSpawn(bool isFruit) 
    {
        //播放音乐
        this.AudioSource.Play();

        //定义坐标范围
        float x = Random.Range(-7.4f, 7.4f);
        float y = transform.position.y;
        float z = tempz;

        //使水果不在一个平面上
        tempz -= 2;
        if (tempz < -12)
            tempz = 0;

        //实例化水果
        int fruitIndex = Random.Range(0, Fruits.Length);
        GameObject go ;
        if (isFruit)
            go= Instantiate<GameObject>(Fruits[fruitIndex],new Vector3(x,y,z),Random.rotation);
        else
            go = Instantiate<GameObject>(Bomb, new Vector3(x, y, z), Random.rotation);
        
        //定义速度
        Vector3 velocity = new Vector3(-x * Random.Range(0.2f, 0.8f), -Physics.gravity.y * Random.Range(1.0f, 1.4f), 0);
        Rigidbody rigidbody = go.GetComponent<Rigidbody>();
        rigidbody.velocity = velocity;    
    }

    //有物体碰撞的时候调用
    private void OnCollisionEnter(Collision other) {
        Destroy(other.gameObject);
    }
}
