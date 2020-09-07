using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using VRGIN.Core;

namespace VRGIN.Native
{
	// Token: 0x02000091 RID: 145
	public class WindowManager
	{
		// Token: 0x0600025E RID: 606 RVA: 0x0000F00C File Offset: 0x0000D20C
		private static global::System.Collections.Generic.List<global::System.IntPtr> GetRootWindowsOfProcess(int pid)
		{
			global::System.Collections.Generic.List<global::System.IntPtr> childWindows = global::VRGIN.Native.WindowManager.GetChildWindows(global::System.IntPtr.Zero);
			global::System.Collections.Generic.List<global::System.IntPtr> list = new global::System.Collections.Generic.List<global::System.IntPtr>();
			foreach (global::System.IntPtr intPtr in childWindows)
			{
				uint num;
				global::VRGIN.Native.WindowsInterop.GetWindowThreadProcessId(intPtr, out num);
				bool flag = (ulong)num == (ulong)((long)pid);
				if (flag)
				{
					list.Add(intPtr);
				}
			}
			return list;
		}

		// Token: 0x0600025F RID: 607 RVA: 0x0000F090 File Offset: 0x0000D290
		private static global::System.Collections.Generic.List<global::System.IntPtr> GetChildWindows(global::System.IntPtr parent)
		{
			global::System.Collections.Generic.List<global::System.IntPtr> list = new global::System.Collections.Generic.List<global::System.IntPtr>();
			global::System.Runtime.InteropServices.GCHandle gchandle = global::System.Runtime.InteropServices.GCHandle.Alloc(list);
			try
			{
				global::VRGIN.Native.WindowsInterop.Win32Callback callback = new global::VRGIN.Native.WindowsInterop.Win32Callback(global::VRGIN.Native.WindowManager.EnumWindow);
				global::VRGIN.Native.WindowsInterop.EnumChildWindows(parent, callback, global::System.Runtime.InteropServices.GCHandle.ToIntPtr(gchandle));
			}
			finally
			{
				bool isAllocated = gchandle.IsAllocated;
				if (isAllocated)
				{
					gchandle.Free();
				}
			}
			return list;
		}

		// Token: 0x06000260 RID: 608 RVA: 0x0000F0F8 File Offset: 0x0000D2F8
		private static bool EnumWindow(global::System.IntPtr handle, global::System.IntPtr pointer)
		{
			global::System.Collections.Generic.List<global::System.IntPtr> list = global::System.Runtime.InteropServices.GCHandle.FromIntPtr(pointer).Target as global::System.Collections.Generic.List<global::System.IntPtr>;
			bool flag = list == null;
			if (flag)
			{
				throw new global::System.InvalidCastException("GCHandle Target could not be cast as List<IntPtr>");
			}
			list.Add(handle);
			return true;
		}

		// Token: 0x1700003E RID: 62
		// (get) Token: 0x06000261 RID: 609 RVA: 0x0000F13C File Offset: 0x0000D33C
		public static global::System.IntPtr Handle
		{
			get
			{
				bool flag = global::VRGIN.Native.WindowManager._Handle == null;
				if (flag)
				{
					int num = 0;
					global::VRGIN.Native.WindowsInterop.RECT rect = default(global::VRGIN.Native.WindowsInterop.RECT);
					string processName = global::System.Diagnostics.Process.GetCurrentProcess().ProcessName;
					global::System.Collections.Generic.List<global::System.IntPtr> rootWindowsOfProcess = global::VRGIN.Native.WindowManager.GetRootWindowsOfProcess(global::System.Diagnostics.Process.GetCurrentProcess().Id);
					foreach (global::System.IntPtr intPtr in rootWindowsOfProcess)
					{
						bool flag2 = global::VRGIN.Native.WindowsInterop.GetWindowRect(intPtr, ref rect) && rect.Right - rect.Left > num;
						if (flag2)
						{
							num = rect.Right - rect.Left;
							global::VRGIN.Native.WindowManager._Handle = new global::System.IntPtr?(intPtr);
						}
					}
					bool flag3 = global::VRGIN.Native.WindowManager._Handle == null;
					if (flag3)
					{
						global::VRGIN.Core.VRLog.Warn("Fall back to first handle!", global::System.Array.Empty<object>());
						global::VRGIN.Native.WindowManager._Handle = new global::System.IntPtr?(global::System.Linq.Enumerable.First<global::System.IntPtr>(rootWindowsOfProcess));
					}
				}
				return global::VRGIN.Native.WindowManager._Handle.Value;
			}
		}

		// Token: 0x06000262 RID: 610 RVA: 0x0000F250 File Offset: 0x0000D450
		public static string GetWindowText(global::System.IntPtr hWnd)
		{
			int windowTextLength = global::VRGIN.Native.WindowsInterop.GetWindowTextLength(hWnd);
			global::System.Text.StringBuilder stringBuilder = new global::System.Text.StringBuilder(windowTextLength + 1);
			global::VRGIN.Native.WindowsInterop.GetWindowText(hWnd, stringBuilder, stringBuilder.Capacity);
			return stringBuilder.ToString();
		}

		// Token: 0x06000263 RID: 611 RVA: 0x0000F288 File Offset: 0x0000D488
		public static void ConfineCursor()
		{
			global::VRGIN.Native.WindowsInterop.RECT clientRect = global::VRGIN.Native.WindowManager.GetClientRect();
			global::VRGIN.Native.WindowsInterop.ClipCursor(ref clientRect);
		}

		// Token: 0x06000264 RID: 612 RVA: 0x0000F2A4 File Offset: 0x0000D4A4
		public static global::VRGIN.Native.WindowsInterop.RECT GetClientRect()
		{
			global::VRGIN.Native.WindowsInterop.RECT result = default(global::VRGIN.Native.WindowsInterop.RECT);
			global::VRGIN.Native.WindowsInterop.GetClientRect(global::VRGIN.Native.WindowManager.Handle, ref result);
			global::VRGIN.Native.WindowsInterop.POINT point = default(global::VRGIN.Native.WindowsInterop.POINT);
			global::VRGIN.Native.WindowsInterop.ClientToScreen(global::VRGIN.Native.WindowManager.Handle, ref point);
			result.Left = point.X;
			result.Top = point.Y;
			result.Right += point.X;
			result.Bottom += point.Y;
			return result;
		}

		// Token: 0x06000265 RID: 613 RVA: 0x0000F31D File Offset: 0x0000D51D
		public static void Activate()
		{
			global::VRGIN.Native.WindowsInterop.SetForegroundWindow(global::VRGIN.Native.WindowManager.Handle);
		}

		// Token: 0x04000536 RID: 1334
		private static global::System.IntPtr? _Handle;
	}
}
