// Author: MyName
// Copyright:   Copyright 2020 Keysight Technologies
//              You have a royalty-free right to use, modify, reproduce and distribute
//              the sample application files (and/or any modified version) in any way
//              you find useful, provided that you agree that Keysight Technologies has no
//              warranty, obligations or liability for any sample application files.
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel;
using OpenTap;

namespace OpenTap.Keysight.Cable.Project.Teststeps
{
    using OpenTap.Keysight.Cable.Project.Instruments;
    using OpenTap.Keysight.Cable.Project.EnumClass;
    using OpenTap.Keysight.Cable.Project.Other;

    [Display("Sweep", Group: "OpenTap.Keysight.Cable.Project.Teststeps", Description: "Insert a description here")]
    public class Sweep : TestStep
    {
        #region Settings

        [Display(Name: "Instrument", Group: "Instrument", Description: "Calling Instrument", Order: 1)]
        public MyInst MyInst { get; set; }

        [Display("S Parameter", Group: "Test Case Setting", Description: "Select the S Parameter", Order: 2.1)]
        public S_Parameters S_Parameters { get; set; }

        [Display("Start Frequency", Group: "Test Case Setting", Description: "Enter Start Frequency", Order: 2.2)]
        [Unit("Hz", UseEngineeringPrefix: true)]
        public double StartFrequency { get; set; }

        [Display("Stop Frequency", Group: "Test Case Setting", Description: "Enter Stop Frequency", Order: 2.3)]
        [Unit("Hz", UseEngineeringPrefix: true)]
        public double StopFrequency { get; set; }

        [Display("IF Bandwidth", Group: "Test Case Setting", Description: "Enter IF Bandwidth", Order: 2.4)]
        [Unit("Hz", UseEngineeringPrefix: true)]
        public double IFBandwidth { get; set; }

        [Display("Sweep Points", Group: "Test Case Setting", Description: "Enter Sweep Points", Order: 2.5)]
        public double SweepPoints { get; set; }

        [Display("Type", "Choose from:\r\nSTEPped\r\nANALog ", "Input Parameters", 2.7)]
        public ESweepType SweepType { get; set; } = ESweepType.ANALog;

        //[Display("Averaging Mode", Group: "Advanced Test Case Setting", Description: "Select the Average Mode", Order: 3.3)]
        //[EnabledIf("Averaging", true, HideIfDisabled = true)]
        public EAveragingMode AverageMode { get; set; }

        #endregion

        public Sweep()
        {
            this.Name = "Sweep";
            S_Parameters = S_Parameters.S11;
            StartFrequency = 500e6;
            StopFrequency = 40e9;
            IFBandwidth = 10e3;
            SweepPoints = 1001;
            AverageMode = EAveragingMode.POINT;
        }

        public override void Run()
        {
            MyInst.ScpiCommand("DISPlay:WINDow:STATE ON");
            MyInst.ScpiCommand("CALCulate:PARameter:DEFine:EXT 'MyMeas1',S11");
            MyInst.ScpiCommand("CALCulate:PARameter:DEFine:EXT 'MyMeas2',S12");
            MyInst.ScpiCommand("CALCulate:PARameter:DEFine:EXT 'MyMeas3',S21");
            MyInst.ScpiCommand("CALCulate:PARameter:DEFine:EXT 'MyMeas4',S22");
            MyInst.ScpiCommand("DISPlay:WINDow:TRACe1:FEED 'MyMeas1'");
            //MyInst.ScpiCommand("DISPlay:WINDow:TRACe2:FEED 'MyMeas2'");
            //MyInst.ScpiCommand("DISPlay:WINDow:TRACe3:FEED 'MyMeas3'");
            //MyInst.ScpiCommand("DISPlay:WINDow:TRACe4:FEED 'MyMeas4'");
            //MyInst.ScpiCommand("DISPlay:WINDow:Y:AUTO");
            MyInst.ScpiQuery<bool>("*OPC?");

            Log.Info("Selected Start Frequency : " + StartFrequency.ToString());
            Log.Info("Selected Stop Frequency : " + StopFrequency.ToString());
            Log.Info("Selected IF Bandwidth : " + IFBandwidth.ToString());
            Log.Info("Selected Power Level : " + SweepPoints.ToString());

            MyInst.IoTimeout = 5000;

            MyMeas measurement = MyMeas.MyMeas1;
            if (S_Parameters == S_Parameters.S11) measurement = MyMeas.MyMeas1;
            if (S_Parameters == S_Parameters.S12) measurement = MyMeas.MyMeas2;
            if (S_Parameters == S_Parameters.S21) measurement = MyMeas.MyMeas3;
            if (S_Parameters == S_Parameters.S22) measurement = MyMeas.MyMeas4;

            MyInst.ScpiCommand(":CALCulate1:PARameter:SELect '{0}'", measurement);
            MyInst.ScpiCommand(":SENSe:BANDwidth:RESolution {0}", IFBandwidth);
            MyInst.ScpiCommand(":SENSe:FREQuency:STARt {0}", StartFrequency);
            MyInst.ScpiCommand(":SENSe:FREQuency:STOP {0}", StopFrequency);
            MyInst.ScpiCommand(":SENSe:SWEep:POINts {0}", SweepPoints);
            MyInst.ScpiCommand(":SENSe:SWEep:GENeration {0}", SweepType);
            MyInst.ScpiCommand(":SENSe:SWEep:TIME:AUTO 1");


            StaticClass.Time = MyInst.ScpiQuery<System.Double>(Scpi.Format(":SENSe:SWEep:TIME?"), true);

            UpgradeVerdict(Verdict.Pass);

        }
    }
}
