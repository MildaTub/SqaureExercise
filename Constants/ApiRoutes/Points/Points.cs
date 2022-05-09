namespace Constants.ApiRoutes.Points
{
    public static class Points
    {
        public const string BasePath = "points";

        public static class Actions
        {
            public const string AddPoint = "add-point";
            public const string AddPoints = "add-points";
            public const string DeletePoint = "delete-point";
            public const string GetSquares = "get-squares";
        }

        public const string BaseAddPointPath = Actions.AddPoint;
        public const string BaseAddPointsPath = Actions.AddPoints;
        public const string BaseDeletePointPath = Actions.DeletePoint;
        public const string BaseGetSquaresPath = Actions.GetSquares;
    }
}
