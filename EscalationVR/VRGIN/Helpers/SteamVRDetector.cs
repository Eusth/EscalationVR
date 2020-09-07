using System;
using System.Diagnostics;
using System.Linq;

namespace VRGIN.Helpers
{
	// Token: 0x020000E6 RID: 230
	public static class SteamVRDetector
	{
		// Token: 0x060005C3 RID: 1475 RVA: 0x0001BF90 File Offset: 0x0001A190
		private static bool FilterInvalidProcesses(global::System.Diagnostics.Process p)
		{
			bool result;
			try
			{
				result = (p.ProcessName != null);
			}
			catch
			{
				result = false;
			}
			return result;
		}

		// Token: 0x1700011A RID: 282
		// (get) Token: 0x060005C4 RID: 1476 RVA: 0x0001BFC4 File Offset: 0x0001A1C4
		public static bool IsRunning
		{
			get
			{
				return global::System.Linq.Enumerable.Any<global::System.Diagnostics.Process>(global::System.Linq.Enumerable.Where<global::System.Diagnostics.Process>(global::System.Diagnostics.Process.GetProcesses(), new global::System.Func<global::System.Diagnostics.Process, bool>(global::VRGIN.Helpers.SteamVRDetector.FilterInvalidProcesses)), (global::System.Diagnostics.Process process) => process.ProcessName == "vrcompositor");
			}
		}
	}
}
