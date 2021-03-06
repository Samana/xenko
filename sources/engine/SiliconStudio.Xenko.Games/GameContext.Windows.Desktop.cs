// Copyright (c) 2014 Silicon Studio Corp. (http://siliconstudio.co.jp)
// This file is distributed under GPL v3. See LICENSE.md for details.
//
// Copyright (c) 2010-2013 SharpDX - Alexandre Mutel
// 
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
#if SILICONSTUDIO_PLATFORM_WINDOWS_DESKTOP && (SILICONSTUDIO_XENKO_UI_WINFORMS || SILICONSTUDIO_XENKO_UI_WPF)
using System;
using System.Windows.Forms;

namespace SiliconStudio.Xenko.Games
{
    /// <summary>
    /// A <see cref="GameContext"/> to use for rendering to an existing WinForm <see cref="Control"/>.
    /// </summary>
    public class GameContextWinforms : GameContextWindows<Control>
    {
        /// <inheritDoc/>
        /// <param name="isUserManagingRun">Is user managing event processing of <paramref name="control"/>?</param>
        public GameContextWinforms(Control control, int requestedWidth = 0, int requestedHeight = 0, bool isUserManagingRun = false)
            : base(control ?? CreateForm(), requestedWidth, requestedHeight)
        {
            ContextType = AppContextType.Desktop;
            IsUserManagingRun = isUserManagingRun;
        }

        /// <summary>
        /// The is running delegate
        /// </summary>
        public bool IsUserManagingRun { get; protected set; }

        /// <summary>
        /// Gets the run loop to be called when <see cref="IsUserManagingRun"/> is true.
        /// </summary>
        /// <value>The run loop.</value>
        public Action RunCallback { get; internal set; }

        /// <summary>
        /// Gets the exit callback to be called when <see cref="IsUserManagingRun"/> is true when exiting the game.
        /// </summary>
        /// <value>The run loop.</value>
        public Action ExitCallback { get; internal set; }

        private static Form CreateForm()
        {
#if !SILICONSTUDIO_XENKO_GRAPHICS_API_OPENGL && !SILICONSTUDIO_XENKO_GRAPHICS_API_NULL
            return new GameForm();
#else
            // Not Reachable.
            return null;
#endif
        }

    }
}
#endif
