using System; 
using System.Collections;
using Microsoft.SPOT;
using System.Resources;

namespace NetduinoSound
{
    /*********************************************************
    * Song Class for storing almost ready to play PWM music
    *********************************************************/
    class Playlist
    {

   
        //Example Test
        public static Song Tetris()
        {
            

            RTTTL myRT = new RTTTL("korobyeyniki:d=4,o=5,b=160:e6,8b,8c6,8d6,16e6,16d6,8c6,8b,a,8a,8c6,e6,8d6,8c6,b,8b,8c6,d6,e6,c6,a,2a,8p,d6,8f6,a6,8g6,8f6,e6,8e6,8c6,e6,8d6,8c6,b,8b,8c6,d6,e6,c6,a,a");
            Song mySong = myRT.GetSong();
            return mySong;
        }

        public static Queue GetQueue() {
            Queue myLibrary = new Queue();
         
            myLibrary.Enqueue(new RTTTL("StWars:d=4,o=5,b=180:8f,8f,8f,2a#.,2f.6,8d#6,8d6,8c6,2a#.6,f.6,8d#6,8d6,8c6,2a#.6,f.6,8d#6,8d6,8d#6,2c6,p,8f,8f,8f,2a#.,2f.6,8d#6,8d6,8c6,2a#.6,f.6,8d#6,8d6,8c6,2a#.6,f.6,8d#6,8d6,8d#6,2c6").GetSong());
            myLibrary.Enqueue(new RTTTL("korobyeyniki:d=4,o=5,b=160:e6,8b,8c6,8d6,16e6,16d6,8c6,8b,a,8a,8c6,e6,8d6,8c6,b,8b,8c6,d6,e6,c6,a,2a,8p,d6,8f6,a6,8g6,8f6,e6,8e6,8c6,e6,8d6,8c6,b,8b,8c6,d6,e6,c6,a,a").GetSong());
            myLibrary.Enqueue(new RTTTL("punch_jog:d=4,o=6,b=125:32a#,32c7,8c#.7,32a#,32c7,8c#.7,32a#,32c7,8c#.7,8a#,8c7,8c#7,8f7,d#7,8c#7,32g#,32a#,8c.7,32g#,32a#,8c.7,32g#,32a#,8c.7,8g#,8a#,8c7,8d#7,c#7,32f#,32g#,8a#.,32f#,32g#,8a#.,32f#,32g#,8a#.,8f#,8g#,8a#,8c#7,c7,8a#,8a#,8f,8f,8f").GetSong());
            myLibrary.Enqueue(new RTTTL("Popcorn:d=4,o=5,b=140:8c6,8a#,8c6,8g,8d#,8g,c,8c6,8a#,8c6,8g,8d#,8g,c,8c6,8d6,8d#6,16c6,8d#6,16c6,8d#6,8d6,16a#,8d6,16a#,8d6,8c6,8a#,8g,8a#,c6").GetSong());
            myLibrary.Enqueue(new RTTTL("Mission:d=4,o=6,b=100:32d,32d#,32d,32d#,32d,32d#,32d,32d#,32d,32d,32d#,32e,32f,32f#,32g,16g,8p,16g,8p,16a#,16p,16c,16p,16g,8p,16g,8p,16f,16p,16f#,16p,16g,8p,16g,8p,16a#,16p,16c,16p,16g,8p,16g,8p,16f,16p,16f#,16p,16a#,16g,2d,32p,16a#,16g,2c#,32p,16a#,16g,2c,16p,16a#5,16c").GetSong());
            myLibrary.Enqueue(new RTTTL("Bond:d=4,o=5,b=320:c,8d,8d,d,2d,c,c,c,c,8d#,8d#,2d#,d,d,d,c,8d,8d,d,2d,c,c,c,c,8d#,8d#,d#,2d#,d,c#,c,c6,1b.,g,f,1g.").GetSong());
            //myLibrary.Enqueue(new RTTTL("").GetSong());
           
            return myLibrary;
                
        }


    

       
    }
}
