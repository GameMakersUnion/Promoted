using UnityEngine;
using System.Collections.Generic;


public class SoundManager : MonoBehaviour {
    public enum Sounds {
        GlassBreak,
        ComputerStart,
        Correct,
        ComputerError,
        ElevatorDing,
        ElevatorMusic,
        FireCrackle,
        FireWoosh,
        WashingMachine,
        LevelMusic,
        OfficeAmbience,
        Promotion,
        Woosh,
        Thud,
        TreadmillSound
    }

    public static Dictionary<Sounds, AudioClip> sounds = new Dictionary<Sounds, AudioClip>()
    {
        { Sounds.GlassBreak,       Resources.Load<AudioClip>("Sounds/Breaking Glass")},
        { Sounds.ComputerStart,    Resources.Load<AudioClip>("Sounds/Computer startup")},
        { Sounds.Correct,          Resources.Load<AudioClip>("Sounds/Correct Sound(bing)")},
        { Sounds.ComputerError,    Resources.Load<AudioClip>("Sounds/Critical error")},
        { Sounds.ElevatorDing,     Resources.Load<AudioClip>("Sounds/Elevator Ding")},
        { Sounds.ElevatorMusic,    Resources.Load<AudioClip>("Sounds/Elevator Music")},
        { Sounds.FireCrackle,      Resources.Load<AudioClip>("Sounds/Fire crackle")},
        { Sounds.FireWoosh,        Resources.Load<AudioClip>("Sounds/Fire woosh")},
        { Sounds.WashingMachine,   Resources.Load<AudioClip>("Sounds/Laundry macnine")},
        { Sounds.LevelMusic,       Resources.Load<AudioClip>("Sounds/Level Music")},
        { Sounds.OfficeAmbience,   Resources.Load<AudioClip>("Sounds/Office ambience loop")},
        { Sounds.Promotion,        Resources.Load<AudioClip>("Sounds/Promoted(level up)")},
        { Sounds.Woosh,            Resources.Load<AudioClip>("Sounds/Throw Woosh")},
        { Sounds.Thud,             Resources.Load<AudioClip>("Sounds/Thud")},
        { Sounds.TreadmillSound,   Resources.Load<AudioClip>("Sounds/Treadmill")},

        /*{ Colors.Black, new Color(0f, 0f, 0f) },*/
        /*{ Colors.Gray, new Color(0.5f, 0.5f, 0.5f) },*/
    };

    // Use this for initialization
    void Start () {
        AudioSource.PlayClipAtPoint(sounds[Sounds.LevelMusic], transform.position, 1.0f);

    }
	
	// Update is called once per frame
	void Update () {
	
	}

    public static void Play(Sounds sound, bool loop = false)
    {
        //Should attach to main camera
        if (sounds[Sounds.ComputerStart] != null) {
            AudioSource.PlayClipAtPoint(sounds[sound], transform.position, 1.0f);
        }
        
        
    }
}
