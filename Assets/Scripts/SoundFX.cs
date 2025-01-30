using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundFX : MonoBehaviour {

    public AudioSource _paintSound;
    public static AudioSource paintSound;



    private void Start()
    {
        paintSound = _paintSound;
    }
}
