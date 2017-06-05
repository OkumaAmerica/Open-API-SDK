//-----------------------------------------------------------------------
// <copyright file="SpecCodes.cs" company="Okuma America Corporation">
//     Copyright© 2016 Okuma America Corporation
// </copyright>
// <project> SCOUT Test Application
// </project>
// <author> Scott Solmer
// </author>   
// <remarks> This sample code is unlicensed.
// It is distributed "AS IS", WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND,
// either expressed or implied. Okuma America grants you permission to use
// this code and derivative works thereof without limitation or obligation.
// </remarks>
// <disclaimer> Under no circumstance shall Okuma America be held liable 
// to anyone using this code or programs derived there from for damages 
// of any kind as a result of the use or inability to use this code, 
// including but not limited to damages for loss of goodwill, work 
// stoppage, computer failure or malfunction, or any and all other 
// commercial damages or losses.
// </disclaimer>
//-----------------------------------------------------------------------

namespace Okuma.Scout.TestApp.net20
{
    using System;
    using System.Collections.Generic;
    using System.Text;
    using System.Windows.Forms;
    using Okuma.Scout;

    /// <summary>
    /// This is just an extension of Form1 broken into a separate file for
    /// organization and clarity </summary>
    public partial class ScoutTestApplicationForm : Form
    {
        private bool NCSpecExecuted = false;
        private bool NCBSpecExecuted = false;
        private bool PLCSpecExecuted = false;


        /// <summary>
        /// This function sets the initial selected index of combo boxes for each Spec Code Group.
        /// </summary>
        private void SetInitialComboBoxConditions()
        {
            // Select "NC1MG [NC-SPEC CODE No.1]" by default.
            ComboBox_NCSpecGroup.SelectedIndex = (int)Okuma.Scout.Enums.NCSpecGroup.NC1MG;

            // Select "NCB1MG [NC B-SPEC CODE No.1]" by default.
            ComboBox_NCBSpecGroup.SelectedIndex = (int)Okuma.Scout.Enums.NCBSpecGroup.NCB1MG;

            // Select "PLC1MG [PLC SPEC CODE No.1]" by default.
            ComboBox_PLCSpecGroup.SelectedIndex = (int)Okuma.Scout.Enums.PLCSpecGroup.PLC1MG;

            ComboBox_NCSpecByte.SelectedIndex = 0;
            ComboBox_NCSpecBit.SelectedIndex = 0;
            ComboBox_NCBSpecByte.SelectedIndex = 0;
            ComboBox_NCBSpecBit.SelectedIndex = 0;
            ComboBox_PLCSpecByte.SelectedIndex = 0;
            ComboBox_PLCSpecBit.SelectedIndex = 0;
        }

