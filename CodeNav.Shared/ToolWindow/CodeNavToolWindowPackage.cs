﻿using System;
using System.Runtime.InteropServices;
using System.Threading;
using Community.VisualStudio.Toolkit;
using Microsoft.VisualStudio;
using Microsoft.VisualStudio.Shell;
using Task = System.Threading.Tasks.Task;

namespace CodeNav.ToolWindow
{
    [Guid(PackageGuids.guidCodeNavToolWindowPackageString)]
    [PackageRegistration(UseManagedResourcesOnly = true, AllowsBackgroundLoading = true)]
    [InstalledProductRegistration("#110", "#112", "1.0", IconResourceID = 400)]
    [ProvideToolWindow(typeof(CodeNavToolWindow.Pane))]
    [ProvideToolWindowVisibility(typeof(CodeNavToolWindow.Pane), VSConstants.UICONTEXT.SolutionExists_string)]
    [ProvideMenuResource("Menus.ctmenu", 1)]
    [ProvideProfile(typeof(OptionsProvider.GeneralOptions), "CodeNav", "CodeNav", 110, 110, false, DescriptionResourceID = 114)]
    public sealed class CodeNavToolWindowPackage : ToolkitPackage
    {
        protected override async Task InitializeAsync(CancellationToken cancellationToken, IProgress<ServiceProgressData> progress)
        {
            this.RegisterToolWindows();

            await this.RegisterCommandsAsync();
        }
    }
}
