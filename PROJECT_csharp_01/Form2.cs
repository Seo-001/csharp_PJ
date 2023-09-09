using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Speech.Synthesis;
using System.IO;

namespace PROJECT_csharp_01
{
    public partial class Form2 : Form
    {
        SpeechSynthesizer voice;
        public Form2()
        {
            InitializeComponent();
        }

        private void Form2_Load(object sender, EventArgs e)
        {
            voice = new SpeechSynthesizer();
            //string[] data = { "여자목소리" };
            // 각 콤보박스에 데이타를 초기화
            //comboBox1.Items.AddRange(data);

            // 처음 선택값 지정. 첫째 아이템 선택
          //  comboBox1.SelectedIndex = 0;
        }//load

        private void btnSpeak_Click(object sender, EventArgs e)
        {
          


            try
            {

               voice.SetOutputToDefaultAudioDevice();

               voice.SelectVoice("Microsoft Heami Desktop");
                //voice.SelectVoiceByHints(VoiceGender.Male);
               // switch (comboBox1.SelectedIndex)
                //{
                   // case 0:
                     //   voice.SelectVoiceByHints(VoiceGender.NotSet);
                     //   break;
                  //  case 0:
                    //    voice.SelectVoiceByHints(VoiceGender.Male);
                     //   break;
                    //case 2:
                     //   voice.SelectVoiceByHints(VoiceGender.Female);
                       // break;
                   // default:
                        //break;
                //}
                voice.SpeakAsync(textBox1.Text);
            }//
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Message", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }//catch
        }// speak

        private void btnStop_Click(object sender, EventArgs e)
        {
            try
            {
                voice.Pause();
            }//
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Message", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }//catch
        }//stop

        private void btnRestart_Click(object sender, EventArgs e)
        {
            try
            {
               voice.Resume();
            }//
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Message", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }//catch
        }//restart

        private void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                using (SaveFileDialog sfd = new SaveFileDialog())
                {
                    sfd.Filter = "Wav files|*.wav";
                    sfd.Title = "Save to a wave file";
                    if (sfd.ShowDialog() == DialogResult.OK)
                    {
                        FileStream fs = new FileStream(sfd.FileName, FileMode.Create, FileAccess.Write);
                        voice.SetOutputToWaveStream(fs);
                        voice.Speak(textBox1.Text);


                    }//if
                }//using
            }//
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Message", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }//catch
        }//save
    }
}
