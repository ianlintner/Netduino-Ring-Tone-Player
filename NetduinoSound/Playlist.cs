using System;
using System.Collections;
using Microsoft.SPOT;

namespace NetduinoSound
{
    /*********************************************************
    * Song Class for storing almost ready to play PWM music
    *********************************************************/
    class Playlist
    {
        public static Song Simpsons()
        {
            RTTTL myRT = new RTTTL("The Simpsons:d=4,o=5,b=160:c.6,e6,f#6,8a6,g.6,e6,c6,8a,8f#,8f#,8f#,2g,8p,8p,8f#,8f#,8f#,8g,a#.,8c6,8c6,8c6,c6");
            Song mySong = myRT.GetSong();
            return mySong;
        }

        public static Song Monty()
        {
            RTTTL myRT = new RTTTL("Monty P:d=4,o=5,b=200:f6,8e6,d6,8c#6,c6,8b,a#,8a,8g,8a,8a#,a,8g,2c6,8p,8c6,8a,8p,8a,8a,8g#,8a,8f6,8p,8c6,8c6,8p,8a,8a#,8p,8a#,8a#,8p,8c6,2d6,8p,8a#,8g,8p,8g,8g,8f#,8g,8e6,8p,8d6,8d6,8p,8a#,8a,8p,8a,8a,8p,8a#,2c6,8p,8c6");
            Song mySong = myRT.GetSong();
            return mySong;
            
        }

        public static Song Popcorn()
        {
            RTTTL myRT = new RTTTL("popcorn:d=4,o=5,b=160:8a,8g,8a,8e,8c,8e,a4,8a,8g,8a,8e,8c,8e,a4,8a,8b,8c6,8b,8c6,8a,8b,8a,8b,8g,8a,8g,8a,8f,a,8a,8g,8a,8e,8c,8e,a4,8a,8g,8a,8e,8c,8e,a4,8a,8b,8c6,8b,8c6,8a,8b,8a,8b,8g,8a,8g,8a,8f,a");
            Song mySong = myRT.GetSong();
            return mySong;

        }

        public static Song Clint()
        {
            RTTTL myRT = new RTTTL("ClintEastwood-GorillaZ:d=8,o=5,b=125:c#6,16d6,f6,4c.6,16p,a#,16a,c#6,4e.6,16p,c#6,16d6,f6,4c.6,16p,a#,a,c#6,4e.6,16p,d6,f6,4c6,16p,a#,a,c#6,4e6,16p,f,e,f,f,16p,f,e,f,f,16p,f,e,f,f");
            Song mySong = myRT.GetSong();
            return mySong;
        }

        public static Song Muppets()
        {
            RTTTL myRT = new RTTTL("Muppets:d=4,o=5,b=250:c6,c6,a,b,8a,b,g,p,c6,c6,a,8b,8a,8p,g.,p,e,e,g,f,8e,f,8c6,8c,8d,e,8e,8e,8p,8e,g,2p,c6,c6,a,b,8a,b,g,p,c6,c6,a,8b,a,g.,p,e,e,g,f,8e,f,8c6,8c,8d,e,8e,d,8d,c");
            Song mySong = myRT.GetSong();
            return mySong;
        }

        public static Song StarWars()
        {
            RTTTL myRT = new RTTTL("StWars:d=4,o=5,b=180:8f,8f,8f,2a#.,2f.6,8d#6,8d6,8c6,2a#.6,f.6,8d#6,8d6,8c6,2a#.6,f.6,8d#6,8d6,8d#6,2c6,p,8f,8f,8f,2a#.,2f.6,8d#6,8d6,8c6,2a#.6,f.6,8d#6,8d6,8c6,2a#.6,f.6,8d#6,8d6,8d#6,2c6");
            Song mySong = myRT.GetSong();
            return mySong;
        }

        
        public static Song StarWarsCatina()
        {
            RTTTL myRT = new RTTTL("Cantina:d=4,o=5,b=250:8a,8p,8d6,8p,8a,8p,8d6,8p,8a,8d6,8p,8a,8p,8g#,a,8a,8g#,8a,g,8f#,8g,8f#,f.,8d.,16p,p.,8a,8p,8d6,8p,8a,8p,8d6,8p,8a,8d6,8p,8a,8p,8g#,8a,8p,8g,8p,g.,8f#,8g,8p,8c6,a#,a,g");
            Song mySong = myRT.GetSong();
            return mySong;
        }

        public static Song YaketySax()
        {
            
            RTTTL myRT = new RTTTL("Yaketysax:d=4,o=5,b=125:8d.,16e,8g,8g,16e,16d,16a4,16b4,16d,16b4,8e,16d,16b4,16a4,16b4,8a4,16a4,16a#4,16b4,16d,16e,16d,g,p,16d,16e,16d,8g,8g,16e,16d,16a4,16b4,16d,16b4,8e,16d,16b4,16a4,16b4,8d,16d,16d,16f#,16a,8f,d,p,16d,16e,16d,8g,16g,16g,8g,16g,16g,8g,8g,16e,8e.,8c,8c,8c,8c,16e,16g,16a,16g,16a#,8g,16a,16b,16a#,16b,16a,16b,8d6,16a,16b,16d6,8b,8g,8d,16e6,16b,16b,16d,8a,8g,g");
            Song mySong = myRT.GetSong();
            return mySong;
        }

        public static Song TetrisA()
        {

            RTTTL myRT = new RTTTL("korobyeyniki:d=4,o=5,b=160:e6,8b,8c6,8d6,16e6,16d6,8c6,8b,a,8a,8c6,e6,8d6,8c6,b,8b,8c6,d6,e6,c6,a,2a,8p,d6,8f6,a6,8g6,8f6,e6,8e6,8c6,e6,8d6,8c6,b,8b,8c6,d6,e6,c6,a,a");
            Song mySong = myRT.GetSong();
            return mySong;
        }


        public static Song Jeopardy()
        {

            RTTTL myRT = new RTTTL("Jeopardy:d=4,o=6,b=125:c,f,c,f5,c,f,2c,c,f,c,f,a.,8g,8f,8e,8d,8c#,c,f,c,f5,c,f,2c,f.,8d,c,a#5,a5,g5,f5,p,d#,g#,d#,g#5,d#,g#,2d#,d#,g#,d#,g#,c.7,8a#,8g#,8g,8f,8e,d#,g#,d#,g#5,d#,g#,2d#,g#.,8f,d#,c#,c,p,a#5,p,g#.5,d#,g#");
            Song mySong = myRT.GetSong();
            return mySong;
        }

       
    }
}
