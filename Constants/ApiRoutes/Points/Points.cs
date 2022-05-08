namespace Constants.ApiRoutes.Points
{
    public static class Points
    {
        public const string BasePath = "points";

        public static class Squares
        {
            public const string BasePath = Points.BasePath + "/squares";

            public static class Action
            {
                public const string GetSquares = Squares.BasePath + "/" + Actions.GetSquares;
            }
        }

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
    }
}

