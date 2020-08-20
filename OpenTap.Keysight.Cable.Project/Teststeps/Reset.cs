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

    [Display("Reset", Group: "OpenTap.Keysight.Cable.Project.Teststeps", Description: "Reset Instrument")]
    public class Reset : TestStep
    {
        #region Settings

        [Display(Name: "Instrument", Group: "Instrument", Description: "Calling Instrument", Order: 1)]
        public MyInst MyInst { get; set; }

        #endregion

        public Reset()
        {
            this.Name = "Reset";
        }

        public override void Run()
        {
            MyInst.ScpiCommand("*RST; SYST:FPR");
            UpgradeVerdict(Verdict.Pass);
        }
    }
}
