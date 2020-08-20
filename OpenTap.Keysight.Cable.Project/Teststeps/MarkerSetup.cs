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
    using System.Diagnostics;
    using System.IO;
    using OpenTap.Keysight.Cable.Project.Other;
    using System.Data;

    [Display("Marker Setup", Group: "OpenTap.Keysight.Cable.Project.Teststeps", Description: "Setup Markers")]
    public class MarkerSetup : TestStep
    {
        #region Settings

        [Display(Name: "Instrument", Group: "Instrument", Description: "Calling Instrument", Order: 1)]
        public MyInst MyInst { get; set; }

        private int _MarkerNumber = 1;
        [Display("Marker Numbers", Group: "Marker Settings", Description: "Enter Number of Markers", Order: 3.0)]
        public int MarkerNumber { get => _MarkerNumber; set => _MarkerNumber = (value > 10) ? 10 : value; }

        [Display("Marker 1 Frequency", Groups: new[] { "Marker Settings", "Marker 1" }, Description: "Enter the Marker 1 Frequency", Order: 3.1)]
        [Unit("Hz", UseEngineeringPrefix: true)]
        [EnabledIf("MarkerNumber", 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, HideIfDisabled = true)]
        public double Marker_1_Frequency { get; set; }

        [Display("Marker 1 Parameter", Groups: new[] { "Marker Settings", "Marker 1" }, Description: "Enter the Marker 1 Parameter", Order: 3.2)]
        [EnabledIf("MarkerNumber", 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, HideIfDisabled = true)]
        public S_Parameters Marker_1_Parameter { get; set; }

        [Display("Marker 2 Frequency", Groups: new[] { "Marker Settings", "Marker 2" }, Description: "Enter the Marker 2 Frequency", Order: 3.1)]
        [Unit("Hz", UseEngineeringPrefix: true)]
        [EnabledIf("MarkerNumber", 2, 3, 4, 5, 6, 7, 8, 9, 10, HideIfDisabled = true)]
        public double Marker_2_Frequency { get; set; }

        [Display("Marker 2 Parameter", Groups: new[] { "Marker Settings", "Marker 2" }, Description: "Enter the Marker 2 Parameter", Order: 3.2)]
        [EnabledIf("MarkerNumber", 2, 3, 4, 5, 6, 7, 8, 9, 10, HideIfDisabled = true)]
        public S_Parameters Marker_2_Parameter { get; set; }

        [Display("Marker 3 Frequency", Groups: new[] { "Marker Settings", "Marker 3" }, Description: "Enter the Marker 3 Frequency", Order: 3.1)]
        [Unit("Hz", UseEngineeringPrefix: true)]
        [EnabledIf("MarkerNumber", 3, 4, 5, 6, 7, 8, 9, 10, HideIfDisabled = true)]
        public double Marker_3_Frequency { get; set; }

        [Display("Marker 3 Parameter", Groups: new[] { "Marker Settings", "Marker 3" }, Description: "Enter the Marker 3 Parameter", Order: 3.2)]
        [EnabledIf("MarkerNumber", 3, 4, 5, 6, 7, 8, 9, 10, HideIfDisabled = true)]
        public S_Parameters Marker_3_Parameter { get; set; }

        [Display("Marker 4 Frequency", Groups: new[] { "Marker Settings", "Marker 4" }, Description: "Enter the Marker 4 Frequency", Order: 3.1)]
        [Unit("Hz", UseEngineeringPrefix: true)]
        [EnabledIf("MarkerNumber", 4, 5, 6, 7, 8, 9, 10, HideIfDisabled = true)]
        public double Marker_4_Frequency { get; set; }

        [Display("Marker 4 Parameter", Groups: new[] { "Marker Settings", "Marker 4" }, Description: "Enter the Marker 4 Parameter", Order: 3.2)]
        [EnabledIf("MarkerNumber", 4, 5, 6, 7, 8, 9, 10, HideIfDisabled = true)]
        public S_Parameters Marker_4_Parameter { get; set; }

        [Display("Marker 5 Frequency", Groups: new[] { "Marker Settings", "Marker 5" }, Description: "Enter the Marker 5 Frequency", Order: 3.1)]
        [Unit("Hz", UseEngineeringPrefix: true)]
        [EnabledIf("MarkerNumber", 5, 6, 7, 8, 9, 10, HideIfDisabled = true)]
        public double Marker_5_Frequency { get; set; }

        [Display("Marker 5 Parameter", Groups: new[] { "Marker Settings", "Marker 5" }, Description: "Enter the Marker 5 Parameter", Order: 3.2)]
        [EnabledIf("MarkerNumber", 5, 6, 7, 8, 9, 10, HideIfDisabled = true)]
        public S_Parameters Marker_5_Parameter { get; set; }

        [Display("Marker 6 Frequency", Groups: new[] { "Marker Settings", "Marker 6" }, Description: "Enter the Marker 6 Frequency", Order: 3.1)]
        [Unit("Hz", UseEngineeringPrefix: true)]
        [EnabledIf("MarkerNumber", 6, 7, 8, 9, 10, HideIfDisabled = true)]
        public double Marker_6_Frequency { get; set; }

        [Display("Marker 6 Parameter", Groups: new[] { "Marker Settings", "Marker 6" }, Description: "Enter the Marker 6 Parameter", Order: 3.2)]
        [EnabledIf("MarkerNumber", 6, 7, 8, 9, 10, HideIfDisabled = true)]
        public S_Parameters Marker_6_Parameter { get; set; }

        [Display("Marker 7 Frequency", Groups: new[] { "Marker Settings", "Marker 7" }, Description: "Enter the Marker 7 Frequency", Order: 3.1)]
        [Unit("Hz", UseEngineeringPrefix: true)]
        [EnabledIf("MarkerNumber", 7, 8, 9, 10, HideIfDisabled = true)]
        public double Marker_7_Frequency { get; set; }

        [Display("Marker 7 Parameter", Groups: new[] { "Marker Settings", "Marker 7" }, Description: "Enter the Marker 7 Parameter", Order: 3.2)]
        [EnabledIf("MarkerNumber", 7, 8, 9, 10, HideIfDisabled = true)]
        public S_Parameters Marker_7_Parameter { get; set; }

        [Display("Marker 8 Frequency", Groups: new[] { "Marker Settings", "Marker 8" }, Description: "Enter the Marker 8 Frequency", Order: 3.1)]
        [Unit("Hz", UseEngineeringPrefix: true)]
        [EnabledIf("MarkerNumber", 8, 9, 10, HideIfDisabled = true)]
        public double Marker_8_Frequency { get; set; }

        [Display("Marker 8 Parameter", Groups: new[] { "Marker Settings", "Marker 8" }, Description: "Enter the Marker 8 Parameter", Order: 3.2)]
        [EnabledIf("MarkerNumber", 8, 9, 10, HideIfDisabled = true)]
        public S_Parameters Marker_8_Parameter { get; set; }

        [Display("Marker 9 Frequency", Groups: new[] { "Marker Settings", "Marker 9" }, Description: "Enter the Marker 9 Frequency", Order: 3.1)]
        [Unit("Hz", UseEngineeringPrefix: true)]
        [EnabledIf("MarkerNumber", 9, 10, HideIfDisabled = true)]
        public double Marker_9_Frequency { get; set; }

        [Display("Marker 9 Parameter", Groups: new[] { "Marker Settings", "Marker 9" }, Description: "Enter the Marker 9 Parameter", Order: 3.2)]
        [EnabledIf("MarkerNumber", 9, 10, HideIfDisabled = true)]
        public S_Parameters Marker_9_Parameter { get; set; }

        [Display("Marker 10 Frequency", Groups: new[] { "Marker Settings", "Marker 10" }, Description: "Enter the Marker 10 Frequency", Order: 3.1)]
        [Unit("Hz", UseEngineeringPrefix: true)]
        [EnabledIf("MarkerNumber", 10, HideIfDisabled = true)]
        public double Marker_10_Frequency { get; set; }

        [Display("Marker 10 Parameter", Groups: new[] { "Marker Settings", "Marker 10" }, Description: "Enter the Marker 10 Parameter", Order: 3.2)]
        [EnabledIf("MarkerNumber", 10, HideIfDisabled = true)]
        public S_Parameters Marker_10_Parameter { get; set; }

        #endregion

        #region Settings

        List<S_Parameters> s_parameter;
        List<double> frequency;

        List<string> columnHeaders;

        public DataTable dt = new DataTable();
        DataColumn dtColumn;

        string markerfilename;

        #endregion Settings

        public MarkerSetup()
        {
            MarkerNumber = 5;
            Marker_1_Frequency = 1;
            Marker_2_Frequency = 2;
            Marker_3_Frequency = 3;
            Marker_4_Frequency = 4;
            Marker_5_Frequency = 5;
            Marker_6_Frequency = 6;
            Marker_7_Frequency = 7;
            Marker_8_Frequency = 8;
            Marker_9_Frequency = 9;
            Marker_10_Frequency = 10;
            Marker_1_Parameter = S_Parameters.S11;
            Marker_2_Parameter = S_Parameters.S12;
            Marker_3_Parameter = S_Parameters.S21;
            Marker_4_Parameter = S_Parameters.S22;
            Marker_5_Parameter = S_Parameters.S11;
            Marker_6_Parameter = S_Parameters.S12;
            Marker_7_Parameter = S_Parameters.S21;
            Marker_8_Parameter = S_Parameters.S22;
            Marker_9_Parameter = S_Parameters.S11;
            Marker_10_Parameter = S_Parameters.S12;
        }

        public override void PrePlanRun()
        {
            frequency = new List<double> { Marker_1_Frequency, Marker_2_Frequency,
                Marker_3_Frequency, Marker_4_Frequency, Marker_5_Frequency, Marker_6_Frequency,
                Marker_7_Frequency, Marker_8_Frequency, Marker_9_Frequency, Marker_10_Frequency};

            s_parameter = new List<S_Parameters> { Marker_1_Parameter, Marker_2_Parameter,
                Marker_3_Parameter, Marker_4_Parameter, Marker_5_Parameter, Marker_6_Parameter,
                Marker_7_Parameter, Marker_8_Parameter, Marker_9_Parameter, Marker_10_Parameter };

            columnHeaders = new List<string>();
            columnHeaders.Add("TimeStamp");
            columnHeaders.Add("Project");
            columnHeaders.Add("CableType");
            columnHeaders.Add("CableID");

            for (int i = 1; i <= MarkerNumber; i++)
            {
                columnHeaders.Add("Parameter" + i);
                columnHeaders.Add("Frequency" + i);
                columnHeaders.Add("Amplitude" + i);
            }

            dt.TableName = "Testplan";
            foreach (var item in columnHeaders)
            {
                dtColumn = new DataColumn();
                dtColumn.ColumnName = item;
                dt.Columns.Add(dtColumn);
            }

            markerfilename = StaticClass.DirPath + StaticClass.MarkerFileName + "_" + StaticClass.TimeStamp + ".csv";
        }

        public override void Run()
        {
            MyInst.IoTimeout = 5000;
            StaticClass.TimeStamp = DateTime.Now.ToString("yyyy-MM-dd_HH-mm-ss");

            #region RUN_INIT

            /* Initializing variables at every RUN */
            List<S_Parameters> activeParameters = new List<S_Parameters>();
            List<double> activeFrequency = new List<double>();
            List<double> activeAmplitude = new List<double>();

            for (int i = 0; i < MarkerNumber; i++)
            {
                activeParameters.Add(s_parameter[i]);
                activeFrequency.Add(frequency[i]);
            }
            /* END Initializing variables at every RUN */

            #endregion RUN_INIT

            #region Calculating Amplitude Value

            // Selecting S Parameter & Reading Marker Value
            for (int i = 0; i < MarkerNumber; i++)
            {
                // Select S Parameter
                string activeMarkerMeasurement;

                switch (activeParameters[i])
                {
                    case S_Parameters.S11:
                        activeMarkerMeasurement = MyMeas.MyMeas1.ToString();
                        break;
                    case S_Parameters.S12:
                        activeMarkerMeasurement = MyMeas.MyMeas2.ToString();
                        break;
                    case S_Parameters.S21:
                        activeMarkerMeasurement = MyMeas.MyMeas3.ToString();
                        break;
                    case S_Parameters.S22:
                        activeMarkerMeasurement = MyMeas.MyMeas4.ToString();
                        break;
                    default:
                        activeMarkerMeasurement = MyMeas.MyMeas1.ToString();
                        break;
                }

                Log.Info("My {0}", (int)activeParameters[i] + 1);

                MyInst.ScpiCommand("CALCulate:PARameter:SELect '{0}'", activeMarkerMeasurement);

                if (!MyInst.ScpiQuery<bool>(Scpi.Format("DISP:WIND{0}:STAT?", (int)activeParameters[i] + 1), true))
                {
                    MyInst.ScpiCommand("DISP:WIND{0}:STAT 1", (int)activeParameters[i] + 1);
                    MyInst.ScpiCommand("DISPlay:WINDow{0}:TRACe{0}:FEED '{1}'", (int)activeParameters[i] + 1, activeMarkerMeasurement);
                    MyInst.ScpiCommand("DISPlay:WINDow{0}:Y:AUTO", (int)activeParameters[i] + 1);
                }

                // Read Marker Value
                MyInst.ScpiCommand("CALCulate:MARKer{0}:STATe {1}", i + 1, 1);
                MyInst.ScpiCommand("CALCulate:MARKer{0}:X {1}", i + 1, activeFrequency[i]);
                MyInst.ScpiCommand("DISPlay:WINDow{0}:TABLe 1", (int)activeParameters[i] + 1);
                string y = MyInst.ScpiQuery<System.String>(Scpi.Format(":CALCulate:MARKer{0}:Y?", i + 1), true);

                //Processing Marker Value
                activeAmplitude.Add(Convert.ToDouble(y.Split(',')[0]));
            }
            
            #endregion Calculating Amplitude Value

            #region ADD Row To DataTable

            /* Adding Row to DataTable dt */

            DataRow dtRow;
            dtRow = dt.NewRow();
            dtRow[columnHeaders[0]] = StaticClass.TimeStamp;
            dtRow[columnHeaders[1]] = StaticClass.ProjectName;
            dtRow[columnHeaders[2]] = StaticClass.DutType;
            dtRow[columnHeaders[3]] = StaticClass.DutId;
            for (int i = 0; i < MarkerNumber; i++)
            {
                dtRow[columnHeaders[3 * i + 4]] = activeParameters[i].ToString();
                dtRow[columnHeaders[3 * i + 5]] = activeFrequency[i];
                dtRow[columnHeaders[3 * i + 6]] = activeAmplitude[i];
            }
            dt.Rows.Add(dtRow);

            #endregion ADD Row To DataTable

            
            StaticClass.FullScreenFilePath = StaticClass.DirPath + StaticClass.ScreenshotFileName + "_" + StaticClass.TimeStamp + ".png";
            StaticClass.FullSnpFilePath = StaticClass.DirPath + StaticClass.SnpFileName + "_" + StaticClass.TimeStamp + ".s2p";

            UpgradeVerdict(Verdict.Pass);
        }

        public override void PostPlanRun()
        {
            base.PostPlanRun();

            //Close Excel File
            CloseExcelFile(markerfilename);

            //dt.WriteXml(markerfilename);

            DataToFile.Data2Csv(dt, markerfilename);
            DataToFile.Data2Html(dt, markerfilename);

        }

        public void CloseExcelFile(string filename)
        {
            var processes = from p in Process.GetProcessesByName("EXCEL") select p;

            foreach (var process in processes)
            {
                //Console.WriteLine(process.MainWindowTitle);
                if (process.MainWindowTitle.Contains(filename))
                    process.Kill();
            }
        }
    }
}
