// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.

namespace Microsoft.EntityFrameworkCore.Infrastructure;

/// <summary>
///     This is an internal API that supports the Entity Framework Core infrastructure and not subject to
///     the same compatibility standards as public APIs. It may be changed or removed without notice in
///     any release. You should only use it directly in your code with extreme caution and knowing that
///     doing so can result in application failures when updating to a new Entity Framework Core release.
/// </summary>
public class RelationalSingletonOptions : IRelationalSingletonOptions
{
    /// <summary>
    ///     Initializes the singleton options from the given <see cref="IDbContextOptions" />.
    /// </summary>
    public virtual void Initialize(IDbContextOptions options)
    {
        LineEnding = RelationalOptionsExtension.Extract(options).CommandLineEnding;
    }

    /// <summary>
    ///     Validates that the options in given <see cref="IDbContextOptions" /> have not
    ///     changed when compared to the options already set here, and throws if they have.
    /// </summary>
    public void Validate(IDbContextOptions options)
    {
        var relationalOptions = RelationalOptionsExtension.Extract(options);
        if (LineEnding != relationalOptions.CommandLineEnding)
        {
            throw new InvalidOperationException(
                CoreStrings.SingletonOptionChanged(
                    $"{nameof(RelationalOptionsExtension.CommandLineEnding)}",
                    nameof(DbContextOptionsBuilder.UseInternalServiceProvider)));
        }
    }

    /// <summary>
    ///     This is an internal API that supports the Entity Framework Core infrastructure and not subject to
    ///     the same compatibility standards as public APIs. It may be changed or removed without notice in
    ///     any release. You should only use it directly in your code with extreme caution and knowing that
    ///     doing so can result in application failures when updating to a new Entity Framework Core release.
    /// </summary>
    public LineEnding LineEnding { get; private set; }
}
