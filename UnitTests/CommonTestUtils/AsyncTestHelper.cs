﻿// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.
// See the LICENSE file in the project root for more information.

using System.Diagnostics;
using GitUI;

namespace CommonTestUtils
{
    public static class AsyncTestHelper
    {
        public static TimeSpan UnexpectedTimeout
        {
            get
            {
                return Debugger.IsAttached ? TimeSpan.FromHours(1) : TimeSpan.FromMinutes(1);
            }
        }

        public static async Task JoinPendingOperationsAsync(TimeSpan timeout)
        {
            using CancellationTokenSource cancellationTokenSource = new(timeout);
            await ThreadHelper.JoinPendingOperationsAsync(cancellationTokenSource.Token);
        }
    }
}
