using System;
using System.Threading;
using System.Collections;
using Microsoft.SPOT;
using Microsoft.SPOT.Hardware;
using SecretLabs.NETMF.Hardware;
using SecretLabs.NETMF.Hardware.Netduino;

namespace NetduinoSound
{
    public class Program
    {

        static bool IsPlay = true;
        static PWM Speaker = new PWM(Pins.GPIO_PIN_D5);
        static Song CurrentSong;
        static InterruptPort Button = new InterruptPort(Pins.ONBOARD_SW1, false, ResistorModes.Disabled, InterruptModes.InterruptEdgeBoth);
        static Queue SongQueue = new Queue();
        public static void Main()
        {
            //Set interuppt
            Button.OnInterrupt += new NativeEventHandler(ButtonPushed);
           
            //Looping
            while (true)
            {
             
                //Reload the Queue -- Not exactly efficient but it's just for fun
                if(SongQueue.Count < 1) 
                {
                    SongQueue = Playlist.GetQueue();
                }
   
                //Check to see what stat our play variable is at based on switch press
                if (IsPlay)
                {
                    CurrentSong = (Song)SongQueue.Dequeue();
                    Play();
                    Thread.Sleep(2000);
                }
                else
                {
                    Thread.Sleep(100);
                }
            }
        }

        //Function to play notes from song class -- our work horse
        public static void Play()
        {
         
            //loop through each notation object in the arraylist
            foreach (Notation myNotation in CurrentSong.Notations)
            {
                if (IsPlay)
                {
                    //see earlier tutorial on playing on notes on netduino using a piezo
                    if (myNotation.Note != 0)
                    {
                        Speaker.SetPulse(myNotation.Period, myNotation.Period / 2);
                        Thread.Sleep(myNotation.SleepDuration(CurrentSong.Interval()));
                        Speaker.SetDutyCycle(0);
                        Thread.Sleep(10);
                      
                    }
                    else
                    {
                        Speaker.SetDutyCycle(0);
                        Thread.Sleep(myNotation.SleepDuration(CurrentSong.Interval()));
                    }
                }
            }
        }

        //Changes IsPlay state on button press
        public static void ButtonPushed(uint data1, uint data2, DateTime time)
        {
            Microsoft.SPOT.Debug.Print(data2.ToString());

            if (data2 == 0)
            {
                //
            }
            else
            {
                IsPlay = !IsPlay;
            }

        }

    }

}
