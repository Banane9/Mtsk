using System;
using System.Collections.Generic;
using System.Linq;
using Newtonsoft.Json;

namespace Mtsk
{
    /// <summary>
    /// Represents the fuel station object which is part of some results (with small additions).
    /// </summary>
    public abstract class FuelStation
    {
        /// <summary>
        /// Gets the brand of the fuel station.
        /// </summary>
        [JsonProperty("brand")]
        public string Brand { get; private set; }

        /// <summary>
        /// Gets the city, that the fuel station is in.
        /// </summary>
        [JsonProperty("place")]
        public string City { get; private set; }

        /// <summary>
        /// Gets the price of Diesel at the fuel station.
        /// </summary>
        [JsonProperty("diesel")]
        public decimal Diesel { get; private set; }

        /// <summary>
        /// Gets the house number of the fuel station.
        /// </summary>
        [JsonProperty("houseNumber")]
        public string HouseNumber { get; private set; }

        /// <summary>
        /// Gets the unique id of the fuel station.
        /// </summary>
        [JsonProperty("id")]
        public string Id { get; private set; }

        /// <summary>
        /// Gets whether the fuel station is open or not (at time of request).
        /// </summary>
        [JsonProperty("isOpen")]
        public bool IsOpen { get; set; }

        /// <summary>
        /// Gets the latitude of the fuel station.
        /// </summary>
        [JsonProperty("lat")]
        public decimal Latitude { get; private set; }

        /// <summary>
        /// Gets the longitude of the fuel station.
        /// </summary>
        [JsonProperty("lng")]
        public decimal Longitude { get; private set; }

        /// <summary>
        /// Gets the name of the fuel station.
        /// </summary>
        [JsonProperty("name")]
        public string Name { get; private set; }

        /// <summary>
        /// Gets the post code of the fuel station.
        /// </summary>
        [JsonProperty("postCode")]
        public string PostCode { get; private set; }

        /// <summary>
        /// Gets the street that the fuel station is on.
        /// </summary>
        [JsonProperty("street")]
        public string Street { get; private set; }

        /// <summary>
        /// Gets the price of Super E10 at the fuel station.
        /// </summary>
        [JsonProperty("e10")]
        public decimal SuperE10 { get; private set; }

        /// <summary>
        /// Gets the price of Super E5 at the fuel station.
        /// </summary>
        [JsonProperty("e5")]
        public decimal SuperE5 { get; private set; }
    }
}