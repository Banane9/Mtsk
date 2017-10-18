﻿using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using Newtonsoft.Json;

namespace Mtsk.ApiResponses
{
    /// <summary>
    /// Represents the Api response from the prices.php endpoint.
    /// </summary>
    [JsonObject]
    public sealed class PriceApiResponse : MtskApiResponse
    {
        /// <summary>
        /// Gets the <see cref="PriceList"/>s, matched to their station's unique id.
        /// </summary>
        [JsonProperty("prices")]
        public ReadOnlyDictionary<string, PriceList> Prices { get; private set; }

        [JsonObject]
        public sealed class PriceList
        {
            /// <summary>
            /// Gets the price of Diesel at the fuel station.
            /// <para/>
            /// May be null if the fuel station isn't open (see <see cref="Status"/>) or doesn't offer this fuel.
            /// </summary>
            [JsonProperty("diesel")]
            public decimal? Diesel { get; private set; }

            /// <summary>
            /// Gets the status of the station.
            /// </summary>
            [JsonProperty("status")]
            public StationStatus Status { get; private set; }

            /// <summary>
            /// Gets the price of Super E10 at the fuel station.
            /// <para/>
            /// May be null if the fuel station isn't open (see <see cref="Status"/>) or doesn't offer this fuel.
            /// </summary>
            [JsonProperty("e10")]
            public decimal? SuperE10 { get; private set; }

            /// <summary>
            /// Gets the price of Super E5 at the fuel station.
            /// <para/>
            /// May be null if the fuel station isn't open (see <see cref="Status"/>) or doesn't offer this fuel.
            /// </summary>
            [JsonProperty("e5")]
            public decimal? SuperE5 { get; private set; }

            /// <summary>
            /// The different statuses of a station.
            /// </summary>
            public enum StationStatus
            {
                /// <summary>
                /// Station is open at time of request.
                /// </summary>
                Open,

                /// <summary>
                /// Station is closed at time of request.
                /// </summary>
                Closed,

                /// <summary>
                /// Station doesn't have prices listed.
                /// </summary>
                NoPrices
            }
        }
    }
}