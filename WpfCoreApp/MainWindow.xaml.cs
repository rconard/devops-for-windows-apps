﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Runtime.Versioning;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using OSVersionHelper;

namespace WpfCoreApp
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();

            versionText.Text = typeof(MainWindow).Assembly.GetCustomAttribute<AssemblyInformationalVersionAttribute>().InformationalVersion;
            inPackage.Text = WindowsVersionHelper.HasPackageIdentity.ToString();
            deploymentType.Text = GetDotNetInfo();
        }

        public static string GetDotNetInfo()
        {
            var runTimeDir = new FileInfo(typeof(string).Assembly.Location);
            var entryDir = new FileInfo(Assembly.GetEntryAssembly().Location);
            var IsSelfContaied = runTimeDir.DirectoryName == entryDir.DirectoryName;

            var result = ".NET Core - ";
            if (IsSelfContaied)
            {
                result += "Self Contained Deployment";
            }
            else
            {
                result += "Framework Dependent Deployment";
            }
            
            return result;
        }
    }
}