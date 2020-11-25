using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Speech.Recognition;
using System.Speech.Synthesis;
using System.Windows.Forms;
using System.Diagnostics;
using System.Runtime.Remoting.Contexts;

namespace DESKY
{
    class DeskyAI
    {
        
        private SpeechSynthesizer ss = new SpeechSynthesizer();
        private Choices list = new Choices();
        private SpeechRecognitionEngine sre = new SpeechRecognitionEngine();
        private String[] arrNavigation, arrMusic;
        private Grammar gr;
        private bool found, bNav, bMusic, bPercentange;
        private int x;
        private Form form; 

        public FormWindowState WindowState;

        public DeskyAI(FormWindowState ws, Form f, Boolean percentage)
        {
            form = f;
            WindowState=ws;
            ss.SelectVoiceByHints(VoiceGender.Female, VoiceAge.Child);
            arrNavigation = new String[26] {"Open anime","Open musicvideos","open music","Open games",
                "Open subdocs","Open pictures","Open comic work","open game work", "Go up","Go down",
                "Go left","Go right","Click enter","Backspace","Copy item","Cut item","Paste item",
                "Select item","Select all","Click tab","Delete item","Open options","Close window",
                "Open movies","Go to bottom","Go to top" };
            arrMusic = new string[] { "Load music","Play music","Pause music","Small skip","Medium skip",
                "Big skip","Small rewind","medium rewind","Big rewind","Volume up","Volume down",
                "Next track","Previous track","End vlc" };

            bNav = false;
            bMusic = false;
            bPercentange = percentage;
            list.Add(/*"turn on","Deactivate percentage mode","Terminate", "Minimize",
                "Maximize", "Normalize", */"Activate navigation mode",
                "Deactivate navigation mode", "Activate music mode", "Deactivate music mode", "Hello Desky");
            list.Add(arrNavigation);
            list.Add(arrMusic);
            gr = new Grammar(new GrammarBuilder(list));

            try
            {
                sre.RequestRecognizerUpdate();
                sre.LoadGrammar(gr);
                sre.SpeechRecognized += Sre_SpeechRecognized;
                sre.SetInputToDefaultAudioDevice();
                sre.RecognizeAsync(RecognizeMode.Multiple);
            }
            catch (Exception e)
            {
                ss.Speak(e.ToString());
            }
        }

        private void Sre_SpeechRecognized(object sender, SpeechRecognizedEventArgs e)
        {

            String r = e.Result.Text;
          /*  if (r.Equals("turn on") && !bPercentange)
            {
                PercentMode pm = new PercentMode();
                pm.Show();
                form.Hide();
                
            } else if (r.Equals("Deactivate percent mode") && !bPercentange)
            {
                DeskyMain mm = new DeskyMain();
                mm.Show();
                form.Hide();

            }
            else if (r.Equals("Minimize"))
            {
                WindowState = FormWindowState.Minimized;
            }
            else if (r.Equals("Maximize"))
            {
                WindowState = FormWindowState.Maximized;
            }
            else if (r.Equals("Normalize"))
            {
                WindowState = FormWindowState.Normal;
            }
            else*/ if (r.Equals("Terminate"))
            {
                Environment.Exit(0);
            }
            else if (r.Equals("Activate navigation mode"))
            {
                if (bNav == false)
                {
                    bNav = true;
                    say("Navigation mode activated");
                }
            }
            else if (r.Equals("Deactivate navigation mode"))
            {
                if (bNav == true)
                {
                    bNav = false;
                    say("Navigation mode deactivated");
                }
            }
            else if (r.Equals("Activate music mode"))
            {
                if (bMusic == false)
                {
                    bMusic = true;
                    say("Music mode activated");
                }
            }
            else if (r.Equals("Deactivate music mode"))
            {
                if (bMusic == true)
                {
                    bMusic = false;
                    say("Music mode deactivated");
                }
            }else if (r.Equals("Hello Desky"))
            {
                say("Hello Nolo");
            }

            if (bNav == true)
            {
                x = 0;
                found = false;
                while (x < arrNavigation.Length && found == false)
                {
                    if (r.Equals(arrNavigation[x]))
                    {
                        nvOptions(x + 1);
                        found = true;
                    }
                    x++;
                }
                found = false;
            }
            if (bMusic == true)
            {
                x = 0;
                found = false;
                while (x < arrMusic.Length && found == false)
                {
                    if (r.Equals(arrMusic[x]))
                    {
                        mucsicOptions(x + 1);
                        found = true;
                    }
                    x++;
                }
                found = false;
            }
        }

