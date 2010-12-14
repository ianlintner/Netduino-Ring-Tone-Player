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

        public static void Main()
        {
            // write your code here
            Button.OnInterrupt += new NativeEventHandler(ButtonPushed);
            while (true)
            {
                CurrentSong = Playlist.TetrisA();
                Play();
            }
        }

        public static void Play()
        {
          

            foreach (Notation myNotation in CurrentSong.Notations)
            {
                if (IsPlay)
                {

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
