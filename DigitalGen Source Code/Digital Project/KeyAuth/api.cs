using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Diagnostics;
using System.IO;
using System.Net;
using System.Net.Security;
using System.Runtime.Serialization;
using System.Security.Cryptography;
using System.Security.Cryptography.X509Certificates;
using System.Security.Principal;
using System.Text;
using System.Threading;

namespace KeyAuth
{
	// Token: 0x02000002 RID: 2
	public class api
	{
		// Token: 0x06000001 RID: 1 RVA: 0x00002050 File Offset: 0x00000250
		public api(string name, string ownerid, string secret, string version)
		{
			bool flag = ownerid.Length != 10 || secret.Length != 64;
			if (flag)
			{
				api.error("Application not setup correctly. Please watch video link found in Program.cs");
				Environment.Exit(0);
			}
			this.name = name;
			this.ownerid = ownerid;
			this.secret = secret;
			this.version = version;
		}

		// Token: 0x06000002 RID: 2 RVA: 0x000020E8 File Offset: 0x000002E8
		public void init()
		{
			string sentKey = encryption.iv_key();
			api.enckey = sentKey + "-" + this.secret;
			NameValueCollection nameValueCollection = new NameValueCollection();
			nameValueCollection["type"] = "init";
			nameValueCollection["ver"] = this.version;
			nameValueCollection["hash"] = api.checksum(Process.GetCurrentProcess().MainModule.FileName);
			nameValueCollection["enckey"] = sentKey;
			nameValueCollection["name"] = this.name;
			nameValueCollection["ownerid"] = this.ownerid;
			NameValueCollection values_to_upload = nameValueCollection;
			string response = api.req(values_to_upload);
			bool flag = response == "KeyAuth_Invalid";
			if (flag)
			{
				api.error("Application not found");
				Environment.Exit(0);
			}
			api.response_structure json = this.response_decoder.string_to_generic<api.response_structure>(response);
			this.load_response_struct(json);
			bool success = json.success;
			if (success)
			{
				this.load_app_data(json.appinfo);
				api.sessionid = json.sessionid;
				this.initialized = true;
			}
			else
			{
				bool flag2 = json.message == "invalidver";
				if (flag2)
				{
					this.app_data.downloadLink = json.download;
				}
			}
		}

		// Token: 0x06000003 RID: 3 RVA: 0x00002228 File Offset: 0x00000428
		public void CheckInit()
		{
			bool flag = !this.initialized;
			if (flag)
			{
				api.error("You must run the function KeyAuthApp.init(); first");
				Environment.Exit(0);
			}
		}

		// Token: 0x06000004 RID: 4 RVA: 0x00002258 File Offset: 0x00000458
		public string expirydaysleft(string Type, int subscription)
		{
			this.CheckInit();
			DateTime dtDateTime = new DateTime(1970, 1, 1, 0, 0, 0, 0, DateTimeKind.Local);
			dtDateTime = dtDateTime.AddSeconds((double)long.Parse(this.user_data.subscriptions[subscription].expiry)).ToLocalTime();
			TimeSpan difference = dtDateTime - DateTime.Now;
			string text = Type.ToLower();
			string a = text;
			string result;
			if (!(a == "months"))
			{
				if (!(a == "days"))
				{
					if (!(a == "hours"))
					{
						result = null;
					}
					else
					{
						result = Convert.ToString(difference.Hours);
					}
				}
				else
				{
					result = Convert.ToString(difference.Days);
				}
			}
			else
			{
				result = Convert.ToString(difference.Days / 30);
			}
			return result;
		}

		// Token: 0x06000005 RID: 5 RVA: 0x00002328 File Offset: 0x00000528
		public void register(string username, string pass, string key, string email = "")
		{
			this.CheckInit();
			string hwid = WindowsIdentity.GetCurrent().User.Value;
			NameValueCollection nameValueCollection = new NameValueCollection();
			nameValueCollection["type"] = "register";
			nameValueCollection["username"] = username;
			nameValueCollection["pass"] = pass;
			nameValueCollection["key"] = key;
			nameValueCollection["email"] = email;
			nameValueCollection["hwid"] = hwid;
			nameValueCollection["sessionid"] = api.sessionid;
			nameValueCollection["name"] = this.name;
			nameValueCollection["ownerid"] = this.ownerid;
			NameValueCollection values_to_upload = nameValueCollection;
			string response = api.req(values_to_upload);
			api.response_structure json = this.response_decoder.string_to_generic<api.response_structure>(response);
			this.load_response_struct(json);
			bool success = json.success;
			if (success)
			{
				this.load_user_data(json.info);
			}
		}

		// Token: 0x06000006 RID: 6 RVA: 0x00002410 File Offset: 0x00000610
		public void forgot(string username, string email)
		{
			this.CheckInit();
			NameValueCollection nameValueCollection = new NameValueCollection();
			nameValueCollection["type"] = "forgot";
			nameValueCollection["username"] = username;
			nameValueCollection["email"] = email;
			nameValueCollection["sessionid"] = api.sessionid;
			nameValueCollection["name"] = this.name;
			nameValueCollection["ownerid"] = this.ownerid;
			NameValueCollection values_to_upload = nameValueCollection;
			string response = api.req(values_to_upload);
			api.response_structure json = this.response_decoder.string_to_generic<api.response_structure>(response);
			this.load_response_struct(json);
		}

