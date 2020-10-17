using UnityEngine;

public class TestAudio : MonoBehaviour
{
    public AudioClip Audio1;
    public AudioClip Audio2;
    public AudioClip Audio3;
    public AudioClip Audio4;
    public AudioClip Audio5;
    public AudioClip Audio6;
    public AudioClip Audio7;
    public AudioClip Audio8;
    public AudioClip Audio9;
    public AudioClip Audio10;
    public AudioClip Audio11;
    public AudioClip Audio12;
    public AudioClip Audio13;
    public AudioClip Audio14;
    public AudioClip Audio15;
    public AudioClip Audio16;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.A))
            AudioManager.Instance.Play(Audio1);
        if (Input.GetKeyDown(KeyCode.S))
            AudioManager.Instance.Play(Audio2);
        if (Input.GetKeyDown(KeyCode.D))
            AudioManager.Instance.Play(Audio3);
        if (Input.GetKeyDown(KeyCode.F))
            AudioManager.Instance.Play(Audio4);
        if (Input.GetKeyDown(KeyCode.G))
            AudioManager.Instance.Play(Audio5);
        if (Input.GetKeyDown(KeyCode.H))
            AudioManager.Instance.Play(Audio6);
        if (Input.GetKeyDown(KeyCode.J))
            AudioManager.Instance.Play(Audio7);
        if (Input.GetKeyDown(KeyCode.K))
            AudioManager.Instance.Play(Audio8);
        if (Input.GetKeyDown(KeyCode.L))
            AudioManager.Instance.Play(Audio9);
        if (Input.GetKeyDown(KeyCode.Z))
            AudioManager.Instance.Play(Audio10);
        if (Input.GetKeyDown(KeyCode.X))
            AudioManager.Instance.Play(Audio11);
        if (Input.GetKeyDown(KeyCode.C))
            AudioManager.Instance.Play(Audio12);
        if (Input.GetKeyDown(KeyCode.V))
            AudioManager.Instance.Play(Audio13);
        if (Input.GetKeyDown(KeyCode.B))
            AudioManager.Instance.Play(Audio14);
        if (Input.GetKeyDown(KeyCode.N))
            AudioManager.Instance.Play(Audio15);
        if (Input.GetKeyDown(KeyCode.M))
            AudioManager.Instance.Play(Audio16);
    }
}