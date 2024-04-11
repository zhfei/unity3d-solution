using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

public class TestTween : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //Transform组件缓动动画
        if(Input.GetKeyDown(KeyCode.D))
        {

            Tweener tweener = transform.DOMoveX(5, 1);
            //动画曲线

            //In指的是一种由慢到快的方式，
            //Out则指的是由快到慢。
            //Sine（正弦曲线）指的是比较平滑的过渡；
            //而Quad则指的是会有更明显的快慢变化；比Quad速度变化更剧烈的，还有Cubic、Quart、Quint等。
            //Expo指数曲线
            //Elastic弹性的曲线
            //Back先后退再前进的曲线
            //Bounce（弹跳曲线）
            tweener.SetEase(Ease.OutSine);

            //动画的控制
            //transform.DOPlay();
            //transform.DOPause();
            //transform.DORestart();
            //transform.DORewind();//倒播，直接退回起始点
            //transform.DOKill();//删除动画
            //transform.DOGoto(1.5f,true); //跳转到1.5s的位置立刻播放
            //transform.DOPlayBackwards();//倒着播
            //transform.DOPlayForward();//正着播

            //动画回调函数
            transform.DOMove(new Vector3(3, 3, 0), 2).OnComplete(()=> {
                Debug.Log("播放完成");
            });

            //无限震动
            Tweener tweener1 = transform.DOShakePosition(1, new Vector3(3, 0, 0));
            tweener1.SetLoops(-1);
            tweener1.OnComplete(()=> { Debug.Log("震动完成"); });
        }

        if(Input.GetKeyDown(KeyCode.A))
        {
            Tweener tweener = transform.DOMoveX(0,1);

            //动画队列
            Sequence seq = DOTween.Sequence();
            //1.添加动画到序列
            seq.Append(transform.DOMove(new Vector3(3,4,5), 2));
            //2.添加间隔
            seq.AppendInterval(1);
            seq.Append(transform.DOMove(new Vector3(0,0,0),1));
            //3.按时间插入动画
            //表示在动画执行的第0秒执行下面的动画， 插入的时间动画会和原队列的动画在同一时间一起播放。表示同时部分多个动画
            //除了可以使用队列的方式实现多个动画同时播放，也可以使用动画连续叠加的方式实现：
            //Tweener tweener1 = transform.DOMoveX(10,1);
            //tweener1.SetEase(Ease.OutQuad);
            //transform.DOMoveY(10,1);
            seq.Insert(0, transform.DORotate(new Vector3(0,90,0),1));
             

        }


        //Camera组件缓动动画
        if (Input.GetKeyDown(KeyCode.K))
        {
            //摄像机震动
            Tweener tweener = Camera.main.DOShakePosition(1);
        }

        //Material组件缓动动画
        if (Input.GetKeyDown(KeyCode.L))
        {
            Material material = GetComponent<MeshRenderer>().material;
            Tweener tweener = material.DOColor(Color.red,3);
        }

        //Text控件缓动动画
        if (Input.GetKeyDown(KeyCode.J))
        {
            Text text = GetComponent<Text>();
            Tween tween = text.DOColor(Color.green,3);
            tween.OnComplete(()=> { Debug.Log("Text动画执行完成"); });
        }
    }
}
