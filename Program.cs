﻿// Copyright (c) 2022 Eli Aloni (a.k.a  elix22)
// Permission is hereby granted, free of charge, to any person obtaining a copy
// of this software and associated documentation files (the "Software"), to deal
// in the Software without restriction, including without limitation the rights
// to use, copy, modify, merge, publish, distribute, sublicense, and/or sell
// copies of the Software, and to permit persons to whom the Software is
// furnished to do so, subject to the following conditions:
//
// The above copyright notice and this permission notice shall be included in
// all copies or substantial portions of the Software.
//
// THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR
// IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY,
// FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE
// AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER
// LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM,
// OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN
// THE SOFTWARE.
//


using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Reflection;
using System.Runtime.InteropServices;
using System.Runtime.Loader;
using System.Security;
using CommandLine;
using Microsoft.Build.Framework;

namespace UrhoCooker
{

    class Program
    {
        static UrhoCookerBuildEngine buildEngine = new UrhoCookerBuildEngine();
        static void Main(string[] args)
        {
            Parser.Default.ParseArguments<Options>(args)
           .WithParsed(RunOptions);

        }

        static void RunOptions(Options opts)
        {
            if (opts.Task != string.Empty)
            {
                switch (opts.Task)
                {
                    case "build":
                        {
                            switch (opts.Arch)
                            {
                                case "android":
                                    {
                                        var task = new AndroidBuildTask(opts);
                                        task.BuildEngine = buildEngine;
                                        task.Execute();
                                    }
                                    break;

                                case "ios":
                                    {
                                        var task = new IOSBuildTask(opts);
                                        task.BuildEngine = buildEngine;
                                        task.Execute();
                                    }
                                    break;

                                default:
                                    {
                                        Console.WriteLine("Unknown Architecture " + opts.Task);
                                    }
                                    break;
                            }

                        }
                        break;

                    case "clean":
                        {

                            var task = new CleanTask(opts);
                            task.BuildEngine = buildEngine;
                            task.Execute();
                        }
                        break;

                    default:
                        {
                            Console.WriteLine("Unknown task " + opts.Task);
                        }
                        break;
                }
            }
        }
    }
}
