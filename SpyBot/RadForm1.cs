using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Threading;
using XInputDotNetPure;
using nsoftware.IPWorksWS;

namespace SpyBot
{
    public partial class RadForm1 : Telerik.WinControls.UI.RadForm
    {
        //The following variables are used across several threads
        float shared_left_trig = 0;
        float shared_left_stick_x = 0;
        float shared_left_stick_y = 0;
        float shared_right_trig = 0;
        float shared_right_stick_x = 0;
        float shared_right_stick_y = 0;

        int shared_A = 0;
        int shared_B = 0;
        int shared_X = 0;
        int shared_Y = 0;

        int shared_dpad_up = 0;
        int shared_dpad_down = 0;
        int shared_dpad_left = 0;
        int shared_dpad_right = 0;

        int shared_left_shoulder = 0;
        int shared_right_shoulder = 0;

        //int rumble = 0;

        float shared_throttle = 500;
        string throttle;
        float shared_steer = 500;
        string steer;

        int steering_mode = 0;
        int throttle_mode = 0;
        int camera_position_flag = 1;

        float shared_cam_pan = 200;
        string cam_pan;
        float shared_cam_tilt = 200;
        string cam_tilt;

        string dataout;

        int headlights = 0;
        int light_brightness = 5;
        int light_sequence = 0;
        int slowmode = 0;
        string headlights_string;
        string slowmode_string;

        //counters used for managing the toggling of car functions
        //eg headlights or slow mode. These counters are used to stop repeated toggling on/off
        //if the xbox controller button is held down too long
        int samplecount = 0;
        int oldsamplecount1 = 0;
        int rumblecount = 0;

        public RadForm1()
        {
            InitializeComponent();
        }

        private void RadForm1_Load(object sender, EventArgs e)
        {
            //Thread for handling Xbox 360 controller
            Thread updatecontroller = new Thread(new ThreadStart(UpdateState));
            updatecontroller.IsBackground = true;
            updatecontroller.Start();

            //Thread for handling Websocket communications
            Thread updateIO = new Thread(new ThreadStart(UpdateWSClient));
            updateIO.IsBackground = true;
            updateIO.Start();       
        }

        //---------------------------------------------------------------------------------------------------------
        //The following section contains code for handling the Xbox360 controller
        //---------------------------------------------------------------------------------------------------------

        //Delegates are required so that the background thread can update data in the GUI thread
        //See tutorials on C# cross thread operations for more details
        private delegate void left_trig_delegate(float i);
        private delegate void left_stick_x_delegate(float i);
        private delegate void left_stick_y_delegate(float i);

        private delegate void right_trig_delegate(float i);
        private delegate void right_stick_x_delegate(float i);
        private delegate void right_stick_y_delegate(float i);

        private delegate void left_shoulder_delegate(int status);
        private delegate void right_shoulder_delegate(int status);

        private delegate void dpad_up_delegate(int status);
        private delegate void dpad_down_delegate(int status);
        private delegate void dpad_left_delegate(int status);
        private delegate void dpad_right_delegate(int status);

        private delegate void button_A_delegate(int status);
        private delegate void button_B_delegate(int status);
        private delegate void button_X_delegate(int status);
        private delegate void button_Y_delegate(int status);

        //private delegate void slowmode_delegate(int status);
        //private delegate void headlights_delegate(int status);
        //private delegate void brightness_delegate(int status);
        //private delegate void sequence_delegate(int status);
        //private delegate void rumble_delegate(int status);

        private void UpdateState()
        {
            while (true)
            {
                GamePadState state = GamePad.GetState(PlayerIndex.One);

                //Read analog control values and save into shared variables
                //Left/right triggers and left thumbstick (x-axis only) also have a process function to change
                //the behaviour of the controls between linear/squared/cubed modes.
                //Squared and cubed gives more control for low speed / small steering angles

                shared_left_trig = state.Triggers.Left;
                //shared_left_trig = process_raw_throttle_data(shared_left_trig);
                left_trig_value.Invoke(new left_trig_delegate(display_left_trig), shared_left_trig);

                shared_left_stick_x = state.ThumbSticks.Left.X;
                //shared_left_stick_x = process_raw_steer_data(shared_left_stick_x);
                left_stick_x_value.Invoke(new left_stick_x_delegate(display_left_stick_x), shared_left_stick_x);

                shared_left_stick_y = state.ThumbSticks.Left.Y;
                left_stick_y_value.Invoke(new left_stick_y_delegate(display_left_stick_y), shared_left_stick_y);





                //The following 'invokes' update the GUI with the various button statuses

                //left_shoulder_status.Invoke(new left_shoulder_delegate(display_left_shoulder), shared_left_shoulder);
                //right_shoulder_status.Invoke(new right_shoulder_delegate(display_right_shoulder), shared_right_shoulder);
                //dpad_up_status.Invoke(new dpad_up_delegate(display_dpad_up), shared_dpad_up);
                //dpad_down_status.Invoke(new dpad_down_delegate(display_dpad_down), shared_dpad_down);
                //dpad_left_status.Invoke(new dpad_left_delegate(display_dpad_left), shared_dpad_left);
                //dpad_right_status.Invoke(new dpad_right_delegate(display_dpad_right), shared_dpad_right);
                //A_button_status.Invoke(new button_A_delegate(display_button_A), shared_A);
                //B_button_status.Invoke(new button_B_delegate(display_button_B), shared_B);
                //X_button_status.Invoke(new button_X_delegate(display_button_X), shared_X);
                //Y_button_status.Invoke(new button_Y_delegate(display_button_Y), shared_Y);

                //Update other GUI statuses
                //slowmode_status.Invoke(new slowmode_delegate(display_slowmode), slowmode);
                //headlights_status.Invoke(new headlights_delegate(display_headlights), headlights);
                //brightness_status.Invoke(new brightness_delegate(display_brightness), light_brightness);
                //sequence_status.Invoke(new sequence_delegate(display_sequence), light_sequence);
                //rumble_status_textbox.Invoke(new rumble_delegate(display_rumble), rumblecount);


                //Put a limit on how frequently this updates
                Thread.Sleep(20);

                //Frame counter for managing repeated on/off toggling of car functions
                //For example, this counter is used for the headlight on/off toggle, to stop it
                //turning on/off continuously when the button is held down.
                samplecount++;
                //manually reset counter if it gets large
                if (samplecount > 2000000000)
                {
                    samplecount = 0;
                }



            }
        }

