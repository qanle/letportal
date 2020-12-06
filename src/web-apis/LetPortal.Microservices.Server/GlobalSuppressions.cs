﻿// This file is used by Code Analysis to maintain SuppressMessage
// attributes that are applied to this project.
// Project-level suppressions either have no target or are given
// a specific target and scoped to a namespace, type, member, etc.

[assembly: System.Diagnostics.CodeAnalysis.SuppressMessage("Build", "CA1303:Method 'Task CheckingLostServicesBackgroundTask.ExecuteAsync(CancellationToken stoppingToken)' passes a literal string as parameter 'message' of a call to 'void LoggerExtensions.LogInformation(ILogger logger, string message, params object[] args)'. Retrieve the following string(s) from a resource table instead: \"Setting up lost cron task and shutdown cron task with options {options}\".", Justification = "<Pending>", Scope = "member", Target = "~M:LetPortal.ServiceManagement.CheckingLostServicesBackgroundTask.ExecuteAsync(System.Threading.CancellationToken)~System.Threading.Tasks.Task")]
[assembly: System.Diagnostics.CodeAnalysis.SuppressMessage("Build", "CA1303:Method 'Task CheckingShutdownServicesBackgroundTask.ExecuteAsync(CancellationToken stoppingToken)' passes a literal string as parameter 'message' of a call to 'void LoggerExtensions.LogInformation(ILogger logger, string message, params object[] args)'. Retrieve the following string(s) from a resource table instead: \"Setting up lost cron task and shutdown cron task with options {options}\".", Justification = "<Pending>", Scope = "member", Target = "~M:LetPortal.ServiceManagement.CheckingShutdownServicesBackgroundTask.ExecuteAsync(System.Threading.CancellationToken)~System.Threading.Tasks.Task")]
[assembly: System.Diagnostics.CodeAnalysis.SuppressMessage("Build", "CA1305:The behavior of 'string.Format(string, object)' could vary based on the current user's locale settings. Replace this call in 'Service.CalculateRunningTime()' with a call to 'string.Format(IFormatProvider, string, params object[])'.", Justification = "<Pending>", Scope = "member", Target = "~M:LetPortal.ServiceManagement.Entities.Service.CalculateRunningTime")]
[assembly: System.Diagnostics.CodeAnalysis.SuppressMessage("Build", "CA1303:Method 'Task GatherAllHardwareCounterServicesBackgroundTask.ExecuteAsync(CancellationToken stoppingToken)' passes a literal string as parameter 'message' of a call to 'void LoggerExtensions.LogError(ILogger logger, Exception exception, string message, params object[] args)'. Retrieve the following string(s) from a resource table instead: \"Error during running Services Report Cron Task\".", Justification = "<Pending>", Scope = "member", Target = "~M:LetPortal.ServiceManagement.GatherAllHardwareCounterServicesBackgroundTask.ExecuteAsync(System.Threading.CancellationToken)~System.Threading.Tasks.Task")]
[assembly: System.Diagnostics.CodeAnalysis.SuppressMessage("Build", "CA1031:Modify 'ExecuteAsync' to catch a more specific allowed exception type, or rethrow the exception.", Justification = "<Pending>", Scope = "member", Target = "~M:LetPortal.ServiceManagement.GatherAllHardwareCounterServicesBackgroundTask.ExecuteAsync(System.Threading.CancellationToken)~System.Threading.Tasks.Task")]
[assembly: System.Diagnostics.CodeAnalysis.SuppressMessage("Build", "CA1062:In externally visible method 'Task LogEventProvider.AddLogEvent(PushLogModel pushLogModel)', validate parameter 'pushLogModel' is non-null before using it. If appropriate, throw an ArgumentNullException when the argument is null or add a Code Contract precondition asserting non-null argument.", Justification = "<Pending>", Scope = "member", Target = "~M:LetPortal.ServiceManagement.Providers.LogEventProvider.AddLogEvent(LetPortal.Core.Logger.Models.PushLogModel)~System.Threading.Tasks.Task")]
[assembly: System.Diagnostics.CodeAnalysis.SuppressMessage("Build", "CA1062:In externally visible method 'Task MonitorProvider.AddMonitorPulse(PushHealthCheckModel pushHealthCheckModel)', validate parameter 'pushHealthCheckModel' is non-null before using it. If appropriate, throw an ArgumentNullException when the argument is null or add a Code Contract precondition asserting non-null argument.", Justification = "<Pending>", Scope = "member", Target = "~M:LetPortal.ServiceManagement.Providers.MonitorProvider.AddMonitorPulse(LetPortal.Core.Monitors.Models.PushHealthCheckModel)~System.Threading.Tasks.Task")]
[assembly: System.Diagnostics.CodeAnalysis.SuppressMessage("Build", "CA1062:In externally visible method 'Task<string> ServiceManagamentProvider.RegisterService(RegisterServiceModel registerServiceModel)', validate parameter 'registerServiceModel' is non-null before using it. If appropriate, throw an ArgumentNullException when the argument is null or add a Code Contract precondition asserting non-null argument.", Justification = "<Pending>", Scope = "member", Target = "~M:LetPortal.ServiceManagement.Providers.ServiceManagamentProvider.RegisterService(LetPortal.Core.Services.Models.RegisterServiceModel)~System.Threading.Tasks.Task{System.String}")]
[assembly: System.Diagnostics.CodeAnalysis.SuppressMessage("Build", "CA1062:In externally visible method 'void LetPortalServiceManagementDbContext.OnModelCreating(ModelBuilder modelBuilder)', validate parameter 'modelBuilder' is non-null before using it. If appropriate, throw an ArgumentNullException when the argument is null or add a Code Contract precondition asserting non-null argument.", Justification = "<Pending>", Scope = "member", Target = "~M:LetPortal.ServiceManagement.Repositories.LetPortalServiceManagementDbContext.OnModelCreating(Microsoft.EntityFrameworkCore.ModelBuilder)")]
[assembly: System.Diagnostics.CodeAnalysis.SuppressMessage("Build", "CA1062:In externally visible method 'void ServiceManagamentExtensions.AddServiceManagement(IServiceCollection services, IConfiguration configuration)', validate parameter 'configuration' is non-null before using it. If appropriate, throw an ArgumentNullException when the argument is null or add a Code Contract precondition asserting non-null argument.", Justification = "<Pending>", Scope = "member", Target = "~M:LetPortal.ServiceManagement.ServiceManagamentExtensions.AddServiceManagement(Microsoft.Extensions.DependencyInjection.IServiceCollection,Microsoft.Extensions.Configuration.IConfiguration)")]
[assembly: System.Diagnostics.CodeAnalysis.SuppressMessage("Build", "CA1716:Rename namespace LetPortal.ServiceManagement.Repositories.Implements so that it no longer conflicts with the reserved language keyword 'Implements'. Using a reserved keyword as the name of a namespace makes it harder for consumers in other languages to use the namespace.", Justification = "<Pending>", Scope = "namespace", Target = "~N:LetPortal.ServiceManagement.Repositories.Implements")]