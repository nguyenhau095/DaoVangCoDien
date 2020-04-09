using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour
{
    [SerializeField]
    private AudioSource m_AudioSource;
    [SerializeField]
    private AudioClip m_audioClipTaget;
    [SerializeField]
    private AudioClip m_audioNextMap;
    [SerializeField]
    private AudioClip m_audioAddScore;
    [SerializeField]
    private AudioClip m_audioTime;
    [SerializeField]
    private AudioClip m_audioGoldBig;
    [SerializeField]
    private AudioClip m_audioGoldSmall;
    [SerializeField]
    private AudioClip m_audioStone;
    [SerializeField]
    private AudioClip m_audioExpod;
    [SerializeField]
    private AudioClip m_audioDiamond;

    [SerializeField]
    private AudioSource m_AudioSourceOldMan;
    [SerializeField]
    private AudioClip m_audioOldManThroww;
    [SerializeField]
    private AudioClip m_audioOldManPull;

    public static SoundManager Instansce { get; set; }
    private void Awake()
    {
        if (Instansce == null)
        {
            Instansce = this;
        }
    }
    public void _BackgroundTaget()
    {
        m_AudioSource.PlayOneShot(m_audioClipTaget);
    }
    public void _NextMap()
    {
        m_AudioSource.PlayOneShot(m_audioNextMap);
    }
    public void _AddScore()
    {
        m_AudioSource.PlayOneShot(m_audioAddScore);
    }
    public void _Time()
    {
        m_AudioSource.PlayOneShot(m_audioTime);
    }
    public void _GoldBig()
    {
        m_AudioSource.PlayOneShot(m_audioGoldBig);
    }
    public void _GoldSmall()
    {
        m_AudioSource.PlayOneShot(m_audioGoldSmall);
    }
    public void _Stone()
    {
        m_AudioSource.PlayOneShot(m_audioStone);
    }
    public void _Explod()
    {
        m_AudioSource.PlayOneShot(m_audioExpod);
    }
    public void _Diamond()
    {
        m_AudioSource.PlayOneShot(m_audioDiamond);
    }
    public void _ThrowAnchor()
    {
        m_AudioSourceOldMan.clip = m_audioOldManThroww;
        m_AudioSourceOldMan.Play();
        //m_AudioSourceOldMan.PlayOneShot(m_audioOldManThroww);
        m_AudioSourceOldMan.loop = true;
    }
    public void _PullAnchor()
    {
        m_AudioSourceOldMan.clip = m_audioOldManPull;
        m_AudioSourceOldMan.Play();
        //m_AudioSourceOldMan.PlayOneShot(m_audioOldManPull);
        m_AudioSourceOldMan.loop = true;
    }
}
