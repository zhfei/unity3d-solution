using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//音频管理器：所有音源Audio Source的创建，添加，音频文件的播放都是使用AudioManager音频管理器
public class AudioManager : MonoBehaviour
{
    //整个游戏中，总音频个数
    private int AUDIO_CHANNEL_NUM = 8;
    //音频频道结构体
    private struct CHANNEL
    {
        public AudioSource channel;
        public float keyOnTime;  //最近播放时间
    }
    private CHANNEL[] m_channels;


    // Start is called before the first frame update
    void Start()
    {
        m_channels = new CHANNEL[AUDIO_CHANNEL_NUM];
        for(int i = 0; i< AUDIO_CHANNEL_NUM; i++)
        {
            //给游戏对象动态添加音源组件，并在数组中进行保存
            m_channels[i].channel = gameObject.AddComponent<AudioSource>();
            m_channels[i].keyOnTime = 0;
        }
    }

    //在音频频道组中选择一个频道，播放一次音频
    //参数：音频片段，音量，左右声道，速度
    public int PlayOneShot(AudioClip audioClip, float volume, float pan, float pitch = 1.0f)
    {

        for(int i = 0; i< m_channels.Length; i++)
        {
            //手抖，0.03秒内重复点击，直接返回
            if(m_channels[i].channel.isPlaying &&
                m_channels[i].channel.clip == audioClip &&
                m_channels[i].keyOnTime >= Time.time - 0.03f)
            {
                return -1;
            }
        }

        int oldest = -1;
        float time = 1000000000.0f;
        for (int i = 0; i < m_channels.Length; i++)
        {
            if(m_channels[i].channel.loop == false &&
                m_channels[i].channel.isPlaying &&
                m_channels[i].keyOnTime < time)
            {
                oldest = i;
                time = m_channels[i].keyOnTime;
            }
            //播放成功
            if(!m_channels[i].channel.isPlaying)
            {
                m_channels[i].channel.clip = audioClip;
                m_channels[i].channel.volume = volume;
                m_channels[i].channel.panStereo = pan;
                m_channels[i].channel.loop = false;
                m_channels[i].channel.pitch = pitch;
                m_channels[i].channel.Play();
                m_channels[i].keyOnTime = Time.time;
                return i;
            }
        }

        //没有空闲频道，最早播放的退出，替换成最新的频道
        if (oldest > 0)
        {
            m_channels[oldest].channel.clip = audioClip;
            m_channels[oldest].channel.volume = volume;
            m_channels[oldest].channel.panStereo = pan;
            m_channels[oldest].channel.loop = false;
            m_channels[oldest].channel.pitch = pitch;
            m_channels[oldest].channel.Play();
            m_channels[oldest].keyOnTime = Time.time;
            return oldest;
        }
        return -1;
    }

    //使用音乐频道循环播放某段音乐：适用于上时间的背景音乐
    public int PlayLoop(AudioClip clip, float volume, float pan, float pitch = 1.0f)
    {

        for (int i = 0; i < m_channels.Length; i++)
        {
            if (!m_channels[i].channel.isPlaying)
            {
                m_channels[i].channel.clip = clip;
                m_channels[i].channel.volume = volume;
                m_channels[i].channel.panStereo = pan;
                m_channels[i].channel.loop = true;
                m_channels[i].channel.pitch = pitch;
                m_channels[i].channel.Play();
                m_channels[i].keyOnTime = Time.time;
                return i;
            }
        }
        return -1;
    }

    //停止所有音频频道的播放任务
    public void StopAll()
    {
        foreach(CHANNEL channel in m_channels)
        {
            channel.channel.Stop();
        }
    }

    //停止指定频道的音频
    public void Stop(int id)
    {
        m_channels[id].channel.Stop();
    }
}
