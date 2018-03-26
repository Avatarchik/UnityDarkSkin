using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace UnityDarkSkin
{
    public partial class Main : Window
    {
        byte[] appdata = new byte[] { };
        SkinData currentSkin = null;
        static string GetSkinDataName(SkinDataType skin)
        {
            return Enum.GetName(typeof(SkinDataType), skin);
        }
        internal enum SkinDataType { White = 117, Black = 116 }
        internal class SkinData
        {
            public SkinDataType skin = SkinDataType.White;
            public string SkinName => GetSkinDataName(skin);
            public int index;
            public SkinData(SkinDataType _skin, int _index)
            {
                skin = _skin;
                index = _index;
            }
        }
        internal class UnityRegistredVersion
        {
            public DirectoryInfo path;
            public string version;
            public FileInfo file;
            public UnityRegistredVersion(DirectoryInfo _path, string _version)
            {
                path = _path;
                version = _version;
                file = new FileInfo(_path.FullName + "Unity.exe");
            }
            
        }
        List<UnityRegistredVersion> unityVersions = new List<UnityRegistredVersion>();
        int UnitySelectedIndex = 0;
        UnityRegistredVersion UnitySelected => unityVersions.Count > 0 ? unityVersions[UnitySelectedIndex] : null;
        public Main()
        {
            InitializeComponent();
            LoadUnityVersions();
            btn_changeSkin.IsEnabled = false;
            LoadTheme();
        }
        public  void LoadUnityVersions()
        {
            unityVersions.Clear();
            versionSelector.Items.Clear();
            versionSelector.SelectedIndex = -1;
            RegistryKey reg = Registry.CurrentUser.OpenSubKey("SOFTWARE\\Unity Technologies\\Installer", true);
            if (reg == null)
            {
                MessageBox.Show("No version of unity was found", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                Environment.Exit(0);
            }
            else
            {
                foreach (string key in reg.GetSubKeyNames())
                {
                    RegistryKey r = reg.OpenSubKey(key);
                    DirectoryInfo path = new DirectoryInfo(r.GetValue("Location" + (Environment.Is64BitOperatingSystem ? " x64" : "")).ToString() + "\\Editor\\");
                    string version = r.GetValue("Version").ToString();
                    var item = new UnityRegistredVersion(path, version);
                    if (item.file.Exists)
                    {
                        unityVersions.Add(item);
                        versionSelector.Items.Add(new TextBlock() { Text = "Unity v" + item.version });
                    }
                }
                if (versionSelector.Items.Count > 0)
                {
                    versionSelector.SelectedIndex = 0;
                    btn_loadUnity.IsEnabled = true;
                }
            }
        }
        void LoadTheme()
        {
            bool isWhite = currentSkin == null || currentSkin.skin == SkinDataType.White;

            btn_changeSkin.Source = GetImage("proSkin_" + (isWhite ? "0" : "1") + ".png");

            bg.Background = new SolidColorBrush(isWhite ? Colors.White : GetColorFromHex("#343434"));
            tabbar.Background = new LinearGradientBrush(isWhite ? Colors.White : GetColorFromHex("#404040"), GetColorFromHex("#70000000"), new Point(0.5, 0), new Point(0.5, 1));
            tabmain.Background = new LinearGradientBrush(isWhite ? GetColorFromHex("#E6E6E6") : GetColorFromHex("464646"), isWhite ? GetColorFromHex("#ffffff") : GetColorFromHex("#404040"), new Point(0.5, 0), new Point(0.5, 1));
            tabmain.Foreground = new SolidColorBrush(isWhite ? GetColorFromHex("#343434") : GetColorFromHex("#B4B4B4"));
            txt_unityLocation.Foreground = txt_proskinlabel.Foreground = btn_close.Foreground = versionSelector.BorderBrush = versionSelector.Foreground = btn_loadUnity.Foreground = tabmain.Foreground;
            txt_unityLocation.Background = btn_loadUnity.Background = versionSelector.Background = isWhite? new SolidColorBrush(GetColorFromHex("#E6E6E6")): bg.Background;
            
            foreach (var i in versionSelector.Items)
                (i as TextBlock).Foreground = versionSelector.Foreground;
        }
        void LoadSkin()
        {
            appdata = File.ReadAllBytes(UnitySelected.file.FullName);
            var whiteSkin = FindSkinData(SkinDataType.White);
            var blackSkin = FindSkinData(SkinDataType.Black);
            if (whiteSkin == null && blackSkin == null)
            {
                MessageBox.Show("This version of unity is not supported!", "", MessageBoxButton.OK, MessageBoxImage.Warning);
                Environment.Exit(0);
                return;
            }

            currentSkin = whiteSkin ?? blackSkin;
            LoadTheme();
        }
        BitmapImage GetImage(string path) => new BitmapImage(new Uri("pack://application:,,,/Resources/imagens/" + path));
        public Color GetColorFromHex(string hex)
        {
            if (hex.StartsWith("#"))
                hex = hex.Substring(1);
            int
                a = 255;
            if (hex.Length > 6)
            {
                a = int.Parse(hex.Substring(0, 2), NumberStyles.HexNumber);
                hex = hex.Substring(2);
            }
            while (hex.Length < 6)
                hex += "f";

            int.TryParse(hex.Substring(0, 2), NumberStyles.HexNumber, null, out int r);
            hex = hex.Substring(2);
            int.TryParse(hex.Substring(0, 2), NumberStyles.HexNumber, null, out int g);
            hex = hex.Substring(2);
            int.TryParse(hex.Substring(0, 2), NumberStyles.HexNumber, null, out int b);

            return Color.FromArgb((byte)a, (byte)r, (byte)g, (byte)b);
        }
        SkinDataType GetInverseSkin(SkinDataType skin)
        {
            return skin == SkinDataType.White ? SkinDataType.Black : SkinDataType.White;
        }
        SkinData FindSkinData(SkinDataType type)
        {
            byte[] d = new byte[] { 132, 192, (byte)type, 4, 51, 192, 94, 195, 139, 6, 94, 195 };
            if (Environment.Is64BitOperatingSystem)
                d = new byte[] { 132, 192, (byte)type, 8, 51, 192, 72, 131, 196, 32, 91, 195, 139, 3, 72, 131, 196, 32, 91, 195 };

            int c = 0;
            SkinData found = null;
            for (int x = 0; x < appdata.Length; x++)
            {
                if (c >= d.Length)
                {
                    int i = x - d.Length + 2;
                    if (appdata[i] == d[2])
                        found = new SkinData(type, i);
                    break;
                }
                else
                {
                    if (d[c] == appdata[x])
                        c++;
                    else
                        c = 0;
                }
            }
            return found;
        }
        void PatchFile(SkinDataType newType)
        {
            if (currentSkin != null)
            {
                var r = FindSkinData(currentSkin.skin);
                if(r != null)
                {
                    appdata[r.index] = (byte)newType;
                    File.WriteAllBytes(UnitySelected.file.FullName, appdata);
                    LoadSkin();
                    MessageBox.Show("Write file successfuly.", "Patched!", MessageBoxButton.OK, MessageBoxImage.Information);
                }
                else
                {
                    MessageBox.Show("There was an error writing the file.", "Error!", MessageBoxButton.OK, MessageBoxImage.Error);
                }
            }
        }
        bool moving = false;
        double movingX;
        double movingY;
        private void Appmove_MouseDown(object sender, MouseButtonEventArgs e)
        {
            moving = true;
            Grid panel = sender as Grid;
            movingX = e.GetPosition(panel).X;
            movingY = e.GetPosition(panel).Y;
            panel.CaptureMouse();
        }

        private void Appmove_MouseMove(object sender, MouseEventArgs e)
        {
            if (!moving) return;

            Grid panel = sender as Grid;
            double x = e.GetPosition(panel).X;
            double y = e.GetPosition(panel).Y;
            Left = (x + Left) - movingX;
            Top = (y + Top) - movingY;
        }

        private void Appmove_MouseUp(object sender, MouseButtonEventArgs e)
        {
            moving = false;
            Grid panel = sender as Grid;
            panel.ReleaseMouseCapture();
        }

        private void Btn_Click(object sender, RoutedEventArgs e)
        {
            string name = (sender as Button).Name;
            ParseCommand(name);
        }

        private void Btn_MouseDown(object sender, MouseButtonEventArgs e)
        {
            string name = (sender as Image).Name;
            ParseCommand(name);
        }
        void ParseCommand(string name)
        {
            if (name == "btn_loadUnity")
            {
                UnitySelectedIndex = versionSelector.SelectedIndex;
                Process[] plist = Process.GetProcessesByName("Unity");
                if (plist.Any())
                {
                    MessageBox.Show("Unity process already running, close and try again.", "Error!", MessageBoxButton.OK, MessageBoxImage.Error);
                }
                else
                {
                    txt_unityLocation.Text = UnitySelected.file.FullName;
                    txt_unityLocation.ScrollToHorizontalOffset(txt_unityLocation.Text.Length - 1);
                    btn_changeSkin.IsEnabled = true;
                    LoadSkin();
                }
            }
            else if(name == "btn_changeSkin")
            {
                PatchFile(GetInverseSkin(currentSkin.skin));
            }
            else if (name == "btn_close")
            {
                this.Close();
            }
        }
    }
}
