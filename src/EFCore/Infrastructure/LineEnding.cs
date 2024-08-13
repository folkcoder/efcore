// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.

namespace Microsoft.EntityFrameworkCore.Infrastructure;

/// <summary>
///     Indicates the line ending type to use when generating multiline strings..
/// </summary>
public enum LineEnding
{
    /// <summary>
    ///     Generated text will use the default line ending type of the execution environment.
    /// </summary>
    System,

    /// <summary>
    ///     Generated text will use Unix line endings.
    /// </summary>
    Unix,

    /// <summary>
    ///     Generated text will use Windows line endings.
    /// </summary>
    Windows,
}
