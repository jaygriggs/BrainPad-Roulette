using GHIElectronics.TinyCLR.BrainPad;

namespace Roulette
{
    class Program
    {
        static SpiDevice spi;
        static GpioPin mr;
        static int count;
        static byte[] data;

        public void BrainPadSetup()
        {
            //Put your setup code here. It runs once when the BrainPad starts up.

            SpiConnectionSettings settings = new SpiConnectionSettings(FEZ.GpioPin.D10)
            {
                ClockFrequency = 12 * 1000 * 1000,
                DataBitLength = 8,
                Mode = SpiMode.Mode0

            };

            spi = SpiDevice.FromId(BrainPad.Expansion.SpiBus.Spi1, settings);
            mr = GpioController.GetDefault().OpenPin(FEZ.GpioPin.A3);
            mr.SetDriveMode(GpioPinDriveMode.Output);
            mr.Write(GpioPinValue.High);
            count = 1;
            data = new byte[4];


            while (true)
            {
                count <<= 1;
                if (count == 0)
                    count = 1;

                data[0] = (byte)(count >> 0);
                data[1] = (byte)(count >> 8);
                data[2] = (byte)(count >> 8 + 8);
                data[3] = (byte)(count >> 8 + 8 + 8);
                spi.Write(data);

                System.Threading.Thread.Sleep(20);

            }
        }

        public void BrainPadLoop()
        {
            //Put your program code here. It runs repeatedly after the BrainPad starts up.

            BrainPad.LightBulb.TurnWhite();
            BrainPad.Wait.Seconds(1);
            BrainPad.LightBulb.TurnOff();
            BrainPad.Wait.Seconds(1);
        }
    }
}
