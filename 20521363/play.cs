﻿using _20521363.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics.Tracing;
using System.Drawing;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace _20521363
{
    public partial class play : Form
    {
        public play()
        {
            InitializeComponent();
            this.StartPosition = FormStartPosition.CenterScreen;
        }
        List<Music> play_;
        public play(List<Music> musicin): this()
        {
            play_ = musicin;
            for (int i = 0; i < play_.Count; i++)
            {
                listBox1.Items.Add(play_[i].Mp3_4);
            }
            lb_name_lyrics.Font = new Font("Times New Roman", 16, FontStyle.Bold);
            listBox1.SelectedIndex = 0;
            lb_name_lyrics.Text = play_[listBox1.SelectedIndex].Name + " Lyrics";
            lb_lyrics.Text = play_[listBox1.SelectedIndex].Lyrics;
            lb_name.Text = play_[listBox1.SelectedIndex].Name + " - " + play_[listBox1.SelectedIndex].Singer;
            axWindowsMediaPlayer1.settings.mute = false;
            axWindowsMediaPlayer1.uiMode = "none";
            axWindowsMediaPlayer1.URL = play_[listBox1.SelectedIndex].Mp3_4;
            timer1.Start();
            trackBar1.Value = 50;
            lb_volume.Text = trackBar1.Value.ToString();
        }

        private void pictureBox1_Click_1(object sender, EventArgs e)
        {
            axWindowsMediaPlayer1.Ctlcontrols.stop();
            this.Close();
        }

        private void btplay_Click(object sender, EventArgs e)
        {
            axWindowsMediaPlayer1.Ctlcontrols.play();
            btplay.Visible = false;
            btstop.Visible = true;
            btpause.Visible = true;
            btcontinue.Visible = false;
        }

        private void btprevious_Click(object sender, EventArgs e)
        {
            if (listBox1.SelectedIndex > 0)
            {
                listBox1.SelectedIndex -= 1;
                axWindowsMediaPlayer1.URL = play_[listBox1.SelectedIndex].Mp3_4;
                axWindowsMediaPlayer1.Ctlcontrols.play();
                lb_name_lyrics.Text = play_[listBox1.SelectedIndex].Name + " Lyrics";
                lb_lyrics.Text = play_[listBox1.SelectedIndex].Lyrics;
                lb_name.Text = play_[listBox1.SelectedIndex].Name + " - " + play_[listBox1.SelectedIndex].Singer;
                timer1.Start();
            }
        }

        private void btstop_Click(object sender, EventArgs e)
        {
            axWindowsMediaPlayer1.Ctlcontrols.stop();
            btstop.Visible = false;
            btplay.Visible = true;
            btpause.Visible = true;
            btcontinue.Visible = false;
        }

        private void btpause_Click(object sender, EventArgs e)
        {
            axWindowsMediaPlayer1.Ctlcontrols.pause();
            if (btplay.Visible == true)
            {
                btpause.Visible = true;
                btcontinue.Visible = false;
            }
            else
            {
                btpause.Visible = false;
                btcontinue.Visible = true;
            }
        }

        private void btnext_Click(object sender, EventArgs e)
        {
            if (listBox1.SelectedIndex < play_.Count - 1)
            {
                listBox1.SelectedIndex += 1;
                axWindowsMediaPlayer1.URL = play_[listBox1.SelectedIndex].Mp3_4;
                axWindowsMediaPlayer1.Ctlcontrols.play();
                lb_name_lyrics.Text = play_[listBox1.SelectedIndex].Name + " Lyrics";
                lb_lyrics.Text = play_[listBox1.SelectedIndex].Lyrics;
                lb_name.Text = play_[listBox1.SelectedIndex].Name + " - " + play_[listBox1.SelectedIndex].Singer;
                timer1.Start();
            }
        }

        private void btcontinue_Click(object sender, EventArgs e)
        {
            axWindowsMediaPlayer1.Ctlcontrols.play();
            btcontinue.Visible = false;
            btpause.Visible = true;
            btstop.Visible = true;
            btplay.Visible = false;
        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (listBox1.SelectedIndex != -1)
            {
                axWindowsMediaPlayer1.URL = play_[listBox1.SelectedIndex].Mp3_4;
                axWindowsMediaPlayer1.Ctlcontrols.play();
                lb_name_lyrics.Text = play_[listBox1.SelectedIndex].Name + " Lyrics";
                lb_lyrics.Text = play_[listBox1.SelectedIndex].Lyrics;
                lb_name.Text = play_[listBox1.SelectedIndex].Name + " - " + play_[listBox1.SelectedIndex].Singer;
                timer1.Start();
            }
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            if (axWindowsMediaPlayer1.playState == WMPLib.WMPPlayState.wmppsPlaying)
            {
                progressBar1.Maximum = (int)axWindowsMediaPlayer1.Ctlcontrols.currentItem.duration;
                progressBar1.Value = (int)axWindowsMediaPlayer1.Ctlcontrols.currentPosition;
            }
            lbtime.Text = axWindowsMediaPlayer1.Ctlcontrols.currentPositionString;
            lbduration.Text = axWindowsMediaPlayer1.Ctlcontrols.currentItem.durationString.ToString();
        }

        private void trackBar1_Scroll(object sender, EventArgs e)
        {
            axWindowsMediaPlayer1.settings.volume = trackBar1.Value;
            lb_volume.Text = trackBar1.Value.ToString();
        }

        private void btdownload_Click(object sender, EventArgs e)
        {
            form_download newform = new form_download(play_[listBox1.SelectedIndex].Mp3_4);
            newform.ShowDialog();
        }
    }
}
