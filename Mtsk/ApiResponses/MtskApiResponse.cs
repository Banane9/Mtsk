using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Mtsk.ApiResponses
{
    /// <summary>
    /// Represents the base response from the Tankerkönig MTS-K Api.
    /// </summary>
    public abstract class MtskApiResponse
    {
        /// <summary>
        /// Gets the source of the data, when <see cref="Success"/> is true.
        /// <para/>
        /// Usually always: "MTS-K"
        /// </summary>
        [JsonProperty("message")]
        public string Data { get; private set; }

        /// <summary>
        /// Gets the license of the data, when <see cref="Success"/> is true.
        /// <para/>
        /// Usually always: "CC BY 4.0 -  https://creativecommons.tankerkoenig.de"
        /// </summary>
        [JsonProperty("license")]
        public string License { get; private set; }

        /// <summary>
        /// Gets the error message, when <see cref="Success"/> is false.
        /// </summary>
        [JsonProperty("message")]
        public string Message { get; private set; }

        /// <summary>
        /// Gets whether the request was successful or not.
        /// </summary>
        [JsonProperty(PropertyName = "ok", Required = Required.Always)]
        public bool Success { get; private set; }
    }
}