		// Token: 0x06000007 RID: 7 RVA: 0x000024A8 File Offset: 0x000006A8
		public void login(string username, string pass)
		{
			this.CheckInit();
			string hwid = WindowsIdentity.GetCurrent().User.Value;
			NameValueCollection nameValueCollection = new NameValueCollection();
			nameValueCollection["type"] = "login";
			nameValueCollection["username"] = username;
			nameValueCollection["pass"] = pass;
			nameValueCollection["hwid"] = hwid;
			nameValueCollection["sessionid"] = api.sessionid;
			nameValueCollection["name"] = this.name;
			nameValueCollection["ownerid"] = this.ownerid;
			NameValueCollection values_to_upload = nameValueCollection;
			string response = api.req(values_to_upload);
			api.response_structure json = this.response_decoder.string_to_generic<api.response_structure>(response);
			this.load_response_struct(json);
			bool success = json.success;
			if (success)
			{
				this.load_user_data(json.info);
			}
		}

		// Token: 0x06000008 RID: 8 RVA: 0x00002578 File Offset: 0x00000778
		public void web_login()
		{
			this.CheckInit();
			string hwid = WindowsIdentity.GetCurrent().User.Value;
			HttpListener listener;
			HttpListenerRequest request;
			HttpListenerResponse responsepp;
			for (;;)
			{
				listener = new HttpListener();
				string outputten = "handshake";
				outputten = "http://localhost:1337/" + outputten + "/";
				listener.Prefixes.Add(outputten);
				listener.Start();
				HttpListenerContext context = listener.GetContext();
				request = context.Request;
				responsepp = context.Response;
				responsepp.AddHeader("Access-Control-Allow-Methods", "GET, POST");
				responsepp.AddHeader("Access-Control-Allow-Origin", "*");
				responsepp.AddHeader("Via", "hugzho's big brain");
				responsepp.AddHeader("Location", "your kernel ;)");
				responsepp.AddHeader("Retry-After", "never lmao");
				responsepp.Headers.Add("Server", "\r\n\r\n");
				bool flag = request.HttpMethod == "OPTIONS";
				if (!flag)
				{
					break;
				}
				responsepp.StatusCode = 200;
				Thread.Sleep(1);
				listener.Stop();
			}
			listener.AuthenticationSchemes = AuthenticationSchemes.Negotiate;
			listener.UnsafeConnectionNtlmAuthentication = true;
			listener.IgnoreWriteExceptions = true;
			string data = request.RawUrl;
			string datastore2 = data.Replace("/handshake?user=", "");
			datastore2 = datastore2.Replace("&token=", " ");
			string datastore3 = datastore2;
			string user = datastore3.Split(Array.Empty<char>())[0];
			string token = datastore3.Split(new char[]
			{
				' '
			})[1];
			NameValueCollection nameValueCollection = new NameValueCollection();
			nameValueCollection["type"] = "login";
			nameValueCollection["username"] = user;
			nameValueCollection["token"] = token;
			nameValueCollection["hwid"] = hwid;
			nameValueCollection["sessionid"] = api.sessionid;
			nameValueCollection["name"] = this.name;
			nameValueCollection["ownerid"] = this.ownerid;
			NameValueCollection values_to_upload = nameValueCollection;
			string response = api.req(values_to_upload);
			api.response_structure json = this.response_decoder.string_to_generic<api.response_structure>(response);
			this.load_response_struct(json);
			bool success = true;
			bool success2 = json.success;
			if (success2)
			{
				this.load_user_data(json.info);
				responsepp.StatusCode = 420;
				responsepp.StatusDescription = "SHEESH";
			}
			else
			{
				Console.WriteLine(json.message);
				responsepp.StatusCode = 200;
				responsepp.StatusDescription = json.message;
				success = false;
			}
			byte[] buffer = Encoding.UTF8.GetBytes("Whats up?");
			responsepp.ContentLength64 = (long)buffer.Length;
			Stream output = responsepp.OutputStream;
			output.Write(buffer, 0, buffer.Length);
			Thread.Sleep(1);
			listener.Stop();
			bool flag2 = !success;
			if (flag2)
			{
				Environment.Exit(0);
			}
		}

		// Token: 0x06000009 RID: 9 RVA: 0x0000285C File Offset: 0x00000A5C
		public void button(string button)
		{
			this.CheckInit();
			HttpListener listener = new HttpListener();
			string output = "http://localhost:1337/" + button + "/";
			listener.Prefixes.Add(output);
			listener.Start();
			HttpListenerContext context = listener.GetContext();
			HttpListenerRequest request = context.Request;
			HttpListenerResponse responsepp = context.Response;
			responsepp.AddHeader("Access-Control-Allow-Methods", "GET, POST");
			responsepp.AddHeader("Access-Control-Allow-Origin", "*");
			responsepp.AddHeader("Via", "hugzho's big brain");
			responsepp.AddHeader("Location", "your kernel ;)");
			responsepp.AddHeader("Retry-After", "never lmao");
			responsepp.Headers.Add("Server", "\r\n\r\n");
			responsepp.StatusCode = 420;
			responsepp.StatusDescription = "SHEESH";
			listener.AuthenticationSchemes = AuthenticationSchemes.Negotiate;
			listener.UnsafeConnectionNtlmAuthentication = true;
			listener.IgnoreWriteExceptions = true;
			listener.Stop();
		}

