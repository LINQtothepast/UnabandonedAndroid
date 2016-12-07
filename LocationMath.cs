using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UnAbandoned
{
    public class LocationMath
    {

        //Calculates the distance with defaults for Northside Hall
        public static double CalcDistance(double toX, double toY,
                                          double fromX = 41.662500,
                                          double fromY = -86.219508)
        {
            double milesAtEq = 69.172;

            fromX = Math.Abs(fromX);
            fromY = Math.Abs(fromY);
            toX = Math.Abs(toX);
            toY = Math.Abs(toY);

            double diffX = Math.Abs(fromX - toX);
            double diffY = Math.Abs(fromY - toY);

            double distX = diffX * milesAtEq;
            double distY = diffY * (Math.Cos(fromX) * milesAtEq);

            double distance = distX * distX + distY * distY;

            return Math.Sqrt(distance);
        }

        //Formats the string to one decimal place
        public static string FormatDistance(double distance)
        {
            return distance.ToString("N" + 1);
        }
    }
}