        /// <summary>
        /// Using Scout, acquire information about the machine specifications
        /// </summary>
        /// <param name="sender">The button object</param>
        /// <param name="e">Event arguments associated with the button click</param>
        private void Button_SpecCodes_Click(object sender, EventArgs e)
        {
            this.TextBox_SpecMachineType.Text = Okuma.Scout.SpecCode.NC.machineNameFromFile;
            this.TextBox_SpecMachineType_DMC.Text = Okuma.Scout.DMC.MachineType;

            this.TextBox_PLCSpec1A.Text = Okuma.Scout.SpecCode.PLC.GroupFirstHalf(Enums.PLCSpecGroup.PLC1MG);
            this.TextBox_PLCSpec1B.Text = Okuma.Scout.SpecCode.PLC.GroupSecondHalf(Enums.PLCSpecGroup.PLC1MG);
            this.TextBox_PLCSpec2A.Text = Okuma.Scout.SpecCode.PLC.GroupFirstHalf(Enums.PLCSpecGroup.PLC2MG);
            this.TextBox_PLCSpec2B.Text = Okuma.Scout.SpecCode.PLC.GroupSecondHalf(Enums.PLCSpecGroup.PLC2MG);

            this.TextBox_NCSpecA.Text = Okuma.Scout.SpecCode.NC.GroupFirstHalf(Enums.NCSpecGroup.NC1MG);
            this.TextBox_NCSpecB.Text = Okuma.Scout.SpecCode.NC.GroupSecondHalf(Enums.NCSpecGroup.NC1MG);

            this.TextBox_NCBSpecA.Text = Okuma.Scout.SpecCode.NCB.GroupFirstHalf(Enums.NCBSpecGroup.NCB1MG);
            this.TextBox_NCBSpecB.Text = Okuma.Scout.SpecCode.NCB.GroupSecondHalf(Enums.NCBSpecGroup.NCB1MG);

            this.TextBox_PLCSpec1A_DMC.Text = Okuma.Scout.SpecCode.PLC1_DMC_FirstHalf;
            this.TextBox_PLCSpec1B_DMC.Text = Okuma.Scout.SpecCode.PLC1_DMC_SecondHalf;
            this.TextBox_PLCSpec2A_DMC.Text = Okuma.Scout.SpecCode.PLC2_DMC_FirstHalf;
            this.TextBox_PLCSpec2B_DMC.Text = Okuma.Scout.SpecCode.PLC2_DMC_SecondHalf;
            this.TextBox_NCSpecA_DMC.Text = Okuma.Scout.SpecCode.NC1_DMC_FirstHalf;
            this.TextBox_NCSpecB_DMC.Text = Okuma.Scout.SpecCode.NC1_DMC_SecondHalf;
            this.TextBox_NCBSpecA_DMC.Text = Okuma.Scout.SpecCode.NCB1_DMC_FirstHalf;
            this.TextBox_NCBSpecB_DMC.Text = Okuma.Scout.SpecCode.NCB1_DMC_SecondHalf;

            this.TextBox_PLCSpec1A_Match.Text = b2s(Okuma.Scout.SpecCode.Match_PLC1_FirstHalf);
            this.TextBox_PLCSpec1B_Match.Text = b2s(Okuma.Scout.SpecCode.Match_PLC1_SecondHalf);
            this.TextBox_PLCSpec2A_Match.Text = b2s(Okuma.Scout.SpecCode.Match_PLC2_FirstHalf);
            this.TextBox_PLCSpec2B_Match.Text = b2s(Okuma.Scout.SpecCode.Match_PLC2_SecondHalf);
            this.TextBox_NCSpecA_Match.Text = b2s(Okuma.Scout.SpecCode.Match_NC1_FirstHalf);
            this.TextBox_NCSpecB_Match.Text = b2s(Okuma.Scout.SpecCode.Match_NC1_SecondHalf);
            this.TextBox_NCBSpecA_Match.Text = b2s(Okuma.Scout.SpecCode.Match_NCB1_FirstHalf);
            this.TextBox_NCBSpecB_Match.Text = b2s(Okuma.Scout.SpecCode.Match_NCB1_SecondHalf);
        }

        private static string b2s(bool? input)
        {
            if (input == null) { return "N/A"; }
            else return input.ToString();
        }

        /// <summary>
        /// Execution code for NC Spec 
        /// </summary>
        /// <param name="sender">Button object</param>
        /// <param name="e">button click arguments</param>
        private void Button_NCSpecFileExecute_Click(object sender, EventArgs e)
        {
            DoNCSpecExecute();
            NCSpecExecuted = true;
        }

        private void Combo_NCSpecGroup_IndexChanged(object sender, EventArgs e)
        {
            if (uiLoaded && NCSpecExecuted)
            {
                DoNCSpecExecute();
            }
        }

        private void Combo_NCSpecByte_IndexChanged(object sender, EventArgs e)
        {
            if (uiLoaded && NCSpecExecuted)
            {
                DoNCSpecExecute();
            }
        }

        private void Combo_NCSpecBit_IndexChanged(object sender, EventArgs e)
        {
            if (uiLoaded && NCSpecExecuted)
            {
                DoNCSpecExecute();
            }
        }

