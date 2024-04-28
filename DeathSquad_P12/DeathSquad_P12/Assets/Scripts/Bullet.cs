using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{

    public static float duration = 0.5f;
    public Vector3 dir;

    Rigidbody rigid;
    float speed = 120;
    float lifeTime = 0.5f;
    string targetTag;

    public void Init(string tag, Vector3 _dir, float time = 0.5f, float _speed = 120)
    {
        targetTag = tag;
        dir = _dir;
        lifeTime = time;
        speed = _speed;
    }

    // Start is called before the first frame update
    void Start()
    {
        rigid = GetComponent<Rigidbody>();
        StartCoroutine(Timeup());
        transform.LookAt(transform.position+dir);
        rigid.velocity = speed * dir.normalized;
    }

    IEnumerator Timeup()
    {
        yield return new WaitForSeconds(lifeTime);
        if(gameObject)
        {
            Destroy(gameObject);
        }
    }

    //子弹脚本：公共脚本，可以是角色或敌人发出的。
    private void OnTriggerEnter(Collider other)
    {
        var go = other.gameObject;
        if(go.tag == targetTag) //忽略开枪打中自己的情况
        {
            if(targetTag == "Enemy")
            {
                EnemyCharacter enemy = go.GetComponent<EnemyCharacter>();
                enemy.BeHit(1);
            }
            else if(targetTag == "Player")
            {
                PlayerCharacter player = go.GetComponent<PlayerCharacter>();
                player.BeHit(1);
            }
        }
        Destroy(gameObject);
    }

}
