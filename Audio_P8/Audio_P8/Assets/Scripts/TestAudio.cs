using System.Collections;
using System.Collections.Generic;
using UnityEngine;


/// <summary>
///
/// </summary>

public class TestAudio : MonoBehaviour
{
    //从外部指定声音片段
    public List<AudioClip> audioClips;
    //音源组件
    AudioSource audioSource;

    // Start is called before the first frame update
    void Start()
    {
        GameObject go = GameObject.Find("Audio Source");
        audioSource = go.GetComponent<AudioSource>();

        //重置状态
        audioSource.Stop();
        audioSource.loop = false;
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.A))
        {
            audioSource.clip = audioClips[0];
            audioSource.Play();
        }
        if(Input.GetKeyDown(KeyCode.B))
        {
            audioSource.clip = audioClips[1];
            audioSource.Play();
        }

        if(Input.GetKeyDown(KeyCode.Space))
        {
            if(audioSource.isPlaying)
            {
                audioSource.Pause();
            }
            else
            {
                audioSource.Play();
            }
        }
    }
}