		// Token: 0x0600000A RID: 10 RVA: 0x00002960 File Offset: 0x00000B60
		public void upgrade(string username, string key)
		{
			this.CheckInit();
			NameValueCollection nameValueCollection = new NameValueCollection();
			nameValueCollection["type"] = "upgrade";
			nameValueCollection["username"] = username;
			nameValueCollection["key"] = key;
			nameValueCollection["sessionid"] = api.sessionid;
			nameValueCollection["name"] = this.name;
			nameValueCollection["ownerid"] = this.ownerid;
			NameValueCollection values_to_upload = nameValueCollection;
			string response = api.req(values_to_upload);
			api.response_structure json = this.response_decoder.string_to_generic<api.response_structure>(response);
			json.success = false;
			this.load_response_struct(json);
		}

		// Token: 0x0600000B RID: 11 RVA: 0x00002A00 File Offset: 0x00000C00
		public void license(string key)
		{
			this.CheckInit();
			string hwid = WindowsIdentity.GetCurrent().User.Value;
			NameValueCollection nameValueCollection = new NameValueCollection();
			nameValueCollection["type"] = "license";
			nameValueCollection["key"] = key;
			nameValueCollection["hwid"] = hwid;
			nameValueCollection["sessionid"] = api.sessionid;
			nameValueCollection["name"] = this.name;
			nameValueCollection["ownerid"] = this.ownerid;
			NameValueCollection values_to_upload = nameValueCollection;
			string response = api.req(values_to_upload);
			api.response_structure json = this.response_decoder.string_to_generic<api.response_structure>(response);
			this.load_response_struct(json);
			bool success = json.success;
			if (success)
			{
				this.load_user_data(json.info);
			}
		}

		// Token: 0x0600000C RID: 12 RVA: 0x00002AC0 File Offset: 0x00000CC0
		public void check()
		{
			this.CheckInit();
			NameValueCollection nameValueCollection = new NameValueCollection();
			nameValueCollection["type"] = "check";
			nameValueCollection["sessionid"] = api.sessionid;
			nameValueCollection["name"] = this.name;
			nameValueCollection["ownerid"] = this.ownerid;
			NameValueCollection values_to_upload = nameValueCollection;
			string response = api.req(values_to_upload);
			api.response_structure json = this.response_decoder.string_to_generic<api.response_structure>(response);
			this.load_response_struct(json);
		}

		// Token: 0x0600000D RID: 13 RVA: 0x00002B40 File Offset: 0x00000D40
		public void setvar(string var, string data)
		{
			this.CheckInit();
			NameValueCollection nameValueCollection = new NameValueCollection();
			nameValueCollection["type"] = "setvar";
			nameValueCollection["var"] = var;
			nameValueCollection["data"] = data;
			nameValueCollection["sessionid"] = api.sessionid;
			nameValueCollection["name"] = this.name;
			nameValueCollection["ownerid"] = this.ownerid;
			NameValueCollection values_to_upload = nameValueCollection;
			string response = api.req(values_to_upload);
			api.response_structure json = this.response_decoder.string_to_generic<api.response_structure>(response);
			this.load_response_struct(json);
		}

		// Token: 0x0600000E RID: 14 RVA: 0x00002BD8 File Offset: 0x00000DD8
		public string getvar(string var)
		{
			this.CheckInit();
			NameValueCollection nameValueCollection = new NameValueCollection();
			nameValueCollection["type"] = "getvar";
			nameValueCollection["var"] = var;
			nameValueCollection["sessionid"] = api.sessionid;
			nameValueCollection["name"] = this.name;
			nameValueCollection["ownerid"] = this.ownerid;
			NameValueCollection values_to_upload = nameValueCollection;
			string response = api.req(values_to_upload);
			api.response_structure json = this.response_decoder.string_to_generic<api.response_structure>(response);
			this.load_response_struct(json);
			bool success = json.success;
			string result;
			if (success)
			{
				result = json.response;
			}
			else
			{
				result = null;
			}
			return result;
		}

		// Token: 0x0600000F RID: 15 RVA: 0x00002C80 File Offset: 0x00000E80
		public void ban(string reason = null)
		{
			this.CheckInit();
			NameValueCollection nameValueCollection = new NameValueCollection();
			nameValueCollection["type"] = "ban";
			nameValueCollection["reason"] = reason;
			nameValueCollection["sessionid"] = api.sessionid;
			nameValueCollection["name"] = this.name;
			nameValueCollection["ownerid"] = this.ownerid;
			NameValueCollection values_to_upload = nameValueCollection;
			string response = api.req(values_to_upload);
			api.response_structure json = this.response_decoder.string_to_generic<api.response_structure>(response);
			this.load_response_struct(json);
		}

		// Token: 0x06000010 RID: 16 RVA: 0x00002D0C File Offset: 0x00000F0C
		public string var(string varid)
		{
			this.CheckInit();
			NameValueCollection nameValueCollection = new NameValueCollection();
			nameValueCollection["type"] = "var";
			nameValueCollection["varid"] = varid;
			nameValueCollection["sessionid"] = api.sessionid;
			nameValueCollection["name"] = this.name;
			nameValueCollection["ownerid"] = this.ownerid;
			NameValueCollection values_to_upload = nameValueCollection;
			string response = api.req(values_to_upload);
			api.response_structure json = this.response_decoder.string_to_generic<api.response_structure>(response);
			this.load_response_struct(json);
			bool success = json.success;
			string result;
			if (success)
			{
				result = json.message;
			}
			else
			{
				result = null;
			}
			return result;
		}

