using System;
using System.Net;
using System.Net.Sockets;
using System.Threading;
using Microsoft.SPOT;
using Microsoft.SPOT.Hardware;
using SecretLabs.NETMF.Hardware;
using SecretLabs.NETMF.Hardware.Netduino;

using NetduinoRGBLCDShield;
using Toolbox.NETMF.Hardware;


namespace NetduinoHelicoptorController
{
    public class Program
    {
        private static MCP23017 mcp23017 { get; set; }
        private static InterruptPort btnShield { get; set; }


        //Articles...
        /* http://www.codeproject.com/Articles/6786/C-Remote-Control-using-the-Audio-Port
         * https://highfieldtales.wordpress.com/2012/02/07/infrared-transmitter-driver-for-netduino/
         * http://www.sbprojects.com/knowledge/ir/index.php
         */

        public static void Main()
        {
            // write your code here
            mcp23017 = new MCP23017();//the MCP is what allows us to talk with the RGB LCD panel. I need it in this class so I can read the button presses from the User...

            //Setup the interrupt port for button presses from the LCD Shield. 
            //Here I have the Interrupt pin from the LCD Shield (configured in the MCP23017 class) going to the Netduino Digital Pin 5
            btnShield = new InterruptPort(Pins.GPIO_PIN_D5, true, Port.ResistorMode.Disabled, Port.InterruptMode.InterruptEdgeLow);
            // Bind the interrupt handler to the pin's interrupt event.
            btnShield.OnInterrupt += new NativeEventHandler(btnShield_OnInterrupt);

            //create the infrared transmitter driver
            //plugging in the IR LED (https://www.adafruit.com/products/387) into Digital Pin 8
            var irtx = new InfraredTransmitter(Pins.GPIO_PIN_D8);

            
        }

        public static void btnShield_OnInterrupt(UInt32 data1, UInt32 data2, DateTime time)
        {
            //Read the button pressed and send IR Commands based on them.
            //Note that an IR Sensor (https://learn.adafruit.com/ir-sensor/using-an-ir-sensor) could be used to decode the IR commands sent to the helicoptor...
        }
    }
}
