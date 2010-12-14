using System;
using Microsoft.SPOT;
using System.Collections;

namespace NetduinoSound
{
    /*********************************************************
    * Song Class for storing almost ready to play PWM music
    *********************************************************/
    class Song
    {


        public ArrayList Notations;
        public int Beat;
        public int Duration;

        public Song(int beat, int duration)
        {
            Notations = new ArrayList();
            Beat = beat;
            Duration = duration;
        }

        //return the calcuated interval of time for sound
        public int Interval()
        {
            return ((1000 * 60) / Beat) * 4;
        }



    }
}