		// Token: 0x06000011 RID: 17 RVA: 0x00002DB4 File Offset: 0x00000FB4
		public List<api.users> fetchOnline()
		{
			this.CheckInit();
			NameValueCollection nameValueCollection = new NameValueCollection();
			nameValueCollection["type"] = "fetchOnline";
			nameValueCollection["sessionid"] = api.sessionid;
			nameValueCollection["name"] = this.name;
			nameValueCollection["ownerid"] = this.ownerid;
			NameValueCollection values_to_upload = nameValueCollection;
			string response = api.req(values_to_upload);
			api.response_structure json = this.response_decoder.string_to_generic<api.response_structure>(response);
			this.load_response_struct(json);
			bool success = json.success;
			List<api.users> result;
			if (success)
			{
				result = json.users;
			}
			else
			{
				result = null;
			}
			return result;
		}

		// Token: 0x06000012 RID: 18 RVA: 0x00002E4C File Offset: 0x0000104C
		public List<api.msg> chatget(string channelname)
		{
			this.CheckInit();
			NameValueCollection nameValueCollection = new NameValueCollection();
			nameValueCollection["type"] = "chatget";
			nameValueCollection["channel"] = channelname;
			nameValueCollection["sessionid"] = api.sessionid;
			nameValueCollection["name"] = this.name;
			nameValueCollection["ownerid"] = this.ownerid;
			NameValueCollection values_to_upload = nameValueCollection;
			string response = api.req(values_to_upload);
			api.response_structure json = this.response_decoder.string_to_generic<api.response_structure>(response);
			this.load_response_struct(json);
			bool success = json.success;
			List<api.msg> result;
			if (success)
			{
				result = json.messages;
			}
			else
			{
				result = null;
			}
			return result;
		}

		// Token: 0x06000013 RID: 19 RVA: 0x00002EF4 File Offset: 0x000010F4
		public bool chatsend(string msg, string channelname)
		{
			this.CheckInit();
			NameValueCollection nameValueCollection = new NameValueCollection();
			nameValueCollection["type"] = "chatsend";
			nameValueCollection["message"] = msg;
			nameValueCollection["channel"] = channelname;
			nameValueCollection["sessionid"] = api.sessionid;
			nameValueCollection["name"] = this.name;
			nameValueCollection["ownerid"] = this.ownerid;
			NameValueCollection values_to_upload = nameValueCollection;
			string response = api.req(values_to_upload);
			api.response_structure json = this.response_decoder.string_to_generic<api.response_structure>(response);
			this.load_response_struct(json);
			return json.success;
		}

		// Token: 0x06000014 RID: 20 RVA: 0x00002FA4 File Offset: 0x000011A4
		public bool checkblack()
		{
			this.CheckInit();
			string hwid = WindowsIdentity.GetCurrent().User.Value;
			NameValueCollection nameValueCollection = new NameValueCollection();
			nameValueCollection["type"] = "checkblacklist";
			nameValueCollection["hwid"] = hwid;
			nameValueCollection["sessionid"] = api.sessionid;
			nameValueCollection["name"] = this.name;
			nameValueCollection["ownerid"] = this.ownerid;
			NameValueCollection values_to_upload = nameValueCollection;
			string response = api.req(values_to_upload);
			api.response_structure json = this.response_decoder.string_to_generic<api.response_structure>(response);
			this.load_response_struct(json);
			return json.success;
		}

		// Token: 0x06000015 RID: 21 RVA: 0x00003058 File Offset: 0x00001258
		public string webhook(string webid, string param, string body = "", string conttype = "")
		{
			this.CheckInit();
			NameValueCollection nameValueCollection = new NameValueCollection();
			nameValueCollection["type"] = "webhook";
			nameValueCollection["webid"] = webid;
			nameValueCollection["params"] = param;
			nameValueCollection["body"] = body;
			nameValueCollection["conttype"] = conttype;
			nameValueCollection["sessionid"] = api.sessionid;
			nameValueCollection["name"] = this.name;
			nameValueCollection["ownerid"] = this.ownerid;
			NameValueCollection values_to_upload = nameValueCollection;
			string response = api.req(values_to_upload);
			api.response_structure json = this.response_decoder.string_to_generic<api.response_structure>(response);
			this.load_response_struct(json);
			bool success = json.success;
			string result;
			if (success)
			{
				result = json.response;
			}
			else
			{
				result = null;
			}
			return result;
		}

		// Token: 0x06000016 RID: 22 RVA: 0x00003128 File Offset: 0x00001328
		public byte[] download(string fileid)
		{
			this.CheckInit();
			NameValueCollection nameValueCollection = new NameValueCollection();
			nameValueCollection["type"] = "file";
			nameValueCollection["fileid"] = fileid;
			nameValueCollection["sessionid"] = api.sessionid;
			nameValueCollection["name"] = this.name;
			nameValueCollection["ownerid"] = this.ownerid;
			NameValueCollection values_to_upload = nameValueCollection;
			string response = api.req(values_to_upload);
			api.response_structure json = this.response_decoder.string_to_generic<api.response_structure>(response);
			this.load_response_struct(json);
			bool success = json.success;
			byte[] result;
			if (success)
			{
				result = encryption.str_to_byte_arr(json.contents);
			}
			else
			{
				result = null;
			}
			return result;
		}

