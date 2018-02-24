using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;
using System.Collections;

namespace Assets._Project.Scripts
{
    class AudioTrigger : MonoBehaviour
    {
        private void Start()
        {
            this.aud = GetComponent<AudioSource>();
            Microphone.GetDeviceCaps("",out min_freq, out max_freq);
        }

        private float abs(float nb)
        {
            if (nb >= 0)
                return nb;
            return -nb;
        }
        int samp_l; // total length of the audio sample in seconds
        float trig_l; // length in second during which the signal must be over threshold to validate detection 
        float threshold; // a level threshold btwn 0 & 1 exclusive
        int max_freq = 0;
        int min_freq = 0;
        AudioSource aud = null;

        public AudioTrigger(float trig_l, float threshold, int samp_l = 1)
        {
            this.samp_l = samp_l;
            this.trig_l = trig_l;
            this.threshold = threshold;
        }

        public bool detect_audio()
        {
            // Default device
            aud.clip = Microphone.Start("", false, samp_l, max_freq);

            float[] samples = new float[aud.clip.samples * aud.clip.channels];
            
            aud.clip.GetData(samples, 0);
            float tmp = 0;
            int consec_samp_above_th = 0;
            int best_c_samp_above_th = 0;

            for (int i = 0; i < samples.Length; i++) {
                for (int j = 0; j < aud.clip.channels; j++)
                    tmp += abs(samples[i + j]);
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
                return true;

            return false;
        }
    }
}
