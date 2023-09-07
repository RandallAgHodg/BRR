namespace BRR.WebAPI;

public static class ApiRoutes
{
    public const string Root = "api";

    public static class Auth
    {
        private const string Base = $"{Root}/auth";

        public const string Login = $"{Base}/login";

        public const string RegisterAgent = $"{Base}/register-agent";

        public const string Profile = $"{Base}/profile";

        public const string RefreshToken = $"{Base}/refresh-token";
    }

    public static class Houses
    {
        private const string Base = $"{Root}/houses";

        public const string SendHouseProposal = $"{Base}/send-house-proposal";

        public const string ApproveHouseProposal = $"{Base}/approve-house-proposal/{{houseId:int}}";

        public const string GetTop5HousesByDiscount = $"{Base}/discount";

        public const string SearchHouses = $"{Base}/search";

        public const string UpdateHouseInformation = $"{Base}/{{houseId:int}}";
        public const string DeleteHouse = $"{Base}/{{houseId:int}}";
        public const string RejectHouse = $"{Base}/{{houseId:int}}";
    }
}