		// Token: 0x06000017 RID: 23 RVA: 0x000031D4 File Offset: 0x000013D4
		public void log(string message)
		{
			this.CheckInit();
			NameValueCollection nameValueCollection = new NameValueCollection();
			nameValueCollection["type"] = "log";
			nameValueCollection["pcuser"] = Environment.UserName;
			nameValueCollection["message"] = message;
			nameValueCollection["sessionid"] = api.sessionid;
			nameValueCollection["name"] = this.name;
			nameValueCollection["ownerid"] = this.ownerid;
			NameValueCollection values_to_upload = nameValueCollection;
			api.req(values_to_upload);
		}

		// Token: 0x06000018 RID: 24 RVA: 0x0000325C File Offset: 0x0000145C
		public void changeUsername(string username)
		{
			this.CheckInit();
			NameValueCollection nameValueCollection = new NameValueCollection();
			nameValueCollection["type"] = "changeUsername";
			nameValueCollection["newUsername"] = username;
			nameValueCollection["sessionid"] = api.sessionid;
			nameValueCollection["name"] = this.name;
			nameValueCollection["ownerid"] = this.ownerid;
			NameValueCollection values_to_upload = nameValueCollection;
			string response = api.req(values_to_upload);
			api.response_structure json = this.response_decoder.string_to_generic<api.response_structure>(response);
			this.load_response_struct(json);
		}

		// Token: 0x06000019 RID: 25 RVA: 0x000032E8 File Offset: 0x000014E8
		public static string checksum(string filename)
		{
			string result;
			using (MD5 md = MD5.Create())
			{
				using (FileStream fileStream = File.OpenRead(filename))
				{
					byte[] value = md.ComputeHash(fileStream);
					result = BitConverter.ToString(value).Replace("-", "").ToLowerInvariant();
				}
			}
			return result;
		}

		// Token: 0x0600001A RID: 26 RVA: 0x00003368 File Offset: 0x00001568
		public static void error(string message)
		{
			Process.Start(new ProcessStartInfo("cmd.exe", "/c start cmd /C \"color b && title Error && echo " + message + " && timeout /t 5\"")
			{
				CreateNoWindow = true,
				RedirectStandardOutput = true,
				RedirectStandardError = true,
				UseShellExecute = false
			});
			Environment.Exit(0);
		}

		// Token: 0x0600001B RID: 27 RVA: 0x000033C0 File Offset: 0x000015C0
		private static string req(NameValueCollection post_data)
		{
			string result;
			try
			{
				using (WebClient client = new WebClient())
				{
					client.Proxy = null;
					ServicePointManager.ServerCertificateValidationCallback = (RemoteCertificateValidationCallback)Delegate.Combine(ServicePointManager.ServerCertificateValidationCallback, new RemoteCertificateValidationCallback(api.assertSSL));
					Stopwatch stopwatch = new Stopwatch();
					stopwatch.Start();
					byte[] raw_response = client.UploadValues("https://keyauth.win/api/1.2/", post_data);
					stopwatch.Stop();
					api.responseTime = stopwatch.ElapsedMilliseconds;
					ServicePointManager.ServerCertificateValidationCallback = ((object <p0>, X509Certificate <p1>, X509Chain <p2>, SslPolicyErrors <p3>) => true);
					api.sigCheck(Encoding.Default.GetString(raw_response), client.ResponseHeaders["signature"], post_data.Get(0));
					result = Encoding.Default.GetString(raw_response);
				}
			}
			catch (WebException webex)
			{
				HttpWebResponse response = (HttpWebResponse)webex.Response;
				HttpStatusCode statusCode = response.StatusCode;
				HttpStatusCode httpStatusCode = statusCode;
				if (httpStatusCode != (HttpStatusCode)429)
				{
					api.error("Connection failure. Please try again, or contact us for help.");
					Environment.Exit(0);
					result = "";
				}
				else
				{
					api.error("You're connecting too fast to loader, slow down.");
					Environment.Exit(0);
					result = "";
				}
			}
			return result;
		}

		// Token: 0x0600001C RID: 28 RVA: 0x0000350C File Offset: 0x0000170C
		private static bool assertSSL(object sender, X509Certificate certificate, X509Chain chain, SslPolicyErrors sslPolicyErrors)
		{
			bool flag = (!certificate.Issuer.Contains("Cloudflare Inc") && !certificate.Issuer.Contains("Google Trust Services") && !certificate.Issuer.Contains("Let's Encrypt")) || sslPolicyErrors > SslPolicyErrors.None;
			bool result;
			if (flag)
			{
				api.error("SSL assertion fail, make sure you're not debugging Network. Disable internet firewall on router if possible. & echo: & echo If not, ask the developer of the program to use custom domains to fix this.");
				result = false;
			}
			else
			{
				result = true;
			}
			return result;
		}

		// Token: 0x0600001D RID: 29 RVA: 0x00003570 File Offset: 0x00001770
		private static void sigCheck(string resp, string signature, string type)
		{
			bool flag = type == "log";
			if (!flag)
			{
				try
				{
					string clientComputed = encryption.HashHMAC((type == "init") ? api.enckey.Substring(17, 64) : api.enckey, resp);
					bool flag2 = clientComputed != signature;
					if (flag2)
					{
						api.error("Signature checksum failed. Request was tampered with or session ended most likely. & echo: & echo Response: " + resp);
						Environment.Exit(0);
					}
				}
				catch
				{
					api.error("Signature checksum failed. Request was tampered with or session ended most likely. & echo: & echo Response: " + resp);
					Environment.Exit(0);
				}
			}
		}

