using System;
using System.Text.RegularExpressions;

namespace _02._Song_Encryption
{
    class Program
    {
        static void Main(string[] args)
        {
            string pattern = @"^(?<artist>[A-Z](?:[a-z]*(?:[ ]|[']){0,}){0,}):(?<song>(?:[A-Z]| )*)$";

            string input;

            while ((input = Console.ReadLine()) != "end")
            {
                Match match = Regex.Match(input, pattern);

                if (match.Success)
                {
                    int key = match.Groups["artist"].Value.Length;

                    string artist = match.Groups["artist"].Value;
                    string song = match.Groups["song"].Value;

                    string encryptedArtist = "";
                    string encryptedSong = "";

                    for (int i = 0; i < artist.Length; i++)
                    {
                        int currCh = artist[i];

                        for (int j = 0; j < key; j++)
                        {
                            if ((char)currCh == ' ' || (char)currCh == '\'')
                            {
                                break;
                            }

                            currCh += 1;

                            if (currCh == 91)
                            {
                                currCh = 65;
                            }
                            if (currCh == 123)
                            {
                                currCh = 97;
                            }                          
                        }
                        encryptedArtist += (char)currCh;
                    }

                    for (int i = 0; i < song.Length; i++)
                    {
                        int currCh = song[i];

                        for (int j = 0; j < key; j++)
                        {
                            if ((char)currCh == ' ' || (char)currCh == '\'')
                            {
                                break;
                            }

                            currCh += 1;

                            if (currCh == 91)
                            {
                                currCh = 65;
                            }
                            if (currCh == 123)
                            {
                                currCh = 97;
                            }
                        }
                        encryptedSong += (char)currCh;
                    }

                    Console.WriteLine($"Successful encryption: {encryptedArtist}@{encryptedSong}");
                }
                else
                {
                    Console.WriteLine("Invalid input!");
                }
            }          
        }
    }
}
