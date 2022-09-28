

using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Reflection;
using System.Runtime.InteropServices;
using System.Runtime.Loader;
using System.Security;
using CommandLine;
// dotnet run --task AndroidBuild --path /Users/elialoni/Development/SliderZ --output /Users/elialoni/Development/SliderZ/output
namespace UrhoCooker
{
    public class Options
    {

        [Option("task", Required = true, HelpText = "Set Task")]
        public string Task { get; set; } = "";

        [Option("architecture", Required = false, HelpText = "Set Architecture , android/ios")]
        public string Arch { get; set; } = "";

        [Option("subtask", Required = false, HelpText = "Set Sub Task")]
        public string SubTask { get; set; } = "";

        [Option("type", Required = false, HelpText = "Set type release/debug")]
        public string Type { get; set; } = "";

        [Option("path", Default = "", Required = true, HelpText = "Set project path")]
        public string ProjectPath { get; set; } = "";

        [Option("output", Required = false, HelpText = "Set output path for build binaries")]
        public string OutputPath { get; set; } = "";

        [Option("verbose", Required = false, HelpText = "Set verbose messages")]
        public bool Verbose { get; set; } = false;

        [Option( "install", Required = false, HelpText = "Install binary")]
        public bool Install { get; set; } = false;

        [Option( "encrypt", Required = false, HelpText = "Encrypt Game.dll")]
        public bool Encrypt { get; set; } = false;

        [Option( "encrypt-key", Required = false, HelpText = "Encryption key path relative to project path")]
        public string EncryptKeyPath { get; set; } = "";

        [Option("developer", Required = false, HelpText = "iOS developer ID")]
        public string DeveloperID { get; set; } = "";

        [Option("graphics", Required = false, HelpText = "Graphics backend , default is OpenGL/OpenGL ES")]
        public string GraphicsBackend { get; set; } = "";

        [Option( "debug", Required = false, HelpText = "install and debug binary")]
        public bool Debug { get; set; } = false;

        [Option( "obfuscate", Required = false, HelpText = "obfuscate the source code")]
        public bool Obfuscate { get; set; } = false;

        [Option("keystore", Required = false, HelpText = "Android key store path")]
        public string KeyStorePath { get; set; } = "";

    }

}
