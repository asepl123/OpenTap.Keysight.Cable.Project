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
    using System.IO;
    using OpenTap.Keysight.Cable.Project.Other;

    [Display("CaptureSnp", Group: "OpenTap.Keysight.Cable.Project.Teststeps", Description: "Capture S2P file")]
    public class CaptureSnp : TestStep
    {
        #region Settings

        [Display(Name: "Instrument", Group: "Instrument", Description: "Calling Instrument", Order: 1)]
        public MyInst MyInst { get; set; }

        #endregion

        public CaptureSnp()
        {
            this.Name = "Capture Snp file";
        }

        public override void Run()
        {
            MyInst.IoTimeout = 5000;

            MyInst.ScpiCommand(":CALCulate{0}:DATA:SNP:PORTs:SAVE \"1,2\",\"{1}\"", 1, StaticClass.SnpFileName);

            byte[] getByte = MyInst.ScpiQueryBlock<byte>("MMEMory:TRANsfer? \"" + StaticClass.SnpFileName + "\"; *OPC?");

            using (Stream file = File.OpenWrite(StaticClass.FullSnpFilePath))
            {
                file.Write(getByte, 0, getByte.Length);
            }

            //MyInst.ScpiCommand(":MMEMory:DELete \"{0}\"", StaticClass.SnpFileName);

            UpgradeVerdict(Verdict.Pass);
        }
    }
}
