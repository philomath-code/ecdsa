using Microsoft.IdentityModel.Tokens;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Text.Json;
using System.IO;

namespace ecdsa
{
    public class ECDSAGenerator
    {
        /// <summary>
        /// Daniel Medina - Export in JSON  ECDSa keys
        /// </summary>
        /// <returns></returns>
        public string GeneratePrivatePublicKeys()
        {
            //Create Public and Private Keys
            var key = ECDsa.Create(ECCurve.NamedCurves.nistP256);
            //Export Keys to be used
            var ExportedParameters = key.ExportParameters(true);
            //Serialize keys into json string
            string Response = JsonConvert.SerializeObject(ExportedParameters);
            //return serialized json keys
            return Response;
        }


        public bool TestECDSAHexPrivatePublicKeys(string TestObject)
        {
           try
            {
                
                var DeserializedECParameter = JsonConvert.DeserializeObject<ECParameters>(TestObject);
                var TestECDSA = ECDsa.Create(new ECParameters
                {
                    Curve = ECCurve.NamedCurves.nistP256, // you'd need to know the curve before hand
                    D = DeserializedECParameter.D,
                    Q = new ECPoint
                    {
                        
                        X = DeserializedECParameter.Q.X,
                        Y = DeserializedECParameter.Q.Y
                    }
                });
                return true;

            }
            catch (Exception ex)
            {
                return false;
            }
            

        }

        public ECDsa ReturnECDSAObjectFromFilePath(string filePath)
        {
            try
            {
                var data = File.ReadAllText(filePath);
                var DeserializedECParameter = JsonConvert.DeserializeObject<ECParameters>(data);
                var TestECDSA = ECDsa.Create(new ECParameters
                {
                    Curve = ECCurve.NamedCurves.nistP256, // you'd need to know the curve before hand
                    D = DeserializedECParameter.D,
                    Q = new ECPoint
                    {

                        X = DeserializedECParameter.Q.X,
                        Y = DeserializedECParameter.Q.Y
                    }
                });
                return TestECDSA;

            }
            catch (Exception ex)
            {
                return null;
            }
        }
        public ECDsa ReturnECDSAObjectFromString(string TestObject)
        {
            try
            {

                var DeserializedECParameter = JsonConvert.DeserializeObject<ECParameters>(TestObject);
                var TestECDSA = ECDsa.Create(new ECParameters
                {
                    Curve = ECCurve.NamedCurves.nistP256, // you'd need to know the curve before hand
                    D = DeserializedECParameter.D,
                    Q = new ECPoint
                    {

                        X = DeserializedECParameter.Q.X,
                        Y = DeserializedECParameter.Q.Y
                    }
                });
                return TestECDSA;

            }
            catch (Exception ex)
            {
                return null;
            }


        }
    }
    public class ECDSAHexPrivatePublicKeys
    {
        public string Private { get; set; }
        public string Public { get; set; }

        public ECDSAHexPrivatePublicKeys(string Private, string Public)
        {
            this.Private = Private;
            this.Public = Public;
        }

    }

}
