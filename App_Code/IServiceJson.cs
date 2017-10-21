using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using Newtonsoft.Json;
using System.Text;

// NOTA: puede usar el comando "Cambiar nombre" del menú "Refactorizar" para cambiar el nombre de interfaz "IService2" en el código y en el archivo de configuración a la vez.
[ServiceContract]
public interface IServiceJson
{
	[OperationContract]
	[WebInvoke(Method = "GET", ResponseFormat = WebMessageFormat.Json, BodyStyle = WebMessageBodyStyle.Bare,
		UriTemplate = "validateuser/{user}")]
	bool ValidateUser(string user);

	[OperationContract]
	[WebInvoke(Method = "GET", ResponseFormat = WebMessageFormat.Json, BodyStyle = WebMessageBodyStyle.Bare,
		UriTemplate = "getpin/{serial}/{user}")]
	PinResponse GetPin(string serial, string user);

	[OperationContract]
	[WebInvoke(Method = "GET", ResponseFormat = WebMessageFormat.Json, BodyStyle = WebMessageBodyStyle.Bare,
		UriTemplate = "isdone/{serial}")]
	bool IsDone(string serial);
}

[DataContract]
public struct PinResponse
{
	public PinResponse(string pin, bool exist, string votingBookCode)
	{
		this.pin = pin;
		this.exist = exist;
		this.votingBookCode = votingBookCode;
	}

	[DataMember]
	public string pin;
	[DataMember]
	public bool exist;
	[DataMember]
	public string votingBookCode;
}