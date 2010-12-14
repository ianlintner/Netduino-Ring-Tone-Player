using System;
using Microsoft.SPOT;
using System.Collections;

namespace NetduinoSound
{
    /*********************************************************
    * RTTTL Class for storing and parsing RTTTL ringtones
    *********************************************************/
    class RTTTL
    {
        public string RawData;
        public string Name;

        public int Duration;
        public int Octave;
        public int Beat;

        public string[] Notes;
        public string[] Header;
        public string[] Divisions;

        static int OctaveOffset = 0;
        
        //c1 - B7
        static uint[] RTTTLNotes = { Pitches.C1,Pitches.CS1,Pitches.D1,Pitches.DS1,Pitches.E1,Pitches.F1,Pitches.FS1,Pitches.G1,Pitches.GS1,Pitches.A1,Pitches.AS1,Pitches.B1,
                                    Pitches.C2,Pitches.CS2,Pitches.D2,Pitches.DS2,Pitches.E2,Pitches.F2,Pitches.FS2,Pitches.G2,Pitches.GS2,Pitches.A2,Pitches.AS2,Pitches.B2,
                                    Pitches.C3,Pitches.CS3,Pitches.D3,Pitches.DS3,Pitches.E3,Pitches.F3,Pitches.FS3,Pitches.G3,Pitches.GS3,Pitches.A3,Pitches.AS3,Pitches.B3,
                                    Pitches.C4,Pitches.CS4,Pitches.D4,Pitches.DS4,Pitches.E4,Pitches.F4,Pitches.FS4,Pitches.G4,Pitches.GS4,Pitches.A4,Pitches.AS4,Pitches.B4,
                                    Pitches.C5,Pitches.CS5,Pitches.D5,Pitches.DS5,Pitches.E5,Pitches.F5,Pitches.FS5,Pitches.G5,Pitches.GS5,Pitches.A5,Pitches.AS5,Pitches.B5,
                                    Pitches.C6,Pitches.CS6,Pitches.D6,Pitches.DS6,Pitches.E6,Pitches.F6,Pitches.FS6,Pitches.G6,Pitches.GS6,Pitches.A6,Pitches.AS6,Pitches.B6,
                                    Pitches.C7,Pitches.CS7,Pitches.D7,Pitches.DS7,Pitches.E7,Pitches.F7,Pitches.FS7,Pitches.G7,Pitches.GS7,Pitches.A7,Pitches.AS7,Pitches.B7
                                  };
       
        /*********************************************************
        * Example RTTTL Format
        * The Simpsons:d=4,o=5,b=160:c.6,e6,f#6,8a6,g.6,e6,c6...
        * Parse by colons to split up sections
        *********************************************************/
        public RTTTL(String song)
        {


            RawData = song;
            Divisions = song.Split(':');
            Name = Divisions[0];
            Header = Divisions[1].Split(',');
            Notes = Divisions[2].Split(',');

            
            Duration = int.Parse(Header[0].Substring(2, Header[0].Length - 2));
            Octave = int.Parse(Header[1].Substring(2, Header[1].Length - 2));
            Beat = int.Parse(Header[2].Substring(2, Header[2].Length - 2));
        }


        /*********************************************************
        * I ported some of this code from a open source C arduino library to c# / Netduino
        * http://code.google.com/p/rogue-code/source/browse/Arduino/libraries/Tone/trunk/examples/RTTTL/RTTTL.pde
        * *********************************************************/
        public Song GetSong()
        {
            Song song = new Song(this.Beat, this.Duration);
            song.Notations = new ArrayList();
           
            //used for parsing the current section
            char[] charParserArray;

            //quarter note unless specified
            int defaultDuration = 4;
            //middle c octave
            int defaultOctave = 6;
            int durationParseNumber = 0;
            int currentDuration = 0;
            int currentScale = 0;
            int currentNote = 0;

            foreach (string myNote in this.Notes)
            {
                charParserArray = myNote.ToCharArray();
                
                //start parsing a note entry
                for (int i = 0; i < myNote.Length; i++)
                {  
                    durationParseNumber = 0;
                    currentNote = 0;
                    currentDuration = 0;
                    currentScale = 0;

                    // first, get note duration, if available
                    while (i < charParserArray.Length && isdigit(charParserArray[i]))
                    {
                        //construct the duration
                        durationParseNumber = (durationParseNumber * 10) + (charParserArray[i++] - '0');
                    }

                    if (durationParseNumber > 0)
                    {
                        currentDuration = durationParseNumber;
                    }
                    else
                    {
                        currentDuration = defaultDuration; 
                    }

                    // c is first note i.e. c = 1
                    // b = 12
                    // pause or undefined = 0
                    if (i<charParserArray.Length) 
                    {
                        switch (charParserArray[i])
                        {
                            case 'c':
                                currentNote = 1;
                                break;
                            case 'd':
                                currentNote = 3;
                                break;
                            case 'e':
                                currentNote = 5;
                                break;
                            case 'f':
                                currentNote = 6;
                                break;
                            case 'g':
                                currentNote = 8;
                                break;
                            case 'a':
                                currentNote = 10;
                                break;
                            case 'b':
                                currentNote = 12;
                                break;
                            case 'p':
                                currentNote = 0;
                                break;
                            default:
                                currentNote = 0;
                                break;
                        }
                    }
                    
                    i++;


                    // process whether the note is sharp
                    if (i<charParserArray.Length && charParserArray[i] == '#')
                    {
                        currentNote++;
                        i++;
                    }

                    // is it dotted note, divide the duration in half
                    if (i < charParserArray.Length && charParserArray[i] == '.')
                    {
                        currentDuration += currentDuration / 2;
                        i++;
                    }

                    // now, get octave
                    if (i < charParserArray.Length && isdigit(charParserArray[i]))
                    {
                        currentScale = charParserArray[i] - '0';
                        i++;
                    }
                    else
                    {
                        currentScale = defaultOctave;
                    }

                    //offset if necessary
                    currentScale += OctaveOffset;

                    //add the note by calculating it's location in the RTTTL note array, scale/octave offsets are by 12 notes
                    song.Notations.Add(new Notation((uint)RTTTLNotes[(currentScale - 1) * 12 + currentNote], (uint)currentDuration));

                }
            }

            return song;
        }

       
        public bool isdigit(char input)
        {
            switch (input)
            {
                case '1':
                    return true;
                case '2':
                    return true;
                case '3':
                    return true;
                case '4':
                    return true;
                case '5':
                    return true;
                case '6':
                    return true;
                case '7':
                    return true;
                case '8':
                    return true;
                case '9':
                    return true;
                case '0':
                    return true;
                default:
                    return false;

            }
        }
        }

    }
       

