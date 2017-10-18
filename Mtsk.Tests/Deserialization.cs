using System;
using System.IO;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Mtsk.ApiResponses;
using Newtonsoft.Json;

namespace Mtsk.Tests
{
    [TestClass]
    public class Deserialization
    {
        private readonly string detailsJson = "{    \"ok\": true,    \"license\": \"CC BY 4.0 -  https://creativecommons.tankerkoenig.de\",    \"data\": \"MTS-K\",    \"status\": \"ok\",    \"station\": {        \"id\": \"24a381e3-0d72-416d-bfd8-b2f65f6e5802\",        \"name\": \"Esso Tankstelle\",        \"brand\": \"ESSO\",        \"street\": \"HAUPTSTR. 7\",        \"houseNumber\": \" \",        \"postCode\": 84152,        \"place\": \"MENGKOFEN\",        \"openingTimes\": [            {                \"text\": \"Mo-Fr\",                \"start\": \"06:00:00\",                \"end\": \"22:30:00\"            },            {                \"text\": \"Samstag\",                \"start\": \"07:00:00\",                \"end\": \"22:00:00\"            },            {                \"text\": \"Sonntag\",                \"start\": \"08:00:00\",                \"end\": \"22:00:00\"            }        ],        \"overrides\": [            \"13.04.2017, 15:00:00 - 13.11.2017, 15:00:00: geschlossen\"        ],        \"wholeDay\": false,        \"isOpen\": false,        \"e5\": 1.379,        \"e10\": 1.359,        \"diesel\": 1.169,        \"lat\": 48.72210601,        \"lng\": 12.44438439,        \"state\": null    }}";
        private readonly string pricesJson = "{    \"ok\": true,    \"license\": \"CC BY 4.0 -  https://creativecommons.tankerkoenig.de\",    \"data\": \"MTS-K\",    \"prices\": {        \"60c0eefa-d2a8-4f5c-82cc-b5244ecae955\": {            \"status\": \"open\",            \"e5\": false,            \"e10\": false,            \"diesel\": 1.189        },        \"446bdcf5-9f75-47fc-9cfa-2c3d6fda1c3b\": {            \"status\": \"closed\"        },        \"4429a7d9-fb2d-4c29-8cfe-2ca90323f9f8\": {            \"status\": \"open\",            \"e5\": 1.409,            \"e10\": 1.389,            \"diesel\": 1.129        },        \"44444444-4444-4444-4444-444444444444\": {            \"status\": \"no prices\"        }    }}";
        private readonly JsonSerializer serializer = new JsonSerializer();
        private readonly string surroundingAreaJson = "{    \"ok\": true,    \"license\": \"CC BY 4.0 -  https://creativecommons.tankerkoenig.de\",    \"data\": \"MTS-K\",    \"status\": \"ok\",    \"stations\": [        {            \"id\": \"474e5046-deaf-4f9b-9a32-9797b778f047\",            \"name\": \"TOTAL BERLIN\",            \"brand\": \"TOTAL\",            \"street\": \"MARGARETE-SOMMER-STR.\",            \"place\": \"BERLIN\",            \"lat\": 52.53083,            \"lng\": 13.440946,            \"dist\": 1.1,            \"diesel\": 1.109,            \"e5\": 1.339,            \"e10\": 1.319,            \"isOpen\": true,            \"houseNumber\": \"2\",            \"postCode\": 10407        }    ]}";

        [TestMethod]
        public void DeserializesDetailsResponse()
        {
            var response = serializer.Deserialize<DetailApiResponse>(new JsonTextReader(new StringReader(detailsJson)));
        }

        [TestMethod]
        public void DeserializesPriceResponse()
        {
            var response = serializer.Deserialize<PriceApiResponse>(new JsonTextReader(new StringReader(pricesJson)));
        }

        [TestMethod]
        public void DeserializesSurroundingAreaResponse()
        {
            var response = serializer.Deserialize<PriceApiResponse>(new JsonTextReader(new StringReader(surroundingAreaJson)));
        }
    }
}