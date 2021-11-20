using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour
{
    [SerializeField] SoundManagerAction action;
    [SerializeField] SoundManagerTarget target;
    [SerializeField] string soundTag = "";

    // Start is called before the first frame update
    void Start()
    {
        List<ClipPlayScript> clipPlayScripts = new List<ClipPlayScript>(FindObjectsOfType<ClipPlayScript>());
        List<ClipPlayScript> remove = new List<ClipPlayScript>();

        foreach (ClipPlayScript clip in clipPlayScripts)
        {
            if (clip.soundTag != soundTag) remove.Add(clip);
        }

        foreach (ClipPlayScript clip in remove)
        {
            clipPlayScripts.Remove(clip);
        }

        if(clipPlayScripts.Count > 0)
        {
            switch (action)
            {
                case SoundManagerAction.Play:
                    switch (target)
                    {
                        case SoundManagerTarget.Fisrt:
                            clipPlayScripts[0].source.Play();
                            clipPlayScripts[0].pause = false;
                            break;
                        case SoundManagerTarget.Last:
                            clipPlayScripts[clipPlayScripts.Count - 1].source.Play();
                            clipPlayScripts[clipPlayScripts.Count - 1].pause = false;
                            break;
                        case SoundManagerTarget.All:
                            foreach (ClipPlayScript clip in clipPlayScripts)
                            {
                                clip.source.Play();
                                clip.pause = false;
                            }
                            break;
                    }
                    break;
                case SoundManagerAction.Pause:
                    switch (target)
                    {
                        case SoundManagerTarget.Fisrt:
                            clipPlayScripts[0].pause = true;
                            clipPlayScripts[0].source.Pause();
                            break;
                        case SoundManagerTarget.Last:
                            clipPlayScripts[clipPlayScripts.Count - 1].pause = true;
                            clipPlayScripts[clipPlayScripts.Count - 1].source.Pause();
                            break;
                        case SoundManagerTarget.All:
                            foreach (ClipPlayScript clip in clipPlayScripts)
                            {
                                clip.pause = true;
                                clip.source.Pause();
                            }
                            break;
                    }
                    break;
                case SoundManagerAction.Stop:
                    switch (target)
                    {
                        case SoundManagerTarget.Fisrt:
                            Destroy(clipPlayScripts[0].gameObject);
                            break;
                        case SoundManagerTarget.Last:
                            Destroy(clipPlayScripts[clipPlayScripts.Count - 1].gameObject);
                            break;
                        case SoundManagerTarget.All:
                            foreach (ClipPlayScript clip in clipPlayScripts)
                            {
                                Destroy(clip.gameObject);
                            }
                            break;
                    }
                    break;
            }
        }
    }
}

public enum SoundManagerAction
{
    Play,
    Pause,
    Stop,
}

public enum SoundManagerTarget
{
    Fisrt,
    Last,
    All,
}
