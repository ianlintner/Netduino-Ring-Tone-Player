using System;
using Microsoft.SPOT;

namespace NetduinoSound
{

   /*********************************************************
   * Notation class for storing a note and it's duration
   *********************************************************/
    class Notation
    {
        public uint Note;
        public uint Duration;
        public uint Period;

        public Notation(uint note, uint duration)
        {
            this.Note = note;
            this.Duration = duration;
            if (note > 0)
            {
                //1000000 = 1 sec
                //Period = 1 sec / f
                this.Period = 1000000 / note;
            }
            else
            {
                this.Period = 0;
            }
        }

        
        public uint CalculateDuration()
        {
            return (uint)(Note / Duration);
        }

        //Calculate duration based on tempo
        public int SleepDuration(int tempo)
        {
            return (int)(tempo / Duration);
        }
        
    }
}
