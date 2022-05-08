using Microsoft.AspNetCore.Mvc;
using Points.Models;
using Points.Services;
using System.Net;
using Routes = Constants.ApiRoutes.Points;

namespace API.Controllers.Points
{
   
    [ApiController]
    [Route(Routes.Points.BasePath)]
    public class PointsController : ControllerBase
    {
        public readonly IPointService pointServices;
        public PointsController(IPointService pointServices)
        {
            this.pointServices = pointServices;
        }

        /// <summary>
        /// Adds a point which coordinates are x and y.
        /// </summary>
        /// <param name="PointModel"></param>
        /// <returns>Ok status code if succeed</returns>
        [HttpPost(Routes.Points.BaseAddPointPath)]
        [ProducesResponseTypeAttribute((int)HttpStatusCode.OK)]
        public async Task<ActionResult> AddSquarePoint(PointModel point)
        {
            await pointServices.AddSquarePoint(point);
            return Ok();
        }

        /// <summary>
        /// Adds point list which consists of coordinates x and y.
        /// </summary>
        /// <param name="PointModelList"></param>
        /// <returns>Ok status code if succeed</returns>
        [HttpPost(Routes.Points.BaseAddPointsPath)]
        [ProducesResponseTypeAttribute((int)HttpStatusCode.OK)]
        public async Task<ActionResult> AddSquarePoints(List<PointModel> points)
        {
            await pointServices.AddSquarePoints(points);
            return Ok();
        }

        /// <summary>
        /// Deletes a point by provided point id.
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpDelete(Routes.Points.BaseDeletePointPath)]
        [ProducesResponseTypeAttribute((int)HttpStatusCode.OK)]
        public async Task<ActionResult> DeleteSquarePoint(int pointId)
        {
            await pointServices.DeleteSquarePoint(pointId);
            return Ok();
        }

        /// <summary>
        /// Gets all point possibilities of drawing squares from already existing points
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet(Routes.Points.Squares.Action.GetSquares)]
        [ProducesResponseTypeAttribute((int)HttpStatusCode.OK)]
        public async Task<ActionResult<List<SquareModel>>> GetSquares()
        {
            return Ok(await pointServices.GetSquares());
        }
    }
}
