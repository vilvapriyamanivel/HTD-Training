using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assessment3
{
    using System;

    // MobilePhone class
    class MobilePhone
    {
        public delegate void RingEventHandler();
        public event RingEventHandler OnRing;
        public void ReceiveCall()
        {
            Console.WriteLine("Incoming call received...\n");

            if (OnRing != null)
            {
                OnRing();
            }
        }
    }

    //Subscriber Classes

    class RingtonePlayer
    {
        public void PlayRingtone()
        {
            Console.WriteLine("Playing ringtone...");
        }
    }

    class ScreenDisplay
    {
        public void DisplayCallerInfo()
        {
            Console.WriteLine("Displaying caller information...");
        }
    }

    class VibrationMotor
    {
        public void Vibrate()
        {
            Console.WriteLine("Phone is vibrating...");
        }
    }

    //  Main Method
    class Program3
    {
        static void Main()
        {
            MobilePhone phone = new MobilePhone();

            RingtonePlayer ringtone = new RingtonePlayer();
            ScreenDisplay screen = new ScreenDisplay();
            VibrationMotor vibration = new VibrationMotor();

            // Subscribe to event
            phone.OnRing += ringtone.PlayRingtone;
            phone.OnRing += screen.DisplayCallerInfo;
            phone.OnRing += vibration.Vibrate;

            // Simulate incoming call
            phone.ReceiveCall();
        }
    }
}
