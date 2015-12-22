/*
C# Class that interfaces to VoiceIt Rest API Calls
Created by Armaan Bindra 03/10/2015
*/

using System;
using System.IO;
using System.Net;
using System.Text;
using System.Security.Cryptography;

//namespace VoiceItAPI
//{
	class VoiceIt
	{
		string developerId;

		public VoiceIt(string devId)
		{
			Console.WriteLine ("Constructor for VoiceIt Called");
			this.developerId = devId;
			Console.WriteLine ("Parameters Initialized");
		}

		//Function to convert password string into a SHA256 Hexadecimal Hash
		public static string GetSha256FromString(string strData)
		{
			var message = Encoding.ASCII.GetBytes(strData);
			SHA256Managed hashString = new SHA256Managed();
			string hex = "";

			var hashValue = hashString.ComputeHash(message);
			foreach (byte x in hashValue)
			{
				hex += String.Format("{0:x2}", x);
			}
			return hex;
		}

	//Function to create a User
	public string createUser(string mail,string passwd, string firstName, string lastName, string phone1 = "", string phone2 = "", string phone3 = "")
	{
		var email = mail;
		var password = GetSha256FromString(passwd);
		//password = GetSha256FromString(password);
		// Create a request for the URL.
		WebRequest request = WebRequest.Create ("https://siv.voiceprintportal.com/sivservice/api/users");
		request.Headers["VsitEmail"] = email;
		request.Headers["VsitPassword"] = password;
		request.Headers["VsitDeveloperId"] = this.developerId;
		request.Headers ["VsitFirstName"] = firstName;
		request.Headers ["VsitLastName"] = lastName;
		request.Headers ["VsitPhone1"] = phone1;
		request.Headers ["VsitPhone2"] = phone2;
		request.Headers ["VsitPhone3"] = phone3;
		request.Method = "POST";
		string postData = "";
		byte[] byteArray = Encoding.UTF8.GetBytes (postData);
		request.ContentLength = byteArray.Length;
		// Get the request stream.
		Stream dataStream = request.GetRequestStream ();
		// Write the data to the request stream.
		dataStream.Write (byteArray, 0, byteArray.Length);
		// Close the Stream object.
		dataStream.Close ();
		// Get the response.
		try{
			WebResponse response = request.GetResponse ();
			// Display the status.
			//Console.WriteLine (((HttpWebResponse)response).StatusDescription);
			// Get the stream containing content returned by the server.
			dataStream = response.GetResponseStream ();
			// Open the stream using a StreamReader for easy access.
			StreamReader reader = new StreamReader (dataStream);
			// Read the content.
			string responseFromServer = reader.ReadToEnd ();
			// Display the content.
			//Console.WriteLine (responseFromServer);
			reader.Close ();
			dataStream.Close ();
			response.Close ();

			return responseFromServer;
			// Clean up the streams.

		}
		catch (WebException ex)
		{
			if (ex.Status == WebExceptionStatus.ProtocolError){
				using (var response = (HttpWebResponse)ex.Response){
					using (var stream = response.GetResponseStream()){
						using (var reader = new StreamReader(stream, Encoding.GetEncoding("utf-8"))){return reader.ReadToEnd();}}}}
		}
		return "";
	}//End of createUser Method

	//Function to delete the user
	public string deleteUser(string mail,string passwd)
	{
		var email = mail;
		var password = GetSha256FromString(passwd);
		//password = GetSha256FromString(password);
		// Create a request for the URL.
		WebRequest request = WebRequest.Create ("https://siv.voiceprintportal.com/sivservice/api/users");
		request.Headers["VsitEmail"] = email;
		request.Headers["VsitPassword"] = password;
		request.Headers["VsitDeveloperId"] = this.developerId;
		request.Method = "DELETE";
		string postData = "";
		byte[] byteArray = Encoding.UTF8.GetBytes (postData);
		request.ContentLength = byteArray.Length;
		// Get the request stream.
		Stream dataStream = request.GetRequestStream ();
		// Write the data to the request stream.
		dataStream.Write (byteArray, 0, byteArray.Length);
		// Close the Stream object.
		dataStream.Close ();
		// Get the response.
		try{
			WebResponse response = request.GetResponse ();
			// Display the status.
			//Console.WriteLine (((HttpWebResponse)response).StatusDescription);
			// Get the stream containing content returned by the server.
			dataStream = response.GetResponseStream ();
			// Open the stream using a StreamReader for easy access.
			StreamReader reader = new StreamReader (dataStream);
			// Read the content.
			string responseFromServer = reader.ReadToEnd ();
			// Display the content.
			//Console.WriteLine (responseFromServer);
			reader.Close ();
			dataStream.Close ();
			response.Close ();

			return responseFromServer;
			// Clean up the streams.

		}
		catch (WebException ex)
		{
			if (ex.Status == WebExceptionStatus.ProtocolError){
				using (var response = (HttpWebResponse)ex.Response){
					using (var stream = response.GetResponseStream()){
						using (var reader = new StreamReader(stream, Encoding.GetEncoding("utf-8"))){return reader.ReadToEnd();}}}}
		}
		return "";
	}//End of deleteUser Method

	//Function to retrieve User Details
	public string getUser(string mail,string passwd)
	{
		var email = mail;
		var password = GetSha256FromString(passwd);
		//password = GetSha256FromString(password);
		// Create a request for the URL.
		WebRequest request = WebRequest.Create ("https://siv.voiceprintportal.com/sivservice/api/users");
		request.Headers["VsitEmail"] = email;
		request.Headers["VsitPassword"] = password;
		request.Headers["VsitDeveloperId"] = this.developerId;
		request.Method = "GET";

		// Get the response.
		try{
			WebResponse response = request.GetResponse ();
			// Display the status.
			//Console.WriteLine (((HttpWebResponse)response).StatusDescription);
			// Get the stream containing content returned by the server.
			Stream dataStream = response.GetResponseStream ();
			// Open the stream using a StreamReader for easy access.
			StreamReader reader = new StreamReader (dataStream);
			// Read the content.
			string responseFromServer = reader.ReadToEnd ();
			// Display the content.
			//Console.WriteLine (responseFromServer);
			reader.Close ();
			dataStream.Close ();
			response.Close ();


			return responseFromServer;
			// Clean up the streams.

		}
		catch (WebException ex)
		{
			if (ex.Status == WebExceptionStatus.ProtocolError){
				using (var response = (HttpWebResponse)ex.Response){
					using (var stream = response.GetResponseStream()){
						using (var reader = new StreamReader(stream, Encoding.GetEncoding("utf-8"))){return reader.ReadToEnd();}}}}
		}
		return "";
	}//End of getUser Method



	//Function to update the user
	public string setUser(string mail,string passwd, string firstName, string lastName, string phone1 = "", string phone2 = "", string phone3 = "")
	{
		var email = mail;
		var password = GetSha256FromString(passwd);
		//password = GetSha256FromString(password);
		// Create a request for the URL.
		WebRequest request = WebRequest.Create ("https://siv.voiceprintportal.com/sivservice/api/users");
		request.Headers["VsitEmail"] = email;
		request.Headers["VsitPassword"] = password;
		request.Headers["VsitDeveloperId"] = this.developerId;
		request.Headers ["VsitFirstName"] = firstName;
		request.Headers ["VsitLastName"] = lastName;
		request.Headers ["VsitPhone1"] = phone1;
		request.Headers ["VsitPhone2"] = phone2;
		request.Headers ["VsitPhone3"] = phone3;
		request.Method = "PUT";
		string postData = "";
		byte[] byteArray = Encoding.UTF8.GetBytes (postData);
		request.ContentLength = byteArray.Length;
		// Get the request stream.
		Stream dataStream = request.GetRequestStream ();
		// Write the data to the request stream.
		dataStream.Write (byteArray, 0, byteArray.Length);
		// Close the Stream object.
		dataStream.Close ();
		// Get the response.
		try{
			WebResponse response = request.GetResponse ();
			// Display the status.
			//Console.WriteLine (((HttpWebResponse)response).StatusDescription);
			// Get the stream containing content returned by the server.
			dataStream = response.GetResponseStream ();
			// Open the stream using a StreamReader for easy access.
			StreamReader reader = new StreamReader (dataStream);
			// Read the content.
			string responseFromServer = reader.ReadToEnd ();
			// Display the content.
			//Console.WriteLine (responseFromServer);
			reader.Close ();
			dataStream.Close ();
			response.Close ();

			return responseFromServer;
			// Clean up the streams.

		}
		catch (WebException ex)
		{
			if (ex.Status == WebExceptionStatus.ProtocolError){
				using (var response = (HttpWebResponse)ex.Response){
					using (var stream = response.GetResponseStream()){
						using (var reader = new StreamReader(stream, Encoding.GetEncoding("utf-8"))){return reader.ReadToEnd();}}}}
		}
		return "";
	}//End of setUser Method

	//Function to create a new Enrollment
	public string createEnrollment(string mail,string passwd, string pathToEnrollmentWav, string contentLanguage = "")
	{
		var email = mail;
		var password = GetSha256FromString(passwd);
		//password = GetSha256FromString(password);
		byte[] wavData = System.IO.File.ReadAllBytes(pathToEnrollmentWav);
		// Create a request for the URL.
		WebRequest request = WebRequest.Create ("https://siv.voiceprintportal.com/sivservice/api/enrollments");
		request.ContentType = "audio/wav";
		request.Headers["VsitEmail"] = email;
		request.Headers["VsitPassword"] = password;
		request.Headers["VsitDeveloperId"] = this.developerId;
		request.Headers["ContentLanguage"] = contentLanguage;
		request.Method = "POST";
		request.ContentLength = wavData.Length;
		// Get the request stream.
		Stream dataStream = request.GetRequestStream ();
		// Write the data to the request stream.
		dataStream.Write (wavData, 0, wavData.Length);
		// Close the Stream object.
		dataStream.Close ();
		// Get the response.
		try{
			WebResponse response = request.GetResponse ();
			// Display the status.
			//Console.WriteLine (((HttpWebResponse)response).StatusDescription);
			// Get the stream containing content returned by the server.
			dataStream = response.GetResponseStream ();
			// Open the stream using a StreamReader for easy access.
			StreamReader reader = new StreamReader (dataStream);
			// Read the content.
			string responseFromServer = reader.ReadToEnd ();
			// Display the content.
			//Console.WriteLine (responseFromServer);
			reader.Close ();
			dataStream.Close ();
			response.Close ();

			return responseFromServer;
			// Clean up the streams.

		}
		catch (WebException ex)
		{
			if (ex.Status == WebExceptionStatus.ProtocolError){
				using (var response = (HttpWebResponse)ex.Response){
					using (var stream = response.GetResponseStream()){
						using (var reader = new StreamReader(stream, Encoding.GetEncoding("utf-8"))){return reader.ReadToEnd();}}}}
		}
		return "";
	}//End of createEnrollment Method

	//Function to create a new Enrollment by Wav URL
	public string createEnrollmentByWavURL(string mail,string passwd, string urlToEnrollmentWav, string contentLanguage = "")
	{
		var email = mail;
		var password = GetSha256FromString(passwd);
		//password = GetSha256FromString(password);
		// Create a request for the URL.
		WebRequest request = WebRequest.Create ("https://siv.voiceprintportal.com/sivservice/api/enrollments/bywavurl");
		request.ContentType = "audio/wav";
		request.Headers["VsitEmail"] = email;
		request.Headers["VsitPassword"] = password;
		request.Headers["VsitDeveloperId"] = this.developerId;
		request.Headers ["VsitwavURL"] = urlToEnrollmentWav;
		request.Headers["ContentLanguage"] = contentLanguage;
		request.Method = "POST";
		string postData = "";
		byte[] byteArray = Encoding.UTF8.GetBytes (postData);
		request.ContentLength = byteArray.Length;
		// Get the request stream.
		Stream dataStream = request.GetRequestStream ();
		// Write the data to the request stream.
		dataStream.Write (byteArray, 0, byteArray.Length);
		// Close the Stream object.
		dataStream.Close ();
		// Get the response.
		try{
			WebResponse response = request.GetResponse ();
			// Display the status.
			//Console.WriteLine (((HttpWebResponse)response).StatusDescription);
			// Get the stream containing content returned by the server.
			dataStream = response.GetResponseStream ();
			// Open the stream using a StreamReader for easy access.
			StreamReader reader = new StreamReader (dataStream);
			// Read the content.
			string responseFromServer = reader.ReadToEnd ();
			// Display the content.
			//Console.WriteLine (responseFromServer);
			reader.Close ();
			dataStream.Close ();
			response.Close ();

			return responseFromServer;
			// Clean up the streams.

		}
		catch (WebException ex)
		{
			if (ex.Status == WebExceptionStatus.ProtocolError){
				using (var response = (HttpWebResponse)ex.Response){
					using (var stream = response.GetResponseStream()){
						using (var reader = new StreamReader(stream, Encoding.GetEncoding("utf-8"))){return reader.ReadToEnd();}}}}
		}
		return "";
	}//End of createEnrollmentByWavURL Method

	//Function to delete a specific enrollment
	public string deleteEnrollment(string mail,string passwd, string enrollmentId)
	{
		var email = mail;
		var password = GetSha256FromString(passwd);
		//password = GetSha256FromString(password);
		// Create a request for the URL.
		WebRequest request = WebRequest.Create ("https://siv.voiceprintportal.com/sivservice/api/enrollments"+ "/"+ enrollmentId);
		request.Headers["VsitEmail"] = email;
		request.Headers["VsitPassword"] = password;
		request.Headers["VsitDeveloperId"] = this.developerId;
		request.Method = "DELETE";
		string postData = "";
		byte[] byteArray = Encoding.UTF8.GetBytes (postData);
		request.ContentLength = byteArray.Length;
		// Get the request stream.
		Stream dataStream = request.GetRequestStream ();
		// Write the data to the request stream.
		dataStream.Write (byteArray, 0, byteArray.Length);
		// Close the Stream object.
		dataStream.Close ();
		// Get the response.
		try{
			WebResponse response = request.GetResponse ();
			// Display the status.
			//Console.WriteLine (((HttpWebResponse)response).StatusDescription);
			// Get the stream containing content returned by the server.
			dataStream = response.GetResponseStream ();
			// Open the stream using a StreamReader for easy access.
			StreamReader reader = new StreamReader (dataStream);
			// Read the content.
			string responseFromServer = reader.ReadToEnd ();
			// Display the content.
			//Console.WriteLine (responseFromServer);
			reader.Close ();
			dataStream.Close ();
			response.Close ();

			return responseFromServer;
			// Clean up the streams.

		}
		catch (WebException ex)
		{
			if (ex.Status == WebExceptionStatus.ProtocolError){
				using (var response = (HttpWebResponse)ex.Response){
					using (var stream = response.GetResponseStream()){
						using (var reader = new StreamReader(stream, Encoding.GetEncoding("utf-8"))){return reader.ReadToEnd();}}}}
		}
		return "";
	}//End of deleteEnrollment Method

	//Function to retrieve array of User Enrollments
	public string getEnrollments(string mail,string passwd)
	{
		var email = mail;
		var password = GetSha256FromString(passwd);
		//password = GetSha256FromString(password);
		// Create a request for the URL.
		WebRequest request = WebRequest.Create ("https://siv.voiceprintportal.com/sivservice/api/enrollments");
		request.Headers["VsitEmail"] = email;
		request.Headers["VsitPassword"] = password;
		request.Headers["VsitDeveloperId"] = this.developerId;
		request.Method = "GET";

		// Get the response.
		try{
			WebResponse response = request.GetResponse ();
			// Display the status.
			//Console.WriteLine (((HttpWebResponse)response).StatusDescription);
			// Get the stream containing content returned by the server.
			Stream dataStream = response.GetResponseStream ();
			// Open the stream using a StreamReader for easy access.
			StreamReader reader = new StreamReader (dataStream);
			// Read the content.
			string responseFromServer = reader.ReadToEnd ();
			// Display the content.
			//Console.WriteLine (responseFromServer);
			reader.Close ();
			dataStream.Close ();
			response.Close ();


			return responseFromServer;
			// Clean up the streams.

		}
		catch (WebException ex)
		{
			if (ex.Status == WebExceptionStatus.ProtocolError){
				using (var response = (HttpWebResponse)ex.Response){
					using (var stream = response.GetResponseStream()){
						using (var reader = new StreamReader(stream, Encoding.GetEncoding("utf-8"))){return reader.ReadToEnd();}}}}
		}
		return "";
	}//End of getEnrollments Method

	//Function to authenticate your Voice Print
	public string authentication(string mail,string passwd, string pathToAuthenticationWav,string accuracy, string accuracyPasses, string accuracyPassIncrement, string confidence, string contentLanguage = "")
	{
			var email = mail;
			var password = GetSha256FromString(passwd);
			//password = GetSha256FromString(password);
			byte[] wavData = System.IO.File.ReadAllBytes(pathToAuthenticationWav);
			// Create a request for the URL.
			WebRequest request = WebRequest.Create ("https://siv.voiceprintportal.com/sivservice/api/authentications");
			request.ContentType = "audio/wav";
			request.Headers["VsitEmail"] = email;
			request.Headers["VsitPassword"] = password;
			request.Headers["VsitDeveloperId"] = this.developerId;
			request.Headers["VsitAccuracy"] = accuracy;
			request.Headers["VsitAccuracyPasses"] = accuracyPasses;
			request.Headers ["VsitAccuracyPassIncrement"] = accuracyPassIncrement;
			request.Headers["VsitConfidence"] = confidence;
			request.Headers["ContentLanguage"] = contentLanguage;
			request.Method = "POST";
			request.ContentLength = wavData.Length;
			// Get the request stream.
			Stream dataStream = request.GetRequestStream ();
			// Write the data to the request stream.
			dataStream.Write (wavData, 0, wavData.Length);
			// Close the Stream object.
			dataStream.Close ();
			// Get the response.
			try{
				WebResponse response = request.GetResponse ();
				// Display the status.
				//Console.WriteLine (((HttpWebResponse)response).StatusDescription);
				// Get the stream containing content returned by the server.
				dataStream = response.GetResponseStream ();
				// Open the stream using a StreamReader for easy access.
				StreamReader reader = new StreamReader (dataStream);
				// Read the content.
				string responseFromServer = reader.ReadToEnd ();
				// Display the content.
				//Console.WriteLine (responseFromServer);
				reader.Close ();
				dataStream.Close ();
				response.Close ();

				return responseFromServer;
				// Clean up the streams.

			}
			catch (WebException ex)
			{
				if (ex.Status == WebExceptionStatus.ProtocolError){
					using (var response = (HttpWebResponse)ex.Response){
						using (var stream = response.GetResponseStream()){
							using (var reader = new StreamReader(stream, Encoding.GetEncoding("utf-8"))){return reader.ReadToEnd();}}}}
			}
			return "";
	}//End of authentication Method

	//Function to authenticate your Voice Print
	public string authenticationByWavURL(string mail,string passwd, string urlToAuthenticationWav,string accuracy, string accuracyPasses, string accuracyPassIncrement, string confidence, string contentLanguage = "")
	{
		var email = mail;
		var password = GetSha256FromString(passwd);
		//password = GetSha256FromString(password);
		// Create a request for the URL.
		WebRequest request = WebRequest.Create ("https://siv.voiceprintportal.com/sivservice/api/authentications/bywavurl");
		request.Headers["VsitwavURL"] = urlToAuthenticationWav;
		request.Headers["VsitEmail"] = email;
		request.Headers["VsitPassword"] = password;
		request.Headers["VsitDeveloperId"] = this.developerId;
		request.Headers["VsitAccuracy"] = accuracy;
		request.Headers["VsitAccuracyPasses"] = accuracyPasses;
		request.Headers["VsitAccuracyPassIncrement"] = accuracyPassIncrement;
		request.Headers["VsitConfidence"] = confidence;
		request.Headers["ContentLanguage"] = contentLanguage;
		request.Method = "POST";
		string postData = "";
		byte[] byteArray = Encoding.UTF8.GetBytes (postData);
		request.ContentLength = byteArray.Length;
		// Get the request stream.
		Stream dataStream = request.GetRequestStream ();
		// Write the data to the request stream.
		dataStream.Write (byteArray, 0, byteArray.Length);
		// Close the Stream object.
		dataStream.Close ();
		// Get the response.
		try{
			WebResponse response = request.GetResponse ();
			// Display the status.
			//Console.WriteLine (((HttpWebResponse)response).StatusDescription);
			// Get the stream containing content returned by the server.
			dataStream = response.GetResponseStream ();
			// Open the stream using a StreamReader for easy access.
			StreamReader reader = new StreamReader (dataStream);
			// Read the content.
			string responseFromServer = reader.ReadToEnd ();
			// Display the content.
			//Console.WriteLine (responseFromServer);
			reader.Close ();
			dataStream.Close ();
			response.Close ();

			return responseFromServer;
			// Clean up the streams.

		}
		catch (WebException ex)
		{
			if (ex.Status == WebExceptionStatus.ProtocolError){
				using (var response = (HttpWebResponse)ex.Response){
					using (var stream = response.GetResponseStream()){
						using (var reader = new StreamReader(stream, Encoding.GetEncoding("utf-8"))){return reader.ReadToEnd();}}}}
		}
		return "";
	}//End of authenticationByWavURL Method

	}//End of Class Declaration
//}
