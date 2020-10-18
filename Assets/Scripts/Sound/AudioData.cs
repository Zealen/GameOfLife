using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu]
public class AudioData : ScriptableObject
{
    public List<AudioClip> sounds = new List<AudioClip>();
    public float bpm;
}
