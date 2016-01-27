using System;
using Microsoft.SPOT;

namespace NetduinoRGBLCDShield
{
    public static class ExtensionMethods
    {
        public static string GetName(this BacklightColor source)
        {
            switch (source)
            {
                case BacklightColor.Off:
                    return "Off";
                case BacklightColor.Red:
                    return "Red";
                case BacklightColor.Yellow:
                    return "Yellow";
                case BacklightColor.Green:
                    return "Green";
                case BacklightColor.Teal:
                    return "Teal";
                case BacklightColor.Blue:
                    return "Blue";
                case BacklightColor.Violet:
                    return "Violet";
                case BacklightColor.White:
                    return "White";
                default:
                    return "Undefined";
            }
        }

        public static BacklightColor GetBackLightColor(this string source)
        {
            switch (source.ToUpper())
            {
                case "OFF":
                    return BacklightColor.Off;
                case "RED":
                    return BacklightColor.Red;
                case "YELLOW":
                    return BacklightColor.Yellow;
                case "GREEN":
                    return BacklightColor.Green;
                case "TEAL":
                    return BacklightColor.Teal;
                case "BLUE":
                    return BacklightColor.Blue;
                case "VIOLET":
                    return BacklightColor.Violet;
                case "WHITE":
                    return BacklightColor.White;
                default:
                    return BacklightColor.Off;
            }
        }
    }
}
