using UnityEngine;

public class SoundManager : MonoBehaviour
{
    public static SoundManager instance;

    [Header("Audio Clips")]
    public AudioClip aidKitSound;
    public AudioClip keyPickUpSound;
    public AudioClip mainTheme;

    private AudioSource source;

    private void Awake()
    {
        instance = this;
    }

    private void Start()
    {
        source = GetComponent<AudioSource>();
        
    }

    public void PlayAidKitSound()
    {
        source.PlayOneShot(aidKitSound);
    }

    public void PlayKeyPickUpSound()
    {
        source.PlayOneShot(keyPickUpSound);
    }

}
