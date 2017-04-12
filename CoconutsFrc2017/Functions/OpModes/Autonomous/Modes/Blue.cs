﻿using System;
using System.Diagnostics;
using WPILib.SmartDashboard;

namespace CoconutsFrc2017
{
    /// <summary>
    /// Runs the red one autonomous.
    /// Places the gear, drives to the boiler, shoots, and goes to a hopper. Woo!
    /// Align to the RED 1 driver station, three feet from the left.
    /// </summary>
    class Blue1 : IAuto
    {
        public void Run()
        {
            //// Place the gear.
            //AutoFunctions.Drive(1.6418);       // Drive forward 1.6418 meters.
            //AutoFunctions.TurnToAngle(-30);   // Turn to -30 degrees.
            //AutoFunctions.Drive(0.96);         // Drive forward 0.96 meters to align at gear peg.
            //AutoFunctions.PlaceGear();         // Place the gear. This might incorporate vision. Currently does not.

            //// Drive to the boiler and shoot.
            //AutoFunctions.Drive(-0.96);        // Drive 0.96 meters backwards away from gear peg.
            //AutoFunctions.TurnToAngle(0);      // Turn to 0 degrees.
            //AutoFunctions.Drive(-0.7);         // Drive backwards -0.7 meters to clear airship for driving.
            //AutoFunctions.TurnToAngle(133.74); // Turn to 133.74 degrees.
            //AutoFunctions.Drive(6.5);          // Drive 6.5 meters forward to the boiler. NEEDS CLARIFICATION FROM LOGAN.
            //AutoFunctions.ShootFuel();         // Shoot fuel. This might incorporate vision. Currently does not.

            //// Drive to a hopper.
            //AutoFunctions.Drive(-2.1);         // Back out of the boiler by driving back 2.1 meters.
            //AutoFunctions.TurnToAngle(33.03);  // Turn to 33.03 degrees.
            //AutoFunctions.Drive(1.5);          // Drive forward 1.5 meteres to the hopper.
            //AutoFunctions.TurnToAngle(90);     // Turn to 90 degrees, which is perpendicular to the perimeter.
            //AutoFunctions.Drive(1.275);        // Drive forward 1.275 meters to the hopper.

            AutoFunctions.Drive(2.8);
            Stopwatch stop = new Stopwatch();
            stop.Start();
            while (AutoFunctions.OnTarget() || stop.ElapsedMilliseconds < 8000)
            {
                SmartDashboard.PutBoolean("In loop?", true);
                SmartDashboard.PutNumber("Left Position", RobotMap.Left1.GetEncoderPosition());
                SmartDashboard.PutNumber("Right Position", RobotMap.Right1.GetEncoderPosition());
            }
            SmartDashboard.PutBoolean("In loop?", false);
            RobotMap.GearSlot.Set(true);
            AutoFunctions.DriveFast(0.35);
            Stopwatch sw = new Stopwatch();
            sw.Start();
            while (sw.ElapsedMilliseconds < 5000) ;


            AutoFunctions.Drive(-1.75);
            while (AutoFunctions.OnTarget())
            {
                SmartDashboard.PutBoolean("In loop?", true);
                SmartDashboard.PutNumber("Left Position", RobotMap.Left1.GetEncoderPosition());
                SmartDashboard.PutNumber("Right Position", RobotMap.Right1.GetEncoderPosition());
            }
            SmartDashboard.PutBoolean("In loop?", false);

            AutoFunctions.TurnToAngle(160);
        }
    }

