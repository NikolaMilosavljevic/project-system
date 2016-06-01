﻿// Copyright (c) Microsoft.  All Rights Reserved.  Licensed under the Apache License, Version 2.0.  See License.txt in the project root for license information.

using System;
using System.ComponentModel.Composition;

namespace Microsoft.VisualStudio.ProjectSystem
{
    /// <summary>
    ///     Provides an implementation of <see cref="IProjectCapabilitiesService"/> that simply delegates 
    ///     onto the <see cref="CapabilitiesExtensions.Contains(IProjectCapabilitiesScope, string)"/> method.
    /// </summary>
    [Export(typeof(IProjectCapabilitiesService))]
    internal class ProjectCapabilitiesService : IProjectCapabilitiesService
    {
        private readonly UnconfiguredProject _project;

        [ImportingConstructor]
        public ProjectCapabilitiesService(UnconfiguredProject project)
        {
            Requires.NotNull(project, nameof(project));

            _project = project;
        }

        public bool Contains(string capability)
        {
            Requires.NotNullOrEmpty(capability, nameof(capability));

            // Just to check capabilities, requires static state and call context that we cannot influence
            return _project.Capabilities.Contains(capability);
        }
    }
}
