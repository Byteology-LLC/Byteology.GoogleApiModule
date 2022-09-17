using GoogleApi.Entities.Maps.Common.Enums;
using GoogleApi.Entities.Maps.Common;
using System.Collections.Generic;
using System;
using GoogleApi.Entities.Common.Enums;

namespace Byteology.GoogleApiModule.Apis.Maps.Inputs;

public class GoogleMapsDistanceInput : BaseChannelInput
{
    //
    // Summary:
    //     One or more addresses and/or textual latitude/longitude values, separated with
    //     the pipe (|) character, from which to calculate distance and time. If you pass
    //     an address as a string, the service will geocode the string and convert it to
    //     a latitude/longitude coordinate to calculate directions. If you pass coordinates,
    //     ensure that no space exists between the latitude and longitude values.
    public virtual IEnumerable<LocationEx> Origins { get; set; } = new List<LocationEx>();


    //
    // Summary:
    //     One or more addresses and/or textual latitude/longitude values, separated with
    //     the pipe (|) character, to which to calculate distance and time. If you pass
    //     an address as a string, the service will geocode the string and convert it to
    //     a latitude/longitude coordinate to calculate directions. If you pass coordinates,
    //     ensure that no space exists between the latitude and longitude values
    public virtual IEnumerable<LocationEx> Destinations { get; set; } = new List<LocationEx>();


    //
    // Summary:
    //     Distance Matrix results contain text within distance fields to indicate the distance
    //     of the calculated route. The unit system to use can be specified: Units=metric
    //     (default) returns distances in kilometers and meters. Units=imperial returns
    //     distances in miles and feet. * Note: this unit system setting only affects the
    //     text displayed within distance fields. The distance fields also contain values
    //     which are always expressed in meters
    public virtual Units Units { get; set; } = Units.Metric;


    //
    // Summary:
    //     avoid (optional) indicates that the calculated route(s) should avoid the indicated
    //     features. Currently, this parameter supports the following two arguments: tolls
    //     indicates that the calculated route should avoid toll roads/bridges. highways
    //     indicates that the calculated route should avoid highways. (For more information
    //     see Route Restrictions below.) Restrictions: Directions may be calculated that
    //     adhere to certain restrictions. Restrictions are indicated by use of the avoid
    //     parameter, and an argument to that parameter indicating the restriction to avoid.
    //     The following estrictions are supported GoogleApi.Entities.Maps.Common.Enums.AvoidWay
    public virtual AvoidWay Avoid { get; set; } = AvoidWay.Nothing;


    //
    // Summary:
    //     (optional, defaults to driving) — specifies what mode of transport to use when
    //     calculating directions. Valid values are specified in Travel Modes.
    public virtual TravelMode TravelMode { get; set; } = TravelMode.Driving;


    //
    // Summary:
    //     Traffic mdel (defaults to best_guess). Specifies the assumptions to use when
    //     calculating time in traffic. This setting affects the value returned in the duration_in_traffic
    //     field in the response, which contains the predicted time in traffic based on
    //     historical averages. The traffic_model parameter may only be specified for requests
    //     where the travel mode is driving, and where the request includes a departure_time,
    //     and only if the request includes an API key or a Google Maps APIs Premium Plan
    //     client ID.The available values for this parameter are:
    public virtual TrafficModel TrafficModel { get; set; } = TrafficModel.Best_Guess;


    //
    // Summary:
    //     Specifies one or more preferred modes of transit. This parameter may only be
    //     specified for requests where the mode is transit. The parameter supports the
    //     following arguments GoogleApi.Entities.Maps.Common.Enums.TransitMode
    public virtual TransitMode TransitMode { get; set; } = TransitMode.Rail | TransitMode.Bus;


    //
    // Summary:
    //     Specifies preferences for transit requests. Using this parameter, you can bias
    //     the options returned, rather than accepting the default best route chosen by
    //     the API. This parameter may only be specified for requests where the mode is
    //     transit. The parameter supports the following arguments: GoogleApi.Entities.Maps.Common.Enums.TransitRoutingPreference
    public virtual TransitRoutingPreference TransitRoutingPreference { get; set; } = TransitRoutingPreference.Nothing;


    //
    // Summary:
    //     The desired time of departure. You can specify the time as an integer in seconds
    //     since midnight, January 1, 1970 UTC. Alternatively, you can specify a value of
    //     now, which sets the departure time to the current time (correct to the nearest
    //     second). The departure time may be specified in two cases: - For requests where
    //     the travel mode is transit: You can optionally specify one of departure_time
    //     or arrival_time. If neither time is specified, the departure_time defaults to
    //     now (that is, the departure time defaults to the current time). - For requests
    //     where the travel mode is driving: Google Maps API for Work customers can specify
    //     the departure_time to receive trip duration considering current traffic conditions.
    //     The departure_time must be set to within a few minutes of the current time. Note:
    //     Requests that include the departure_time parameter are limited to 100 elements
    //     Note: You can specify either DepartureTime or ArrivalTime, but not both
    public virtual DateTime? DepartureTime { get; set; }

    //
    // Summary:
    //     Specifies the desired time of arrival for transit requests, in seconds since
    //     midnight, January 1, 1970 UTC. Note: You can specify either DepartureTime or
    //     ArrivalTime, but not both
    public virtual DateTime? ArrivalTime { get; set; }

    //
    // Summary:
    //     language (optional) — The language in which to return results. See the supported
    //     list of domain languages. Note that we often update supported languages so this
    //     list may not be exhaustive. If language is not supplied, the Directions service
    //     will attempt to use the native language of the browser wherever possible. You
    //     may also explicitly bias the results by using localized domains of http://map.google.com.
    //     See Region Biasing for more information.
    public virtual Language Language { get; set; } = Language.English;


    //
    // Summary:
    //     region (optional) — The region code, specified as a ccTLD (country code top-level
    //     domain - https://en.wikipedia.org/wiki/CcTLD) two-character value. Most ccTLD
    //     codes are identical to ISO 3166-1 codes, with some exceptions. This parameter
    //     will only influence, not fully restrict, results from the geocoder. If more relevant
    //     results exist outside of the specified region, they may be included.
    public virtual string Region { get; set; }
}