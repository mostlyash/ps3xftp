﻿using System;
using DevExpress.XtraEditors;
using ModioX.Models.Resources;

namespace ModioX.Forms.Windows
{
    public partial class SettingsWindow : XtraForm
    {
        public SettingsWindow()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Get the user's current settings data.
        /// </summary>
        public static SettingsData Settings { get; } = MainWindow.Settings;

        private void SettingsWindow_Load(object sender, EventArgs e)
        {
            /* Appearance */

            // Theme
            CheckBoxSaveThemeOnClose.Checked = Settings.SaveSkinOnClose;

            // File Size
            CheckBoxShowFileSizeInBytes.Checked = Settings.ShowFileSizeInBytes;

            // Xbox Debugging (HexBox)
            ColorXboxDebuggingFont.Color = Settings.HexBoxForeColor;
            ColorXboxDebuggingBackground.Color = Settings.HexBoxBackColor;

            /* Database */
            RadioConsoles.SelectedIndex = Settings.LoadConsoleMods switch
            {
                ConsoleTypePrefix.PS3 => 0,
                ConsoleTypePrefix.XBOX => 1,
                _ => 0,
            };

            /* Content Recognition */
            CheckBoxAutoDetectGameRegions.Checked = Settings.AutoDetectGameRegions;
            CheckBoxAutoDetectGameTitles.Checked = Settings.AutoDetectGameTitles;
            CheckBoxRememberGameRegions.Checked = Settings.RememberGameRegions;

            /* File Manager */
            CheckBoxSaveLocalPath.Checked = Settings.SaveLocalPath;
            CheckBoxSaveConsolePath.Checked = Settings.SaveConsolePath;

            /* Plugins Editor */
            TextBoxLaunchIniFilePath.Text = Settings.LaunchIniFilePath;
        }

        private void ButtonSaveSettings_Click(object sender, EventArgs e)
        {
            /* Appearance */

            // Theme
            Settings.SaveSkinOnClose = CheckBoxSaveThemeOnClose.Checked;

            // File Size
            Settings.ShowFileSizeInBytes = CheckBoxShowFileSizeInBytes.Checked;

            /* Database */
            Settings.LoadConsoleMods = RadioConsoles.SelectedIndex switch
            {
                0 => ConsoleTypePrefix.PS3,
                1 => ConsoleTypePrefix.XBOX,
                _ => ConsoleTypePrefix.PS3
            };

            /* Content Recognition */
            Settings.AutoDetectGameRegions = CheckBoxAutoDetectGameRegions.Checked;
            Settings.AutoDetectGameTitles = CheckBoxAutoDetectGameTitles.Checked;
            Settings.RememberGameRegions = CheckBoxRememberGameRegions.Checked;

            /* File Manager */
            Settings.SaveLocalPath = CheckBoxSaveLocalPath.Checked;
            Settings.SaveConsolePath = CheckBoxSaveConsolePath.Checked;

            /* Plugins Editor */
            Settings.LaunchIniFilePath = TextBoxLaunchIniFilePath.Text;

            Close();
        }
    }
}