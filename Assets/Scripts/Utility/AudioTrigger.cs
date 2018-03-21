using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;
using System.Collections;
using System.Threading;

class AudioTrigger : MonoBehaviour
{
    public static AudioTrigger instance;
    public bool isTalking = false;

    int samp_l; // total length of the audio sample in seconds
    float trig_l; // length in second during which the signal must be over threshold to validate detection 
    float threshold; // a level threshold btwn 0 & 1 exclusive
    int max_freq = 0;
    int min_freq = 0;
    String device = "";

    public void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            throw new System.Exception("Singleton error");
        }
    }

    private void Start()
    {
        this.samp_l = 2;
        this.trig_l = .1f;
        this.threshold = .000000001f;
        Microphone.GetDeviceCaps(this.device, out min_freq, out max_freq);
    }

    private static float Abs(float nb)
    {
        if (nb >= 0)
            return nb;
        return -nb;
    }

    // Can be run inside a separate thread and interrupted
    public void DetectAudio()
    {
        this.isTalking = false;

        // Default device
        AudioClip clip = new AudioClip();
        do
        {
            clip = Microphone.Start(this.device, false, this.samp_l, this.min_freq);

            if (Microphone.IsRecording(this.device))
            { //check that the mic is recording, otherwise you'll get stuck in an infinite loop waiting for it to start
                while (!(Microphone.GetPosition(this.device) > 0))
                    continue;
                // Now that recording started, let it go through and the stop it
                System.Threading.Thread.Sleep(1000 * this.samp_l);
                Microphone.End(this.device);
            }
            else
            {
                Debug.Log("There was a problem recording from the default microphone!");
            }

            float[] samples = new float[clip.samples * clip.channels];

            clip.GetData(samples, 0);

            float rawlvl = 0;
            float avglvl = 0;

            foreach (float f in samples)
            {
                rawlvl += Abs(f);
            }

            avglvl = rawlvl / samples.Length;

            Debug.Log("[AUDIOTRIGGER] Raw level is " + rawlvl + " average is " + avglvl);

            if (avglvl > this.threshold)
            {
                this.isTalking = true;
                Debug.Log("[AUDIOTRIGGER] Talk detected!");
            }
        } while (!this.isTalking && Thread.CurrentThread.IsAlive);
    }
}
