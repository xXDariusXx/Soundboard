﻿using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Soundboard
{
    class player        //Handles sound playing
    {
        WMPLib.WindowsMediaPlayer wplayer = new WMPLib.WindowsMediaPlayer();
        List<WMPLib.WindowsMediaPlayer> spamPlayer = new List<WMPLib.WindowsMediaPlayer>();
        public void playSound(String path)
        {

            wplayer.URL = path;
            wplayer.controls.play();

        }
        public void playSpam(string path)
        {
            WMPLib.WindowsMediaPlayer player = new WMPLib.WindowsMediaPlayer();
            player.URL = path;
            player.controls.play();
            spamPlayer.Add(player);
            
        }
        public void setVolume(int volume)
        {
            wplayer.settings.volume = volume;
        }
        public void stopSound()
        {
            wplayer.controls.stop();
            for (int i = 0; i < spamPlayer.Count(); i++)
            {
                spamPlayer[i].controls.stop();
            }
            
            spamPlayer.Clear();
            GC.Collect();
        }

        public void resume()
        {
            wplayer.controls.play();
        }

        public void pause()
        {
            wplayer.controls.pause();
        }

    }
}
