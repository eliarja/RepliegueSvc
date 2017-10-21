using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using Newtonsoft.Json;

// NOTA: puede usar el comando "Cambiar nombre" del menú "Refactorizar" para cambiar el nombre de clase "Service2" en el código, en svc y en el archivo de configuración a la vez.
public class ServiceJson : IServiceJson
{
	public PinResponse GetPin(string serial, string user)
	{
		return new PinResponse("123456", true, "020101002.02");
	}

	public bool IsDone(string serial)
	{
		return true;
	}

	public bool ValidateUser(string user)
	{
		return true;
	}
}