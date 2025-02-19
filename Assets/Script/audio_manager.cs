using UnityEngine;

public class audio_manager : MonoBehaviour
{
    public static audio_manager instance;

    [SerializeField]
    private AudioSource effect;

    [SerializeField]
    private AudioClip jumpClip;

    [SerializeField]
    private AudioClip tabClip;

    [SerializeField]
    private AudioClip hurtClip;

    [SerializeField]
    private AudioClip crackEgg;

    private bool hasPlayAudio = false;



    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }


    }
    public void setHasPlayAudio(bool value)

    {
        hasPlayAudio = true;
    }
    public bool HasPlayAudio()
    {
        return hasPlayAudio;
    }
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        effect.Stop();
        hasPlayAudio = true;




    }

    public void PlayJumpClip()
    {
        effect.PlayOneShot(jumpClip);
    }

    public void PlayTabClip()
    {
        effect.PlayOneShot(tabClip);
    }

    public void PlayhurtClip()
    {
        effect.PlayOneShot(hurtClip);
    }

    public void PlayCrackEgg()
    {
        effect.PlayOneShot(crackEgg);
    }
}