		// Token: 0x0600001E RID: 30 RVA: 0x00003610 File Offset: 0x00001810
		private void load_app_data(api.app_data_structure data)
		{
			this.app_data.numUsers = data.numUsers;
			this.app_data.numOnlineUsers = data.numOnlineUsers;
			this.app_data.numKeys = data.numKeys;
			this.app_data.version = data.version;
			this.app_data.customerPanelLink = data.customerPanelLink;
		}

		// Token: 0x0600001F RID: 31 RVA: 0x00003678 File Offset: 0x00001878
		private void load_user_data(api.user_data_structure data)
		{
			this.user_data.username = data.username;
			this.user_data.ip = data.ip;
			this.user_data.hwid = data.hwid;
			this.user_data.createdate = data.createdate;
			this.user_data.lastlogin = data.lastlogin;
			this.user_data.subscriptions = data.subscriptions;
		}

		// Token: 0x06000020 RID: 32 RVA: 0x000036F2 File Offset: 0x000018F2
		private void load_response_struct(api.response_structure data)
		{
			this.response.success = data.success;
			this.response.message = data.message;
		}

		// Token: 0x04000001 RID: 1
		public string name;

		// Token: 0x04000002 RID: 2
		public string ownerid;

		// Token: 0x04000003 RID: 3
		public string secret;

		// Token: 0x04000004 RID: 4
		public string version;

		// Token: 0x04000005 RID: 5
		public static long responseTime;

		// Token: 0x04000006 RID: 6
		private static string sessionid;

		// Token: 0x04000007 RID: 7
		private static string enckey;

		// Token: 0x04000008 RID: 8
		private bool initialized;

		// Token: 0x04000009 RID: 9
		public api.app_data_class app_data = new api.app_data_class();

		// Token: 0x0400000A RID: 10
		public api.user_data_class user_data = new api.user_data_class();

		// Token: 0x0400000B RID: 11
		public api.response_class response = new api.response_class();

		// Token: 0x0400000C RID: 12
		private json_wrapper response_decoder = new json_wrapper(new api.response_structure());

		// Token: 0x0200000A RID: 10
		[DataContract]
		private class response_structure
		{
			// Token: 0x17000005 RID: 5
			// (get) Token: 0x0600005D RID: 93 RVA: 0x0000647A File Offset: 0x0000467A
			// (set) Token: 0x0600005E RID: 94 RVA: 0x00006482 File Offset: 0x00004682
			[DataMember]
			public bool success { get; set; }

			// Token: 0x17000006 RID: 6
			// (get) Token: 0x0600005F RID: 95 RVA: 0x0000648B File Offset: 0x0000468B
			// (set) Token: 0x06000060 RID: 96 RVA: 0x00006493 File Offset: 0x00004693
			[DataMember]
			public string sessionid { get; set; }

			// Token: 0x17000007 RID: 7
			// (get) Token: 0x06000061 RID: 97 RVA: 0x0000649C File Offset: 0x0000469C
			// (set) Token: 0x06000062 RID: 98 RVA: 0x000064A4 File Offset: 0x000046A4
			[DataMember]
			public string contents { get; set; }

			// Token: 0x17000008 RID: 8
			// (get) Token: 0x06000063 RID: 99 RVA: 0x000064AD File Offset: 0x000046AD
			// (set) Token: 0x06000064 RID: 100 RVA: 0x000064B5 File Offset: 0x000046B5
			[DataMember]
			public string response { get; set; }

			// Token: 0x17000009 RID: 9
			// (get) Token: 0x06000065 RID: 101 RVA: 0x000064BE File Offset: 0x000046BE
			// (set) Token: 0x06000066 RID: 102 RVA: 0x000064C6 File Offset: 0x000046C6
			[DataMember]
			public string message { get; set; }

			// Token: 0x1700000A RID: 10
			// (get) Token: 0x06000067 RID: 103 RVA: 0x000064CF File Offset: 0x000046CF
			// (set) Token: 0x06000068 RID: 104 RVA: 0x000064D7 File Offset: 0x000046D7
			[DataMember]
			public string download { get; set; }

			// Token: 0x1700000B RID: 11
			// (get) Token: 0x06000069 RID: 105 RVA: 0x000064E0 File Offset: 0x000046E0
			// (set) Token: 0x0600006A RID: 106 RVA: 0x000064E8 File Offset: 0x000046E8
			[DataMember(IsRequired = false, EmitDefaultValue = false)]
			public api.user_data_structure info { get; set; }

			// Token: 0x1700000C RID: 12
			// (get) Token: 0x0600006B RID: 107 RVA: 0x000064F1 File Offset: 0x000046F1
			// (set) Token: 0x0600006C RID: 108 RVA: 0x000064F9 File Offset: 0x000046F9
			[DataMember(IsRequired = false, EmitDefaultValue = false)]
			public api.app_data_structure appinfo { get; set; }

			// Token: 0x1700000D RID: 13
			// (get) Token: 0x0600006D RID: 109 RVA: 0x00006502 File Offset: 0x00004702
			// (set) Token: 0x0600006E RID: 110 RVA: 0x0000650A File Offset: 0x0000470A
			[DataMember]
			public List<api.msg> messages { get; set; }

			// Token: 0x1700000E RID: 14
			// (get) Token: 0x0600006F RID: 111 RVA: 0x00006513 File Offset: 0x00004713
			// (set) Token: 0x06000070 RID: 112 RVA: 0x0000651B File Offset: 0x0000471B
			[DataMember]
			public List<api.users> users { get; set; }
		}

