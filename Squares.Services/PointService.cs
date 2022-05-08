using Microsoft.EntityFrameworkCore;
using Points.DataAccess;
using Points.Models;

using System.ComponentModel.DataAnnotations;

namespace Points.Services
{
    public interface IPointService
    {
        Task AddSquarePoint(PointModel model);
        Task AddSquarePoints(List<PointModel> model);
        Task DeleteSquarePoint(int pointId);
        Task<List<SquareModel>> GetSquares();
    }

    public class PointService : IPointService
    {   
        private readonly PointsDbContext pointsContext;
        public PointService(PointsDbContext pointsContext)
        {
            this.pointsContext = pointsContext;
        }
        public async Task AddSquarePoint(PointModel model)
        {
            if (model == null)
            {
                throw new ValidationException("model can not be null");
            }

            var point = new Point()
            {
                X = model.X,
                Y = model.Y
            };

            pointsContext.Add(point);

            await pointsContext.SaveChangesAsync();
        }
        public async Task AddSquarePoints(List<PointModel> pointsModel)
        {
            var pointList = new List<Point>();

            foreach (var pointItem in pointsModel)
            {
                var point = new Point()
                {
                    X = pointItem.X,
                    Y = pointItem.Y
                };

                pointList.Add(point);
            }

            foreach (var point in pointList)
            {
                pointsContext.Add(point);

                await pointsContext.SaveChangesAsync();
            }
        }
        public async Task DeleteSquarePoint(int pointId)
        {
            var point = await pointsContext.Points
                .Where(x => x.Id == pointId)
                .FirstOrDefaultAsync() ??
                throw new ValidationException("The point does not exist");

            pointsContext.Points.Remove(point);
            await pointsContext.SaveChangesAsync();
        }
        public async Task<List<SquareModel>> GetSquares()
        {
            var points = await pointsContext.Points
                .ToListAsync() ??
                 throw new ValidationException("Please create at least 4 points");

            var pointsModel = new List<PointModel>();
            foreach (var pointItem in points)
            {
                var point = new PointModel
                {
                    X = pointItem.X,
                    Y = pointItem.Y
                };

                pointsModel.Add(point);
            }

            return CalculateSquaresFromPoints(pointsModel);
        }

        private static List<SquareModel> CalculateSquaresFromPoints(List<PointModel> points)
        {
            Dictionary<(int, int), int> pointDictionary = new();
            List<SquareModel> list = new();

            foreach (var point in points)
            {
                if (pointDictionary.ContainsKey(new(point.X, point.Y)))
                {
                    continue;
                }

                pointDictionary.Add(new(point.X, point.Y), 0);
            }

            foreach (var key in pointDictionary.Keys)
            {
                var squareModel = FindPoints(pointDictionary, key.Item1, key.Item2);
                
                if (squareModel != null)
                {
                    list.Add(squareModel);
                }
            }

            return list;
        }

        public static SquareModel? FindPoints(Dictionary<(int, int), int> pointDictionary, int pointX, int pointY)
        {
            foreach (var pointCoordinates in pointDictionary.Keys)
            {
                var x = pointCoordinates.Item1;
                var y = pointCoordinates.Item2;

                if (Math.Abs(pointX - x) != Math.Abs(pointY - y) || x == pointX || y == pointY)
                    continue;

                if (pointDictionary.ContainsKey(new(x, pointY)) && pointDictionary.ContainsKey(new(pointX, y)))
                {
                    return new SquareModel
                    {
                        FirstPoint = new PointModel
                        {
                            X = x,
                            Y = y
                        },
                        SecondPoint = new PointModel
                        {
                            X = pointX,
                            Y = pointY
                        },
                        ThirdPoint = new PointModel
                        {
                            X = x,
                            Y = pointY
                        },
                        FourthPoint = new PointModel
                        {
                            X = pointX,
                            Y = y
                        }
                    };
                }
            }

            return null;
        }
    }
}