        //Functions for use with the delegates
        private void display_left_trig(float i)
        {
            left_trig_value.Text = String.Format("{0:0.000}", i);
            if (i == 0)
            {
                //left_trig_value.BackColor = Color.Black;
            }
            else
            {
                //left_trig_value.BackColor = Color.Orange;
            }
        }

        private void display_left_stick_x(float i)
        {
            left_stick_x_value.Text = String.Format("{0:0.000}", i);
            if (i == 0)
            {
                //left_stick_x_value.BackColor = Color.LightBlue;
            }
            else
            {
                //left_stick_x_value.BackColor = Color.Orange;
            }
        }

        private void display_left_stick_y(float i)
        {
            left_stick_y_value.Text = String.Format("{0:0.000}", i);
            if (i == 0)
            {
                //left_stick_y_value.BackColor = Color.LightBlue;
            }
            else
            {
                //left_stick_y_value.BackColor = Color.Orange;
            }
        }

        //---------------------------------------------------------------------------------------------------------
        //The following section contains code for WebSocket operations
        //---------------------------------------------------------------------------------------------------------

        private void UpdateWSClient()
        {
            //WebSocket operations
            //polling function

            //float ltrig = shared_left_trig;
            //float lstickx = shared_left_stick_x;
            //float lsticky = shared_left_stick_y;

            while (true)
            {
                if (wsclient.Connected)
                {

                    if (shared_left_trig != 0 || shared_left_stick_x != 0 || shared_left_stick_y != 0)
                    {


                        //tbEcho.AppendText("Sending.\r\n");
                        try
                        {
                            //wsclient.DataToSend = left_trig_value.Text.ToString();
                            //        wsclient.DataToSend = throttle;
                            wsclient.DataToSend = shared_left_trig.ToString() + " " + shared_left_stick_x.ToString() + " " + shared_left_stick_y.ToString();


                        }
                        catch (IPWorksWSException ipwse)
                        {
                            //        //tbEcho.AppendText("Failed to send. Reason: " + ipwse.Message + ".\r\n");
                        }
                    }

                    else
                    {
                        try
                        {
                            string xxx = "0";
                            wsclient.DataToSend = xxx + " " + xxx + " " + xxx;

                        }
                        catch (IPWorksWSException ipwse)
                        {
                            //        //tbEcho.AppendText("Failed to send. Reason: " + ipwse.Message + ".\r\n");
                        }
                        
                    }
                }
                else
                {
                    //    //tbEcho.AppendText("You are not connected.\r\n");
                }
                if (wsclient.Connected == false)
                {
                    Thread.Sleep(20);
                }

                Thread.Sleep(10);

            }

        }

        

        private void wsclient_OnConnected(object sender, WsclientConnectedEventArgs e)
        {

        }

        private void wsclient_OnDataIn(object sender, WsclientDataInEventArgs e)
        {

        }

        private void wsclient_OnDisconnected(object sender, WsclientDisconnectedEventArgs e)
        {

        }

        private void connect_wsclient_button_Click(object sender, EventArgs e)
        {
            connect_wsclient_button.Enabled = false;
            try
            {
                if (connect_wsclient_button.Text == "Connect")
                {
                    wsclient.Timeout = 10;
                    wsclient.InvokeThrough = this;

                    wsclient.Connect(tbServer.Text);
                    connect_wsclient_button.Text = "Disconnect";
                }
                else
                {
                    wsclient.Disconnect();
                }
            }
            catch (IPWorksWSException ipwse)
            {
                MessageBox.Show(this, ipwse.Message, "Error", MessageBoxButtons.OK);
                connect_wsclient_button.Text = "Connect";
                connect_wsclient_button.Enabled = true;
            }

        }

        private void bSend_Click(object sender, EventArgs e)
        {
            if (wsclient.Connected)
            {
                tbEcho.AppendText("Sending '" + left_trig_value.Text + "'.\r\n");

                try
                {
                    //String value = trackBar1.Value.ToString();
                    //wsclient2.DataFormat.dfText = 1;


                    //wsclient2.DataFormat[1];

                    //wsclient2.DataToSend = trackBar1.Value.ToString() + " " + tbText.Text;
                    wsclient.DataToSend = left_trig_value.Text.ToString();
                }
                catch (IPWorksWSException ipwse)
                {
                    //tbEcho.AppendText("Failed to send '" + tbText.Text + "'. Reason: " + ipwse.Message + ".\r\n");
                    tbEcho.AppendText("Failed to send - Reason: " + ipwse.Message + ".\r\n");
                }
            }
            else
            {
                tbEcho.AppendText("You are not connected.\r\n");
            }
        }
    }
}
