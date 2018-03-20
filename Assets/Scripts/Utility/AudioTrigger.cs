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
        this.isTalking = false;
        // Default device
        AudioClip clip = new AudioClip();
        clip = Microphone.Start("", false, samp_l, max_freq);

        float[] samples = new float[clip.samples * clip.channels];

        clip.GetData(samples, 0);
        float tmp = 0;
        int consec_samp_above_th = 0;
        int best_c_samp_above_th = 0;

        for (int i = 0; i < samples.Length; i++)
        {
            for (int j = 0; j < clip.channels; j++)
                tmp += Abs(samples[i + j]);
            tmp /= clip.channels;

            if (tmp > threshold)
                consec_samp_above_th++;
            else if (consec_samp_above_th > best_c_samp_above_th)
            {
                best_c_samp_above_th = consec_samp_above_th;
                consec_samp_above_th = 0;
            }

            i += clip.channels - 1;
        }
        Debug.Log("[AUDIOTRIGGER] Nb channels : " + clip.channels + " Nb consec. samples > thres. : " + best_c_samp_above_th +
            " Max freq : " + max_freq + " trigger len : " + trig_l);
        if (best_c_samp_above_th / max_freq >= trig_l)
        {
            this.isTalking = true;
            Debug.Log("[AUDIOTRIGGER] Audio detected!");
        }
    }
}