        private void DoNCSpecExecute()
        {
            TextBox_NCSpecFileExists.Text = Okuma.Scout.SpecCode.NC.MachineSpecCodeFileExists.ToString();

            TextBox_NCSpecMachineType.Text = Okuma.Scout.SpecCode.NC.machineNameFromFile;
            TextBox_NCSpecSerialNumber.Text = Okuma.Scout.SpecCode.NC.projectNumberFromFile.ToString();

            Okuma.Scout.Enums.NCSpecGroup selectedGroup = Enums.NCSpecGroup.NC1MG;

            switch (ComboBox_NCSpecGroup.SelectedIndex)
            {
                case 0: { selectedGroup = Enums.NCSpecGroup.NC1MG; break; }
                case 1: { selectedGroup = Enums.NCSpecGroup.NC2MG; break; }
                case 2: { selectedGroup = Enums.NCSpecGroup.NC3MG; break; }
                case 3: { selectedGroup = Enums.NCSpecGroup.NC4MG; break; }
                case 4: { selectedGroup = Enums.NCSpecGroup.NC5MG; break; }
                case 5: { selectedGroup = Enums.NCSpecGroup.NC6MG; break; }
                case 6: { selectedGroup = Enums.NCSpecGroup.NC7MG; break; }
                case 7: { selectedGroup = Enums.NCSpecGroup.NC8MG; break; }
            }

            TextBox_NCSpecFirstHalf.Text = Okuma.Scout.SpecCode.NC.GroupFirstHalf(selectedGroup);
            TextBox_NCSpecSecondHalf.Text = Okuma.Scout.SpecCode.NC.GroupSecondHalf(selectedGroup);

            int byteNo = ComboBox_NCSpecByte.SelectedIndex + 1;
            int bitNo = ComboBox_NCSpecBit.SelectedIndex;

            TextBox_NCSpecByteHex.Text = Okuma.Scout.SpecCode.NC.Byte(selectedGroup, byteNo);
            TextBox_NCSpecByteBin.Text = ConvertHexToBin(TextBox_NCSpecByteHex.Text);
            TextBox_NCSpecBitActive.Text = Okuma.Scout.SpecCode.NC.Bit(selectedGroup, byteNo, bitNo).ToString();
        }

        /// <summary>
        /// Event triggered when the NC Spec radio button's checked state changes
        /// </summary>
        /// <param name="sender">RadioButton object</param>
        /// <param name="e">changed arguments</param>
        private void RadioButton_NCSpecFile_CheckedChanged(object sender, EventArgs e)
        {
            this.RadioButton_NCSpecFile();
        }

        /// <summary>
        /// Function called when radio button checked changed event is triggered.
        /// Sets user defined file path and "UseUserDefinedFilePath" properties depending
        /// on the checked state of the radio buttons.
        /// </summary>
        private void RadioButton_NCSpecFile()
        {
            if ((bool)uiLoaded)
            {
                if (RadioButton_NCSpecFileUser.Checked == true)
                {
                    Okuma.Scout.SpecCode.NC.UseUserDefinedFile = true;
                    if (string.IsNullOrEmpty(Okuma.Scout.SpecCode.NC.UserDefinedFilePath))
                    {
                        this.ChooseNCSpecFile();
                    }
                }
                else if (RadioButton_NCSpecFileDefault.Checked == true)
                {
                    Okuma.Scout.SpecCode.NC.UseUserDefinedFile = false;
                }
            }
        }

        /// <summary>
        /// Button click event for File Select.
        /// Triggers Choose Spec file function and sets radio button checked state. 
        /// </summary>
        /// <param name="sender">button object</param>
        /// <param name="e">click arguments</param>
        private void Button_NCSpecFileSelectFile_Click(object sender, EventArgs e)
        {
            if (RadioButton_NCSpecFileDefault.Checked == true)
            {
                RadioButton_NCSpecFileUser.Checked = true;
            }
            else { this.ChooseNCSpecFile(); }
        }

