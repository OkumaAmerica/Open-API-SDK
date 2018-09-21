//-----------------------------------------------------------------------
// <copyright file="NativeMethods.cs" company="Okuma America Corporation">
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
    using System.Runtime.InteropServices;
    using System.Text;

    /// <summary>
    /// Class for holding Win32 and COM wrappers
    /// </summary>
    public static class NativeMethods
    {
        [DllImport("user32")]
        internal static extern bool HideCaret(IntPtr hWnd);
    }
}
