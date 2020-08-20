using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel;
using OpenTap;

namespace OpenTap.Keysight.Cable.Project.Teststeps
{
    using System.IO;
    using OpenTap.Keysight.Cable.Project.Instruments;
    using OpenTap.Keysight.Cable.Project.Other;

    [Display("CaptureScreenshot", Group: "OpenTap.Keysight.Cable.Project.Teststeps", Description: "Insert a description here")]
    public class CaptureScreenshot : TestStep
    {
        #region Settings

        [Display(Name: "Instrument", Group: "Instrument", Description: "Calling Instrument", Order: 1)]
        public MyInst MyInst { get; set; }

        #endregion

        public CaptureScreenshot()
        {
            this.Name = "Capture Screenshot";
        }

        public override void Run()
        {
            string screenshotfilename = StaticClass.FullScreenFilePath;

            MyInst.IoTimeout = 5000;

            MyInst.ScpiCommand(":HCOPy:SDUMp:DATA:FORMat PNG");
            byte[] getData = MyInst.ScpiQueryBlock<byte>("HCOPy:SDUMp:DATA?; *OPC?");

            MemoryStream mapData = new MemoryStream(getData);
            System.Drawing.Image myImage = System.Drawing.Image.FromStream(mapData);
            myImage.Save(screenshotfilename);

            UpgradeVerdict(Verdict.Pass);

        }
    }
}
