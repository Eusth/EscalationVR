using System;
using System.Diagnostics;
using System.IO;

namespace VRGIN.Core
{
	// Token: 0x020000A3 RID: 163
	public class VRLog
	{
		// Token: 0x06000305 RID: 773 RVA: 0x00011264 File Offset: 0x0000F464
		static VRLog()
		{
			global::VRGIN.Core.VRLog.S_Handle = new global::System.IO.StreamWriter(global::System.IO.File.OpenWrite(global::VRGIN.Core.VRLog.LOG_PATH));
			global::VRGIN.Core.VRLog.S_Handle.BaseStream.SetLength(0L);
			global::VRGIN.Core.VRLog.S_Handle.AutoFlush = true;
		}

		// Token: 0x06000306 RID: 774 RVA: 0x000112BE File Offset: 0x0000F4BE
		protected VRLog()
		{
		}

		// Token: 0x06000307 RID: 775 RVA: 0x000112C8 File Offset: 0x0000F4C8
		public static void Debug(string text, params object[] args)
		{
			global::VRGIN.Core.VRLog.Log(text, args, global::VRGIN.Core.VRLog.LogMode.Debug);
		}

		// Token: 0x06000308 RID: 776 RVA: 0x000112D4 File Offset: 0x0000F4D4
		public static void Info(string text, params object[] args)
		{
			global::VRGIN.Core.VRLog.Log(text, args, global::VRGIN.Core.VRLog.LogMode.Info);
		}

		// Token: 0x06000309 RID: 777 RVA: 0x000112E0 File Offset: 0x0000F4E0
		public static void Warn(string text, params object[] args)
		{
			global::VRGIN.Core.VRLog.Log(text, args, global::VRGIN.Core.VRLog.LogMode.Warning);
		}

		// Token: 0x0600030A RID: 778 RVA: 0x000112EC File Offset: 0x0000F4EC
		public static void Error(string text, params object[] args)
		{
			global::VRGIN.Core.VRLog.Log(text, args, global::VRGIN.Core.VRLog.LogMode.Error);
		}

		// Token: 0x0600030B RID: 779 RVA: 0x000112F8 File Offset: 0x0000F4F8
		public static void Debug(object obj)
		{
			global::VRGIN.Core.VRLog.Log("{0}", new object[]
			{
				obj
			}, global::VRGIN.Core.VRLog.LogMode.Debug);
		}

		// Token: 0x0600030C RID: 780 RVA: 0x00011311 File Offset: 0x0000F511
		public static void Info(object obj)
		{
			global::VRGIN.Core.VRLog.Log("{0}", new object[]
			{
				obj
			}, global::VRGIN.Core.VRLog.LogMode.Info);
		}

		// Token: 0x0600030D RID: 781 RVA: 0x0001132A File Offset: 0x0000F52A
		public static void Warn(object obj)
		{
			global::VRGIN.Core.VRLog.Log("{0}", new object[]
			{
				obj
			}, global::VRGIN.Core.VRLog.LogMode.Warning);
		}

		// Token: 0x0600030E RID: 782 RVA: 0x00011343 File Offset: 0x0000F543
		public static void Error(object obj)
		{
			global::VRGIN.Core.VRLog.Log("{0}", new object[]
			{
				obj
			}, global::VRGIN.Core.VRLog.LogMode.Error);
		}

		// Token: 0x0600030F RID: 783 RVA: 0x0001135C File Offset: 0x0000F55C
		public static void Log(string text, object[] args, global::VRGIN.Core.VRLog.LogMode severity)
		{
			try
			{
				bool flag = severity < global::VRGIN.Core.VRLog.Level;
				if (!flag)
				{
					string text2 = string.Format(global::VRGIN.Core.VRLog.Format(text, severity), args);
					object @lock = global::VRGIN.Core.VRLog._LOCK;
					lock (@lock)
					{
						global::System.Console.WriteLine(text2);
						global::VRGIN.Core.VRLog.S_Handle.WriteLine(text2);
					}
				}
			}
			catch (global::System.Exception ex)
			{
				global::System.Console.WriteLine(ex);
			}
		}

		// Token: 0x06000310 RID: 784 RVA: 0x000113E8 File Offset: 0x0000F5E8
		private static string Format(string text, global::VRGIN.Core.VRLog.LogMode mode)
		{
			global::System.Diagnostics.StackTrace stackTrace = new global::System.Diagnostics.StackTrace(3);
			global::System.Diagnostics.StackFrame frame = stackTrace.GetFrame(0);
			return string.Format("[{0}][{1}][{3}#{4}] {2}", new object[]
			{
				global::System.DateTime.Now.ToString("HH':'mm':'ss"),
				mode.ToString().ToUpper(),
				text,
				frame.GetMethod().DeclaringType.Name,
				frame.GetMethod().Name,
				frame.GetFileLineNumber()
			});
		}

		// Token: 0x04000562 RID: 1378
		private static string LOG_PATH = "vr.log";

		// Token: 0x04000563 RID: 1379
		private static object _LOCK = new object();

		// Token: 0x04000564 RID: 1380
		private static global::System.IO.StreamWriter S_Handle;

		// Token: 0x04000565 RID: 1381
		public static global::VRGIN.Core.VRLog.LogMode Level = global::VRGIN.Core.VRLog.LogMode.Info;

		// Token: 0x020001F6 RID: 502
		public enum LogMode
		{
			// Token: 0x0400077C RID: 1916
			Debug,
			// Token: 0x0400077D RID: 1917
			Info,
			// Token: 0x0400077E RID: 1918
			Warning,
			// Token: 0x0400077F RID: 1919
			Error
		}
	}
}