    /// <summary>
    /// Runs the red two autonomous.
    /// Places the gear.
    /// Align to the RED 2 driver station, three feet from the left.
    /// </summary>
    class Blue2 : IAuto
    {
        public void Run()
        {
            // Place the gear.
            //AutoFunctions.Drive(0.52);         // Drive forward 0.52 meters.
            //AutoFunctions.TurnToAngle(-32.70); // Turn to 60.25 degrees.
            //AutoFunctions.Drive(0.72);         // Drive forward 0.72 meters.
            //AutoFunctions.TurnToAngle(0);      // Turn to 0 degrees.
            //AutoFunctions.Drive(1.00);         // Drive forward one meter to place the gear.
            //AutoFunctions.PlaceGear();         // Place the gear.

            AutoFunctions.Drive(2.08);
            Stopwatch sw = new Stopwatch();
            while (AutoFunctions.OnTarget() || sw.ElapsedMilliseconds < 5000)
            {
                SmartDashboard.PutBoolean("In loop?", true);
                SmartDashboard.PutNumber("Left Position", RobotMap.Left1.GetEncoderPosition());
                SmartDashboard.PutNumber("Right Position", RobotMap.Right1.GetEncoderPosition());
            }
            SmartDashboard.PutBoolean("In loop?", false);
            RobotMap.GearSlot.Set(true);
            sw.Start();
            while (sw.ElapsedMilliseconds < 5000) ;


            AutoFunctions.Drive(-1.75);
            while (AutoFunctions.OnTarget())
            {
                SmartDashboard.PutBoolean("In loop?", true);
                SmartDashboard.PutNumber("Left Position", RobotMap.Left1.GetEncoderPosition());
                SmartDashboard.PutNumber("Right Position", RobotMap.Right1.GetEncoderPosition());
            }
            SmartDashboard.PutBoolean("In loop?", false);

            AutoFunctions.TurnToAngle(90);

            AutoFunctions.Drive(3);
            while (AutoFunctions.OnTarget())
            {
                SmartDashboard.PutBoolean("In loop?", true);
                SmartDashboard.PutNumber("Left Position", RobotMap.Left1.GetEncoderPosition());
                SmartDashboard.PutNumber("Right Position", RobotMap.Right1.GetEncoderPosition());
            }
            SmartDashboard.PutBoolean("In loop?", false);
        }
    }

    /// <summary>
    /// Runs the red three autonomous.
    /// Places the gear, and goes to a hopper.
    /// Align to the RED 3 driver station, three feet from the left.
    /// </summary>
    class Blue3 : IAuto
    {
        public void Run()
        {

            RobotMap.Shooter.Set(.95);
            Stopwatch sw = new Stopwatch();
            sw.Start();
            while (sw.ElapsedMilliseconds < 1000) ;
            RobotMap.Agitator.Set(-1);
            RobotMap.IntakeSecondStage.Set(-1);
            sw.Reset();
            sw.Start();
            while (sw.ElapsedMilliseconds < 12000) ;
            RobotMap.Shooter.Set(0);
            RobotMap.Agitator.Set(0);
            RobotMap.IntakeSecondStage.Set(0);
            AutoFunctions.DriveFast(-3.1);

            //// Place the gear.
            //AutoFunctions.Drive(2.445);        // Drive forward one meter to place the gear.
            //AutoFunctions.TurnToAngle(60.25);  // Turn to 60.25 degrees.
            //AutoFunctions.Drive(1.175);        // Drive forward 1.175 meters.
            //AutoFunctions.PlaceGear();         // Place the gear.

            //// Drive to a hopper.
            //AutoFunctions.Drive(-1.175);       // Drive backwards 1.175 meters.
            //AutoFunctions.TurnToAngle(17.3);   // Turn to 17.3 degrees.
            //AutoFunctions.Drive(2.84);         // Drive forwards 2.84 meters.
            //AutoFunctions.TurnToAngle(-90);    // Turn to -90 degrees.
            //AutoFunctions.Drive(0.825);        // Drive forward 0.825 to the hopper.

            //AutoFunctions.Drive(3.08);
            //while (AutoFunctions.OnTarget())
            //{
            //    SmartDashboard.PutBoolean("In loop?", true);
            //    SmartDashboard.PutNumber("Left Position", RobotMap.Left1.GetEncoderPosition());
            //    SmartDashboard.PutNumber("Right Position", RobotMap.Right1.GetEncoderPosition());
            //}
            //SmartDashboard.PutBoolean("In loop?", false);

            //RobotMap.GearSlot.Set(true);
            //Stopwatch sw = new Stopwatch();
            //sw.Start();
            //while (sw.ElapsedMilliseconds < 5000) ;


            //AutoFunctions.Drive(-1.75);
            //while (AutoFunctions.OnTarget())
            //{
            //    SmartDashboard.PutBoolean("In loop?", true);
            //    SmartDashboard.PutNumber("Left Position", RobotMap.Left1.GetEncoderPosition());
            //    SmartDashboard.PutNumber("Right Position", RobotMap.Right1.GetEncoderPosition());
            //}
            //SmartDashboard.PutBoolean("In loop?", false);

            //AutoFunctions.TurnToAngle(60);

            //AutoFunctions.Drive(5);
            //while (AutoFunctions.OnTarget())
            //{
            //    SmartDashboard.PutBoolean("In loop?", true);
            //    SmartDashboard.PutNumber("Left Position", RobotMap.Left1.GetEncoderPosition());
            //    SmartDashboard.PutNumber("Right Position", RobotMap.Right1.GetEncoderPosition());
            //}
            //SmartDashboard.PutBoolean("In loop?", false);
        }
    }
}



