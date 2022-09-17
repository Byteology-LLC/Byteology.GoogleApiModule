namespace Byteology.GoogleApiModule;
using GoogleApi.Entities.Common;
using GoogleApi.Entities.Maps.Common;
using System.Collections.Generic;

/* Inherit from this class for your application layer tests.
 * See SampleAppService_Tests for example.
 */
public abstract class GoogleApiModuleApplicationTestBase : GoogleApiModuleTestBase<GoogleApiModuleApplicationTestModule>
{
    public readonly Dictionary<TestLocation, CoordinateEx> Coordinates = new Dictionary<TestLocation, CoordinateEx>
        {
            {TestLocation.EmpireStateBuilding, new CoordinateEx(40.7484, -73.9857) },
            {TestLocation.WhiteHouse, new CoordinateEx(38.8977, -77.0365) },
            {TestLocation.MountRushmore, new CoordinateEx(43.8791, -103.4591) },
            {TestLocation.MallOfAmerica, new CoordinateEx(44.8549, -93.2422) },
            {TestLocation.GrandCanyon, new CoordinateEx(36.0544, -112.1401) },
            {TestLocation.StatueOfLiberty, new CoordinateEx(40.689247, -74.044502) },
            {TestLocation.DemarestBuilding, new CoordinateEx(40.7478, 73.9847) },
            {TestLocation.Route66, new CoordinateEx(35.254688,-101.643883) }
        };

    public const string WhiteHouseAddressString = "1600 Pennsylvania Avenue Northwest, Washington, DC, USA";
    public readonly Address WhiteHouseAddress = new Address(WhiteHouseAddressString);
    public const string WhiteHousePlaceId = "ChIJGVtI4by3t4kRr51d_Qm_x58";
    public const string WhiteHouseLocalPlusCode = "VXX7+39";
    public const string WhiteHouseGlobalPlusCode = "87C4VXX7+39";
}

public enum TestLocation
{
    EmpireStateBuilding,
    StatueOfLiberty,
    DemarestBuilding,
    WhiteHouse,
    MountRushmore,
    MallOfAmerica,
    GrandCanyon,
    Route66
}