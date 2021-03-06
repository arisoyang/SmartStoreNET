﻿using SmartStore.Core.Domain.DataExchange;

namespace SmartStore.Services.DataExchange.Export
{
	public abstract class ExportProviderBase : IExportProvider
	{
		/// <summary>
		/// The exported entity type
		/// </summary>
		public virtual ExportEntityType EntityType
		{
			get { return ExportEntityType.Product; }
		}

		/// <summary>
		/// File extension of the export files (without dot). Return <c>null</c> for a non file based, on-the-fly export.
		/// </summary>
		public virtual string FileExtension
		{
			get { return null; }
		}

		/// <summary>
		/// Get provider specific configuration information. Return <c>null</c> when no provider specific configuration is required.
		/// </summary>
		public virtual ExportConfigurationInfo ConfigurationInfo
		{
			get { return null; }
		}

		/// <summary>
		/// Export data to a file
		/// </summary>
		/// <param name="context">Export execution context</param>
		protected abstract void Export(IExportExecuteContext context);

		public void Execute(IExportExecuteContext context)
		{
			Export(context);
		}

		/// <summary>
		/// Called once per store when export execution ended
		/// </summary>
		/// <param name="context">Export execution context</param>
		public virtual void OnExecuted(IExportExecuteContext context)
		{
		}
	}
}
