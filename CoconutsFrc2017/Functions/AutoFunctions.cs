﻿using CoconutsFrc2017.Functions;
using CTRE;
using System;
using System.Diagnostics;
using System.Threading;
using WPILib.SmartDashboard;
using static CTRE.CANTalon;

namespace CoconutsFrc2017
{
    static class AutoFunctions
    {
        /// <summary>
        /// Drives the specified distance.
        /// Enter a negative amount to drive backwards.
        /// </summary>
        /// <param name="desiredDistance">Distance in meters.</param>
        public static void Drive(double desiredDistance)
        {
            RobotMap.Left1.MotorControlMode  = WPILib.Interfaces.ControlMode.Position;
            RobotMap.Right1.MotorControlMode = WPILib.Interfaces.ControlMode.Position;

            // Converts meters to inches.
            double desiredInches = 39.3701 * desiredDistance;

            // Converts inches to rotations.
            double rotations = desiredInches / 3.29; // 3.29 inches per rotation.

            // Drive with the specified distance.
            DriveRotations(rotations);
        }

        static int runs = 0;

        /// <summary>
        /// Drive the specified rotations.
        /// </summary>
        /// <param name="rotations">Number of rotations.</param>
        public static void DriveRotations(double rotations)
        {
            runs++;
            SmartDashboard.PutNumber("Runs", runs);
            // Set the motors to go to the specified rotation amount.
            RobotMap.Left1.Set (RobotMap.Left1.Get() + rotations);
            // RobotMap.Left2.Set (RobotMap.Left1.Get() + rotations); // Commented out due to Left2  being a slave of Left1.
            RobotMap.Right1.Set(RobotMap.Left1.Get() + rotations);
            // RobotMap.Right2.Set(RobotMap.Left1.Get() + rotations); // Commented out due to Right2 being a slabe of Right2.
            SmartDashboard.PutString("DriveRotations", "Exiting loop.");
            bool leftHit  = false;
            bool rightHit = false;
            while(Math.Abs(RobotMap.Left1.GetClosedLoopError()) > 100) { }
            //while (!leftHit && !rightHit)
            //{
            //    if ((Math.Abs(RobotMap.Left1.GetClosedLoopError())  < 100))
            //        leftHit  = true;
            //    if ((Math.Abs(RobotMap.Right1.GetClosedLoopError()) < 100))
            //        rightHit = true;
            //    SmartDashboard.PutString("DriveRotations", "Stuck in loop.");
            //    SmartDashboard.PutNumber("Left Error",    RobotMap.Left1.GetClosedLoopError());
            //    SmartDashboard.PutNumber("Left Encoder",  RobotMap.Left1.GetEncoderPosition());
            //    SmartDashboard.PutNumber("Right Error",   RobotMap.Right1.GetClosedLoopError());
            //    SmartDashboard.PutNumber("Right Encoder", RobotMap.Right1.GetEncoderPosition());
            //}
            SmartDashboard.PutString("DriveRotations", "Exiting loop.");
            // Reset encoder positions.
            //RobotMap.Left1.SetEncoderPostition (0);
            //RobotMap.Right1.SetEncoderPostition(0);
            SmartDashboard.PutNumber("Right Encoder", RobotMap.Right1.GetEncoderPosition());
            SmartDashboard.PutNumber("Left Encoder",   RobotMap.Left1.GetEncoderPosition());
        }

        /// <summary>
        /// Sets the talon to run at the given rpm.
        /// </summary>
        /// <param name="rpm">Amount of RPMs to run the motor at.</param>
        /// <param name="talon">Which talon to run.</param>
        public static void SetVelocity(double rpm, CANTalon talon)
        {
            talon.Set(rpm);
        }

        public static void SetTurntable(int position)
        {
            RobotMap.TurntableController.Controller.Setpoint = position;
            RobotMap.TurntableController.Controller.Enable();
        }

        /// <summary>
        /// Drive to the desired angle.
        /// </summary>
        /// <param name="desiredAngle">Desired angle from -180 to 180.</param>
        public static void TurnToAngle(double desiredAngle)
        {
            ConfigureTalon(RobotMap.Left1, ConfigureType.Normal);
            ConfigureTalon(RobotMap.Right1, ConfigureType.Normal);
            // Set the controller setpoint to the desired angle.
            RobotMap.TurnController.Controller.Setpoint = desiredAngle;
            // Enables the controller.
            RobotMap.TurnController.Controller.Enable();
            // Keeps the robot in a loop until it is on target.
            while (RobotMap.TurnController.Controller.OnTarget() == false) { SmartDashboard.PutBoolean("On Target?", RobotMap.TurnController.Controller.OnTarget()); }
            SmartDashboard.PutBoolean("On Target?", RobotMap.TurnController.Controller.OnTarget());
            // Disables the controller since we are on target.
            RobotMap.TurnController.Controller.Disable();
        }

