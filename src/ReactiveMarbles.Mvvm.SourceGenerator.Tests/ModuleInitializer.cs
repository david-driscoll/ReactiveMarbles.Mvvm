// Copyright (c) 2019-2023 ReactiveUI Association Incorporated. All rights reserved.
// ReactiveUI Association Incorporated licenses this file to you under the MIT license.
// See the LICENSE file in the project root for full license information.

using VerifyTests;

namespace ReactiveMarbles.Mvvm.SourceGenerator.Tests;

/// <summary>
/// Initialize for the module.
/// </summary>
public static class ModuleInitializer
{
    /// <summary>
    /// Initializes the source generators.
    /// </summary>
    public static void Init() => VerifySourceGenerators.Enable();
}
