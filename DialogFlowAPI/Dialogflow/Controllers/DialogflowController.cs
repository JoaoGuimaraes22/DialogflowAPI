using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Google.Cloud.Dialogflow.V2;
using Google.Protobuf;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace Dialogflow.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class DialogflowController : ControllerBase
    {
        // A Protobuf JSON parser configured to ignore unknown fields. This makes
        // the action robust against new fields being introduced by Dialogflow.
        private static readonly JsonParser jsonParser = new JsonParser(JsonParser.Settings.Default.WithIgnoreUnknownFields(true));


        [HttpPost]

        public ContentResult DialogAction()
        {
            // Parse the body of the request using the Protobuf JSON parser,
            // *not* Json.NET.
            WebhookRequest request;
            using (var reader = new StreamReader(Request.Body))
            {
                request = jsonParser.Parse<WebhookRequest>(reader);
            }

            double noites = 0;
            double pessoas = 0;
            double dollars = 0;

            var requestParameters = request.QueryResult.Parameters;
            noites = requestParameters.Fields["noites"].NumberValue;
            pessoas = requestParameters.Fields["pessoas"].NumberValue;
            dollars = noites * pessoas;
            

            // Note: you should authenticate the request here.

            // Populate the response
            WebhookResponse response = new WebhookResponse
            {
                FulfillmentText = $"Obrigado por nos escolher! Vai ficar com {pessoas} durante {noites}, o que amonta para {dollars}$"
            };

            // Ask Protobuf to format the JSON to return.
            string responseJson = response.ToString();
            return Content(responseJson, "application/json");
        }

    }
}
