using GHIElectronics.TinyCLR.BrainPad;
using System.Diagnostics;
using System.Threading;

namespace Roulette
{
    [DebuggerNonUserCode]
    public class Startup
    {
        public static void Main()
        {
            var p = new Program();

            p.BrainPadSetup();

            while (true)
            {
                p.BrainPadLoop();

                Thread.Sleep(10);
            }
        }
    }

    [DebuggerNonUserCode]
    public static class BrainPad
    {
        public static void WriteToComputer(string message) => Debug.WriteLine(message);
        public static void WriteToComputer(int message) => BrainPad.WriteToComputer(message.ToString("N0"));
        public static void WriteToComputer(double message) => BrainPad.WriteToComputer(message.ToString("N4"));

        public static Accelerometer Accelerometer { get; } = new Accelerometer();
        public static Buttons Buttons { get; } = new Buttons();
        public static Buzzer Buzzer { get; } = new Buzzer();
        public static Display Display { get; } = new Display();
        public static LightBulb LightBulb { get; } = new LightBulb();
        public static LightSensor LightSensor { get; } = new LightSensor();
        public static ServoMotors ServoMotors { get; } = new ServoMotors();
        public static TemperatureSensor TemperatureSensor { get; } = new TemperatureSensor();
        public static Wait Wait { get; } = new Wait();

        public static class Expansion
        {
            public static class GpioPin
            {
                public const string Id = "GHIElectronics.TinyCLR.NativeApis.STM32F4.GpioProvider\\0";
                public const int Mosi = 21;
                public const int Miso = 20;
                public const int Sck = 19;
                public const int Cs = 35;
                public const int Rst = 6;
                public const int An = 7;
                public const int Pwm = 8;
                public const int Int = 2;
                public const int Rx = 10;
                public const int Tx = 9;
            }

            public static class AdcChannel
            {
                public const string Id = "GHIElectronics.TinyCLR.NativeApis.STM32F4.AdcProvider\\0";
                public const int An = 7;
                public const int Rst = 6;
                public const int Cs = 13;
                public const int Int = 2;
            }

            public static class PwmPin
            {
                public static class Controller1
                {
                    public const string Id = "GHIElectronics.TinyCLR.NativeApis.STM32F4.PwmProvider\\0";
                    public const int Pwm = 0;
                    public const int Rx = 2;
                    public const int Tx = 1;
                }

                public static class Controller2
                {
                    public const string Id = "GHIElectronics.TinyCLR.NativeApis.STM32F4.PwmProvider\\1";
                    public const int Int = 2;
                }
            }

            public static class UartPort
            {
                public const string Usart1 = "GHIElectronics.TinyCLR.NativeApis.STM32F4.UartProvider\\0";
            }

            public static class I2cBus
            {
                public const string I2c1 = "GHIElectronics.TinyCLR.NativeApis.STM32F4.I2cProvider\\0";
            }

            public static class SpiBus
            {
                public const string Spi1 = "GHIElectronics.TinyCLR.NativeApis.STM32F4.SpiProvider\\0";
            }
        }
    }
}
