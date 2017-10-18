Mtsk
====

PCL for accessing the [Tankerkönig API](https://creativecommons.tankerkoenig.de/) to get the MTS-K fuel prices.

---------------------------------------------------------------------------------------------------------------

## Usage ##

You have to get your own key [here](https://creativecommons.tankerkoenig.de/). Mind the Terms set by their site.

The key in the examples and tests here is their demo key and will only ever return the same price-results and pretty json.

CSharp
```
// Create a client with your client key
var client = new MtskApiClient("00000000-0000-0000-0000-000000000002");

// Get the fuel stations and prices in an area using latitude, longitude and a radius
var response = await client.GetSurroundingAreaAsync(52.521m, 13.438m, 1.5m);

// Get extended details about a specific station by unique id
var response = await client.GetStationDetailsAsync("24a381e3-0d72-416d-bfd8-b2f65f6e5802");

// Get price information about known fuel stations
var response = await client.GetPricesAsync("4429a7d9-fb2d-4c29-8cfe-2ca90323f9f8", "446bdcf5-9f75-47fc-9cfa-2c3d6fda1c3b");
```
