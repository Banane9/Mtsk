using System;
using System.Collections.Generic;
using System.Linq;
using Newtonsoft.Json;

namespace Mtsk.ApiResponses
{
    /// <summary>
    /// Represents the Api response from the details.php endpoint.
    /// </summary>
    [JsonObject]
    public sealed class DetailApiResponse : MtskApiResponse
    {
        /// <summary>
        /// Gets the detailed fuel station information.
        /// </summary>
        [JsonProperty("station")]
        public DetailedFuelStation Station { get; private set; }

        /// <summary>
        /// Represents the fuel station object which is part of the details.php results.
        /// </summary>
        [JsonObject]
        public sealed class DetailedFuelStation : FuelStation
        {
            /// <summary>
            /// Gets the opening times of the fuel station.
            /// </summary>
            [JsonProperty("openingTimes")]
            public OpeningTime[] OpeningTimes { get; set; }

            /// <summary>
            /// Gets the short term overrides to the normal opening times of the fuel station.
            /// </summary>
            [JsonProperty("overrides")]
            public string[] Overrides { get; set; }

            /// <summary>
            /// Gets the state (abbreviation) that the fuel station is in. Usually null.
            /// </summary>
            [JsonProperty("state")]
            public string State { get; set; }

            /// <summary>
            /// Gets whether the fuel station is open 24 hours a day or not.
            /// </summary>
            [JsonProperty("wholeDay")]
            public bool WholeDay { get; set; }

            /// <summary>
            /// Represents the opening times object which are part of the detailed fuel station.
            /// </summary>
            [JsonObject]
            public class OpeningTime
            {
                /// <summary>
                /// Gets the time (hh:mm:ss) when the fuel station closes.
                /// </summary>
                [JsonProperty("end")]
                public string Close { get; set; }

                /// <summary>
                /// Gets the time (hh:mm:ss) when the fuel station opens.
                /// </summary>
                [JsonProperty("start")]
                public string Open { get; set; }

                /// <summary>
                /// Gets a description of the days when these opening times apply.
                /// </summary>
                [JsonProperty("text")]
                public string Text { get; set; }
            }
        }
    }
}