        /// <summary>
        /// Place the gear on the peg.
        /// </summary>
        public static void PlaceGear()
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Shoot fuel into the boiler for 5 seconds.
        /// </summary>
        public static void ShootFuel()
        {
            ShootFuel(5000);
        }

        /// <summary>
        /// Align to the target then shoot for the supplied amount of time.
        /// </summary>
        /// <param name="TimeFor">Once at the target, shoot for the supplied time in milliseconds.</param>
        public static void ShootFuel(long TimeFor)
        {
            // Creates a new stopwatch.
            Stopwatch sw = new Stopwatch();
            // Run the shooter at 1500 RPM.
            RobotMap.Shooter.Set(1500);
            // Allow the motors to rev up.
            Thread.Sleep(250);
            // Starts the stopwatch for timing.
            sw.Start();

            // Shoot while the stopwatch is under this time.
            while (sw.ElapsedMilliseconds <= TimeFor)
            {
                // Put the turntable code in here for aligning.
            }

            // Stop the shooter.
            RobotMap.Shooter.Set(0);
        }

        /// <summary>
        /// Configure the desired talon for closed-loop control.
        /// Uses the default configuration parameters.
        /// </summary>
        /// <param name="talon">The talon to configure.</param>
        /// <param name="type">Configure the talon for velocity or positional control.</param>
        public static void ConfigureTalon(CANTalon talon, ConfigureType type)
        {
            switch (type)
            {
                case ConfigureType.Position:
                    EncoderParameters parametersPosition = new EncoderParameters
                    {
                        Device         = FeedbackDevice.CtreMagEncoderRelative,
                        ReverseSensor  = true,
                        PIDFValues     = new PIDF
                        {
                            kP = 0.02,
                            kI = 0.00,
                            kD = 0.00,
                            kF = 0.00
                        },
                        AllowedError   = 1,
                        NominalVoltage = 0f,
                        PeakVoltage    = 12f
                    };

                    ConfigureTalon(talon, type, parametersPosition);

                    break;

                case ConfigureType.Velocity:

                    EncoderParameters parametersVelocity = new EncoderParameters
                    {
                        Device = FeedbackDevice.CtreMagEncoderRelative,
                        ReverseSensor = true,
                        PIDFValues = new Functions.PIDF
                        {
                            kP = 0.02,
                            kI = 0.00,
                            kD = 0.00,
                            kF = 0.00
                        },
                        AllowedError = 1,
                        NominalVoltage = 0f,
                        PeakVoltage = 12f
                    };

                    ConfigureTalon(talon, type, parametersVelocity);
                    break;

                case ConfigureType.Normal:

                    talon.MotorControlMode = WPILib.Interfaces.ControlMode.PercentVbus;

                    break;
            }
        }