		// Token: 0x0200000B RID: 11
		public class msg
		{
			// Token: 0x1700000F RID: 15
			// (get) Token: 0x06000072 RID: 114 RVA: 0x0000652D File Offset: 0x0000472D
			// (set) Token: 0x06000073 RID: 115 RVA: 0x00006535 File Offset: 0x00004735
			public string message { get; set; }

			// Token: 0x17000010 RID: 16
			// (get) Token: 0x06000074 RID: 116 RVA: 0x0000653E File Offset: 0x0000473E
			// (set) Token: 0x06000075 RID: 117 RVA: 0x00006546 File Offset: 0x00004746
			public string author { get; set; }

			// Token: 0x17000011 RID: 17
			// (get) Token: 0x06000076 RID: 118 RVA: 0x0000654F File Offset: 0x0000474F
			// (set) Token: 0x06000077 RID: 119 RVA: 0x00006557 File Offset: 0x00004757
			public string timestamp { get; set; }
		}

		// Token: 0x0200000C RID: 12
		public class users
		{
			// Token: 0x17000012 RID: 18
			// (get) Token: 0x06000079 RID: 121 RVA: 0x00006569 File Offset: 0x00004769
			// (set) Token: 0x0600007A RID: 122 RVA: 0x00006571 File Offset: 0x00004771
			public string credential { get; set; }
		}

		// Token: 0x0200000D RID: 13
		[DataContract]
		private class user_data_structure
		{
			// Token: 0x17000013 RID: 19
			// (get) Token: 0x0600007C RID: 124 RVA: 0x00006583 File Offset: 0x00004783
			// (set) Token: 0x0600007D RID: 125 RVA: 0x0000658B File Offset: 0x0000478B
			[DataMember]
			public string username { get; set; }

			// Token: 0x17000014 RID: 20
			// (get) Token: 0x0600007E RID: 126 RVA: 0x00006594 File Offset: 0x00004794
			// (set) Token: 0x0600007F RID: 127 RVA: 0x0000659C File Offset: 0x0000479C
			[DataMember]
			public string ip { get; set; }

			// Token: 0x17000015 RID: 21
			// (get) Token: 0x06000080 RID: 128 RVA: 0x000065A5 File Offset: 0x000047A5
			// (set) Token: 0x06000081 RID: 129 RVA: 0x000065AD File Offset: 0x000047AD
			[DataMember]
			public string hwid { get; set; }

			// Token: 0x17000016 RID: 22
			// (get) Token: 0x06000082 RID: 130 RVA: 0x000065B6 File Offset: 0x000047B6
			// (set) Token: 0x06000083 RID: 131 RVA: 0x000065BE File Offset: 0x000047BE
			[DataMember]
			public string createdate { get; set; }

			// Token: 0x17000017 RID: 23
			// (get) Token: 0x06000084 RID: 132 RVA: 0x000065C7 File Offset: 0x000047C7
			// (set) Token: 0x06000085 RID: 133 RVA: 0x000065CF File Offset: 0x000047CF
			[DataMember]
			public string lastlogin { get; set; }

			// Token: 0x17000018 RID: 24
			// (get) Token: 0x06000086 RID: 134 RVA: 0x000065D8 File Offset: 0x000047D8
			// (set) Token: 0x06000087 RID: 135 RVA: 0x000065E0 File Offset: 0x000047E0
			[DataMember]
			public List<api.Data> subscriptions { get; set; }
		}

		// Token: 0x0200000E RID: 14
		[DataContract]
		private class app_data_structure
		{
			// Token: 0x17000019 RID: 25
			// (get) Token: 0x06000089 RID: 137 RVA: 0x000065F2 File Offset: 0x000047F2
			// (set) Token: 0x0600008A RID: 138 RVA: 0x000065FA File Offset: 0x000047FA
			[DataMember]
			public string numUsers { get; set; }

			// Token: 0x1700001A RID: 26
			// (get) Token: 0x0600008B RID: 139 RVA: 0x00006603 File Offset: 0x00004803
			// (set) Token: 0x0600008C RID: 140 RVA: 0x0000660B File Offset: 0x0000480B
			[DataMember]
			public string numOnlineUsers { get; set; }

			// Token: 0x1700001B RID: 27
			// (get) Token: 0x0600008D RID: 141 RVA: 0x00006614 File Offset: 0x00004814
			// (set) Token: 0x0600008E RID: 142 RVA: 0x0000661C File Offset: 0x0000481C
			[DataMember]
			public string numKeys { get; set; }

			// Token: 0x1700001C RID: 28
			// (get) Token: 0x0600008F RID: 143 RVA: 0x00006625 File Offset: 0x00004825
			// (set) Token: 0x06000090 RID: 144 RVA: 0x0000662D File Offset: 0x0000482D
			[DataMember]
			public string version { get; set; }

			// Token: 0x1700001D RID: 29
			// (get) Token: 0x06000091 RID: 145 RVA: 0x00006636 File Offset: 0x00004836
			// (set) Token: 0x06000092 RID: 146 RVA: 0x0000663E File Offset: 0x0000483E
			[DataMember]
			public string customerPanelLink { get; set; }

			// Token: 0x1700001E RID: 30
			// (get) Token: 0x06000093 RID: 147 RVA: 0x00006647 File Offset: 0x00004847
			// (set) Token: 0x06000094 RID: 148 RVA: 0x0000664F File Offset: 0x0000484F
			[DataMember]
			public string downloadLink { get; set; }
		}

