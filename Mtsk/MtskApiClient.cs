using System;
using System.Collections.Generic;
using System.Linq;
using System.Globalization;
using System.IO;

using System.Linq;

using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using Mtsk.ApiResponses;
using Newtonsoft.Json;

namespace Mtsk
{
    /// <summary>
    /// Represents the client to query the Tankerkönig MTS-K Api.
    /// </summary>
    public sealed class MtskApiClient
    {
        private const string baseUrl = "https://creativecommons.tankerkoenig.de/json/";

        private static readonly CultureInfo invariantCulture = CultureInfo.InvariantCulture;
        private readonly string clientId;

        private readonly HttpClient httpClient;
        private readonly JsonSerializer serializer = new JsonSerializer();

        /// <summary>
        /// Creates a new instance of the <see cref="MtskApiClient"/> class with the given client Id.
        /// </summary>
        /// <param name="clientId">The client Id required for the API to work.</param>
        public MtskApiClient(string clientId)
        {
            if (string.IsNullOrWhiteSpace(clientId))
                throw new ArgumentNullException(nameof(clientId), "Client Id can't be null or whitespace.");

            this.clientId = clientId;

            var clientHandler = new HttpClientHandler();
            if (clientHandler.SupportsAutomaticDecompression)
                clientHandler.AutomaticDecompression = DecompressionMethods.GZip | DecompressionMethods.Deflate;

            httpClient = new HttpClient(clientHandler);

            httpClient.DefaultRequestHeaders.Add("Host", "creativecommons.tankerkoenig.de");
            httpClient.DefaultRequestHeaders.Add("UserAgent", "CSharp Tankerkönig MTS-K API Client");
            httpClient.DefaultRequestHeaders.Add("Accept", "application/json; charset=UTF-8");
            httpClient.DefaultRequestHeaders.Add("Connection", "keep-alive");
        }

        /// <summary>
        /// Makes a call to the prices.php endpoint to get up-to-date prices for known fuel stations.
        /// </summary>
        /// <param name="ids">The unique ids of the fuel stations to get prices for.</param>
        /// <returns>The deserialized response or null if the call wasn't successful.</returns>
        public async Task<PriceApiResponse> GetPricesAsync(IEnumerable<string> ids)
        {
            if (ids == null)
                throw new ArgumentNullException(nameof(ids), "Ids must not be null!");

            if (ids.Count() == 0 || ids.Count() > 10)
                throw new ArgumentOutOfRangeException(nameof(ids), "There must be [1; 10] ids!");

            return await deserializeAsync<PriceApiResponse>(await getAsync($"prices.php?ids={String.Join(",", ids)}"));
        }

        /// <summary>
        /// Makes a call to the prices.php endpoint to get up-to-date prices for known fuel stations.
        /// </summary>
        /// <param name="ids">The unique ids of the fuel stations to get prices for.</param>
        /// <returns>The deserialized response or null if the call wasn't successful.</returns>
        public async Task<PriceApiResponse> GetPricesAsync(params string[] ids)
        {
            return await GetPricesAsync((IEnumerable<string>)ids);
        }

        /// <summary>
        /// Makes a call to the detail.php endpoint to get extended information about a specific fuel station.
        /// </summary>
        /// <param name="id">The unique id of the fuel station.</param>
        /// <returns>The deserialized response or null if the call wasn't successful.</returns>
        public async Task<DetailApiResponse> GetStationDetailsAsync(string id)
        {
            if (string.IsNullOrWhiteSpace(id))
                throw new ArgumentNullException(nameof(id), "Id must be a valid unique fuel station id!");

            return await deserializeAsync<DetailApiResponse>(await getAsync($"detail.php?id={id}"));
        }

        /// <summary>
        /// Makes a call to the list.php endpoint to get all fuel stations with a certain radius around a longitude/latitude point.
        /// </summary>
        /// <param name="latitude">The latitude of the point to search around.</param>
        /// <param name="longitude">The longitude of the point to search around.</param>
        /// <param name="radius">The radius in kilometres to search within. Must be [1; 25].</param>
        /// <returns>The deserialized response or null if the call wasn't successful.</returns>
        public async Task<SurroundingAreaApiResponse> GetSurroundingAreaAsync(decimal latitude, decimal longitude, decimal radius)
        {
            if (radius < 1 || radius > 25)
                throw new ArgumentOutOfRangeException(nameof(radius), "Radius must be [1; 25]!");

            return await deserializeAsync<SurroundingAreaApiResponse>(
                await getAsync($"list.php?type=all&lng={longitude.ToString(invariantCulture)}&lat={latitude.ToString(invariantCulture)}&rad={radius.ToString(invariantCulture)}"));
        }

        private Task<TResult> deserializeAsync<TResult>(Stream stream) where TResult : MtskApiResponse
        {
            if (stream == null)
                return null;

            return Task.Run(() =>
                serializer.Deserialize<TResult>(new JsonTextReader(new StreamReader(stream))));
        }

        private async Task<Stream> getAsync(string suffixUrl)
        {
            var httpResponse = await httpClient.GetAsync($"{baseUrl}{suffixUrl}&apikey={clientId}");

            if (!httpResponse.IsSuccessStatusCode)
                return null;

            return await httpResponse.Content.ReadAsStreamAsync();
        }
    }
}