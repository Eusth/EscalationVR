using System;
using System.Text;

namespace EscalationVR
{
	// Token: 0x02000003 RID: 3
	public static class ProcessUtils
	{
		// Token: 0x0600000B RID: 11 RVA: 0x000024B0 File Offset: 0x000006B0
		public static string EncodeParameterArgument(string argument, bool force = false)
		{
			bool flag = argument == null;
			if (flag)
			{
				throw new global::System.ArgumentNullException("argument");
			}
			bool flag2 = !force && argument.Length > 0 && argument.IndexOfAny(" \t\n\v\"".ToCharArray()) == -1;
			string result;
			if (flag2)
			{
				result = argument;
			}
			else
			{
				global::System.Text.StringBuilder stringBuilder = new global::System.Text.StringBuilder();
				stringBuilder.Append('"');
				int num = 0;
				int i = 0;
				while (i < argument.Length)
				{
					char c = argument.get_Chars(i);
					char c2 = c;
					char c3 = c2;
					if (c3 == '"')
					{
						stringBuilder.Append('\\', num * 2 + 1);
						stringBuilder.Append(c);
						goto IL_B5;
					}
					if (c3 != '\\')
					{
						stringBuilder.Append('\\', num);
						stringBuilder.Append(c);
						goto IL_B5;
					}
					num++;
					IL_B8:
					i++;
					continue;
					IL_B5:
					num = 0;
					goto IL_B8;
				}
				stringBuilder.Append('\\', num * 2);
				stringBuilder.Append('"');
				result = stringBuilder.ToString();
			}
			return result;
		}
	}
}
