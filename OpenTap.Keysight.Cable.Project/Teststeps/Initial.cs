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

    [Display("Initial", Group: "OpenTap.Keysight.Cable.Project.Teststeps", Description: "Initial TestStep")]
    public class Initial : TestStep
    {
        #region Settings

        [Display(Name: "Instrument", Group: "Instrument", Description: "Calling Instrument", Order: 1)]
        public MyInst MyInst { get; set; }

        [Display(Name: "Project Name", Group: "Project", Description: "Name of Project", Order: 2.1)]
        public string ProjectName { get; set; }

        [Display(Name: "DUT ID", Group: "Project", Description: "Id of Dut", Order: 2.2)]
        public string DutId { get; set; }

        [Display(Name: "Dut Type", Group: "Project", Description: "Name of Project", Order: 2.3)]
        public EDutType DutType { get; set; }

        private string _DirPath;
        [DirectoryPath]
        [Display(Name: "Directory Path", Group: "Project", Description: "Directory Path", Order: 2.4)]
        public string DirPath { get => _DirPath; set => _DirPath = (value.Substring(value.Length - 1) == "\\") ? value : value + "\\"; }

        [Display(Name: "Marker File Name", Group: "Project", Description: "Name of Marker File", Order: 2.5)]
        public string MarkerFilename { get; set; }

        [Display(Name: "Snp File Name", Group: "Project", Description: "Name of Snp File", Order: 2.6)]
        public string SnpFilename { get; set; }

        [Display(Name: "Screenshot File Name", Group: "Project", Description: "Name of Screenshot File", Order: 2.7)]
        public string ScreenshotFilename { get; set; }

        //[Display(Name: "List of Ports", Group: "Input Paramrters", Description: "Enters List of ports for snp file", Order: 2.8)]
        //public string ListOfPorts { get; set; }

        #endregion

        public Initial()
        {
            this.Name = "Initial";

            ProjectName = "Project";
            DutId = "123";
            DutType = EDutType.Cable;
            DirPath = @"D:\";
            MarkerFilename = "Marker";
            SnpFilename = DutId;
            ScreenshotFilename = DutId;
        }

        public override void Run()
        {
            StaticClass.DirPath = DirPath;
            StaticClass.DutId = DutId;
            StaticClass.DutType = DutType;
            StaticClass.ProjectName = ProjectName;
            StaticClass.MarkerFileName = MarkerFilename;
            StaticClass.SnpFileName = SnpFilename;
            StaticClass.ScreenshotFileName = ScreenshotFilename;
            StaticClass.TimeStamp = DateTime.Now.ToString("yyyy-MM-dd_HH-mm-ss");
            //StaticClass.ListOfPort = ListOfPorts;

            UpgradeVerdict(Verdict.Pass);
        }
    }
}