        //Navigation Mode Options
        public void nvOptions(int ind)
        {
            switch (ind)
            {

                case 1:
                    Process.Start(@"C:\Users\Lord NolZ\Videos\Anime and Cartoons");
                    break;
                case 2:
                    Process.Start(@"C:\Users\Lord NolZ\Videos\MUSIC VIDS");
                    break;
                case 3:
                    Process.Start(@"C:\Users\Lord NolZ\Music");
                    break;
                case 4:
                    Process.Start(@"C:\Games");
                    break;
                case 5:
                    Process.Start(@"C:\Users\Lord NolZ\Desktop\Sub Docs");
                    break;
                case 6:
                    Process.Start(@"C:\Users\Lord NolZ\Pictures");
                    break;
                case 7:
                    Process.Start(@"C:\Users\Lord NolZ\Desktop\DeadEnd Entertainment\Manga Stories\Stories");
                    break;
                case 8:
                    Process.Start(@"C:\Users\Lord NolZ\Desktop\DeadEnd Entertainment\Games");
                    break;
                case 9:
                    SendKeys.Send("{up}");
                    break;
                case 10:
                    SendKeys.Send("{down}");
                    break;
                case 11:
                    SendKeys.Send("{left}");
                    break;
                case 12:
                    SendKeys.Send("{right}");
                    break;
                case 13:
                    SendKeys.Send("{enter}");
                    break;
                case 14:
                    SendKeys.Send("{BACKSPACE}");
                    break;
                case 15:
                    SendKeys.Send("^c");
                    say("Item copied");
                    break;
                case 16:
                    SendKeys.Send("^x");
                    say("Item cut");
                    break;
                case 17:
                    SendKeys.Send("^v");
                    break;
                case 18:
                    SendKeys.Send(" ");
                    break;
                case 19:
                    SendKeys.Send("^a");
                    break;
                case 20:
                    SendKeys.Send("{tab}");
                    break;
                case 21:
                    SendKeys.Send("{del}");
                    break;
                case 22:
                    SendKeys.Send("+{f10}");
                    break;
                case 23:
                    SendKeys.Send("%{f4}");
                    break;
                case 24:
                    Process.Start(@"C:\Users\Lord NolZ\Videos\Movies");
                    break;
                case 25:
                    SendKeys.Send("{pgdn}");
                    break;
                case 26:
                    SendKeys.Send("{pgup}");
                    break;
            }
        }

        //Music Mode Options
        public void mucsicOptions(int ind)
        {
            switch (ind)
            {
                case 1:
                    Process.Start(@"C:\Users\Lord NolZ\Videos\MUSIC VIDS\Playlists\Alessia Cara.xspf");
                    break;
                case 2:
                    SendKeys.Send(" ");
                    break;
                case 3:
                    SendKeys.Send(" ");
                    break;
                case 4:
                    SendKeys.Send("+{right}");
                    break;
                case 5:
                    SendKeys.Send("%{right}");
                    break;
                case 6:
                    SendKeys.Send("^{right}");
                    break;
                case 7:
                    SendKeys.Send("+{left}");
                    break;
                case 8:
                    SendKeys.Send("%{left}");
                    break;
                case 9:
                    SendKeys.Send("^{left}");
                    break;
                case 10:
                    SendKeys.Send("^{up}");
                    break;
                case 11:
                    SendKeys.Send("^{down}");
                    break;
                case 12:
                    SendKeys.Send("n");
                    break;
                case 13:
                    SendKeys.Send("p");
                    break;
                case 14:
                    killprog("vlc");
                    break;
            }
        }

        //Responder
        public void say(String s)
        {
            ss.Speak(s);
        }

        //Program killer
        public void killprog(String s)
        {
            System.Diagnostics.Process[] procs = Process.GetProcessesByName(s);
            try
            {
                Process prog;

                prog = procs[0];

                if (!prog.HasExited)
                {
                    prog.Kill();
                }
            }
            catch (Exception e)
            {
                say(e.Message);
            }
            finally
            {
                if (procs != null)
                {
                    foreach (Process p in procs)
                    {
                        p.Dispose();
                    }
                }
            }
        }
    }

}

