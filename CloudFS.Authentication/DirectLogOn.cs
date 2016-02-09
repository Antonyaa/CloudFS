﻿/*
The MIT License(MIT)

Copyright(c) 2015 IgorSoft

Permission is hereby granted, free of charge, to any person obtaining a copy
of this software and associated documentation files (the "Software"), to deal
in the Software without restriction, including without limitation the rights
to use, copy, modify, merge, publish, distribute, sublicense, and/or sell
copies of the Software, and to permit persons to whom the Software is
furnished to do so, subject to the following conditions:

The above copyright notice and this permission notice shall be included in all
copies or substantial portions of the Software.

THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR
IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY,
FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE
AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER
LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM,
OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN THE
SOFTWARE.
*/

using System;
using System.Collections.Specialized;
using System.Threading;

namespace IgorSoft.CloudFS.Authentication
{
    public sealed class DirectLogOn : LogOnBase
    {
        public DirectLogOn(SynchronizationContext synchonizationContext) : base(synchonizationContext)
        {
        }

        public void Show(string serviceName, string account)
        {
            base.Show(serviceName, account,
                () => {
                    var window = new LogOnWindow();
                    window.btnAuthenticate.Click += (s, e) => {
                        var parameters = new NameValueCollection();
                        parameters.Add("account", window.tbAccount.Text);
                        parameters.Add("password", window.pbPassword.Password);

                        OnAuthenticated(parameters);

                        window.Close();
                    };
                    return window;
                },
                window => { }
            );
        }
    }
}