        /// <summary>
        /// Configure the desired talon for closed-loop control.
        /// </summary>
        /// <param name="talon">The talon to configure.</param>
        /// <param name="type">Configure the talon for velocity or positional control.</param>
        /// <param name="parameters">Set the settings for the talon. Some</param>
        public static void ConfigureTalon(CANTalon talon, ConfigureType type, EncoderParameters parameters)
        {
            // Grab the 360 degree of the magnetic encoder's absolute position.
            int absolutePosition = talon.GetPulseWidthPosition() & 0xFFF; // Throw out the bits dealing with wrap-arounds.

            // Set the encoder's signal.
            talon.SetEncoderPostition(absolutePosition);

            // Set the sensor and direction.
            talon.FeedBackDevice = parameters.Device;
            talon.ReverseSensor(parameters.ReverseSensor);

            // Set the peak and nominal outputs. +12V is full throttle forward, -12V is full throttle backwards.
            talon.ConfigNominalOutputVoltage(+parameters.NominalVoltage, -parameters.NominalVoltage);
            talon.ConfigPeakOutputVoltage(+parameters.PeakVoltage, -parameters.PeakVoltage);

            // Set the allowed closed-loop error.
            talon.SetAllowableClosedLoopErr(parameters.AllowedError);

            // Set the PIDF gains.
            talon.Profile = parameters.PIDProfile; // Sets the current profile for saving the variables.
            talon.P = parameters.PIDFValues.kP; // Sets the proportional gain.
            talon.I = parameters.PIDFValues.kI; // Sets the integral gain.
            talon.D = parameters.PIDFValues.kD; // Sets the derivative gain.
            talon.F = parameters.PIDFValues.kF; // Sets the filter gain.

            // Switches how to configure the talon based on the 'type' parameter.
            switch (type)
            {
                // Run the positional config.
                case ConfigureType.Position:

                    // Set the talon to be in positional control mode.
                    talon.MotorControlMode = WPILib.Interfaces.ControlMode.Position;

                    break;

                // Run the velocity config.
                case ConfigureType.Velocity:

                    // Set the talon to be in speed control mode.
                    talon.MotorControlMode = WPILib.Interfaces.ControlMode.Speed;

                    break;

                case ConfigureType.Normal:

                    talon.MotorControlMode = WPILib.Interfaces.ControlMode.PercentVbus;

                    break;
            }
        }
    }

    /// <summary>
    /// Parameters for defining encoder settings with the CAN Talon.
    /// Not all options are required.
    /// See the CTRE documentation for more information.
    /// </summary>
    public struct EncoderParameters
    {
        /// <summary>
        /// Defines how many counts there are per revolution.
        /// </summary>
        public int CountsPerRevolution { get; set; }

        /// <summary>
        /// Determines the type of device to be used.
        /// </summary>
        /// <seealso cref="FeedbackDevice"/>
        public FeedbackDevice Device { get; set; }

        /// <summary>
        /// Reverses the direction that the sensor is reading in.
        /// </summary>
        public bool ReverseSensor { get; set; }

        /// <summary>
        /// Holds the PIDF values for the sensor.
        /// </summary>
        public Functions.PIDF PIDFValues { get; set; }

        /// <summary>
        /// Profile for the PID settings to be saved to.
        /// Written to the Talon itself. (Check this?)
        /// </summary>
        public int PIDProfile { get; set; }
        
        /// <summary>
        /// Configures the normal voltage.
        /// Will be negated for a min/max.
        /// </summary>
        public double NominalVoltage { get; set; }

        /// <summary>
        /// Configures the max voltage.
        /// Will be negated for a min/max.
        /// </summary>
        public double PeakVoltage { get; set; }

        /// <summary>
        /// Sets the tolerable error before the controller stops.
        /// Is an absolute measure!
        /// </summary>
        public int AllowedError { get; set; }
    }

    /// <summary>
    /// Parameters for positional control. This code is deprecated.
    /// </summary>
    /// <remarks>Please use <see cref="EncoderParameters"/> instead.</remarks>
    [Obsolete("PositionParameters is deprecated, please use EncoderParameters instead.")]
    public struct PositionParameters
    {
        /// <summary>
        /// Determines the type of device to be used.
        /// </summary>
        /// <seealso cref="FeedbackDevice"/>
        public FeedbackDevice Device     { get; set; }

        /// <summary>
        /// Reverses the direction that the sensor is reading in.
        /// </summary>
        public bool ReverseSensor        { get; set; }

        /// <summary>
        /// Holds the PIDF values for the sensor.
        /// </summary>
        public Functions.PIDF PIDFValues { get; set; } 

        /// <summary>
        /// Configures the normal voltage.
        /// Will be negated for a min/max.
        /// </summary>
        public double NominalVoltage     { get; set; }

        /// <summary>
        /// Configures the max voltage.
        /// Will be negated for a min/max.
        /// </summary>
        public double PeakVoltage        { get; set; }

        /// <summary>
        /// Sets the tolerable error before the controller stops.
        /// Is an absolute measure!
        /// </summary>
        public double AllowedError       { get; set; }
    }

    /// <summary>
    /// Type of configuration to set. Allows for switching between velocity and positional control.
    /// </summary>
    public enum ConfigureType
    {
        /// <summary>
        /// Allows for manipulation of the position of the motor.
        /// </summary>
        Position,
        /// <summary>
        /// Allows for maintaining a specific RPM of the motor.
        /// </summary>
        Velocity,
        Normal
    }
}