        /// <summary>
        /// Generate open file dialog for selection of user defined spec file
        /// </summary>
        private void ChooseNCSpecFile()
        {
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.Title = "Select NC Spec Code File";
            ofd.InitialDirectory = @"C:\";
            ofd.CustomPlaces.Add(@"C:\OSP-P\CNS-DAT\");
            ofd.Filter = "NCSPEC File (*.DAT)|*.DAT";
            ofd.FilterIndex = 2;
            ofd.RestoreDirectory = true;
            if (ofd.ShowDialog() == DialogResult.OK)
            {
                Okuma.Scout.SpecCode.NC.UserDefinedFilePath = ofd.FileName;

                if (!Okuma.Scout.SpecCode.NC.SpecFileIsValid)
                {
                    RadioButton_NCBSpecFileDefault.Checked = true;
                    MessageBox.Show(
                        "The selected Spec Code file is not valid." + Environment.NewLine +
                        "Please choose another file.",
                        "Error Reading File",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Error,
                        MessageBoxDefaultButton.Button1);

                    Okuma.Scout.SpecCode.NC.UseUserDefinedFile = false;
                    Label_NCSpecFileUserFile.Text = string.Empty;
                    Okuma.Scout.SpecCode.NC.UserDefinedFilePath = string.Empty;
                }
                else { Label_NCSpecFileUserFile.Text = ofd.FileName; }
            }
            else { RadioButton_NCSpecFileDefault.Checked = true; }
        }

        /// <summary>
        /// Execution code for NC B-Spec 
        /// </summary>
        /// <param name="sender">Button object</param>
        /// <param name="e">button click arguments</param>
        private void Button_NCBSpecFileExecute_Click(object sender, EventArgs e)
        {
            DoNCBSpecExecute();
            NCBSpecExecuted = true;
        }

        private void Combo_NCBSpecGroup_IndexChanged(object sender, EventArgs e)
        {
            if (uiLoaded && NCBSpecExecuted)
            {
                DoNCBSpecExecute();
            }
        }

        private void Combo_NCBSpecByte_IndexChanged(object sender, EventArgs e)
        {
            if (uiLoaded && NCBSpecExecuted)
            {
                DoNCBSpecExecute();
            }
        }

        private void Combo_NCBSpecBit_IndexChanged(object sender, EventArgs e)
        {
            if (uiLoaded && NCBSpecExecuted)
            {
                DoNCBSpecExecute();
            }
        }

        private void DoNCBSpecExecute()
        {
            TextBox_NCBSpecFileExists.Text = Okuma.Scout.SpecCode.NCB.MachineSpecCodeFileExists.ToString();

            TextBox_NCBSpecMachineType.Text = Okuma.Scout.SpecCode.NCB.machineNameFromFile;
            TextBox_NCBSpecSerialNumber.Text = Okuma.Scout.SpecCode.NCB.projectNumberFromFile.ToString();

            Okuma.Scout.Enums.NCBSpecGroup selectedGroup = Enums.NCBSpecGroup.NCB1MG;

            switch (ComboBox_NCBSpecGroup.SelectedIndex)
            {
                case 0: { selectedGroup = Enums.NCBSpecGroup.NCB1MG; break; }
                case 1: { selectedGroup = Enums.NCBSpecGroup.NCB2MG; break; }
                case 2: { selectedGroup = Enums.NCBSpecGroup.NCB3MG; break; }
                case 3: { selectedGroup = Enums.NCBSpecGroup.NCB4MG; break; }
                case 4: { selectedGroup = Enums.NCBSpecGroup.NCB5MG; break; }
                case 5: { selectedGroup = Enums.NCBSpecGroup.NCB6MG; break; }
                case 6: { selectedGroup = Enums.NCBSpecGroup.NCB7MG; break; }
                case 7: { selectedGroup = Enums.NCBSpecGroup.NCB8MG; break; }
            }

            TextBox_NCBSpecFirstHalf.Text = Okuma.Scout.SpecCode.NCB.GroupFirstHalf(selectedGroup);
            TextBox_NCBSpecSecondHalf.Text = Okuma.Scout.SpecCode.NCB.GroupSecondHalf(selectedGroup);

            int byteNo = ComboBox_NCBSpecByte.SelectedIndex + 1;
            int bitNo = ComboBox_NCBSpecBit.SelectedIndex;

            TextBox_NCBSpecByteHex.Text = Okuma.Scout.SpecCode.NCB.Byte(selectedGroup, byteNo);
            TextBox_NCBSpecByteBin.Text = ConvertHexToBin(TextBox_NCBSpecByteHex.Text);
            TextBox_NCBSpecBitActive.Text = Okuma.Scout.SpecCode.NCB.Bit(selectedGroup, byteNo, bitNo).ToString();
        }

        /// <summary>
        /// Event triggered when the NC B-Spec radio button's checked state changes
        /// </summary>
        /// <param name="sender">RadioButton object</param>
        /// <param name="e">changed arguments</param>
        private void RadioButton_NCBSpecFile_CheckedChanged(object sender, EventArgs e)
        {
            this.RadioButton_NCBSpecFile();
        }

        /// <summary>
        /// Function called when radio button checked changed event is triggered.
        /// Sets user defined file path and "UseUserDefinedFilePath" properties depending
        /// on the checked state of the radio buttons.
        /// </summary>
        private void RadioButton_NCBSpecFile()
        {
            if ((bool)uiLoaded)
            {
                if (RadioButton_NCBSpecFileUser.Checked == true)
                {
                    Okuma.Scout.SpecCode.NCB.UseUserDefinedFile = true;
                    if (string.IsNullOrEmpty(Okuma.Scout.SpecCode.NCB.UserDefinedFilePath))
                    {
                        this.ChooseNCBSpecFile();
                    }
                }
                else if (RadioButton_NCBSpecFileDefault.Checked == true)
                {
                    Okuma.Scout.SpecCode.NCB.UseUserDefinedFile = false;
                }
            }
        }

        /// <summary>
        /// Button click event for File Select.
        /// Triggers Choose Spec file function and sets radio button checked state. 
        /// </summary>
        /// <param name="sender">button object</param>
        /// <param name="e">click arguments</param>
        private void Button_NCBSpecFileSelectFile_Click(object sender, EventArgs e)
        {
            if (RadioButton_NCBSpecFileDefault.Checked == true)
            {
                RadioButton_NCBSpecFileUser.Checked = true;
            }
            else
            {
                this.ChooseNCBSpecFile();
            }
        }

        /// <summary>
        /// Generate open file dialog for selection of user defined spec file
        /// </summary>
        private void ChooseNCBSpecFile()
        {
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.Title = "Select NC B-Spec Code File";
            ofd.InitialDirectory = @"C:\";
            ofd.CustomPlaces.Add(@"C:\OSP-P\CNS-DAT\");
            ofd.Filter = "NC B-SPEC File (*.DAT)|*.DAT";
            ofd.FilterIndex = 2;
            ofd.RestoreDirectory = true;
            if (ofd.ShowDialog() == DialogResult.OK)
            {
                Okuma.Scout.SpecCode.NCB.UserDefinedFilePath = ofd.FileName;

                if (!Okuma.Scout.SpecCode.NCB.SpecFileIsValid)
                {
                    RadioButton_NCBSpecFileDefault.Checked = true;
                    MessageBox.Show(
                        "The selected Spec Code file is not valid." + Environment.NewLine +
                        "Please choose another file.",
                        "Error Reading File",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Error,
                        MessageBoxDefaultButton.Button1);

                    Okuma.Scout.SpecCode.NCB.UseUserDefinedFile = false;
                    Label_NCBSpecFileUserFile.Text = string.Empty;
                    Okuma.Scout.SpecCode.NCB.UserDefinedFilePath = string.Empty;
                }
                else
                {
                    Label_NCBSpecFileUserFile.Text = ofd.FileName;
                }
            }
            else
            {
                RadioButton_NCBSpecFileDefault.Checked = true;
            }
        }

        /// <summary>
        /// Execution code for PLC Spec 
        /// </summary>
        /// <param name="sender">Button object</param>
        /// <param name="e">button click arguments</param>
        private void Button_PLCSpecFileExecute_Click(object sender, EventArgs e)
        {
            DoPLCSpecExecute();
            PLCSpecExecuted = true;
        }

        private void Combo_PLCSpecGroup_IndexChanged(object sender, EventArgs e)
        {
            if (uiLoaded && PLCSpecExecuted)
            {
                DoPLCSpecExecute();
            }
        }

        private void Combo_PLCSpecByte_IndexChanged(object sender, EventArgs e)
        {
            if (uiLoaded && PLCSpecExecuted)
            {
                DoPLCSpecExecute();
            }
        }

        private void Combo_PLCSpecBit_IndexChanged(object sender, EventArgs e)
        {
            if (uiLoaded && PLCSpecExecuted)
            {
                DoPLCSpecExecute();
            }
        }

        private void DoPLCSpecExecute()
        {
            TextBox_PLCSpecFileExists.Text = Okuma.Scout.SpecCode.PLC.MachineSpecCodeFileExists.ToString();

            Okuma.Scout.Enums.PLCSpecGroup selectedGroup = Enums.PLCSpecGroup.PLC1MG;

            switch (ComboBox_PLCSpecGroup.SelectedIndex)
            {
                case 0: { selectedGroup = Enums.PLCSpecGroup.PLC1MG; break; }
                case 1: { selectedGroup = Enums.PLCSpecGroup.PLC2MG; break; }
                case 2: { selectedGroup = Enums.PLCSpecGroup.PLC3MG; break; }
            }

            TextBox_PLCSpecFirstHalf.Text = Okuma.Scout.SpecCode.PLC.GroupFirstHalf(selectedGroup);
            TextBox_PLCSpecSecondHalf.Text = Okuma.Scout.SpecCode.PLC.GroupSecondHalf(selectedGroup);

            int byteNo = ComboBox_PLCSpecByte.SelectedIndex + 1;
            int bitNo = ComboBox_PLCSpecBit.SelectedIndex;

            TextBox_PLCSpecByteHex.Text = Okuma.Scout.SpecCode.PLC.Byte(selectedGroup, byteNo);
            TextBox_PLCSpecByteBin.Text = ConvertHexToBin(TextBox_PLCSpecByteHex.Text);
            TextBox_PLCSpecBitActive.Text = Okuma.Scout.SpecCode.PLC.Bit(selectedGroup, byteNo, bitNo).ToString();
        }

        /// <summary>
        /// Event triggered when the PLC Spec radio button's checked state changes
        /// </summary>
        /// <param name="sender">RadioButton object</param>
        /// <param name="e">changed arguments</param>
        private void RadioButton_PLCSpecFile_CheckedChanged(object sender, EventArgs e)
        {
            this.RadioButton_PLCSpecFile();
        }

        /// <summary>
        /// Function called when radio button checked changed event is triggered.
        /// Sets user defined file path and "UseUserDefinedFilePath" properties depending
        /// on the checked state of the radio buttons.
        /// </summary>
        private void RadioButton_PLCSpecFile()
        {
            if ((bool)uiLoaded)
            {
                if (RadioButton_PLCSpecFileUser.Checked == true)
                {
                    Okuma.Scout.SpecCode.PLC.UseUserDefinedFile = true;
                    if (string.IsNullOrEmpty(Okuma.Scout.SpecCode.PLC.UserDefinedFilePath))
                    {
                        this.ChoosePLCSpecFile();
                    }
                }
                else if (RadioButton_PLCSpecFileDefault.Checked == true)
                {
                    Okuma.Scout.SpecCode.PLC.UseUserDefinedFile = false;
                }
            }
        }

        /// <summary>
        /// Button click event for File Select.
        /// Triggers Choose Spec file function and sets radio button checked state. 
        /// </summary>
        /// <param name="sender">button object</param>
        /// <param name="e">click arguments</param>
        private void Button_PLCSpecFileSelectFile_Click(object sender, EventArgs e)
        {
            if (RadioButton_PLCSpecFileDefault.Checked == true)
            {
                RadioButton_PLCSpecFileUser.Checked = true;
            }
            else
            {
                this.ChoosePLCSpecFile();
            }
        }

        /// <summary>
        /// Generate open file dialog for selection of user defined spec file
        /// </summary>
        private void ChoosePLCSpecFile()
        {
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.Title = "Select PLC Spec Code File";
            ofd.InitialDirectory = @"C:\";
            ofd.CustomPlaces.Add(@"C:\OSP-P\CNS-DAT\");
            ofd.Filter = "PLC File (*.CNS)|*.CNS";
            ofd.FilterIndex = 2;
            ofd.RestoreDirectory = true;
            if (ofd.ShowDialog() == DialogResult.OK)
            {
                Okuma.Scout.SpecCode.PLC.UserDefinedFilePath = ofd.FileName;

                if (!Okuma.Scout.SpecCode.PLC.SpecFileIsValid)
                {
                    RadioButton_NCBSpecFileDefault.Checked = true;
                    MessageBox.Show(
                        "The selected Spec Code file is not valid." + Environment.NewLine +
                        "Please choose another file.",
                        "Error Reading File",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Error,
                        MessageBoxDefaultButton.Button1);

                    Okuma.Scout.SpecCode.PLC.UseUserDefinedFile = false;
                    Label_PLCSpecFileUserFile.Text = string.Empty;
                    Okuma.Scout.SpecCode.PLC.UserDefinedFilePath = string.Empty;
                }
                else { Label_PLCSpecFileUserFile.Text = ofd.FileName; }
            }
            else { RadioButton_PLCSpecFileDefault.Checked = true; }
        }


        public string ConvertHexToBin(string hex)
        {
            UInt32 theByte = System.Convert.ToUInt32(hex, 16);
            return System.Convert.ToString(theByte, 2).PadLeft(8, '0');
        }

    }
} 

