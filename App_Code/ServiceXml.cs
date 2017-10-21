using System;
using System.ServiceModel.Activation;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using Newtonsoft.Json;
using System.IO;
using System.Web.Services;

// NOTA: puede usar el comando "Rename" del menú "Refactorizar" para cambiar el nombre de clase "Service1" en el código, en svc y en el archivo de configuración.
[ServiceBehavior(ConcurrencyMode = ConcurrencyMode.Multiple, InstanceContextMode = InstanceContextMode.PerCall)]
public class ServiceXml : IServiceXml
{
	public void UploadFile(FileUploadMessage request)
	{
		using (FileStream outfile = new FileStream("d:\\" + request.pin, FileMode.Create))
		{
			const int bufferSize = 65536;
			Byte[] buffer = new Byte[bufferSize];
			int bytesRead = request.FileByteStream.Read(buffer, 0, bufferSize);

			while (bytesRead > 0)
			{
				outfile.Write(buffer, 0, bytesRead);
				bytesRead = request.FileByteStream.Read(buffer, 0, bufferSize);
				outfile.Flush();
			}
			outfile.Close();
		}
	}

	public ValidPinResponse ValidatePin(string pin)
	{
		return new ValidPinResponse(true, "020301001.03");
	}
}
