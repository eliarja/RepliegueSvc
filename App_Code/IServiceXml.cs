using System;
using System.ServiceModel.Activation;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Web;
using System.Web.Services;
using System.IO;

// NOTA: puede usar el comando "Rename" del menú "Refactorizar" para cambiar el nombre de interfaz "IService1" en el código y en el archivo de configuración a la vez.
[ServiceContract]
public interface IServiceXml
{
	[OperationContract]
	ValidPinResponse ValidatePin(string pin);

	[OperationContract(IsOneWay = true)]
	void UploadFile(FileUploadMessage request);
	// TODO: agregue aquí sus operaciones de servicio
}

[MessageContract]
public class FileUploadMessage
{
	[MessageHeader(MustUnderstand =true)]
	public string pin;
	[MessageBodyMember(Order =1)]
	public Stream FileByteStream { get; set; }
}

// Utilice un contrato de datos, como se ilustra en el ejemplo siguiente, para agregar tipos compuestos a las operaciones de servicio.
[DataContract]
public struct ValidPinResponse
{
	public ValidPinResponse(bool BackupFiles, string votingBookCode)
	{
		this.BackupFiles = BackupFiles;
		this.votingBookCode = votingBookCode;
	}

	[DataMember]
	public bool BackupFiles;
	[DataMember]
	public string votingBookCode; 
}