using System;
using System.Collections.Generic;
using System.Linq;
using Newtonsoft.Json;

namespace Mtsk.ApiResponses
{
    /// <summary>
    /// Represents the Api response from the list.php endpoint.
    /// </summary>
    [JsonObject]
    public sealed class SurroundingAreaApiResponse : MtskApiResponse
    {
        /// <summary>
        /// Gets the surrounding stations.
        /// </summary>
        [JsonProperty("stations")]
        public DistantFuelStation[] Stations { get; private set; }

        /// <summary>
        /// Represents the fuel station object which is part of the list.php results.
        /// </summary>
        [JsonObject]
        public sealed class DistantFuelStation : FuelStation
        {
            /// <summary>
            /// Gets the distance of the fuel station to the querried coordinates.
            /// </summary>
            [JsonProperty("dist")]
            public double Distance { get; private set; }
        }
    }
}