/*using ChadDotNet;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WPILib.SmartDashboard;

namespace CoconutsFrc2017
{
    /// <summary>
    /// Runs the blue one autonomous.
    /// Places the gear, shoots in the boiler, and goes to a hopper. Bloo!
    /// Align to the BLUE 1 driver station, three feet from the left.
    /// </summary>
    class Blue1 : IAuto
    {
        public void Run()
        {
            //// Place the gear.
            //AutoFunctions.Drive(1.6418);        // Drive forward 1.6418 meters.
            //AutoFunctions.TurnToAngle(30);      // Turn to 30 degrees.
            //AutoFunctions.Drive(0.96);          // Drive forward 0.96 meters to align at gear peg.
            //AutoFunctions.PlaceGear();          // Place the gear. This might incorporate vision. Currently does not.

            //// Drive to the boiler and shoot.
            //AutoFunctions.Drive(-0.96);         // Drive 0.96 meters backwards away from gear peg.
            //AutoFunctions.TurnToAngle(0);       // Turn to 0 degrees.
            //AutoFunctions.Drive(-0.7);          // Drive backwards -0.7 meters to clear airship for driving.
            //AutoFunctions.TurnToAngle(-133.74); // Turn to -133.74 degrees.
            //AutoFunctions.Drive(6.5);           // Drive 6.5 meters forward to the boiler. NEEDS CLARIFICATION FROM LOGAN.
            //AutoFunctions.ShootFuel();          // Shoot fuel. This might incorporate vision. Currently does not.

            //// Drive to a hopper.
            //AutoFunctions.Drive(-2.1);          // Back out of the boiler by driving back 2.1 meters.
            //AutoFunctions.TurnToAngle(-33.03);  // Turn to -33.03 degrees.
            //AutoFunctions.Drive(1.5);           // Drive forward 1.5 meteres to the hopper.
            //AutoFunctions.TurnToAngle(-90);     // Turn to -90 degrees, which is perpendicular to the perimeter.
            //AutoFunctions.Drive(1.275);         // Drive forward 1.275 meters to the hopper.

            AutoFunctions.Drive(3.3);
            while (AutoFunctions.OnTarget())
            {
                SmartDashboard.PutBoolean("In loop?", true);
                SmartDashboard.PutNumber("Left Position", RobotMap.Left1.GetEncoderPosition());
                SmartDashboard.PutNumber("Right Position", RobotMap.Right1.GetEncoderPosition());
            }
            SmartDashboard.PutBoolean("In loop?", false);

            RobotMap.GearSlot.Set(true);
            Stopwatch sw = new Stopwatch();
            sw.Start();
            while (sw.ElapsedMilliseconds < 5000) ;


            AutoFunctions.Drive(-1.75);
            while (AutoFunctions.OnTarget())
            {
                SmartDashboard.PutBoolean("In loop?", true);
                SmartDashboard.PutNumber("Left Position", RobotMap.Left1.GetEncoderPosition());
                SmartDashboard.PutNumber("Right Position", RobotMap.Right1.GetEncoderPosition());
            }
            SmartDashboard.PutBoolean("In loop?", false);

            AutoFunctions.TurnToAngle(-160);

            //AutoFunctions.Drive(3);
            //while (AutoFunctions.OnTarget())
            //{
            //    SmartDashboard.PutBoolean("In loop?", true);
            //    SmartDashboard.PutNumber("Left Position", RobotMap.Left1.GetEncoderPosition());
            //    SmartDashboard.PutNumber("Right Position", RobotMap.Right1.GetEncoderPosition());
            //}
            //SmartDashboard.PutBoolean("In loop?", false);
        }
    }

    /// <summary>
    /// Runs the blue two autonomous.
    /// Places the gear, shoots in the boiler, and goes to a hopper. Bloo!
    /// Align to the BLUE 2 driver station, three feet from the left.
    /// </summary>
    class Blue2 : IAuto
    {
        public void Run()
        {
            // Place the gear.
            //AutoFunctions.Drive(0.52);         // Drive forward 0.52 meters.
            //AutoFunctions.TurnToAngle(32.70);  // Turn to -60.25 degrees.
            //AutoFunctions.Drive(0.72);         // Drive forward 0.72 meters.
            //AutoFunctions.TurnToAngle(0);      // Turn to 0 degrees.
            //AutoFunctions.Drive(1.00);         // Drive forward one meter to place the gear.
            //AutoFunctions.PlaceGear();         // Place the gear.

            AutoFunctions.Drive(2.08);
            while (AutoFunctions.OnTarget())
            {
                SmartDashboard.PutBoolean("In loop?", true);
                SmartDashboard.PutNumber("Left Position", RobotMap.Left1.GetEncoderPosition());
                SmartDashboard.PutNumber("Right Position", RobotMap.Right1.GetEncoderPosition());
            }
            SmartDashboard.PutBoolean("In loop?", false);
            RobotMap.GearSlot.Set(true);
            Stopwatch sw = new Stopwatch();
            sw.Start();
            while (sw.ElapsedMilliseconds < 5000) ;

            AutoFunctions.Drive(-1.75);
            while (AutoFunctions.OnTarget())
            {
                SmartDashboard.PutBoolean("In loop?", true);
                SmartDashboard.PutNumber("Left Position", RobotMap.Left1.GetEncoderPosition());
                SmartDashboard.PutNumber("Right Position", RobotMap.Right1.GetEncoderPosition());
            }
            SmartDashboard.PutBoolean("In loop?", false);

            AutoFunctions.TurnToAngle(-90);

            AutoFunctions.Drive(3);
            while (AutoFunctions.OnTarget())
            {
                SmartDashboard.PutBoolean("In loop?", true);
                SmartDashboard.PutNumber("Left Position", RobotMap.Left1.GetEncoderPosition());
                SmartDashboard.PutNumber("Right Position", RobotMap.Right1.GetEncoderPosition());
            }
            SmartDashboard.PutBoolean("In loop?", false);
        }
    }

    /// <summary>
    /// Runs the blue three autonomous.
    /// Places the gear, shoots in the boiler, and goes to a hopper. Bloo!
    /// Align to the BLUE 3 driver station, three feet from the left.
    /// </summary>
    class Blue3 : IAuto
    {
        public void Run()
        {
            //// Place the gear.
            //AutoFunctions.Drive(2.445);        // Drive forward one meter to place the gear.
            //AutoFunctions.TurnToAngle(-60.25); // Turn to -60.25 degrees.
            //AutoFunctions.Drive(1.175);        // Drive forward 1.175 meters.
            //AutoFunctions.PlaceGear();         // Place the gear.

            //// Drive to a hopper.
            //AutoFunctions.Drive(-1.175);       // Drive backwards 1.175 meters.
            //AutoFunctions.TurnToAngle(-17.3);  // Turn to -17.3 degrees.
            //AutoFunctions.Drive(2.84);         // Drive forwards 2.84 meters.
            //AutoFunctions.TurnToAngle(90);     // Turn to 90 degrees.
            //AutoFunctions.Drive(0.825);        // Drive forward 0.825 to the hopper.

            AutoFunctions.Drive(3.08);
            while (AutoFunctions.OnTarget())
            {
                SmartDashboard.PutBoolean("In loop?", true);
                SmartDashboard.PutNumber("Left Position", RobotMap.Left1.GetEncoderPosition());
                SmartDashboard.PutNumber("Right Position", RobotMap.Right1.GetEncoderPosition());
            }
            RobotMap.GearSlot.Set(true);
            
            SmartDashboard.PutBoolean("In loop?", false);

            Stopwatch sw = new Stopwatch();
            sw.Start();
            while (sw.ElapsedMilliseconds < 5000) ;

            AutoFunctions.Drive(-1.75);
            while (AutoFunctions.OnTarget())
            {
                SmartDashboard.PutBoolean("In loop?", true);
                SmartDashboard.PutNumber("Left Position", RobotMap.Left1.GetEncoderPosition());
                SmartDashboard.PutNumber("Right Position", RobotMap.Right1.GetEncoderPosition());
            }
            SmartDashboard.PutBoolean("In loop?", false);

            AutoFunctions.TurnToAngle(-60);

            AutoFunctions.Drive(5);
            while (AutoFunctions.OnTarget())
            {
                SmartDashboard.PutBoolean("In loop?", true);
                SmartDashboard.PutNumber("Left Position", RobotMap.Left1.GetEncoderPosition());
                SmartDashboard.PutNumber("Right Position", RobotMap.Right1.GetEncoderPosition());
            }
            SmartDashboard.PutBoolean("In loop?", false);
        }
    }
}
*/
