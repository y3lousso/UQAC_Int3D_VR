using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;
using System.Collections;

class AudioTrigger : MonoBehaviour
{
    public static AudioTrigger instance;
    public bool isTalking = false;

    int samp_l; // total length of the audio sample in seconds
    float trig_l; // length in second during which the signal must be over threshold to validate detection 
    float threshold; // a level threshold btwn 0 & 1 exclusive
    int max_freq = 0;
    int min_freq = 0;
    AudioSource aud = null;

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
        this.samp_l = 1;
        this.trig_l = .1f;
        this.threshold = .1f;
        this.aud = GetComponent<AudioSource>();
        Microphone.GetDeviceCaps("", out min_freq, out max_freq);
    }

    private float Abs(float nb)
    {
        if (nb >= 0)
            return nb;
        return -nb;
    }

    public void DetectAudio()
    {
        // Default device
        aud.clip = Microphone.Start("", false, samp_l, max_freq);

        float[] samples = new float[aud.clip.samples * aud.clip.channels];

        aud.clip.GetData(samples, 0);
        float tmp = 0;
        int consec_samp_above_th = 0;
        int best_c_samp_above_th = 0;

        for (int i = 0; i < samples.Length; i++)
        {
            for (int j = 0; j < aud.clip.channels; j++)
                tmp += Abs(samples[i + j]);
            tmp /= aud.clip.channels;

            if (tmp > threshold)
                consec_samp_above_th++;
            else if (consec_samp_above_th > best_c_samp_above_th)
            {
                best_c_samp_above_th = consec_samp_above_th;
                consec_samp_above_th = 0;
            }

            i += aud.clip.channels - 1;
        }

        if (best_c_samp_above_th / max_freq >= trig_l)
        {
            // isTalking = true or false
        }
    }
}