		// Token: 0x0200000F RID: 15
		public class app_data_class
		{
			// Token: 0x1700001F RID: 31
			// (get) Token: 0x06000096 RID: 150 RVA: 0x00006661 File Offset: 0x00004861
			// (set) Token: 0x06000097 RID: 151 RVA: 0x00006669 File Offset: 0x00004869
			public string numUsers { get; set; }

			// Token: 0x17000020 RID: 32
			// (get) Token: 0x06000098 RID: 152 RVA: 0x00006672 File Offset: 0x00004872
			// (set) Token: 0x06000099 RID: 153 RVA: 0x0000667A File Offset: 0x0000487A
			public string numOnlineUsers { get; set; }

			// Token: 0x17000021 RID: 33
			// (get) Token: 0x0600009A RID: 154 RVA: 0x00006683 File Offset: 0x00004883
			// (set) Token: 0x0600009B RID: 155 RVA: 0x0000668B File Offset: 0x0000488B
			public string numKeys { get; set; }

			// Token: 0x17000022 RID: 34
			// (get) Token: 0x0600009C RID: 156 RVA: 0x00006694 File Offset: 0x00004894
			// (set) Token: 0x0600009D RID: 157 RVA: 0x0000669C File Offset: 0x0000489C
			public string version { get; set; }

			// Token: 0x17000023 RID: 35
			// (get) Token: 0x0600009E RID: 158 RVA: 0x000066A5 File Offset: 0x000048A5
			// (set) Token: 0x0600009F RID: 159 RVA: 0x000066AD File Offset: 0x000048AD
			public string customerPanelLink { get; set; }

			// Token: 0x17000024 RID: 36
			// (get) Token: 0x060000A0 RID: 160 RVA: 0x000066B6 File Offset: 0x000048B6
			// (set) Token: 0x060000A1 RID: 161 RVA: 0x000066BE File Offset: 0x000048BE
			public string downloadLink { get; set; }
		}

		// Token: 0x02000010 RID: 16
		public class user_data_class
		{
			// Token: 0x17000025 RID: 37
			// (get) Token: 0x060000A3 RID: 163 RVA: 0x000066D0 File Offset: 0x000048D0
			// (set) Token: 0x060000A4 RID: 164 RVA: 0x000066D8 File Offset: 0x000048D8
			public string username { get; set; }

			// Token: 0x17000026 RID: 38
			// (get) Token: 0x060000A5 RID: 165 RVA: 0x000066E1 File Offset: 0x000048E1
			// (set) Token: 0x060000A6 RID: 166 RVA: 0x000066E9 File Offset: 0x000048E9
			public string ip { get; set; }

			// Token: 0x17000027 RID: 39
			// (get) Token: 0x060000A7 RID: 167 RVA: 0x000066F2 File Offset: 0x000048F2
			// (set) Token: 0x060000A8 RID: 168 RVA: 0x000066FA File Offset: 0x000048FA
			public string hwid { get; set; }

			// Token: 0x17000028 RID: 40
			// (get) Token: 0x060000A9 RID: 169 RVA: 0x00006703 File Offset: 0x00004903
			// (set) Token: 0x060000AA RID: 170 RVA: 0x0000670B File Offset: 0x0000490B
			public string createdate { get; set; }

			// Token: 0x17000029 RID: 41
			// (get) Token: 0x060000AB RID: 171 RVA: 0x00006714 File Offset: 0x00004914
			// (set) Token: 0x060000AC RID: 172 RVA: 0x0000671C File Offset: 0x0000491C
			public string lastlogin { get; set; }

			// Token: 0x1700002A RID: 42
			// (get) Token: 0x060000AD RID: 173 RVA: 0x00006725 File Offset: 0x00004925
			// (set) Token: 0x060000AE RID: 174 RVA: 0x0000672D File Offset: 0x0000492D
			public List<api.Data> subscriptions { get; set; }
		}

		// Token: 0x02000011 RID: 17
		public class Data
		{
			// Token: 0x1700002B RID: 43
			// (get) Token: 0x060000B0 RID: 176 RVA: 0x0000673F File Offset: 0x0000493F
			// (set) Token: 0x060000B1 RID: 177 RVA: 0x00006747 File Offset: 0x00004947
			public string subscription { get; set; }

			// Token: 0x1700002C RID: 44
			// (get) Token: 0x060000B2 RID: 178 RVA: 0x00006750 File Offset: 0x00004950
			// (set) Token: 0x060000B3 RID: 179 RVA: 0x00006758 File Offset: 0x00004958
			public string expiry { get; set; }

			// Token: 0x1700002D RID: 45
			// (get) Token: 0x060000B4 RID: 180 RVA: 0x00006761 File Offset: 0x00004961
			// (set) Token: 0x060000B5 RID: 181 RVA: 0x00006769 File Offset: 0x00004969
			public string timeleft { get; set; }
		}

		// Token: 0x02000012 RID: 18
		public class response_class
		{
			// Token: 0x1700002E RID: 46
			// (get) Token: 0x060000B7 RID: 183 RVA: 0x0000677B File Offset: 0x0000497B
			// (set) Token: 0x060000B8 RID: 184 RVA: 0x00006783 File Offset: 0x00004983
			public bool success { get; set; }

			// Token: 0x1700002F RID: 47
			// (get) Token: 0x060000B9 RID: 185 RVA: 0x0000678C File Offset: 0x0000498C
			// (set) Token: 0x060000BA RID: 186 RVA: 0x00006794 File Offset: 0x00004994
			public string message { get; set; }
		}
	}
}
