using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml;

namespace WindowsFormsApp1.Utils
{
    class WebServiceSiscob
    {
        public static void CallWebService(String idContrato, String cod, String mensagem)
        {
            var _url = @"http://20.10.1.104:8601/SOAP?service=CSLogService";
            var _action = @"urn:DWLibrary-CSLogService";

            XmlDocument soapEnvelopeXml = CreateSoapEnvelope(idContrato,cod,mensagem);
            HttpWebRequest webRequest = CreateWebRequest(_url, _action);
            InsertSoapEnvelopeIntoWebRequest(soapEnvelopeXml, webRequest);

            // begin async call to web request.
            IAsyncResult asyncResult = webRequest.BeginGetResponse(null, null);

            // suspend this thread until call is complete. You might want to
            // do something usefull here like update your UI.
            asyncResult.AsyncWaitHandle.WaitOne();

            // get the response from the completed web request.
            string soapResult;
            using (WebResponse webResponse = webRequest.EndGetResponse(asyncResult))
            {
                using (StreamReader rd = new StreamReader(webResponse.GetResponseStream()))
                {
                    soapResult = rd.ReadToEnd();
                }
                Console.WriteLine(soapResult);
                //Clipboard.SetText(soapResult);
            }
        }

        private static HttpWebRequest CreateWebRequest(string url, string action)
        {
            HttpWebRequest webRequest = (HttpWebRequest)WebRequest.Create(url);
            webRequest.Headers.Add("SOAPAction", action);
            webRequest.ContentType = "text/xml;charset=\"utf-8\"";
            webRequest.Accept = "text/xml";
            webRequest.Method = "POST";
            return webRequest;
        }

        private static XmlDocument CreateSoapEnvelope(String idContrato,String codAcionamento, String msg)
        {
            XmlDocument soapEnvelopeDocument = new XmlDocument();

            String soapRequest = @"<soapenv:Envelope xmlns:xsi=""http://www.w3.org/2001/XMLSchema-instance"" xmlns:xsd=""http://www.w3.org/2001/XMLSchema"" xmlns:soapenv=""http://schemas.xmlsoap.org/soap/envelope/"" xmlns:urn=""urn:DWLibrary-CSLogService"">" +
                                 @"<soapenv:Header/><soapenv:Body><urn:insereHistorico soapenv:encodingStyle = ""http://schemas.xmlsoap.org/soap/encoding/"">" +
                                 @"<login xsi:type=""xsd:string"">informaredati</login>" +
                                 @"<senha xsi:type=""xsd:string"">mare@018</senha>" +
                                 @"<id_fornecedor xsi:type=""xsd:int"">0</id_fornecedor>" +
                                 @"<id_contr xsi:type=""xsd:int"">" + idContrato + "</id_contr>" +
                                 @"<id_funcionario xsi:type=""xsd:int"">0</id_funcionario>" +
                                 @"<id_tel xsi:type=""xsd:int"">0</id_tel>" +
                                 @"<telefone xsi:type=""xsd:string""></telefone>" +
                                 @"<codigo_acionamento xsi:type=""xsd:int"">" + codAcionamento + "</codigo_acionamento>" +
                                 @"<mensagem xsi:type=""xsd:string"">"+msg+"</mensagem>" +
                                 @"<modo xsi:type=""xsd:string"">D</modo>" +
                                 @"<motivo xsi:type=""xsd:string""></motivo>" +
                                 @"<autorizacao xsi:type=""xsd:string""></autorizacao>" +
                                 @"</urn:insereHistorico></soapenv:Body></soapenv:Envelope> ";

            //soapEnvelopeDocument.Load("WebServiceTemplates/InsereHistorico.xml");
            soapEnvelopeDocument.LoadXml(soapRequest);
            Console.WriteLine(soapEnvelopeDocument.InnerXml);
            return soapEnvelopeDocument;
        }

        private static void InsertSoapEnvelopeIntoWebRequest(XmlDocument soapEnvelopeXml, HttpWebRequest webRequest)
        {
            using (Stream stream = webRequest.GetRequestStream())
            {
                soapEnvelopeXml.Save(stream);
            }
        }
    }
}
