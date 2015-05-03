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
        { Sounds.GlassBreak,       Resources.Load<AudioClip>("Sounds/Breaking Glass T2")},
        { Sounds.ComputerStart,    Resources.Load<AudioClip>("Sounds/Computer startup T2")},
        { Sounds.Correct,          Resources.Load<AudioClip>("Sounds/Correct Sound(bing) T2")},
        { Sounds.ComputerError,    Resources.Load<AudioClip>("Sounds/Critical error T2")},
        { Sounds.ElevatorDing,     Resources.Load<AudioClip>("Sounds/Elevator Ding T2")},
        { Sounds.ElevatorMusic,    Resources.Load<AudioClip>("Sounds/Elevator Music T2")},
        { Sounds.FireCrackle,      Resources.Load<AudioClip>("Sounds/Fire crackle T2")},
        { Sounds.FireWoosh,        Resources.Load<AudioClip>("Sounds/Fire woosh T2")},
        { Sounds.WashingMachine,   Resources.Load<AudioClip>("Sounds/Laundry macnine T2")},
        { Sounds.LevelMusic,       Resources.Load<AudioClip>("Sounds/Level Music T2")},
        { Sounds.OfficeAmbience,   Resources.Load<AudioClip>("Sounds/Office ambience loop T2")},
        { Sounds.Promotion,        Resources.Load<AudioClip>("Sounds/Promoted(level up) T2")},
        { Sounds.Woosh,            Resources.Load<AudioClip>("Sounds/Throw Woosh T2")},
        { Sounds.Thud,             Resources.Load<AudioClip>("Sounds/Thud T2")},
        { Sounds.TreadmillSound,   Resources.Load<AudioClip>("Sounds/Treadmill T2")},

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
            AudioSource.PlayClipAtPoint(sounds[sound], new Vector2(0.0f,0.0f), 1.0f);
        }
        
        
    }
}
