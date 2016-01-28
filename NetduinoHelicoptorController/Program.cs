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
        private static InfraredTransmitter irtx { get; set; }

        //Articles...
        /* http://www.codeproject.com/Articles/6786/C-Remote-Control-using-the-Audio-Port
         * https://highfieldtales.wordpress.com/2012/02/07/infrared-transmitter-driver-for-netduino/
         * http://www.sbprojects.com/knowledge/ir/index.php
         * http://www.kerrywong.com/2012/08/27/reverse-engineering-the-syma-s107g-ir-protocol/
         * https://learn.adafruit.com/ir-sensor/using-an-ir-sensor
         */

        public static void Main()
        {
            //the MCP is what allows us to talk with the RGB LCD panel. I need it in this class so I can read the button presses from the User...
            mcp23017 = new MCP23017();

            //Setup the interrupt port for button presses from the LCD Shield. 
            //Here I have the Interrupt pin from the LCD Shield (configured in the MCP23017 class) going to the Netduino Digital Pin 5
            btnShield = new InterruptPort(Pins.GPIO_PIN_D5, true, Port.ResistorMode.Disabled, Port.InterruptMode.InterruptEdgeLow);
            // Bind the interrupt handler to the pin's interrupt event.
            btnShield.OnInterrupt += new NativeEventHandler(btnShield_OnInterrupt);

            //create the infrared transmitter driver
            //plugging in the IR LED (https://www.adafruit.com/products/387) into Digital Pin 8
            irtx = new InfraredTransmitter(Pins.GPIO_PIN_D8);

            //We are done. The thread must sleep or else the netduino turns off...
            Thread.Sleep(Timeout.Infinite);
        }

        public static void btnShield_OnInterrupt(UInt32 data1, UInt32 data2, DateTime time)
        {
            //Read the button pressed and send IR Commands based on them.

            var ButtonPressed = mcp23017.ReadGpioAB();

            var InterruptBits = BitConverter.GetBytes(ButtonPressed);

            /*Perform bitwise AND (&) against the interrupt bits using a mask that masks out the pertinant bits*/
            var ButtonValue = (InterruptBits[0] & 0x1F);
                if (ButtonValue == 0)
                    return;
                Debug.Print("Pressed Button Value is: " + ButtonValue);
                switch ((NetduinoRGBLCDShield.Button)ButtonValue)
                {
                    case NetduinoRGBLCDShield.Button.Left:

                        break;
                    case NetduinoRGBLCDShield.Button.Right:

                        break;
                    case NetduinoRGBLCDShield.Button.Up:

                        break;
                    case NetduinoRGBLCDShield.Button.Down:

                        break;
                    case NetduinoRGBLCDShield.Button.Select:

                        break;
                    default:
                        Debug.Print("Unrecognized Button...");
                        throw new Exception("Unrecognized Button Pressed");
                }
        }
    }
}
